using Stock_analysis.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_analysis.Services
{
    internal class dataReader
    {

        public static List<smartCandlestick> ReadCVSDataAsCandleSticks(string filename)
        {
            List<smartCandlestick> CandlesticksList = new List<smartCandlestick>();
            //the list aCandlesticks holds all the candlestick objects

            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string firstLine = sr.ReadLine();//ReadLine function reads each line of data
                    //the first line of the file with the labels is discarded

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parsedValues = line.Split(',');

                        if (parsedValues.Length >= 9)
                        {
                            smartCandlestick aCandlestick = new smartCandlestick(parsedValues);
                            CandlesticksList.Add(aCandlestick);
                        }
                        else
                        {
                            MessageBox.Show("Invalid data in CSV file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CandlesticksList.Reverse();//so that the list is reversed the oldest date is at the top
            return CandlesticksList;
        }

    }
}

/*
 The class dataReader reads data from chosen file and parses the data to be stored inside 
a string list values depending on delimiters. 
Next, a candlestick object using aCandlestick class is created and the values list is passed as an argument for every line
in the data file. 
 */
