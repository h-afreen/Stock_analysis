using Stock_analysis.Model;
using Stock_analysis.PatternRecognizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock_analysis
{
    public partial class form_displayChart : Form
    {
        List<smartCandlestick> stockData = null;
        List<smartCandlestick> tempSmartCandlestickData = null;
        List<axxxRecognizer> recognizers = null;
        private BindingList<smartCandlestick> candlesticksChosen { get; set; }
        public form_displayChart(List<smartCandlestick> data, DateTime begin, DateTime end)
        {
            InitializeComponent();
            stockData = data;
            dateTimePicker_start.Value = begin;
            dateTimePicker_end.Value = end;


            stockLoadRecognizers();
            stockLoadComboBox();

            var TempData = stockData.FirstOrDefault();

            label_tickerName.Text = TempData.ticker;
            label_dataPeriod.Text = TempData.period;
            reloadCandlesticks();
        }

        /*
         the reloadCandlesticks function makes sure that the chart is clear if values pre-exist. 
        This function also makes sure that only the candlesticks within the chose timeframe
        is displayed. Additionally, it also binds the data with the chart.
        */
        public void reloadCandlesticks()
        {
            if (candlesticksChosen != null) candlesticksChosen.Clear();
            if (stockData == null) return;
            var tempdata = stockData.Where(x => x.date >= dateTimePicker_start.Value && x.date <= dateTimePicker_end.Value).ToList();
            tempSmartCandlestickData = tempdata;
            if (tempdata == null || tempdata.Count == 0)
            {
                MessageBox.Show("Invalid Date Range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            candlesticksChosen = new BindingList<smartCandlestick>();
            decimal max = 0, min = 9999999;
            foreach (smartCandlestick cs in tempdata)
            {
                if (cs.high > max)
                {
                    max = cs.high;
                }

                if (cs.low < min)
                {
                    min = cs.low;
                }

                candlesticksChosen.Add(cs);

            }

            chart_dataDisplay.ChartAreas["ChartArea_ohlcDisplay"].AxisY.Minimum = (double)min - 10;
            chart_dataDisplay.ChartAreas["ChartArea_ohlcDisplay"].AxisY.Maximum = (double)max + 10;
            chart_dataDisplay.DataSource = candlesticksChosen;
            chart_dataDisplay.DataBind();

            var data = stockData.FirstOrDefault();

        }

        /*
         When the user clicks on the Reload Button, all the data displayed on the chart is reloaded.
        */
        private void button_reloadData_MouseClick(object sender, MouseEventArgs e)
        {
            reloadCandlesticks();
        }

        /*
         the comboBox_dojiPatterns_SelectedIndexChanged function helps determine what kind of candlestick
        pattern user wants to detect. Next, it makes sure to display an arrow at each candlestick that 
        is determined to be the pattern the user wishes to detect.
        */
        private void comboBox_dojiPatterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart_dataDisplay.Annotations.Clear();

            var selectedRecognizer = recognizers[comboBox_dojiPatterns.SelectedIndex];
            if (tempSmartCandlestickData == null) return;
            for (int i = 0; i < tempSmartCandlestickData.Count; i++)
            {
                if (selectedRecognizer.recognizePattern(tempSmartCandlestickData[i]) && selectedRecognizer.patternSize == 1)
                {
                    CreateAnnotation(tempSmartCandlestickData[i]);
                }
                else if (i < tempSmartCandlestickData.Count - selectedRecognizer.patternSize + 1)
                {
                    List<smartCandlestick> subList = tempSmartCandlestickData.GetRange(i, selectedRecognizer.patternSize);
                    if (selectedRecognizer.recognizePattern(subList))
                    {
                        CreateListOfAnnotation(subList, selectedRecognizer.patternName);
                    }
                }
            }

        }

        /*
         CreateAnnotation creates and adds an arrow notations to a chart control, it
        specifies the size and the color. 
        */
        public void CreateAnnotation(smartCandlestick cs, Color color = default, Color color2 = default, string patternName = "")
        {
            var arrowAnnotation = new ArrowAnnotation();
            arrowAnnotation.AxisX = chart_dataDisplay.ChartAreas[0].AxisX;
            arrowAnnotation.AxisY = chart_dataDisplay.ChartAreas[0].AxisY;
            arrowAnnotation.X = cs.date.ToOADate();

            arrowAnnotation.Y = (double)(cs.low) - 5;
            arrowAnnotation.LineWidth = 1;
            arrowAnnotation.Width = 0;
            arrowAnnotation.Height = 5;
            arrowAnnotation.ArrowSize = 2;
            arrowAnnotation.ForeColor = color;
            arrowAnnotation.LineColor = color == default ? (cs.isBullish ? Color.Green : Color.Red) : color;
            arrowAnnotation.BackColor = color2 == default ? default : color2;

            if (color2 != default)
            {
                double x1 = chart_dataDisplay.Series[0].Points[0].XValue;
                double x2 = chart_dataDisplay.Series[0].Points[1].XValue;
                double candlestickWidth = Math.Abs(x2 - x1);

                var textAnnotation = new TextAnnotation();
                textAnnotation.AxisX = chart_dataDisplay.ChartAreas[0].AxisX;
                textAnnotation.AxisY = chart_dataDisplay.ChartAreas[0].AxisY;
                textAnnotation.X = cs.date.ToOADate() - candlestickWidth;
                textAnnotation.Y = (double)(cs.high) * 1.1;
                textAnnotation.Text = patternName;
                textAnnotation.AnchorAlignment = ContentAlignment.MiddleLeft;
                textAnnotation.Alignment = ContentAlignment.MiddleLeft;
                chart_dataDisplay.Annotations.Add(textAnnotation);
            }

            chart_dataDisplay.Annotations.Add(arrowAnnotation);

        }

        public void CreateListOfAnnotation(List<smartCandlestick> cs, string patternName)
        {
            if (cs.Count == 2)
            {
                CreateAnnotation(cs[0], Color.LightGreen);
                CreateAnnotation(cs[1], Color.Red, Color.Red, patternName);
            }
            else if (cs.Count == 3)
            {
                CreateAnnotation(cs[0], Color.LightGreen);
                CreateAnnotation(cs[2], Color.LightGreen);
                CreateAnnotation(cs[1], Color.Red, Color.Red, patternName);
            }
        }

        public void stockLoadRecognizers()
        {
            List<axxxRecognizer> lr = new List<axxxRecognizer>();
            lr.Add(new bullishRecognizer(1, "Bullish"));
            lr.Add(new bearishRecognizer(1, "Bearish"));
            lr.Add(new neutralRecognizer(1, "Neutral"));
            lr.Add(new bullishEngulfingRecognizer(2, "Bullish Engulfing"));
            lr.Add(new bearishEngulfingRecognizer(2, "Bearish Engulfing"));
            lr.Add(new bullishHaramiRecognizer(2, "Bullish Harami"));
            lr.Add(new bearishHaramiRecognizer(2, "Bearish Harami"));
            lr.Add(new marubozuRecognizer(1, "Marubozu"));
            lr.Add(new dojiRecognizer(1, "Doji"));
            lr.Add(new dragonflyDojiRecognizer(1, "DragonFly Doji"));
            lr.Add(new gravestoneDojiRecognizer(1, "Gravestone Doji"));
            lr.Add(new hammerRecognizer(1, "Hammer"));
            lr.Add(new invertedHammerRecognizer(1, "Inverted Hammer"));
            lr.Add(new peakRecognizer(3, "Peak"));
            lr.Add(new valleyRecognizer(3, "Valley"));

            recognizers = lr;
        }
        public void stockLoadComboBox()
        {
            List<string> patternNames = new List<string>();
            foreach (axxxRecognizer r in recognizers)
            {
                patternNames.Add(r.patternName);
            }

            comboBox_dojiPatterns.DataSource = patternNames;
        }
    }
}
