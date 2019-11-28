using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            File f1 = new File(3);
            File f2 = new File(4);
            File f3 = new File(5);
            Console.WriteLine("F1 - {0}, F2 - {1}, F3 - {2}", f1.Size(), f2.Size(), f3.Size());
            Folder fl1 = new Folder();
            fl1.Add(f1);
            fl1.Add(f2);
            fl1.Add(f3);
            Console.WriteLine("Size Folder1 = {0}", fl1.Size());
            fl1.Remove(f1);
            Console.WriteLine("File1 was deleted!");
            Console.WriteLine("Size Folder1 = {0}", fl1.Size());
            Console.ReadKey();
        }
    }
    abstract class FSElement
    {
        public abstract int Size();
 
    }
    class File:FSElement
    {
        int size;
        public File(int s) { size = s; }
        public override int Size() {
            return size; }

    }
    class Folder:FSElement
    {
        private List<FSElement> elements;
        public Folder()
        {
            elements = new List<FSElement>();
        }
        public void Add(FSElement fse)
        {
            elements.Add(fse);
        }
        public void Remove(FSElement fse)
        {
            elements.Remove(fse);
        }
        public override int Size()
        {
            int s = 0;
            foreach (FSElement fse in elements)
                s += fse.Size();
            return s;
        }

    }
}
