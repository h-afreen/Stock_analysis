using Stock_analysis.Model;
using Stock_analysis.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_analysis
{
    public partial class form_stockLoad : Form
    {
        private BindingList<aCandlestick> candlesticks { get; set; }

        public form_stockLoad()
        {
            InitializeComponent();
        }

        /*
         When the user click on the Load Stock Data button, the openFileDialog opens
        the file explorer and finds the stock data folder.
        */
        private void button_loadStock_Click(object sender, EventArgs e)
        {
            openFileDialog_stockFile.ShowDialog();
        }

        /*
         openFileDialog_stockFile_FileOk is triggered when the user chooses files and clicks open. 
        Next the function iterates through the array of selected file names and passes each file
        through the ReadCVSDataAsCandleSticks function from the dataReader class and stores the 
        returned value in smartCandlestick list. Once the data is extracted from the file,
        a new form is created to display the charts to represent the candlesticks.
        */
        private void openFileDialog_stockFile_FileOk(object sender, CancelEventArgs e)
        {
            foreach (string file in openFileDialog_stockFile.FileNames)
            {
                List<smartCandlestick> data = dataReader.ReadCVSDataAsCandleSticks(file);

                form_displayChart newChart = new form_displayChart(data, dateTimePicker_start.Value, dateTimePicker_end.Value);
                newChart.Show();
            }
        }
    }
}
