using Stock_analysis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_analysis.PatternRecognizer
{
    /*
     axxxRecognizer is an abstract class that is common doji pattern recognizer with implementations of different pattern recognizer method inside it. 
    */
    abstract class axxxRecognizer
    {
        public int dojiPatternSize;
        public string dojiPatternName;
        public axxxRecognizer(int dojiPatternSize, string dojiPatternName)
        {
            this.dojiPatternSize = dojiPatternSize;

            this.dojiPatternName = dojiPatternName;
        }

        /*
         recognizeDojiPattern is a virtual method that is implemented by derived classes for recognizing patterns from 
        a list of smartCandlestick objects.
        */
        public virtual bool recognizeDojiPattern(smartCandlestick sc)
        {
            return false;
        }

        /*
         recognizeDojiPattern is a virtual method that is implemented by derived classes for recognizing patterns from 
        a list of smartCandlestick objects.
        */
        public virtual bool recognizeDojiPattern(List<smartCandlestick> sc)
        {
            return false;
        }
    }

    /*
     dojiRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Doji candlesticks
    */
    class dojiRecognizer : axxxRecognizer
    {
        public dojiRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizeDojiPattern(smartCandlestick cs)
        {
            return cs.isDoji;
        }
    }

    /*
     hammerRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Hammer Doji candlesticks
    */
    class hammerRecognizer : axxxRecognizer
    {
        public hammerRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizeDojiPattern(smartCandlestick cs)
        {
            return cs.isHammer;
        }
    }

    /*
     bullishRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Bullish Doji candlesticks
    */
    class bullishRecognizer : axxxRecognizer
    {
        public bullishRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizeDojiPattern(smartCandlestick cs)
        {
            return cs.isBullish;
        }
    }

    /*
     bearishRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Bearish Doji candlesticks
    */
    class bearishRecognizer : axxxRecognizer
    {
        public bearishRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizeDojiPattern(smartCandlestick cs)
        {
            return cs.isBearish;
        }
    }

    /*
     neutralRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Neutral Doji candlesticks
    */
    class neutralRecognizer : axxxRecognizer
    {
        public neutralRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizeDojiPattern(smartCandlestick cs)
        {
            return cs.isNeutral;
        }
    }

    /*
     marubozuRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Marubozu Doji candlesticks
    */
    class marubozuRecognizer : axxxRecognizer
    {
        public marubozuRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizeDojiPattern(smartCandlestick cs)
        {
            return cs.isMarubozu;
        }
    }

    /*
     dragonflyDojiRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Dragonfly Doji candlesticks
    */
    class dragonflyDojiRecognizer : axxxRecognizer
    {
        public dragonflyDojiRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizeDojiPattern(smartCandlestick cs)
        {
            return cs.isDragonFlyDoji;
        }
    }

    /*
     gravestoneDojiRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Gravestone Doji candlesticks
    */
    class gravestoneDojiRecognizer : axxxRecognizer
    {
        public gravestoneDojiRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizeDojiPattern(smartCandlestick cs)
        {
            return cs.isGravestoneDoji;
        }
    }

    /*
     invertedHammerRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Inverted Hammer Doji candlesticks
    */
    class invertedHammerRecognizer : axxxRecognizer
    {
        public invertedHammerRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizeDojiPattern(smartCandlestick cs)
        {
            return cs.isInvertedHammer;
        }
    }

    /*
     peakRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Peak Doji patterned candlesticks
    */
    class peakRecognizer : axxxRecognizer
    {
        public peakRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        // override bool recognizeDojiPattern overrides the recognizeDojiPattern method for multi smartCandlestick patterns
        public override bool recognizeDojiPattern(List<smartCandlestick> scs)
        {
            if (scs.Count == 3)
            {
                smartCandlestick scs1 = scs[0];
                smartCandlestick scs2 = scs[1];
                smartCandlestick scs3 = scs[2];

                return (scs2.high > scs1.high) && (scs2.high > scs3.high);
            }

            return false;
        }
    }

    /*
     valleyRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Valley Doji patterned candlesticks
    */
    class valleyRecognizer : axxxRecognizer
    {
        public valleyRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        // override bool recognizeDojiPattern overrides the recognizeDojiPattern method for multi smartCandlestick patterns
        public override bool recognizeDojiPattern(List<smartCandlestick> scs)
        {
            if (scs.Count == 3)
            {
                smartCandlestick scs1 = scs[0];
                smartCandlestick scs2 = scs[1];
                smartCandlestick scs3 = scs[2];

                return (scs2.low < scs1.low) && (scs2.low < scs3.low);
            }

            return false;
        }
    }

    /*
     bullishEngulfingRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Bullish Engulfing Doji patterned candlesticks
    */
    class bullishEngulfingRecognizer : axxxRecognizer
    {
        public bullishEngulfingRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        // override bool recognizeDojiPattern overrides the recognizeDojiPattern method for multi smartCandlestick patterns
        public override bool recognizeDojiPattern(List<smartCandlestick> scs)
        {
            if (scs.Count == dojiPatternSize)
            {
                smartCandlestick scs1 = scs[0];
                smartCandlestick scs2 = scs[1];

                return (scs2.close > scs2.open) && (scs1.close < scs1.open) && (scs2.close > scs1.open) && (scs2.open < scs1.close);
            }

            return false;
        }
    }

    /*
     bearishEngulfingRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Bearish Engulfing Doji patterned candlesticks
    */
    class bearishEngulfingRecognizer : axxxRecognizer
    {
        public bearishEngulfingRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        // override bool recognizeDojiPattern overrides the recognizeDojiPattern method for multi smartCandlestick patterns
        public override bool recognizeDojiPattern(List<smartCandlestick> scs)
        {
            if (scs.Count == dojiPatternSize)
            {
                smartCandlestick scs1 = scs[0];
                smartCandlestick scs2 = scs[1];

                return (scs2.close < scs2.open) && (scs1.close > scs1.open) && (scs2.close < scs1.open) && (scs2.open > scs1.close);
            }

            return false;
        }
    }

    /*
     bullishHaramiRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Bullish Harami Doji patterned candlesticks
    */
    class bullishHaramiRecognizer : axxxRecognizer
    {
        public bullishHaramiRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        // override bool recognizeDojiPattern overrides the recognizeDojiPattern method for multi smartCandlestick patterns
        public override bool recognizeDojiPattern(List<smartCandlestick> scs)
        {
            if (scs.Count == dojiPatternSize)
            {
                smartCandlestick scs1 = scs[0];
                smartCandlestick scs2 = scs[1];

                return ((scs2.close>scs2.open) && (scs1.close<scs1.open) && (scs2.close<scs1.open) && (scs2.open>scs1.close));
            }

            return false;
        }
    }

    /*
     bearishHaramiRecognizer is a derived class from the abstract class axxxRecognizer that represent a doji pattern recognizer 
    for detecting Bearish Harami Doji patterned candlesticks
    */
    class bearishHaramiRecognizer : axxxRecognizer
    {
        public bearishHaramiRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        // override bool recognizeDojiPattern overrides the recognizeDojiPattern method for multi smartCandlestick patterns
        public override bool recognizeDojiPattern(List<smartCandlestick> scs)
        {
            if (scs.Count == dojiPatternSize)
            {
                smartCandlestick scs1 = scs[0];
                smartCandlestick scs2 = scs[1];

                return ((scs2.close < scs2.open) && (scs1.close > scs1.open) && (scs2.close > scs1.open) && (scs2.open < scs1.close));
            }

            return false;
        }
    }

}
