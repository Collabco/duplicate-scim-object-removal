namespace Remove_duplicate_objects
{
    partial class RemoveDuplicates
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lbl_TenantId;
            System.Windows.Forms.Label lbl_Token;
            System.Windows.Forms.Label lbl_Duplicates;
            System.Windows.Forms.Label lbl_Total;
            System.Windows.Forms.Label lbl_Unique;
            System.Windows.Forms.Label lbl_Deleted;
            System.Windows.Forms.Label lbl_Errors;
            System.Windows.Forms.Label lbl_ScimUrl;
            System.Windows.Forms.Label lbl_Type;
            System.Windows.Forms.Label lbl_Field;
            System.Windows.Forms.Label lbl_Actions;
            System.Windows.Forms.Label lbl_Found;
            this.txt_TenantId = new System.Windows.Forms.TextBox();
            this.txt_Token = new System.Windows.Forms.TextBox();
            this.btn_Identify = new System.Windows.Forms.Button();
            this.lbl_DuplicatesNo = new System.Windows.Forms.Label();
            this.lbl_TotalNo = new System.Windows.Forms.Label();
            this.lbl_UniqueNo = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.lbl_DeletedNo = new System.Windows.Forms.Label();
            this.lbl_ErrorsNo = new System.Windows.Forms.Label();
            this.txt_ScimUrl = new System.Windows.Forms.TextBox();
            this.txt_Type = new System.Windows.Forms.ComboBox();
            this.txt_Field = new System.Windows.Forms.ComboBox();
            this.txt_Found = new System.Windows.Forms.TextBox();
            lbl_TenantId = new System.Windows.Forms.Label();
            lbl_Token = new System.Windows.Forms.Label();
            lbl_Duplicates = new System.Windows.Forms.Label();
            lbl_Total = new System.Windows.Forms.Label();
            lbl_Unique = new System.Windows.Forms.Label();
            lbl_Deleted = new System.Windows.Forms.Label();
            lbl_Errors = new System.Windows.Forms.Label();
            lbl_ScimUrl = new System.Windows.Forms.Label();
            lbl_Type = new System.Windows.Forms.Label();
            lbl_Field = new System.Windows.Forms.Label();
            lbl_Actions = new System.Windows.Forms.Label();
            lbl_Found = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_TenantId
            // 
            lbl_TenantId.AutoSize = true;
            lbl_TenantId.Location = new System.Drawing.Point(12, 44);
            lbl_TenantId.Name = "lbl_TenantId";
            lbl_TenantId.Size = new System.Drawing.Size(55, 13);
            lbl_TenantId.TabIndex = 1;
            lbl_TenantId.Text = "Tenant ID";
            // 
            // lbl_Token
            // 
            lbl_Token.AutoSize = true;
            lbl_Token.Location = new System.Drawing.Point(12, 70);
            lbl_Token.Name = "lbl_Token";
            lbl_Token.Size = new System.Drawing.Size(72, 13);
            lbl_Token.TabIndex = 3;
            lbl_Token.Text = "Access token";
            // 
            // lbl_Duplicates
            // 
            lbl_Duplicates.AutoSize = true;
            lbl_Duplicates.Location = new System.Drawing.Point(429, 195);
            lbl_Duplicates.Name = "lbl_Duplicates";
            lbl_Duplicates.Size = new System.Drawing.Size(60, 13);
            lbl_Duplicates.TabIndex = 5;
            lbl_Duplicates.Text = "Duplicates:";
            // 
            // lbl_Total
            // 
            lbl_Total.AutoSize = true;
            lbl_Total.Location = new System.Drawing.Point(429, 169);
            lbl_Total.Name = "lbl_Total";
            lbl_Total.Size = new System.Drawing.Size(34, 13);
            lbl_Total.TabIndex = 7;
            lbl_Total.Text = "Total:";
            // 
            // lbl_Unique
            // 
            lbl_Unique.AutoSize = true;
            lbl_Unique.Location = new System.Drawing.Point(429, 222);
            lbl_Unique.Name = "lbl_Unique";
            lbl_Unique.Size = new System.Drawing.Size(44, 13);
            lbl_Unique.TabIndex = 9;
            lbl_Unique.Text = "Unique:";
            // 
            // lbl_Deleted
            // 
            lbl_Deleted.AutoSize = true;
            lbl_Deleted.Location = new System.Drawing.Point(429, 248);
            lbl_Deleted.Name = "lbl_Deleted";
            lbl_Deleted.Size = new System.Drawing.Size(47, 13);
            lbl_Deleted.TabIndex = 12;
            lbl_Deleted.Text = "Deleted:";
            // 
            // lbl_Errors
            // 
            lbl_Errors.AutoSize = true;
            lbl_Errors.Location = new System.Drawing.Point(429, 273);
            lbl_Errors.Name = "lbl_Errors";
            lbl_Errors.Size = new System.Drawing.Size(37, 13);
            lbl_Errors.TabIndex = 14;
            lbl_Errors.Text = "Errors:";
            // 
            // lbl_ScimUrl
            // 
            lbl_ScimUrl.AutoSize = true;
            lbl_ScimUrl.Location = new System.Drawing.Point(12, 18);
            lbl_ScimUrl.Name = "lbl_ScimUrl";
            lbl_ScimUrl.Size = new System.Drawing.Size(58, 13);
            lbl_ScimUrl.TabIndex = 17;
            lbl_ScimUrl.Text = "SCIM URL";
            // 
            // lbl_Type
            // 
            lbl_Type.AutoSize = true;
            lbl_Type.Location = new System.Drawing.Point(13, 105);
            lbl_Type.Name = "lbl_Type";
            lbl_Type.Size = new System.Drawing.Size(61, 13);
            lbl_Type.TabIndex = 20;
            lbl_Type.Text = "Object type";
            // 
            // lbl_Field
            // 
            lbl_Field.AutoSize = true;
            lbl_Field.Location = new System.Drawing.Point(13, 132);
            lbl_Field.Name = "lbl_Field";
            lbl_Field.Size = new System.Drawing.Size(29, 13);
            lbl_Field.TabIndex = 22;
            lbl_Field.Text = "Field";
            // 
            // lbl_Actions
            // 
            lbl_Actions.AutoSize = true;
            lbl_Actions.Location = new System.Drawing.Point(12, 179);
            lbl_Actions.Name = "lbl_Actions";
            lbl_Actions.Size = new System.Drawing.Size(42, 13);
            lbl_Actions.TabIndex = 23;
            lbl_Actions.Text = "Actions";
            // 
            // lbl_Found
            // 
            lbl_Found.AutoSize = true;
            lbl_Found.Location = new System.Drawing.Point(13, 217);
            lbl_Found.Name = "lbl_Found";
            lbl_Found.Size = new System.Drawing.Size(53, 13);
            lbl_Found.TabIndex = 25;
            lbl_Found.Text = "IDs found";
            // 
            // txt_TenantId
            // 
            this.txt_TenantId.Location = new System.Drawing.Point(90, 41);
            this.txt_TenantId.Name = "txt_TenantId";
            this.txt_TenantId.Size = new System.Drawing.Size(448, 20);
            this.txt_TenantId.TabIndex = 0;
            // 
            // txt_Token
            // 
            this.txt_Token.Location = new System.Drawing.Point(90, 67);
            this.txt_Token.Name = "txt_Token";
            this.txt_Token.Size = new System.Drawing.Size(448, 20);
            this.txt_Token.TabIndex = 2;
            // 
            // btn_Identify
            // 
            this.btn_Identify.Location = new System.Drawing.Point(90, 169);
            this.btn_Identify.Name = "btn_Identify";
            this.btn_Identify.Size = new System.Drawing.Size(164, 32);
            this.btn_Identify.TabIndex = 4;
            this.btn_Identify.Text = "Identify Duplicates";
            this.btn_Identify.UseVisualStyleBackColor = true;
            this.btn_Identify.Click += new System.EventHandler(this.btn_Identify_Click);
            // 
            // lbl_DuplicatesNo
            // 
            this.lbl_DuplicatesNo.Location = new System.Drawing.Point(491, 195);
            this.lbl_DuplicatesNo.Name = "lbl_DuplicatesNo";
            this.lbl_DuplicatesNo.Size = new System.Drawing.Size(47, 13);
            this.lbl_DuplicatesNo.TabIndex = 6;
            this.lbl_DuplicatesNo.Text = "0";
            this.lbl_DuplicatesNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TotalNo
            // 
            this.lbl_TotalNo.Location = new System.Drawing.Point(488, 169);
            this.lbl_TotalNo.Name = "lbl_TotalNo";
            this.lbl_TotalNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_TotalNo.Size = new System.Drawing.Size(50, 13);
            this.lbl_TotalNo.TabIndex = 8;
            this.lbl_TotalNo.Text = "0";
            this.lbl_TotalNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_UniqueNo
            // 
            this.lbl_UniqueNo.Location = new System.Drawing.Point(491, 222);
            this.lbl_UniqueNo.Name = "lbl_UniqueNo";
            this.lbl_UniqueNo.Size = new System.Drawing.Size(47, 18);
            this.lbl_UniqueNo.TabIndex = 10;
            this.lbl_UniqueNo.Text = "0";
            this.lbl_UniqueNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(260, 169);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(153, 32);
            this.btn_Delete.TabIndex = 11;
            this.btn_Delete.Text = "Delete Duplicates";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // lbl_DeletedNo
            // 
            this.lbl_DeletedNo.Location = new System.Drawing.Point(491, 248);
            this.lbl_DeletedNo.Name = "lbl_DeletedNo";
            this.lbl_DeletedNo.Size = new System.Drawing.Size(47, 13);
            this.lbl_DeletedNo.TabIndex = 13;
            this.lbl_DeletedNo.Text = "0";
            this.lbl_DeletedNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_ErrorsNo
            // 
            this.lbl_ErrorsNo.Location = new System.Drawing.Point(491, 273);
            this.lbl_ErrorsNo.Name = "lbl_ErrorsNo";
            this.lbl_ErrorsNo.Size = new System.Drawing.Size(47, 13);
            this.lbl_ErrorsNo.TabIndex = 15;
            this.lbl_ErrorsNo.Text = "0";
            this.lbl_ErrorsNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_ScimUrl
            // 
            this.txt_ScimUrl.Location = new System.Drawing.Point(90, 15);
            this.txt_ScimUrl.Name = "txt_ScimUrl";
            this.txt_ScimUrl.Size = new System.Drawing.Size(448, 20);
            this.txt_ScimUrl.TabIndex = 16;
            this.txt_ScimUrl.Text = "https://scim.myday.cloud";
            // 
            // txt_Type
            // 
            this.txt_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_Type.FormattingEnabled = true;
            this.txt_Type.Items.AddRange(new object[] {
            "Users",
            "Groups"});
            this.txt_Type.Location = new System.Drawing.Point(90, 102);
            this.txt_Type.Name = "txt_Type";
            this.txt_Type.Size = new System.Drawing.Size(448, 21);
            this.txt_Type.TabIndex = 19;
            // 
            // txt_Field
            // 
            this.txt_Field.FormattingEnabled = true;
            this.txt_Field.Items.AddRange(new object[] {
            "id",
            "externalId",
            "userName"});
            this.txt_Field.Location = new System.Drawing.Point(90, 129);
            this.txt_Field.Name = "txt_Field";
            this.txt_Field.Size = new System.Drawing.Size(448, 21);
            this.txt_Field.TabIndex = 21;
            // 
            // txt_Found
            // 
            this.txt_Found.Location = new System.Drawing.Point(90, 214);
            this.txt_Found.Multiline = true;
            this.txt_Found.Name = "txt_Found";
            this.txt_Found.Size = new System.Drawing.Size(323, 72);
            this.txt_Found.TabIndex = 24;
            // 
            // RemoveDuplicates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 302);
            this.Controls.Add(lbl_Found);
            this.Controls.Add(this.txt_Found);
            this.Controls.Add(lbl_Actions);
            this.Controls.Add(lbl_Field);
            this.Controls.Add(this.txt_Field);
            this.Controls.Add(lbl_Type);
            this.Controls.Add(this.txt_Type);
            this.Controls.Add(lbl_ScimUrl);
            this.Controls.Add(this.txt_ScimUrl);
            this.Controls.Add(this.lbl_ErrorsNo);
            this.Controls.Add(lbl_Errors);
            this.Controls.Add(this.lbl_DeletedNo);
            this.Controls.Add(lbl_Deleted);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.lbl_UniqueNo);
            this.Controls.Add(lbl_Unique);
            this.Controls.Add(this.lbl_TotalNo);
            this.Controls.Add(lbl_Total);
            this.Controls.Add(this.lbl_DuplicatesNo);
            this.Controls.Add(lbl_Duplicates);
            this.Controls.Add(this.btn_Identify);
            this.Controls.Add(lbl_Token);
            this.Controls.Add(this.txt_Token);
            this.Controls.Add(lbl_TenantId);
            this.Controls.Add(this.txt_TenantId);
            this.Name = "RemoveDuplicates";
            this.Text = "Remove duplicate SCIM objects";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_TenantId;
        private System.Windows.Forms.TextBox txt_Token;
        private System.Windows.Forms.Button btn_Identify;
        private System.Windows.Forms.Label lbl_DuplicatesNo;
        private System.Windows.Forms.Label lbl_TotalNo;
        private System.Windows.Forms.Label lbl_UniqueNo;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label lbl_DeletedNo;
        private System.Windows.Forms.Label lbl_ErrorsNo;
        private System.Windows.Forms.TextBox txt_ScimUrl;
        private System.Windows.Forms.ComboBox txt_Type;
        private System.Windows.Forms.ComboBox txt_Field;
        private System.Windows.Forms.TextBox txt_Found;
    }
}

