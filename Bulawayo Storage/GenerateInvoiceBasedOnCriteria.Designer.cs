namespace Bulawayo_Storage
{
    partial class GenerateInvoiceBasedOnCriteria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateInvoiceBasedOnCriteria));
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_BasedOn = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_FromPeriod = new System.Windows.Forms.ComboBox();
            this.cbx_ToPeriod = new System.Windows.Forms.ComboBox();
            this.btn_GenerateInvoice = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_NameBillerInfo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_SurnameBillerInfo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbx_EmailBillerInfo = new System.Windows.Forms.TextBox();
            this.tbx_NumberBillerInfo = new System.Windows.Forms.TextBox();
            this.btn_GenInvBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Based On:";
            // 
            // cbx_BasedOn
            // 
            this.cbx_BasedOn.FormattingEnabled = true;
            this.cbx_BasedOn.Location = new System.Drawing.Point(98, 30);
            this.cbx_BasedOn.Name = "cbx_BasedOn";
            this.cbx_BasedOn.Size = new System.Drawing.Size(248, 21);
            this.cbx_BasedOn.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Period:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(237, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "To";
            // 
            // cbx_FromPeriod
            // 
            this.cbx_FromPeriod.FormattingEnabled = true;
            this.cbx_FromPeriod.Location = new System.Drawing.Point(98, 76);
            this.cbx_FromPeriod.Name = "cbx_FromPeriod";
            this.cbx_FromPeriod.Size = new System.Drawing.Size(108, 21);
            this.cbx_FromPeriod.TabIndex = 5;
            // 
            // cbx_ToPeriod
            // 
            this.cbx_ToPeriod.FormattingEnabled = true;
            this.cbx_ToPeriod.Location = new System.Drawing.Point(240, 76);
            this.cbx_ToPeriod.Name = "cbx_ToPeriod";
            this.cbx_ToPeriod.Size = new System.Drawing.Size(108, 21);
            this.cbx_ToPeriod.TabIndex = 6;
            // 
            // btn_GenerateInvoice
            // 
            this.btn_GenerateInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_GenerateInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerateInvoice.Location = new System.Drawing.Point(171, 273);
            this.btn_GenerateInvoice.Name = "btn_GenerateInvoice";
            this.btn_GenerateInvoice.Size = new System.Drawing.Size(175, 46);
            this.btn_GenerateInvoice.TabIndex = 7;
            this.btn_GenerateInvoice.Text = "Generate Invoice";
            this.btn_GenerateInvoice.UseVisualStyleBackColor = true;
            this.btn_GenerateInvoice.Click += new System.EventHandler(this.btn_GenerateInvoice_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Biller Information";
            // 
            // tbx_NameBillerInfo
            // 
            this.tbx_NameBillerInfo.Location = new System.Drawing.Point(98, 146);
            this.tbx_NameBillerInfo.Name = "tbx_NameBillerInfo";
            this.tbx_NameBillerInfo.Size = new System.Drawing.Size(248, 20);
            this.tbx_NameBillerInfo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Surname";
            // 
            // tbx_SurnameBillerInfo
            // 
            this.tbx_SurnameBillerInfo.Location = new System.Drawing.Point(98, 176);
            this.tbx_SurnameBillerInfo.Name = "tbx_SurnameBillerInfo";
            this.tbx_SurnameBillerInfo.Size = new System.Drawing.Size(248, 20);
            this.tbx_SurnameBillerInfo.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(50, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Email";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(34, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Number";
            // 
            // tbx_EmailBillerInfo
            // 
            this.tbx_EmailBillerInfo.Location = new System.Drawing.Point(98, 212);
            this.tbx_EmailBillerInfo.Name = "tbx_EmailBillerInfo";
            this.tbx_EmailBillerInfo.Size = new System.Drawing.Size(248, 20);
            this.tbx_EmailBillerInfo.TabIndex = 15;
            // 
            // tbx_NumberBillerInfo
            // 
            this.tbx_NumberBillerInfo.Location = new System.Drawing.Point(98, 245);
            this.tbx_NumberBillerInfo.Name = "tbx_NumberBillerInfo";
            this.tbx_NumberBillerInfo.Size = new System.Drawing.Size(248, 20);
            this.tbx_NumberBillerInfo.TabIndex = 16;
            // 
            // btn_GenInvBack
            // 
            this.btn_GenInvBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_GenInvBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenInvBack.Location = new System.Drawing.Point(50, 273);
            this.btn_GenInvBack.Name = "btn_GenInvBack";
            this.btn_GenInvBack.Size = new System.Drawing.Size(115, 46);
            this.btn_GenInvBack.TabIndex = 17;
            this.btn_GenInvBack.Text = "Back";
            this.btn_GenInvBack.UseVisualStyleBackColor = true;
            this.btn_GenInvBack.Click += new System.EventHandler(this.btn_GenInvBack_Click);
            // 
            // GenerateInvoiceBasedOnCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 331);
            this.Controls.Add(this.btn_GenInvBack);
            this.Controls.Add(this.tbx_NumberBillerInfo);
            this.Controls.Add(this.tbx_EmailBillerInfo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbx_SurnameBillerInfo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbx_NameBillerInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_GenerateInvoice);
            this.Controls.Add(this.cbx_ToPeriod);
            this.Controls.Add(this.cbx_FromPeriod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_BasedOn);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GenerateInvoiceBasedOnCriteria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenerateInvoiceBasedOnCriteria";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GenerateInvoiceBasedOnCriteria_FormClosed);
            this.Load += new System.EventHandler(this.GenerateInvoiceBasedOnCriteria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_BasedOn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_FromPeriod;
        private System.Windows.Forms.ComboBox cbx_ToPeriod;
        private System.Windows.Forms.Button btn_GenerateInvoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_NameBillerInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_SurnameBillerInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbx_EmailBillerInfo;
        private System.Windows.Forms.TextBox tbx_NumberBillerInfo;
        private System.Windows.Forms.Button btn_GenInvBack;
    }
}