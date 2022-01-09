using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Services
{
    class Library
    {
        public List<Book> books = new List<Book>();
        public List<Book> FindAllBooksByName(string name)
        {
             return books.FindAll(book => book.Name.ToLower().Contains(name.ToLower()));
        }
        public void RemoveAllBookByName(string name)
        {
            books.RemoveAll(b => b.Name.ToLower().Contains(name.ToLower()));
        }
        public List<Book> SearchBooks(string name)
        {
            name = name.ToLower();
             return books.FindAll(b => b.Name.ToLower().Contains(name) || b.AuthorName.Contains(name) || name.Equals(b.PageCount.ToString()));
        }
        public List<Book> FindAllBooksByPageCountRange(int min,int max)
        {
            return books.FindAll(b => b.PageCount >= min && b.PageCount <=max);
        }
        public void RemoveByNo(string no)
        {
            books.Remove(books.Find(b => b.No.ToLower() == no.ToLower()));
        }
    }
}
