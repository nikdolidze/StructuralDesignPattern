using Adapter3.Adapter;
using Adapter3.Models;
using System;
using System.Collections.Generic;
// idea there is  that in this case  a client is the code that calls other code.
namespace Adapter3
{
    public class AdapterExample
    {
        public  void ExecuteClient()
        {
            //bag fruit
            var bagOfPeeleableFruit = new List<Ipeelable>();
            //add an orange to the bag of fruit
            bagOfPeeleableFruit.Add(new Orange());
            //add an banana to the bag of fruit
            bagOfPeeleableFruit.Add(new Banana());

            //add an apple to the bag of fruit
            bagOfPeeleableFruit.Add(new SkinableToPeelableAdapter(new Apple()));
            //add an pear to the bag of fruit
            bagOfPeeleableFruit.Add(new SkinableToPeelableAdapter(new Pear()));


            foreach (var item in bagOfPeeleableFruit)
            {
                item.Peel();
            }
        }

    }
}
