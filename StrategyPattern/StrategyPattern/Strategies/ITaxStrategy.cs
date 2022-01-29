using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies
{
    internal interface ITaxStrategy
    {
        public decimal CalculateTax(decimal subtotal);
    }
}
