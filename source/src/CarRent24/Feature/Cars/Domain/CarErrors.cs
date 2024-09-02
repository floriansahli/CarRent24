using CarRent24.Common;

namespace CarRent24.Feature.Cars.Domain
{
    public static class CarErrors
    {
       public static DomainException InvalidLicensePlate => 
            new DomainException("Cars.InvalidLicensePlate", "The licenseplate was invalid");
    }
}
