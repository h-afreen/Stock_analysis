using Stock_analysis.Model;
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
        private BindingList<smartCandlestick> candlesticksChosen { get; set; }
        public form_displayChart(List<smartCandlestick> data, DateTime begin, DateTime end)
        {
            InitializeComponent();
            stockData = data;
            dateTimePicker_start.Value = begin;
            dateTimePicker_end.Value = end;

            List<string> candlestickDojiPatterns = new List<string>
            {
                "",
                "Bullish",
                "Bearish",
                "Neutral",
                "Doji",
                "Marubozu",
                "DragonFly Doji",
                "Gravestone Doji",
                "Hammer",
                "Inverted Hammer"
            };
            comboBox_dojiPatterns.DataSource = candlestickDojiPatterns;

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


            if (comboBox_dojiPatterns.SelectedValue.ToString() == "Bullish")
            {
                foreach (smartCandlestick cs in tempSmartCandlestickData)
                {
                    if (cs.isBullish)
                    {
                        CreateAnnotation(cs);
                    }
                }
            }

            if (comboBox_dojiPatterns.SelectedValue.ToString() == "Bearish")
            {
                foreach (smartCandlestick cs in tempSmartCandlestickData)
                {
                    if (cs.isBearish)
                    {
                        CreateAnnotation(cs);
                    }
                }
            }

            if (comboBox_dojiPatterns.SelectedValue.ToString() == "Neutral")
            {
                foreach (smartCandlestick cs in tempSmartCandlestickData)
                {
                    if (cs.isNeutral)
                    {
                        CreateAnnotation(cs);
                    }
                }
            }

            if (comboBox_dojiPatterns.SelectedValue.ToString() == "Doji")
            {
                foreach (smartCandlestick cs in tempSmartCandlestickData)
                {

                    if (cs.isDoji)
                    {
                        CreateAnnotation(cs);
                    }
                }
            }

            if (comboBox_dojiPatterns.SelectedValue.ToString() == "Marubozu")
            {
                foreach (smartCandlestick cs in tempSmartCandlestickData)
                {
                    if (cs.isMarubozu)
                    {
                        CreateAnnotation(cs);
                    }
                }
            }

            if (comboBox_dojiPatterns.SelectedValue.ToString() == "DragonFly Doji")
            {
                foreach (smartCandlestick cs in tempSmartCandlestickData)
                {
                    if (cs.isDragonFlyDoji)
                    {
                        CreateAnnotation(cs);
                    }
                }
            }

            if (comboBox_dojiPatterns.SelectedValue.ToString() == "Gravestone Doji")
            {
                foreach (smartCandlestick cs in tempSmartCandlestickData)
                {
                    if (cs.isGravestoneDoji)
                    {
                        CreateAnnotation(cs);
                    }
                }
            }

            if (comboBox_dojiPatterns.SelectedValue.ToString() == "Hammer")
            {
                foreach (smartCandlestick cs in tempSmartCandlestickData)
                {
                    if (cs.isHammer)
                    {
                        CreateAnnotation(cs);
                    }
                }
            }

            if (comboBox_dojiPatterns.SelectedValue.ToString() == "Inverted Hammer")
            {
                foreach (smartCandlestick cs in tempSmartCandlestickData)
                {
                    if (cs.isInvertedHammer)
                    {
                        CreateAnnotation(cs);
                    }
                }
            }
        }

        /*
         CreateAnnotation creates and adds an arrow notations to a chart control, it
        specifies the size and the color. 
        */
        public void CreateAnnotation(smartCandlestick cs)
        {
            var rectangleAnnotation = new ArrowAnnotation();
            rectangleAnnotation.AxisX = chart_dataDisplay.ChartAreas[0].AxisX;
            rectangleAnnotation.AxisY = chart_dataDisplay.ChartAreas[0].AxisY;
            rectangleAnnotation.X = cs.date.ToOADate();

            rectangleAnnotation.Y = (double)(cs.low) - 5;
            rectangleAnnotation.LineWidth = 1;
            rectangleAnnotation.Width = 0;
            rectangleAnnotation.Height = 5;
            rectangleAnnotation.ArrowSize = 2;

            rectangleAnnotation.LineColor = Color.Red;

            chart_dataDisplay.Annotations.Add(rectangleAnnotation);
        }
    }
}
