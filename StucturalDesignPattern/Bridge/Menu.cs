using System;
/* The intent is to decouple an abstraction from its implementation so the two can vary indepentendly.
 you could rephrase this as this pattern aims to separate an abstraction of the class from the implementation. As a result,this provides the  means to replace an implementation
with another omplementation without modifing abstraction.Abstractin in this context means can be seen as a way to sumplify somthing complex.
Abstraction handle complexity by hiding  the parts that we dont need to know about.And this abstraction is what we're trying to decouple from its implementation.
.. Abstract Menu class structurally is called an abstraction as it hides complexity of getting the coupon value. The abstraction does define the abstraction's interface
it holds a reference to an implementor.a concrete implementatoin is named refinedAbstraction. this extends the interface defined by abstraction. the coupon base is the implementor
this defines the interface for concreate implementation.
    Use Cases:
1.When you want to avoid a permanent binding between an abstraction and its implementation(to enable switching implementations at runtime
2.When abstraction and implementation should be extensible by subclassing.
3.when you don't wont changes in the implementation of an abstraction have an   impact on the client;
4.
*/


namespace Bridge
{/// <summary>
///     
/// </summary>
    public abstract class Menu
    {
        public readonly ICoupon _coupon = null!;
        public abstract int CalculatePrice();
        public Menu(ICoupon coupon)
        {
            this._coupon = coupon;
        }
    }
    // RefinedAbstraction 
    public class VegetarianMenu : Menu
    {
        public VegetarianMenu(ICoupon coupon) : base(coupon)
        { }

        public override int CalculatePrice()
        {
            return 20 - _coupon.CouponValue;
        }
    }

    public class MeatBaseMenu : Menu
    {
        public MeatBaseMenu(ICoupon coupon) : base(coupon)
        { }

        public override int CalculatePrice()
        {
            return 30 - _coupon.CouponValue;
        }
    }

    /// Implementor
    public interface ICoupon
    {
        int CouponValue { get; }
    }
    public class NoCoupon : ICoupon
    {
        public int CouponValue => 0;
    }
    public class OneEuroCoupon : ICoupon
    {
        public int CouponValue => 1;
    }
    public class TwoEuroCoupon : ICoupon
    {
        public int CouponValue => 2;
    }
}
