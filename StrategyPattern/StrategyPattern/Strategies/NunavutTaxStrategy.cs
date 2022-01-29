using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Strategies
{
    internal class NunavutTaxStrategy : ITaxStrategy
    {
        public decimal CalculateTax(decimal subtotal)
        {
            return subtotal * 0.05m;
        }
    }
}
