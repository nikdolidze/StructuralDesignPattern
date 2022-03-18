using Adapter;
using Adapter2;
using Adapter3;
using System;
using System.Collections.Generic;
using static Adapter._2proviers.StarWarsCharacterDisplayService;

namespace StucturalDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Adapter3();

            Adapter2();

            Adapter();

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

