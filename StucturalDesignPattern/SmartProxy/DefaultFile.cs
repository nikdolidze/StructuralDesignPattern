using System.IO;

namespace SmartProxy
{
    public class DefaultFile : IFile
    {
        public FileStream OpenWrite(string path)
        {
            return File.OpenWrite(path);
        }
    }
}
