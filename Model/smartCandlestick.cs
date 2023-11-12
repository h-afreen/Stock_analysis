using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_analysis.Model
{
    public class smartCandlestick : aCandlestick
    {
        //Smart Candlestick Properties
        public decimal range { get; set; }
        public decimal bodyRange { get; set; }
        public decimal topPrice { get; set; }
        public decimal bottomPrice { get; set; }
        public decimal topTail { get; set; }
        public decimal bottomTail { get; set; }
        public bool isBullish { get; set; }
        public bool isBearish { get; set; }
        public bool isMarubozu { get; set; }
        public bool isNeutral { get; set; }
        public bool isDoji { get; set; }
        public bool isDragonFlyDoji { get; set; }
        public bool isGravestoneDoji { get; set; }
        public bool isHammer { get; set; }
        public bool isInvertedHammer { get; set; }

        // Constructor that calls the base class constructor
        public smartCandlestick(string[] values) : base(values)
        {
            // Calculate smart properties based on aCandlestick properties
            range = high - low;
            bodyRange = Math.Abs(close - open);
            topPrice = Math.Max(open, close);
            bottomPrice = Math.Min(open, close);
            topTail = high - Math.Max(open, close);
            bottomTail = Math.Min(open, close) - low;

            
            isBullish = close > open;
            isBearish = open > close;
            isNeutral = open == close;

            double lowerShadowRatio = (double)(close - low) / (double)(high - low);
            double upperShadowRatio = (double)(high - close) / (double)(high - low);

            decimal dojiThreshold = 0.01m;

            isDoji = (bodyRange <= dojiThreshold && bodyRange <= (high - low) * 0.05m) || isNeutral;
            isMarubozu = (bodyRange / range) >= 0.95m && topTail == 0 
                && bottomTail == 0;
            double lowerShadowRatioThreshold = 0.02;
            double upperShadowRatioThreshold = 0.98;

            bool moreBullishTrend = bottomTail > (high - low) * 0.2m;
            isDragonFlyDoji = topTail == 0 // Opening and closing prices are at the highest of the day
                  && lowerShadowRatio >= lowerShadowRatioThreshold
                  && upperShadowRatio < upperShadowRatioThreshold
                  && moreBullishTrend; //works

            bool bearishTrendSignal = topTail > (high - low) * 0.2m;
            isGravestoneDoji = bottomTail == 0 // Opening and closing prices are at the lowest of the day
                   && upperShadowRatio >= upperShadowRatioThreshold
                   && lowerShadowRatio < lowerShadowRatioThreshold
                   && bearishTrendSignal;

            isHammer = bodyRange <= (high - low) * 0.2m 
                && topTail <= (high - low) * 0.05m && bottomTail > (high - low) * 0.6m 
                && isBullish; //works

            isInvertedHammer = bodyRange <= (high - low) * 0.2m
                    && bottomTail <= (high - low) * 0.05m
                    && topTail > (high - low) * 0.6m
                    && isBullish; //works
            


        }

    }
}
