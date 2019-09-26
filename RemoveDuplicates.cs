using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Collabco.Myday.Scim;
using Polly;

namespace Remove_duplicate_objects
{
    public partial class RemoveDuplicates : Form
    {
        private readonly SynchronizationContext synchronizationContext;

        public RemoveDuplicates()
        {
            InitializeComponent();
            synchronizationContext = SynchronizationContext.Current;
        }

        // Dictionary of object by a key
        Dictionary<string, Collabco.Myday.Scim.Core.Model.Resource> results = new Dictionary<string, Collabco.Myday.Scim.Core.Model.Resource>();

        // List of duplicate object IDs
        List<string> duplicateObjectIds = new List<string>();

        private string ResourceType = null;

        private async void btn_Identify_Click(object sender, EventArgs e)
        {
            try
            {
                results.Clear();
                duplicateObjectIds.Clear();
                var scimClient = CreateScimClient();

                this.ResourceType = txt_Type.Text;

                var attribute = txt_Field.Text;
                var attributes = new List<string> { "id", "externalId", "meta.created", "meta.lastModified" };

                if (string.IsNullOrEmpty(attribute))
                {
                    attribute = "externalId";
                }

                if (attribute != "id" && attribute != "externalId")
                {
                    attributes.Add(attribute);
                }

                await Task.Run(() =>
                {
                    if (this.ResourceType == "Groups")
                    {
                        return FindDuplicateScimObjects<Collabco.Myday.Scim.v2.Model.ScimGroup2>(scimClient, attributes, attribute);
                    }
                    else
                    {
                        return FindDuplicateScimObjects<Collabco.Myday.Scim.v2.Model.ScimUser2>(scimClient, attributes, attribute);
                    }
                });
                
                MessageBox.Show("Duplicate search completed", "Operation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task FindDuplicateScimObjects<T>(ScimClient scimClient, List<string> attributes, string attribute) where T: Collabco.Myday.Scim.Core.Model.Resource
        {
            var errorCount = 0;
            var totalObjectCount = 0;
            var startIndex = 1;

            var attributeUpper = attribute.First().ToString().ToUpper() + attribute.Substring(1);
            System.Reflection.PropertyInfo prop = typeof(T).GetProperty(attributeUpper);

            Collabco.Myday.Scim.v2.Model.ScimListResponse2<T> resultsPage = null;

            while (resultsPage == null || resultsPage.TotalResults > totalObjectCount)
            {
                resultsPage = await Policy
                 .Handle<Exception>(e => !(e is ArgumentNullException || e is ArgumentException))
                 .WaitAndRetryAsync(
                   DecorrelatedJitter(5, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(30)),
                   (exception, timeSpan, context) =>
                   {
                       errorCount++;
                       UpdateErrorCount(errorCount);
                       Debug.WriteLine($"Scim search error: {exception.Message}");
                   }
                 )
                 .ExecuteAsync(() =>
                 {
                     return scimClient.Search<T>(
                         new Collabco.Myday.Scim.Query.ScimQueryOptions
                         {
                             Attributes = attributes,
                             StartIndex = startIndex,
                             // SortBy = "meta.created",
                             // SortOrder = Collabco.Myday.Scim.Core.Model.SortOrder.Ascending,
                             Count = 100
                         }
                     );
                 });

                totalObjectCount += resultsPage.Resources.Count();                
                startIndex += resultsPage.ItemsPerPage;

                foreach (var currentObject in resultsPage.Resources)
                {
                    var propertyValue = (String)prop.GetValue(currentObject);

                    if (string.IsNullOrEmpty(propertyValue))
                    {
                        Debug.WriteLine($"Property does not exist, most likely a local user/group: " + currentObject.Id);
                        continue;
                    }

                    if (results.TryGetValue(propertyValue.ToLowerInvariant(), out Collabco.Myday.Scim.Core.Model.Resource existingObject))
                    {
                        if (SuperceedsExistingObject(existingObject, currentObject))
                        {
                            results[propertyValue.ToLowerInvariant()] = currentObject;
                            duplicateObjectIds.Add(existingObject.Id);
                        }
                        else
                        {
                            duplicateObjectIds.Add(currentObject.Id);
                        }
                    }
                    else
                    {
                        results[propertyValue.ToLowerInvariant()] = currentObject;
                    }
                }

                UpdateDuplicateCounts(totalObjectCount);
            }
        }

        private void UpdateDuplicateCounts(int totalGroupCount)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lbl_TotalNo.Text = o.ToString();
                lbl_DuplicatesNo.Text = duplicateObjectIds.Count.ToString();
                lbl_UniqueNo.Text = results.Count.ToString();
                txt_Found.Text = String.Join(Environment.NewLine, duplicateObjectIds);
            }), totalGroupCount);
        }

        private async void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var scimClient = CreateScimClient();

                if (string.IsNullOrEmpty(this.ResourceType))
                {
                    throw new Exception("Resource type is not selected");
                }

                await Task.Run(async () =>
                {
                    var deleteCount = 0; 
                    
                    foreach (var objectId in duplicateObjectIds)
                    {
                        await Policy
                         .Handle<Exception>(ex => !(ex is ArgumentNullException || ex is ArgumentException))
                         .WaitAndRetryAsync(
                           DecorrelatedJitter(5, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(30)),
                           (exception, timeSpan, context) =>
                           {
                               Debug.WriteLine($"Scim delete error: {exception.Message}");
                           }
                         )
                         .ExecuteAsync(() =>
                         {
                             if (this.ResourceType == "Groups")
                             {
                                 return scimClient.Delete<Collabco.Myday.Scim.v2.Model.ScimGroup2>(objectId);
                             }
                             else
                             {
                                 return scimClient.Delete<Collabco.Myday.Scim.v2.Model.ScimUser2>(objectId);
                             }
                         });

                        deleteCount++;
                        UpdateDeleteCount(deleteCount);
                    }
                });

                MessageBox.Show("Delete duplicates completed", "Operation complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateErrorCount(int deleteCount)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lbl_ErrorsNo.Text = o.ToString();
            }), deleteCount);
        }

        private void UpdateDeleteCount(int deleteCount)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lbl_DeletedNo.Text = o.ToString();
            }), deleteCount);
        }

        private ScimClient CreateScimClient()
        {
            var scimConfig = new Collabco.Myday.Scim.Configuration.ScimConfiguration
            {
                BaseUrl = $"{txt_ScimUrl.Text}/{txt_TenantId.Text}/v2",
                DefaultSearchPageSize = 100
            };

            scimConfig.AddDefaultScimResourceTypes();
            scimConfig.AddMydayScimResourceTypes();

            return new ScimClient(scimConfig, txt_Token.Text);
        }

        /// <summary>
        /// Implementation of Decorrelated Jitter strategy
        /// </summary>
        /// <param name="maxRetries">Max imum number of retries</param>
        /// <param name="seedDelay">Initial minimum delay for a retry</param>
        /// <param name="maxDelay">Maximum delay for a retry</param>
        /// <returns>TimeSpan of the delay</returns>
        private static IEnumerable<TimeSpan> DecorrelatedJitter(int maxRetries, TimeSpan seedDelay, TimeSpan maxDelay)
        {
            Random jitterer = new Random();
            int retries = 0;

            double seed = seedDelay.TotalMilliseconds;
            double max = maxDelay.TotalMilliseconds;
            double current = seed;

            while (++retries <= maxRetries)
            {
                current = Math.Min(max, Math.Max(seed, current * 3 * jitterer.NextDouble())); // adopting the 'Decorrelated Jitter' formula from https://www.awsarchitectureblog.com/2015/03/backoff.html.  Can be between seed and previous * 3.  Mustn't exceed max.
                yield return TimeSpan.FromMilliseconds(current);
            }
        }

        private bool SuperceedsExistingObject(Collabco.Myday.Scim.Core.Model.Resource existing, Collabco.Myday.Scim.Core.Model.Resource duplicate)
        {
            ////Superceed if duplicate user is active and existing user is not
            //bool superceed = !(existingtUser.Active ?? false) && (duplicateUser.Active ?? false);

            //if (!superceed)
            //{
            //    //Superceed if duplicate user has UserType 'AzureAD' and existing user does not
            //    superceed = existingtUser.UserType != "AzureAD" && duplicateUser.UserType == "AzureAD";
            //}

            //if (!superceed)
            //{
            //    //Superceed if duplicate user has more identityProviders associated that the existing user
            //    var existingUserIdProviders = existingtUser.Extension<Collabco.Myday.Scim.v2.Model.MydayUser2Extension>()?.IdentityProviders;
            //    var duplicateUserIdProviders = duplicateUser.Extension<Collabco.Myday.Scim.v2.Model.MydayUser2Extension>()?.IdentityProviders;
            //    superceed = duplicateUserIdProviders != null && duplicateUserIdProviders.Count > (existingUserIdProviders?.Count ?? 0);
            //}

            return duplicate.Meta.Created < existing.Meta.Created;
        }
    }
}
