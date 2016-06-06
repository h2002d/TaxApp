namespace TaxApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btndebit = new System.Windows.Forms.Button();
            this.btncredit = new System.Windows.Forms.Button();
            this.checkBox_All = new System.Windows.Forms.CheckBox();
            this.textBoxCompanyId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_ByDate = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_From = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_To = new System.Windows.Forms.DateTimePicker();
            this.button_ExportExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btndebit
            // 
            this.btndebit.Font = new System.Drawing.Font("Sylfaen", 20F);
            this.btndebit.Location = new System.Drawing.Point(43, 74);
            this.btndebit.Name = "btndebit";
            this.btndebit.Size = new System.Drawing.Size(140, 53);
            this.btndebit.TabIndex = 0;
            this.btndebit.Text = "Դեբիտոր";
            this.btndebit.UseVisualStyleBackColor = true;
            this.btndebit.Click += new System.EventHandler(this.btndebit_Click);
            // 
            // btncredit
            // 
            this.btncredit.Font = new System.Drawing.Font("Sylfaen", 20F);
            this.btncredit.Location = new System.Drawing.Point(365, 74);
            this.btncredit.Name = "btncredit";
            this.btncredit.Size = new System.Drawing.Size(158, 53);
            this.btncredit.TabIndex = 1;
            this.btncredit.Text = "Կրեդիտոր";
            this.btncredit.UseVisualStyleBackColor = true;
            this.btncredit.Click += new System.EventHandler(this.btncredit_Click);
            // 
            // checkBox_All
            // 
            this.checkBox_All.AutoSize = true;
            this.checkBox_All.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.checkBox_All.Location = new System.Drawing.Point(23, 181);
            this.checkBox_All.Name = "checkBox_All";
            this.checkBox_All.Size = new System.Drawing.Size(69, 22);
            this.checkBox_All.TabIndex = 2;
            this.checkBox_All.Text = "Բոլորը";
            this.checkBox_All.UseVisualStyleBackColor = true;
            this.checkBox_All.CheckedChanged += new System.EventHandler(this.checkBox_All_CheckedChanged);
            // 
            // textBoxCompanyId
            // 
            this.textBoxCompanyId.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.textBoxCompanyId.Location = new System.Drawing.Point(146, 181);
            this.textBoxCompanyId.Name = "textBoxCompanyId";
            this.textBoxCompanyId.Size = new System.Drawing.Size(335, 25);
            this.textBoxCompanyId.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ՀՎՀՀ";
            // 
            // checkBox_ByDate
            // 
            this.checkBox_ByDate.AutoSize = true;
            this.checkBox_ByDate.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.checkBox_ByDate.Location = new System.Drawing.Point(23, 277);
            this.checkBox_ByDate.Name = "checkBox_ByDate";
            this.checkBox_ByDate.Size = new System.Drawing.Size(117, 22);
            this.checkBox_ByDate.TabIndex = 7;
            this.checkBox_ByDate.Text = "Ըստ Ամսաթվի";
            this.checkBox_ByDate.UseVisualStyleBackColor = true;
            this.checkBox_ByDate.CheckedChanged += new System.EventHandler(this.checkBox_ByDate_CheckedChanged);
            // 
            // dateTimePicker_From
            // 
            this.dateTimePicker_From.Enabled = false;
            this.dateTimePicker_From.Location = new System.Drawing.Point(146, 279);
            this.dateTimePicker_From.Name = "dateTimePicker_From";
            this.dateTimePicker_From.Size = new System.Drawing.Size(170, 20);
            this.dateTimePicker_From.TabIndex = 8;
            // 
            // dateTimePicker_To
            // 
            this.dateTimePicker_To.Enabled = false;
            this.dateTimePicker_To.Location = new System.Drawing.Point(322, 279);
            this.dateTimePicker_To.Name = "dateTimePicker_To";
            this.dateTimePicker_To.Size = new System.Drawing.Size(158, 20);
            this.dateTimePicker_To.TabIndex = 9;
            // 
            // button_ExportExcel
            // 
            this.button_ExportExcel.Location = new System.Drawing.Point(165, 349);
            this.button_ExportExcel.Name = "button_ExportExcel";
            this.button_ExportExcel.Size = new System.Drawing.Size(211, 77);
            this.button_ExportExcel.TabIndex = 10;
            this.button_ExportExcel.Text = "Արտահանել Excel";
            this.button_ExportExcel.UseVisualStyleBackColor = true;
            this.button_ExportExcel.Click += new System.EventHandler(this.button_ExportExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 531);
            this.Controls.Add(this.button_ExportExcel);
            this.Controls.Add(this.dateTimePicker_To);
            this.Controls.Add(this.dateTimePicker_From);
            this.Controls.Add(this.checkBox_ByDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCompanyId);
            this.Controls.Add(this.checkBox_All);
            this.Controls.Add(this.btncredit);
            this.Controls.Add(this.btndebit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btndebit;
        private System.Windows.Forms.Button btncredit;
        private System.Windows.Forms.CheckBox checkBox_All;
        private System.Windows.Forms.TextBox textBoxCompanyId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_ByDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_From;
        private System.Windows.Forms.DateTimePicker dateTimePicker_To;
        private System.Windows.Forms.Button button_ExportExcel;
    }
}

