using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter3.Models
{
    public class Pear : ISkinable
    {
        public void Skin()
        {
            Console.WriteLine("Skin a pear");
        }
    }
}
