using System;
using System.Collections.Generic;
/*
This is a pattern that uses sharing to support large numbers of fine-grained objects efficiently.THe intent of this pattern is to use sharing to support large number of fine-grainded objects efficiently.
it does that by sharing parts of the state between these objects instead of keeping all that state in all of the objects.
*/
namespace FlyWeight
{
    /// <summary>
    /// Flywigth
    /// </summary>
    public interface ICharacter
    {

        void Draw(string fontFamily,int fontSize);  
    }
    /// <summary>
    ///     Concraete Flyweigth
    /// </summary>
    public class CharacterA : ICharacter
    {
        private char _actualCharacter = 'a';                    //intrinsic
        private string _fontFamily = string.Empty;              //extrinsic  these can be changed and changing that is done via the draw method
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;

            Console.WriteLine($"Drawing {_actualCharacter}, {fontFamily}, {_fontSize}");

        }
    }

    public class CharacterB : ICharacter
    {
        private char _actualCharacter = 'b';                    //intrinsic
        private string _fontFamily = string.Empty;              //extrinsic  these can be changed and changing that is done via the draw method
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;

            Console.WriteLine($"Drawing {_actualCharacter}, {fontFamily}, {_fontSize}");

        }
    }
    /// <summary>
    ///     FlyweightFactory
    /// </summary>
    public class CharacterFactory
    {
        private readonly Dictionary<char, ICharacter> _characters = new();
        public ICharacter GetCharacter(char characterIdentifier)
        {
            if (_characters.ContainsKey(characterIdentifier))
            {
                Console.WriteLine("Character Reuse");
                return _characters[characterIdentifier];
            }
            Console.WriteLine("Caracter construction");
            switch (characterIdentifier)
            {
                case 'a':
                    _characters[characterIdentifier]= new CharacterA();
                    return _characters[characterIdentifier];
                    case 'b':
                    _characters[characterIdentifier] =new CharacterB();
                    return _characters[characterIdentifier];
            }
            return null;
        }
        public  ICharacter CraeteParagrahp(List<ICharacter>  characters,int location)
        {
            return new Paragraph(characters, location); 
        }

    }

    public class Paragraph : ICharacter
    {
        private int _location;
        private List<ICharacter> _characters = new();
        public Paragraph(List<ICharacter> characters,int location)
        {
            this._location = location;
            this._characters = characters;
        }

        public void Draw(string fontFamily, int fontSize)
        {
            Console.WriteLine($"Drawing in parahraph at location {_location}");
            foreach (var item in _characters)
            {
                item.Draw(fontFamily, fontSize);
            }
        }
    }
}
