using System;
using System.Collections.Generic;
using System.Linq;
/*
Composite pattern takes  advantage of recursion and is often used when your data resembles  a tree-like structure.The intent of this pattern is to compose object into tree structures to represent part-whole 
hierarchies. As such, it lets clients treat individual object  and compositions of objects uniformaly: as if they all were individual objects.
Component declares the interface for object on the compositions  and contains a common operations.
*/
namespace Composite
{/// <summary>
/// Component
/// </summary>
    public abstract class FileSystemItem
    {
        public string Name { get; set; }
        public abstract long GetSize();
        public FileSystemItem(string name)
        {
            Name = name;
        }
    }
    /// <summary>
    ///     Leaf
    /// </summary>
    public class File : FileSystemItem
    {
        private long _size;
        public File(string name, long size) : base(name) => _size = size;
        public override long GetSize() => _size;
    }

    public class Directory : FileSystemItem
    {
        private List<FileSystemItem> _directories = new List<FileSystemItem>();
        public void Add(FileSystemItem item)=>_directories.Add(item);
        public void Remove(FileSystemItem item)=>_directories.Remove(item);
        private long _size;
        public Directory(string name, long size) : base(name) => _size = size;
        public override long GetSize()
        {
           var treesize = _size;

            foreach (var fileSystemItem in _directories)
            {
                treesize += fileSystemItem.GetSize();
            }
            return treesize;
        }
    }
}
