using CarRent24.Common;
using System.Text.RegularExpressions;

namespace CarRent24.Feature.Cars.Domain
{
    public class LicensePlate : ValueObject
    {
        private LicensePlate() { }
        private LicensePlate(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        protected override IEnumerable<object?> EqualityComponents
        {
            get
            {
                yield return Value;
            }
        }

        public static LicensePlate Create(string licensePlate)
        {
            if (!Regex.IsMatch(licensePlate, @"^[A-Z]{2}\-\d+$"))
            {
                throw CarErrors.InvalidLicensePlate;
            }
            return new LicensePlate(licensePlate);
        }
    }
}