using Adapter;
using Adapter2;
using Adapter3;
using Bridge;
using Bridge2;
using System;
using System.Collections.Generic;
using static Adapter._2proviers.StarWarsCharacterDisplayService;

namespace StucturalDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();


            Bridge2();
            Bridge();
            Adapter3();
            Adapter2();
            Adapter();

        }




















        public static void Bridge2()
        {
            DateTime now = DateTime.Now;

            var license1 = new MovieLicense("Secret Life of Pets", now, Discount.None, LicenceType.LiveLonf);
            var license2 = new MovieLicense("Matrix", now, Discount.None, LicenceType.LiveLonf);

            PrintLicenseDetails(license1);
            PrintLicenseDetails(license2);


            var licence3 = new MovieLicense("nika", now, Discount.Senior, LicenceType.TwoDays);
            var licence4 = new MovieLicense("nnika", now, Discount.Military, LicenceType.TwoDays);
            PrintLicenseDetails(licence3);
            PrintLicenseDetails(licence4);


            static void PrintLicenseDetails(MovieLicense license)
            {
                Console.WriteLine($"Movie: {license.Movie}");
                Console.WriteLine($"Price: {GetPrice(license)}");
                Console.WriteLine($"Valid for: {GetValidFor(license)}");

                Console.WriteLine();
            }

            static string GetPrice(MovieLicense license)
            {
                return $"${license.GetPrice():0.00}";
            }

            static string GetValidFor(MovieLicense license)
            {
                DateTime? expirationDate = license.GetExpirationDate();

                if (expirationDate == null)
                    return "Forever";

                TimeSpan timeSpan = expirationDate.Value - DateTime.Now;

                return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
            }
        }











        public static void Bridge()
        {
            var coupon = new NoCoupon();
            var oneEuroCoupon = new OneEuroCoupon();

            var meatBaseMenu = new MeatBaseMenu(coupon);
            var result = meatBaseMenu.CalculatePrice();
        }

        public static void Adapter3()
        {
            var adapter = new AdapterExample();
            adapter.ExecuteClient();
        }


        public async static void Adapter2()
        {

            var starWarsCharacterDisplayService = new StarWarsCharacterDisplayService();
            await starWarsCharacterDisplayService.ListCharacters();

            var badPractice = new Adapter._2proviers.StarWarsCharacterDisplayService();
            await badPractice.ListCharacters(CharacterSource.File);


            var adapter = new AdapterIntroduction.StarWarsCharacterDisplayService();
            await adapter.ListCharacters(AdapterIntroduction.CharacterSource.File);


            var betterCode = new ImproveAdapterIntroduction.StarWarsCharacterDisplayService(
                                     new ImproveAdapterIntroduction.CharacterFileSourceAdapter("People.json", new ImproveAdapterIntroduction.CharacterFileSource()));

            await betterCode.ListCharacters();




        }


        public static void Adapter()
        {
            var adapter = new CityAdapter();
            var city = adapter.Getcity();

            Console.WriteLine(city.FullName + city.Inhabitants);


            var adapter2 = new ClassAdapter.CityAdapter();
            var city2 = adapter2.Getcity();

            Console.WriteLine(city2.FullName + city2.Inhabitants);
            Console.ReadKey();
        }
    }
}

