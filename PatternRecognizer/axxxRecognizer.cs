using Stock_analysis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_analysis.PatternRecognizer
{
    abstract class axxxRecognizer
    {
        public int dojiPatternSize;
        public string dojiPatternName;
        public axxxRecognizer(int dojiPatternSize, string dojiPatternName)
        {
            this.dojiPatternSize = dojiPatternSize;

            this.dojiPatternName = dojiPatternName;
        }
        public List<smartCandlestick> Recognize(List<smartCandlestick> smartCandlesticks)
        {
            List<smartCandlestick> smartCandlesticksTemp = new List<smartCandlestick>();
            foreach (smartCandlestick cs in smartCandlesticks)
            {
                if (recognizePattern(cs))
                {
                    smartCandlesticksTemp.Add(cs);
                }
            }
            return smartCandlesticksTemp;
        }

        public virtual bool recognizePattern(smartCandlestick sc)
        {
            return false;
        }

        public virtual bool recognizePattern(List<smartCandlestick> sc)
        {
            return false;
        }
    }

    class dojiRecognizer : axxxRecognizer
    {
        public dojiRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizePattern(smartCandlestick cs)
        {
            return cs.isDoji;
        }
    }

    class hammerRecognizer : axxxRecognizer
    {
        public hammerRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizePattern(smartCandlestick cs)
        {
            return cs.isHammer;
        }
    }
    class bullishRecognizer : axxxRecognizer
    {
        public bullishRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizePattern(smartCandlestick cs)
        {
            return cs.isBullish;
        }
    }

    class bearishRecognizer : axxxRecognizer
    {
        public bearishRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizePattern(smartCandlestick cs)
        {
            return cs.isBearish;
        }
    }

    class neutralRecognizer : axxxRecognizer
    {
        public neutralRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizePattern(smartCandlestick cs)
        {
            return cs.isNeutral;
        }
    }

    class marubozuRecognizer : axxxRecognizer
    {
        public marubozuRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizePattern(smartCandlestick cs)
        {
            return cs.isMarubozu;
        }
    }

    class dragonflyDojiRecognizer : axxxRecognizer
    {
        public dragonflyDojiRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizePattern(smartCandlestick cs)
        {
            return cs.isDragonFlyDoji;
        }
    }

    class gravestoneDojiRecognizer : axxxRecognizer
    {
        public gravestoneDojiRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizePattern(smartCandlestick cs)
        {
            return cs.isGravestoneDoji;
        }
    }

    class invertedHammerRecognizer : axxxRecognizer
    {
        public invertedHammerRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }
        public override bool recognizePattern(smartCandlestick cs)
        {
            return cs.isInvertedHammer;
        }
    }

    class peakRecognizer : axxxRecognizer
    {
        public peakRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        public override bool recognizePattern(List<smartCandlestick> scs)
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

    class valleyRecognizer : axxxRecognizer
    {
        public valleyRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        public override bool recognizePattern(List<smartCandlestick> scs)
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

    class bullishEngulfingRecognizer : axxxRecognizer
    {
        public bullishEngulfingRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        public override bool recognizePattern(List<smartCandlestick> scs)
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

    class bearishEngulfingRecognizer : axxxRecognizer
    {
        public bearishEngulfingRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        public override bool recognizePattern(List<smartCandlestick> scs)
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

    class bullishHaramiRecognizer : axxxRecognizer
    {
        public bullishHaramiRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        public override bool recognizePattern(List<smartCandlestick> scs)
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

    class bearishHaramiRecognizer : axxxRecognizer
    {
        public bearishHaramiRecognizer(int dojiPatternSize, string dojiPatternName) : base(dojiPatternSize, dojiPatternName)
        {

        }

        public override bool recognizePattern(List<smartCandlestick> scs)
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
