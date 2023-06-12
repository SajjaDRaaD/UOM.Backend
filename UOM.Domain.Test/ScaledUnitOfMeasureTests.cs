using FluentAssertions;

namespace UOM.Domain.Test
{
    public class ScaledUnitOfMeasureTests
    {
        [Fact]
        public void it_gets_constructed_properly()
        {
            var title = "Kilogram";
            var symbol = "KG";
            var scaleToBase = 1000;
            var dimensionId = 1;

            var unitOfMeasure = new ScaledUnitOfMeasure(title, symbol, scaleToBase, dimensionId);

            unitOfMeasure.Title.Should().Be(title);
            unitOfMeasure.Symbol.Should().Be(symbol);
            unitOfMeasure.ScaleToBase.Should().Be(scaleToBase);
            unitOfMeasure.DimensionId.Should().Be(dimensionId);
        }

        [Fact]
        public void converts_value_to_base_dimension()
        {
            var title = "Kilogram";
            var symbol = "KG";
            var scaleToBase = 1000;
            var dimensionId = 1;

            
            var unitOfMeasure = new ScaledUnitOfMeasure(title, symbol, scaleToBase, dimensionId);
            
            var result = unitOfMeasure.ConvertToBase(0.5M);
            result.Should().Be(500M);
        }

        [Theory]
        [InlineData(50,5000000)]
        [InlineData(0.5,50000)]
        [InlineData(0,0)]
        public void converts_value_to_another_scaled_unit(decimal valueToConvert, decimal expected)
        {
            var centimeter = new ScaledUnitOfMeasure("Centimeter","CM",0.01M,2);
            var kilometer = new ScaledUnitOfMeasure("Kilometer", "KM", 1000, 3);

            var valueInCentimeter = kilometer.Convert(centimeter,valueToConvert);

            valueInCentimeter.Should().Be(expected);
        }

    }
}
