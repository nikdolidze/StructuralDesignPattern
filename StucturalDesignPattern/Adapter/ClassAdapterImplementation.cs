using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAdapter
{
    public class CityFromExternalSystem
    {
        public string Name { get; private set; }
        public string NickName { get; private set; }
        public int Inhabitans { get; private set; }

        public CityFromExternalSystem(string name, string nickName, int inhabitans)
        {
            Name = name;
            NickName = nickName;
            Inhabitans = inhabitans;
        }
    }

    /// Adaptee
    public class ExternalSystem
    {
        public CityFromExternalSystem Getcity()
        {
            return new CityFromExternalSystem("nika", "dolidze", 1);
        }
    }

    public class City
    {
        public string FullName { get; set; }
        public long Inhabitants { get; set; }

        public City(string fullName, long inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }
    }

    /// Target
    public interface ICityAdapter
    {
        City Getcity();
    }
    //Adapter
    public class CityAdapter : ExternalSystem,ICityAdapter
    {
        public City Getcity()
        {
            var cityFromExternalSystem = base.Getcity();

            return new City($"{cityFromExternalSystem.Name}-{cityFromExternalSystem.NickName}", cityFromExternalSystem.Inhabitans);
        }
    }
}
