using Adapter3.Models;

namespace Adapter3.Adapter
{
    public class SkinableToPeelableAdapter : Ipeelable
    {
        private ISkinable Skinable;
        public SkinableToPeelableAdapter(ISkinable skinable)
        {
            this.Skinable = skinable;
        }


        public void Peel()
        {
            Skinable.Skin();
        }
    }
}