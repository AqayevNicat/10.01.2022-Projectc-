using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Book
    {
        public static int Count = 0;
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }
        public string No { get; set; }

        public Book(string name, string authorname, int pagecount)
        {
            Name = name;
            AuthorName = authorname;
            PageCount = pagecount;
            Count++;
            No = name.Substring(0, 2).ToUpper() + Count;
        }
        public override string ToString()
        {
            return $"Kitabin No : {No}\n" +
                $"Kitabin Adi : {Name}\n" +
                $"Yazici : {AuthorName}\n" +
                $"Sehife sayi : {PageCount}\n-----------------------";
        }
    }
}
