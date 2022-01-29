using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies
{
    internal class BritishColumbiaTaxStrategy : ITaxStrategy
    {
        public decimal CalculateTax(decimal subtotal)
        {
            return subtotal * 0.12m;
        }
    }
}
