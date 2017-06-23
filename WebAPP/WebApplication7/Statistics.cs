using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Statistics
    {
        public int Points { get; set; }
        public int NumOfGames { get; set; }
        public int TotalGrossProfit { get; set; }
        public int HighestCashGain { get; set; }
        public int AvgGrossProfit { get; set; }
        public int AvgCashGain { get; set; }

        public Statistics()
        {
            Points = 0;
            NumOfGames = 0;
            TotalGrossProfit = 0;
            HighestCashGain = 0;
            AvgGrossProfit = 0;
            AvgCashGain = 0;
        }
    }

