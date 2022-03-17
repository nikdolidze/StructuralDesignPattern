using Adapter;
using Adapter2;
using System;
using static Adapter._2proviers.StarWarsCharacterDisplayService;

namespace StucturalDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Adapter2();

            Adapter();

        }


        public async static void Adapter2()
        {
            var fourth = new ImproveAdapterIntroduction.StarWarsCharacterDisplayService(
                               new ImproveAdapterIntroduction.CharacterFileSourceAdapter("People.json", new ImproveAdapterIntroduction
                               .CharacterFileSource()));

            var starWarsCharacterDisplayService = new StarWarsCharacterDisplayService();
            await starWarsCharacterDisplayService.ListCharacters();

            var badPractice = new Adapter._2proviers.StarWarsCharacterDisplayService();
            await badPractice.ListCharacters(CharacterSource.File);


            var adapter = new AdapterIntroduction.StarWarsCharacterDisplayService();
            await adapter.ListCharacters(AdapterIntroduction.CharacterSource.File);




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

