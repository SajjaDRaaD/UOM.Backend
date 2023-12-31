﻿using FluentAssertions;
using UOM.Domain.Test.TestUtils;

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

        [Theory]
        [InlineData(5,5000)]
        [InlineData(0.5,500)]
        [InlineData(50,50000)]
        public void converts_value_to_base_dimension(decimal valueToConvert, decimal expected)
        {
            var unitOfMeasure = CreateScaledUnitOfMeasure(x => x.WithScaledToBase(1000));
            
            var result = unitOfMeasure.ConvertToBase(valueToConvert);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(50,5000000)]
        [InlineData(0.5,50000)]
        [InlineData(0,0)]
        public void converts_value_to_another_scaled_unit(decimal valueToConvert, decimal expected)
        {
            var centimeter = CreateScaledUnitOfMeasure(x=> x.WithTitle("Centimeter").WithScaledToBase(0.01M));
            var kilometer = CreateScaledUnitOfMeasure(x=> x.WithTitle("Kilometer").WithScaledToBase(1000));

            var valueInCentimeter = kilometer.Convert(centimeter,valueToConvert);

            valueInCentimeter.Should().Be(expected);
        }

        private ScaledUnitOfMeasure CreateScaledUnitOfMeasure(Action<ScaledUnitOfMeasureBuilder> builderConfig)
        {
            var builder = new ScaledUnitOfMeasureBuilder();
            builderConfig.Invoke(builder);

            return builder.Build();
        }
    }
}
