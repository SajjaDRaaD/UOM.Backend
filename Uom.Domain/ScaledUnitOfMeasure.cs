namespace UOM.Domain
{
    public class ScaledUnitOfMeasure
    {
        public string Title { get;}
        public string Symbol { get; }
        public decimal ScaleToBase { get; }
        public int DimensionId { get; }

        public ScaledUnitOfMeasure(string title, string symbol, decimal scaleToBase, int dimensionId)
        {
            this.Title = title;
            this.Symbol = symbol;
            this.ScaleToBase = scaleToBase;
            this.DimensionId = dimensionId;
        }

        public decimal ConvertToBase(decimal value)
        {
            return value * ScaleToBase;
        }

        public decimal Convert(ScaledUnitOfMeasure targetUnit, decimal value)
        {
            var valueInBase = ConvertToBase(value);
            return valueInBase / targetUnit.ScaleToBase;
        }
    }
}