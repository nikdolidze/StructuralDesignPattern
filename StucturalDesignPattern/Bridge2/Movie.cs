using System;
/* The Gang of Four, in their Design pattern Book, defined its purpose as to decouple an abstraction from its implementation, so that two can very independently.
To apply bridge pattern and simplify  our over-complicated class hirearchy,we will introduce a separate class hirearchy called Discount.and we will move all discount-related fucntionality to that hirearcchy.
*/
namespace Bridge2
{
    public class MovieLicense
    {
        public string Movie { get; }
        public DateTime PurchaseTime { get; }
        private Discount _dicount { get; }
        public LicenceType _licenceType { get; }
        public SpeciafOffer _spercialOffer { get; }

        public MovieLicense(string movie, DateTime purchaseTime, Discount discount, LicenceType licenceType, SpeciafOffer spercialOffer = SpeciafOffer.None)
        {
            _dicount = discount; _licenceType = licenceType;
            _spercialOffer = spercialOffer;
            Movie = movie; PurchaseTime = purchaseTime;
        }
        public decimal GetPrice()
        {
            int discount = GetDiscount();
            decimal multiplier = 1 - discount / 100m;
            return GetBasePriceCore() * multiplier;
        }
        private decimal GetBasePriceCore()
        {
            return _licenceType switch
            {
                LicenceType.LiveLonf => 4,
                LicenceType.TwoDays => 8,
                _ => throw new NotImplementedException()
            };
        }
        public DateTime? GetExpirationDate()
        {
            DateTime? expirationDate = GetBaseExpiratonDate();
            TimeSpan extensions = SpecialOfferExtension();

            return expirationDate?.Add(extensions);
        }
        private TimeSpan SpecialOfferExtension()
        {
            return
                _spercialOffer switch
                {
                    SpeciafOffer.None => TimeSpan.Zero,
                    SpeciafOffer.TwoDaysExtensions => TimeSpan.FromDays(2),
                    _ => throw new NotImplementedException()
                }; 
        }

        private DateTime? GetBaseExpiratonDate()
        {
            return _licenceType switch
            {
                LicenceType.LiveLonf => null,
                LicenceType.TwoDays => DateTime.Now,
                _ => throw new NotImplementedException()
            };
        }

        private int GetDiscount()
        {
            return _dicount switch
            {
                Discount.None => 0,
                Discount.Military => 10,
                Discount.Senior => 20,
                _ => throw new NotImplementedException()
            };
        }
    }


    public enum LicenceType
    {
        TwoDays, LiveLonf
    }

    public enum Discount
    {
        None, Military, Senior
    }
    public enum SpeciafOffer
    {
        None,TwoDaysExtensions
    }

    //  public abstract class Discount
    //  {
    //      public abstract int GetDiscount();
    //  }
    //public  class NoDiscount : Discount
    //  {
    //      public override int GetDiscount() => 0;
    //  }
    //  public class MililaryDiscount : Discount
    //  {
    //      public override int GetDiscount() => 10;
    //  }
    //  public class SeniorDiscount : Discount
    //  {
    //      public override int GetDiscount() => 20;
    //  }

    //public class TwoDaysLicense : MovieLicense
    //{
    //    public TwoDaysLicense(string movie, DateTime purchaseTime, Discount discount)
    //        : base(movie, purchaseTime, discount)
    //    {
    //    }
    //    protected override decimal GetPriceCore() => 4;
    //    public override DateTime? GetExpirationDate() => PurchaseTime.AddDays(2);
    //}

    //public class LifeLongLicense : MovieLicense
    //{
    //    public LifeLongLicense(string movie, DateTime purchaseTime, Discount discount)
    //        : base(movie, purchaseTime, discount)
    //    {
    //    }
    //    protected override decimal GetPriceCore() => 8;
    //    public override DateTime? GetExpirationDate() => null;
    //}
    //public class MilitaryTwoDaysLIcense : TwoDaysLicense
    //{
    //    public MilitaryTwoDaysLIcense(string movie, DateTime purchaseTime,Discount discount) : base(movie, purchaseTime,discount)
    //    {
    //    }
    //    public override decimal GetPriceCore()
    //    {
    //        return base.GetPriceCore() * 0.9m;
    //    }
    //}

    //public class SenionrTwoDaysLIcense : TwoDaysLicense
    //{
    //    public SenionrTwoDaysLIcense(string movie, DateTime purchaseTime,Discount discount) : base(movie, purchaseTime,discount)
    //    {
    //    }
    //    public override decimal GetPriceCore()
    //    {
    //        return base.GetPriceCore() * 0.8m;
    //    }
    //}
    //public class MilitaryLifeLongLicense : LifeLongLicense
    //{
    //    public MilitaryLifeLongLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
    //    {
    //    }
    //    public override decimal GetPriceCore()
    //    {
    //        return base.GetPriceCore() * 0.9m;
    //    }
    //}

    //public class SeniorLifeLongLicense : LifeLongLicense
    //{
    //    public SeniorLifeLongLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
    //    {
    //    }
    //    public override decimal GetPriceCore()
    //    {
    //        return base.GetPriceCore() * 0.8m;
    //    }
    //}



}
