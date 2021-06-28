using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Parameters
{
    public class GameParameters : SomeParameters
    {
        public double MinCost { get; set; } = 0;
        public double MaxCost { get; set; } = double.MaxValue;

        public bool ValidCostRange => MaxCost >= MinCost && MinCost >= 0;

        public string Name { get; set; }
    }
}
