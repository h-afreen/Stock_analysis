namespace Stock_analysis
{
    partial class form_stockLoad
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
            this.label_beginDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.button_loadStock = new System.Windows.Forms.Button();
            this.openFileDialog_stockFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label_beginDate
            // 
            this.label_beginDate.AutoSize = true;
            this.label_beginDate.Location = new System.Drawing.Point(85, 122);
            this.label_beginDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_beginDate.Name = "label_beginDate";
            this.label_beginDate.Size = new System.Drawing.Size(159, 25);
            this.label_beginDate.TabIndex = 11;
            this.label_beginDate.Text = "Beginning Date\r\n";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(85, 198);
            this.label_endDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(130, 25);
            this.label_endDate.TabIndex = 12;
            this.label_endDate.Text = "Ending Date";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(451, 122);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(403, 31);
            this.dateTimePicker_start.TabIndex = 13;
            this.dateTimePicker_start.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(451, 192);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(402, 31);
            this.dateTimePicker_end.TabIndex = 14;
            this.dateTimePicker_end.Value = new System.DateTime(2023, 6, 30, 0, 0, 0, 0);
            // 
            // button_loadStock
            // 
            this.button_loadStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_loadStock.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button_loadStock.Location = new System.Drawing.Point(90, 275);
            this.button_loadStock.Name = "button_loadStock";
            this.button_loadStock.Size = new System.Drawing.Size(763, 59);
            this.button_loadStock.TabIndex = 15;
            this.button_loadStock.Text = "Load Stock Data\r\n";
            this.button_loadStock.UseVisualStyleBackColor = true;
            this.button_loadStock.Click += new System.EventHandler(this.button_loadStock_Click);
            // 
            // openFileDialog_stockFile
            // 
            this.openFileDialog_stockFile.FileName = "openFileDialog1";
            this.openFileDialog_stockFile.Filter = "All Stock files| *.csv|Daily Stocks|*-Day.csv|Weekly Stocks|*-Week.csv|Monthly St" +
    "ocks|* -Month.csv";
            this.openFileDialog_stockFile.InitialDirectory = "C:\\..\\Stock Data";
            this.openFileDialog_stockFile.Multiselect = true;
            this.openFileDialog_stockFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_stockFile_FileOk);
            // 
            // form_stockLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 385);
            this.Controls.Add(this.button_loadStock);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_beginDate);
            this.Name = "form_stockLoad";
            this.Text = "Stock Analysis Choose Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_beginDate;
        private System.Windows.Forms.Label label_endDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.Button button_loadStock;
        private System.Windows.Forms.OpenFileDialog openFileDialog_stockFile;
    }
}

