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
            // smart properties are calculated based on aCandlestick properties
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
            isMarubozu = (bodyRange / range) >= 0.95m && topTail == 0 && bottomTail == 0;

            isDragonFlyDoji = bodyRange <= (high - low) * 0.2m
                    && topTail <= (high - low) * 0.05m
                    && (bottomTail > (high - low) * 0.6m && isBullish || topTail > (high - low) * 0.6m && isBearish);

            isGravestoneDoji = bodyRange <= (high - low) * 0.2m
                    && bottomTail <= (high - low) * 0.1m
                    && topTail > (high - low) * 0.6m
                    && (isBullish || isBearish);

            decimal hammerBodyRangeThreshold = 0.2m;
            decimal hammerUpperShadowThreshold = 0.20m;
            decimal hammerLowerShadowThreshold = 0.50m;

            isHammer = bodyRange <= (high - low) * hammerBodyRangeThreshold
                    && topTail <= (high - low) * hammerUpperShadowThreshold
                    && bottomTail > (high - low) * hammerLowerShadowThreshold
                    && isBullish; // Confirming it's a green candle for bullish pattern

            decimal invertedHammerBodyRangeThreshold = 0.2m;
            decimal invertedHammerUpperShadowThreshold = 0.2m;
            decimal invertedHammerLowerShadowThreshold = 0.5m;

            isInvertedHammer = bodyRange <= (high - low) * invertedHammerBodyRangeThreshold
                    && bottomTail <= (high - low) * invertedHammerUpperShadowThreshold
                    && topTail > (high - low) * invertedHammerLowerShadowThreshold
                    && isBearish; // Confirming it's a red candle for bearish pattern

        }

    }
}
/*
 smartCandlestick class creates a smartCandlestick object with the following information:
range, bodyRange,topPrice, bottomPrice, topTail,bottomTail, isBullish, isBearish, 
isNeutral, isMarubozu, isNeutral, isDoji, isDragonFlyDoji, isGravestoneDoji,
isHammer, and isInvertedHammer. These values help determine the candlestick patterns for each 
candlestick
 */