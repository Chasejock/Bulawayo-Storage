namespace Bulawayo_Storage
{
    partial class SearchDataBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchDataBase));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_Students = new System.Windows.Forms.DataGridView();
            this.pCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pStudentSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pGuardianNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pNumberOfTrunks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pStoragePeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_SerDbBack = new System.Windows.Forms.Button();
            this.btn_GenerateInvoice = new System.Windows.Forms.Button();
            this.tbx_Search = new System.Windows.Forms.TextBox();
            this.lbl_Search = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Students)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.dgv_Students);
            this.panel1.Location = new System.Drawing.Point(12, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 491);
            this.panel1.TabIndex = 0;
            // 
            // dgv_Students
            // 
            this.dgv_Students.AllowUserToAddRows = false;
            this.dgv_Students.AllowUserToDeleteRows = false;
            this.dgv_Students.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Students.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Students.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pCode,
            this.pStudentName,
            this.pStudentSurname,
            this.pHouse,
            this.pEmail,
            this.pNumber,
            this.pGuardianNumber,
            this.pNumberOfTrunks,
            this.pOption,
            this.pPaymentMethod,
            this.pStoragePeriod});
            this.dgv_Students.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Students.Location = new System.Drawing.Point(0, 0);
            this.dgv_Students.Name = "dgv_Students";
            this.dgv_Students.ReadOnly = true;
            this.dgv_Students.Size = new System.Drawing.Size(1043, 491);
            this.dgv_Students.TabIndex = 0;
            this.dgv_Students.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Students_CellDoubleClick);
            // 
            // pCode
            // 
            this.pCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pCode.DataPropertyName = "pCode";
            this.pCode.HeaderText = "Code";
            this.pCode.Name = "pCode";
            this.pCode.ReadOnly = true;
            this.pCode.Visible = false;
            // 
            // pStudentName
            // 
            this.pStudentName.DataPropertyName = "pStudentName";
            this.pStudentName.HeaderText = "Student Name";
            this.pStudentName.Name = "pStudentName";
            this.pStudentName.ReadOnly = true;
            // 
            // pStudentSurname
            // 
            this.pStudentSurname.DataPropertyName = "pStudentSurname";
            this.pStudentSurname.HeaderText = "Student Surname";
            this.pStudentSurname.Name = "pStudentSurname";
            this.pStudentSurname.ReadOnly = true;
            // 
            // pHouse
            // 
            this.pHouse.DataPropertyName = "pHouse";
            this.pHouse.HeaderText = "House";
            this.pHouse.Name = "pHouse";
            this.pHouse.ReadOnly = true;
            // 
            // pEmail
            // 
            this.pEmail.DataPropertyName = "pEmail";
            this.pEmail.HeaderText = "Email";
            this.pEmail.Name = "pEmail";
            this.pEmail.ReadOnly = true;
            // 
            // pNumber
            // 
            this.pNumber.DataPropertyName = "pNumber";
            this.pNumber.HeaderText = "Mobile Number";
            this.pNumber.Name = "pNumber";
            this.pNumber.ReadOnly = true;
            // 
            // pGuardianNumber
            // 
            this.pGuardianNumber.DataPropertyName = "pGuardianNumber";
            this.pGuardianNumber.HeaderText = "Guardian Number";
            this.pGuardianNumber.Name = "pGuardianNumber";
            this.pGuardianNumber.ReadOnly = true;
            // 
            // pNumberOfTrunks
            // 
            this.pNumberOfTrunks.DataPropertyName = "pNumberOfTrunks";
            this.pNumberOfTrunks.HeaderText = "Number Of Trunks";
            this.pNumberOfTrunks.Name = "pNumberOfTrunks";
            this.pNumberOfTrunks.ReadOnly = true;
            // 
            // pOption
            // 
            this.pOption.DataPropertyName = "pOption";
            this.pOption.HeaderText = "Storage Option";
            this.pOption.Name = "pOption";
            this.pOption.ReadOnly = true;
            // 
            // pPaymentMethod
            // 
            this.pPaymentMethod.DataPropertyName = "pPaymentMethod";
            this.pPaymentMethod.HeaderText = "Payment Method";
            this.pPaymentMethod.Name = "pPaymentMethod";
            this.pPaymentMethod.ReadOnly = true;
            // 
            // pStoragePeriod
            // 
            this.pStoragePeriod.DataPropertyName = "pStoragePeriod";
            this.pStoragePeriod.HeaderText = "Storage Period";
            this.pStoragePeriod.Name = "pStoragePeriod";
            this.pStoragePeriod.ReadOnly = true;
            // 
            // btn_SerDbBack
            // 
            this.btn_SerDbBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SerDbBack.Location = new System.Drawing.Point(12, 12);
            this.btn_SerDbBack.Name = "btn_SerDbBack";
            this.btn_SerDbBack.Size = new System.Drawing.Size(115, 46);
            this.btn_SerDbBack.TabIndex = 1;
            this.btn_SerDbBack.Text = "Back";
            this.btn_SerDbBack.UseVisualStyleBackColor = true;
            this.btn_SerDbBack.Click += new System.EventHandler(this.btn_SerDbBack_Click);
            // 
            // btn_GenerateInvoice
            // 
            this.btn_GenerateInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_GenerateInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerateInvoice.Location = new System.Drawing.Point(12, 572);
            this.btn_GenerateInvoice.Name = "btn_GenerateInvoice";
            this.btn_GenerateInvoice.Size = new System.Drawing.Size(203, 46);
            this.btn_GenerateInvoice.TabIndex = 2;
            this.btn_GenerateInvoice.Text = "Generate Invoice";
            this.btn_GenerateInvoice.UseVisualStyleBackColor = true;
            this.btn_GenerateInvoice.Click += new System.EventHandler(this.btn_GenerateInvoice_Click);
            // 
            // tbx_Search
            // 
            this.tbx_Search.Location = new System.Drawing.Point(326, 29);
            this.tbx_Search.Name = "tbx_Search";
            this.tbx_Search.Size = new System.Drawing.Size(474, 20);
            this.tbx_Search.TabIndex = 4;
            this.tbx_Search.TextChanged += new System.EventHandler(this.tbx_Search_KeyPress);
            // 
            // lbl_Search
            // 
            this.lbl_Search.AutoSize = true;
            this.lbl_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Search.Location = new System.Drawing.Point(267, 29);
            this.lbl_Search.Name = "lbl_Search";
            this.lbl_Search.Size = new System.Drawing.Size(57, 17);
            this.lbl_Search.TabIndex = 5;
            this.lbl_Search.Text = "Search:";
            // 
            // SearchDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 624);
            this.Controls.Add(this.lbl_Search);
            this.Controls.Add(this.tbx_Search);
            this.Controls.Add(this.btn_GenerateInvoice);
            this.Controls.Add(this.btn_SerDbBack);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchDataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchDataBase_FormClosed);
            this.Load += new System.EventHandler(this.SearchDataBase_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Students)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_Students;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn pStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn pStudentSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn pHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn pEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn pNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn pGuardianNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn pNumberOfTrunks;
        private System.Windows.Forms.DataGridViewTextBoxColumn pOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn pPaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn pStoragePeriod;
        private System.Windows.Forms.Button btn_SerDbBack;
        private System.Windows.Forms.Button btn_GenerateInvoice;
        private System.Windows.Forms.TextBox tbx_Search;
        private System.Windows.Forms.Label lbl_Search;
    }
}