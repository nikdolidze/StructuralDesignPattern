using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter3.Models
{
    public class Apple : ISkinable
    {
        public void Skin()
        {
            Console.WriteLine("Skin a Banana");
        }
    }
}
