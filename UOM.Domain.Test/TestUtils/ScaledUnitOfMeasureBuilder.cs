using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOM.Domain.Test.TestUtils
{
    internal class ScaledUnitOfMeasureBuilder
    {
        private string _title;
        private string _symbol;
        private decimal _scaleToBase;
        private int _dimensionId;

        public ScaledUnitOfMeasureBuilder()
        {
            _title = "Kilogram";
            _symbol = "KG";
            _scaleToBase = 1000;
            _dimensionId = 1;
        }

        public ScaledUnitOfMeasureBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public ScaledUnitOfMeasureBuilder WithScaledToBase(decimal scaleToBase)
        {
            _scaleToBase = scaleToBase;
            return this;
        }

        public ScaledUnitOfMeasure Build()
        {
            return new ScaledUnitOfMeasure(_title, _symbol, _scaleToBase, _dimensionId);
        }
    }
    
}
