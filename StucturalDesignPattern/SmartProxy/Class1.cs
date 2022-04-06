using System;
using System.IO;

namespace SmartProxy
{
    public interface IFile
    {
        FileStream OpenWrite(string path);
    }
}
