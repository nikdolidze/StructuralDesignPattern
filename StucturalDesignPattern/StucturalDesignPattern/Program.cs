using Adapter;
using Adapter2;
using Adapter3;
using Bridge;
using Bridge2;
using Composite;
using Decorator;
using Decorator2;
using System;
using static Adapter._2proviers.StarWarsCharacterDisplayService;
using Facade;
using Proxy;

namespace StucturalDesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {


     



            Console.ReadKey();
            Proxy();
            Facade();
            Composite();
            Decorator2();
            Decorator();
            Bridge2();
            Bridge();
            Adapter3();
            Adapter2();
            Adapter();

        }
        public static void Proxy()
        {
            //without proxy
            Console.WriteLine("Constructing document");
            var myDocument = new Document("myDocumetn.txt");
            Console.WriteLine("Document constuectes");
            myDocument.DisplayDocument();
            Console.WriteLine();

            //with proxy
            Console.WriteLine("Constructing document proxy");
            var myDocumentProxy = new DocumentProxy("myDocumetn.txt");
            Console.WriteLine("Document constuectes");
            myDocumentProxy.DisplayDocument();
            myDocumentProxy.DisplayDocument();
            Console.WriteLine();

            //with chain proxy 
            var myProcetedDocumentProxy = new ProtectedDocumentProxy("nika", "Viewer");
            myProcetedDocumentProxy.DisplayDocument();
        }
        public static void Facade()
        {
            var facade = new DiscoutFacade();
            Console.WriteLine($"Discount percentage for cusomer with id 1  :  {facade.CalculateDiscountPercentage(1)}");
            Console.WriteLine($"Discount percentage for cusomer with id 10  :  {facade.CalculateDiscountPercentage(10)}");
            facade.CalculateDiscountPercentage(8);

        }
        public static void Composite()
        {
            var root = new Directory("root", 0);
            var topLeaveFile = new File("toplevel.txt", 100);
            var topLeveldirectory1 = new Directory("topLeveldirectory1", 4);
            var topLeveldirectory2 = new Directory("topLeveldirectory2", 4);

            root.Add(topLeaveFile);
            root.Add(topLeveldirectory1);
            root.Add(topLeveldirectory2);

            var sublevelfile = new File("SublevelFile1", 200);
            var sublevelfile2 = new File("SublevelFile2", 150);
            topLeveldirectory2.Add(sublevelfile);
            topLeveldirectory2.Add(sublevelfile2);

            Console.WriteLine($"Size of topLevelDirectory1: {topLeveldirectory1.GetSize()}");
            Console.WriteLine($"Size of topLevelDirectory2: {topLeveldirectory2.GetSize()}");
            Console.WriteLine($"Size of root: {root.GetSize()}");
        }

        public static void Decorator2()
        {
            var regularOrder = new RegularOrder();
            Console.WriteLine(regularOrder.CalculateTotalOrderPrice());
            Console.WriteLine();
            var preOrder = new Preorder();
            Console.WriteLine(preOrder.CalculateTotalOrderPrice());
            Console.WriteLine();
            var premiumPreorder = new PremiumPreorder(preOrder);
            Console.WriteLine(premiumPreorder.CalculateTotalOrderPrice());


        }

        public static void Decorator()
        {
            var cloudeService = new CloudMainServer();
            cloudeService.SendMail("nika");

            var onPremiseMainService = new OnPremiseMainService();
            onPremiseMainService.SendMail("dolidze");

            // add behaviour
            var statisticDecorator = new StatisticsDecorator(cloudeService);
            statisticDecorator.SendMail("nika");

            var databaseDecorator = new MessageDatabaseDecorator(onPremiseMainService);
            databaseDecorator.SendMail("dolidze");

            foreach (var item in databaseDecorator.SentMessages)
            {
                Console.WriteLine(item);
            }
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

