using StrategyPattern.Strategies;

Dictionary<string, ITaxStrategy> taxStrategies = new Dictionary<string, ITaxStrategy>();
taxStrategies.Add("AB", new AlbertaTaxStrategy());
taxStrategies.Add("BC", new BritishColumbiaTaxStrategy());
taxStrategies.Add("MB", new ManitobaTaxStrategy());
taxStrategies.Add("NB", new NewBrunswickTaxStrategy());
taxStrategies.Add("NL", new NewfoundlandLabradorTaxStrategy());
taxStrategies.Add("NT", new NorthwestTerritoriesTaxStrategy());
taxStrategies.Add("NS", new NovaScotiaTaxStrategy());
taxStrategies.Add("NU", new NunavutTaxStrategy());
taxStrategies.Add("ON", new OntarioTaxStrategy());
taxStrategies.Add("PE", new PEITaxStrategy());
taxStrategies.Add("QC", new QuebecTaxStrategy());
taxStrategies.Add("SK", new SaskatchewanTaxStrategy());
taxStrategies.Add("YT", new YukonTaxStrategy());

decimal subtotal = 120.0m;
decimal taxAmount = taxStrategies["NS"].CalculateTax(subtotal);

Console.WriteLine("Total in Nova Scotia:");

Console.WriteLine($"Sub total: ${subtotal.ToString("0.00")}");
Console.WriteLine($"Tax:       ${taxAmount.ToString("0.00")}");
Console.WriteLine($"Total:     ${(subtotal + taxAmount).ToString("0.00")}");

Console.WriteLine();

Console.WriteLine("Totals in other provinces:");

foreach (KeyValuePair<string, ITaxStrategy> strategy in taxStrategies.Where(p => p.Key != "NS"))
{
    taxAmount = strategy.Value.CalculateTax(subtotal);
    Console.WriteLine($"{strategy.Key}: ${(subtotal + taxAmount).ToString("0.00")} - Tax: ${taxAmount.ToString("0.00")}");
}