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

        private void button_loadStock_Click(object sender, EventArgs e)
        {
            openFileDialog_stockFile.ShowDialog();
        }

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
