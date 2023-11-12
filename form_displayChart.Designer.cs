namespace Stock_analysis
{
    partial class form_displayChart
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label_tickerName = new System.Windows.Forms.Label();
            this.label_dataPeriod = new System.Windows.Forms.Label();
            this.chart_dataDisplay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_beginDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.comboBox_dojiPatterns = new System.Windows.Forms.ComboBox();
            this.button_reloadData = new System.Windows.Forms.Button();
            this.aCandlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_dataDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label_tickerName
            // 
            this.label_tickerName.AutoSize = true;
            this.label_tickerName.ForeColor = System.Drawing.Color.Green;
            this.label_tickerName.Location = new System.Drawing.Point(99, 28);
            this.label_tickerName.Name = "label_tickerName";
            this.label_tickerName.Size = new System.Drawing.Size(128, 25);
            this.label_tickerName.TabIndex = 0;
            this.label_tickerName.Text = "Stock Name";
            // 
            // label_dataPeriod
            // 
            this.label_dataPeriod.AutoSize = true;
            this.label_dataPeriod.ForeColor = System.Drawing.Color.Green;
            this.label_dataPeriod.Location = new System.Drawing.Point(771, 28);
            this.label_dataPeriod.Name = "label_dataPeriod";
            this.label_dataPeriod.Size = new System.Drawing.Size(74, 25);
            this.label_dataPeriod.TabIndex = 1;
            this.label_dataPeriod.Text = "Period";
            // 
            // chart_dataDisplay
            // 
            chartArea3.Name = "ChartArea_ohlcDisplay";
            chartArea4.AlignWithChartArea = "ChartArea_ohlcDisplay";
            chartArea4.Name = "ChartArea_volumeDisplay";
            this.chart_dataDisplay.ChartAreas.Add(chartArea3);
            this.chart_dataDisplay.ChartAreas.Add(chartArea4);
            this.chart_dataDisplay.Location = new System.Drawing.Point(104, 66);
            this.chart_dataDisplay.Name = "chart_dataDisplay";
            series3.ChartArea = "ChartArea_ohlcDisplay";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.CustomProperties = "PriceDownColor=Red, PriceUpColor=LawnGreen";
            series3.EmptyPointStyle.CustomProperties = "PriceDownColor=Red, PriceUpColor=LawnGreen";
            series3.MarkerBorderColor = System.Drawing.Color.White;
            series3.Name = "Series_ohlcDisplay";
            series3.XValueMember = "date";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series3.YValueMembers = "high, low, open, close";
            series3.YValuesPerPoint = 4;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            series4.ChartArea = "ChartArea_volumeDisplay";
            series4.Name = "Series_volume";
            series4.XValueMember = "date";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series4.YValueMembers = "volume";
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            this.chart_dataDisplay.Series.Add(series3);
            this.chart_dataDisplay.Series.Add(series4);
            this.chart_dataDisplay.Size = new System.Drawing.Size(1461, 648);
            this.chart_dataDisplay.TabIndex = 2;
            this.chart_dataDisplay.Text = "chart1";
            // 
            // label_beginDate
            // 
            this.label_beginDate.AutoSize = true;
            this.label_beginDate.Location = new System.Drawing.Point(99, 730);
            this.label_beginDate.Name = "label_beginDate";
            this.label_beginDate.Size = new System.Drawing.Size(159, 25);
            this.label_beginDate.TabIndex = 3;
            this.label_beginDate.Text = "Beginning Date";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(771, 730);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(130, 25);
            this.label_endDate.TabIndex = 4;
            this.label_endDate.Text = "Ending Date";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(104, 758);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(394, 31);
            this.dateTimePicker_start.TabIndex = 5;
            this.dateTimePicker_start.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(776, 758);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(391, 31);
            this.dateTimePicker_end.TabIndex = 6;
            this.dateTimePicker_end.Value = new System.DateTime(2023, 6, 30, 0, 0, 0, 0);
            // 
            // comboBox_dojiPatterns
            // 
            this.comboBox_dojiPatterns.FormattingEnabled = true;
            this.comboBox_dojiPatterns.Location = new System.Drawing.Point(1326, 755);
            this.comboBox_dojiPatterns.Name = "comboBox_dojiPatterns";
            this.comboBox_dojiPatterns.Size = new System.Drawing.Size(121, 33);
            this.comboBox_dojiPatterns.TabIndex = 7;
            this.comboBox_dojiPatterns.SelectedIndexChanged += new System.EventHandler(this.comboBox_dojiPatterns_SelectedIndexChanged);
            // 
            // button_reloadData
            // 
            this.button_reloadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_reloadData.Location = new System.Drawing.Point(537, 815);
            this.button_reloadData.Name = "button_reloadData";
            this.button_reloadData.Size = new System.Drawing.Size(596, 44);
            this.button_reloadData.TabIndex = 8;
            this.button_reloadData.Text = "Reload";
            this.button_reloadData.UseVisualStyleBackColor = true;
            this.button_reloadData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_reloadData_MouseClick);
            // 
            // aCandlestickBindingSource
            // 
            this.aCandlestickBindingSource.DataSource = typeof(Stock_analysis.Model.smartCandlestick);
            // 
            // form_displayChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1674, 871);
            this.Controls.Add(this.button_reloadData);
            this.Controls.Add(this.comboBox_dojiPatterns);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_beginDate);
            this.Controls.Add(this.chart_dataDisplay);
            this.Controls.Add(this.label_dataPeriod);
            this.Controls.Add(this.label_tickerName);
            this.Name = "form_displayChart";
            this.Text = "Stock Analysis Chart Display";
            ((System.ComponentModel.ISupportInitialize)(this.chart_dataDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_tickerName;
        private System.Windows.Forms.Label label_dataPeriod;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_dataDisplay;
        private System.Windows.Forms.Label label_beginDate;
        private System.Windows.Forms.Label label_endDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.ComboBox comboBox_dojiPatterns;
        private System.Windows.Forms.Button button_reloadData;
        private System.Windows.Forms.BindingSource aCandlestickBindingSource;
    }
}