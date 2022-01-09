using ConsoleApp1.Services;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            do
            {
                Console.WriteLine("      ==============================  * __ MY LIBRARY __ *  ============================== \n");
                Console.WriteLine(" 1 -> Kitablarin siyahisinin gosterilmesi");
                Console.WriteLine(" 2 -> Kitablarin elave edilmesi");
                Console.WriteLine(" 3 -> Kitablarin gosterilmesi");
                Console.WriteLine(" 4 -> Kitablarin ada gore silinmesi");
                Console.WriteLine(" 5 -> Kitablarin search edilmesi");
                Console.WriteLine(" 6 -> Kitablarin sehife araligina gore tapilmasi");
                Console.WriteLine(" 7 -> Kitablarin nomresine gore silinmesi");
                Console.WriteLine(" 8 -> Sistemden cixis");
                Console.Write("Daxil edin :  ");
                string Choose = Console.ReadLine();
                int ChooseNum;
                if(int.TryParse(Choose,out ChooseNum))
                {
                    switch (ChooseNum)
                    {
                        case 1:
                            Console.Clear();
                            MainMethod(ref library, ShowBooks);
                            break;
                        case 2:
                            Console.Clear();
                            AddBook(ref library);
                            break;
                        case 3:
                            Console.Clear();
                            MainMethod(ref library, FindAllBooksByName);
                            break;
                        case 4:
                            Console.Clear();
                            MainMethod(ref library, RemoveAllBookByName);
                            break;
                        case 5:
                            Console.Clear();
                            MainMethod(ref library, SearchBooks);
                            break;
                        case 6:
                            Console.Clear();
                            MainMethod(ref library, FindAllBooksByPageCountRange);
                            break;
                        case 7:
                            Console.Clear();
                            MainMethod(ref library, RemoveByNo);
                            break;
                        case 8:
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("*** Duzgun reqem daxil edin : ***");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("*** Duzgun deyer gonderin : ***");
                }
                
            } while(true);
        }

        delegate void Check(ref Library library);
        static void MainMethod(ref Library library, Check check)
        {
            if (library.books.Count > 0)
            {
                check(ref library);
            }
            else
            {
                Console.WriteLine("*** Hec bir kitab elave edilmeyib.Ilk once kitab elave edin. ***");
                return;
            }
        }


        static void ShowBooks(ref Library library)
        {
            Console.WriteLine("Movcud kitablarin siyahisi : \n");
            for (int i = 0; i < library.books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {library.books[i]}");
            }
        }
        static void AddBook(ref Library library)
        {
            //Name of book--->
            Console.WriteLine("Elave etmek istediyiniz kitabin adin daxil edin :");
            CheckName:
            string name = Console.ReadLine().Trim();
            if(name.Length < 2)
            {
                Console.WriteLine("*** Kitabin adinin uzunlugu 2-den az ola bilmez ***");
                goto CheckName;
            }
            //Authorname of book--->
            Console.WriteLine("Elave etmek istediyiniz kitabin muellifini daxil edin :");
            CheckAuthorName:
            string authorname = Console.ReadLine().Trim();
            if(authorname.Split(' ').Length < 2)
            {
                Console.WriteLine("*** Muellifin hem adini hem de soyadini daxil edin ***");
                goto CheckAuthorName;
            }
            //Pagecount of book--->
            Console.WriteLine("Kitabin sehife sayini daxil edin :");
            CheckPageCount:
            string pagecountName = Console.ReadLine().Trim();
            int pagecount;
            if(!int.TryParse(pagecountName, out pagecount) || pagecount < 2)
            {
                Console.WriteLine("*** Sehife sayi 2-den az ola blmez.Sehife sayini duzgun daxil edin : ***");
                goto CheckPageCount;
            }
            //Result--->
            Console.WriteLine($"\n*** \"{name}\" adli kitab ugurla elave edildi ***");
            library.books.Add(new Book(name, authorname, pagecount));
        }
        static void FindAllBooksByName(ref Library library)
        {
            Console.WriteLine("Gormek istediyiniz kitablarda olan ad daxil edin");
            string name = Console.ReadLine().Trim();
            if(name.Length < 2)
            {
                Console.WriteLine("*** Kitabin adinin uzunlugu 2-den az ola bilmez ***");
                return;
            }
            int count = 0;
            foreach (Book item in library.books)
            {
                if (item.Name.ToLower().Contains(name.ToLower()))
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("*** Daxil etdiyniz adda kitab tapilmadi ***");
                return;
            }
            else
            {
                foreach (Book item in library.FindAllBooksByName(name))
                {
                    Console.WriteLine(item);
                }
            }
        }
        static void RemoveAllBookByName(ref Library library)
        {
            ShowBooks(ref library);
            Console.WriteLine("Silmek istediyiniz kitabi adini daxil edin :");
            string name = Console.ReadLine().Trim();
            if (name.Length < 2)
            {
                Console.WriteLine("*** Kitabin adinin uzunlugu 2-den az ola bilmez ***");
                return;
            }
            int count = 0;
            foreach (Book item in library.books)
            {
                if (item.Name.ToLower().Contains(name.ToLower()))
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("*** Daxil etdiyniz adda kitab yoxdur ***");
                return;
            }
            Console.WriteLine($"\n*** Adinda \"{name}\" olan kitablar ugurla silindi ***");
            library.RemoveAllBookByName(name);

        }
        static void SearchBooks(ref Library library)
        {
            Console.WriteLine("Gormek istediyiniz kitablarin adini,muellifini ve ya sehife sayini daxil edin : ");
            string name = Console.ReadLine().Trim();
            if (name.Length < 2)
            {
                Console.WriteLine("*** Kitabin adinin uzunlugu 2-den az ola bilmez ***");
                return;
            }
            int count = 0;
            foreach (Book item in library.books)
            {
                if (item.Name.ToLower().Contains(name.ToLower()) || item.AuthorName.ToLower().Contains(name.ToLower()) || name.ToLower() == item.PageCount.ToString().ToLower())
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("*** Daxil etdiyniz deyerde kitab yoxdur ***");
                return;
            }
            else
            {
                foreach (Book item in library.SearchBooks(name))
                {
                    Console.WriteLine(item);
                }
            }
        }
        static void FindAllBooksByPageCountRange(ref Library library)
        {
            //Checking min value--->
            Console.WriteLine("Gormek istediyiniz kitablarin sehifesinin minimum deyerini daxil edin :");
        CheckMin:
            string minName = Console.ReadLine().Trim();
            int min;
            if (!int.TryParse(minName, out min) || min < 1)
            {
                Console.WriteLine("*** Minimum sehife sayini duzgun daxil edin ***");
                goto CheckMin;
            }
            //Checking max value--->
            Console.WriteLine("Gormek istediyiniz kitablarin sehifesinin max deyerini daxil edin :");
        CheckMax:
            string maxName = Console.ReadLine().Trim();
            int max;
            if (!int.TryParse(maxName, out max) || max < 1)
            {
                Console.WriteLine("*** Minimum sehife sayini duzgun daxil edin ***");
                goto CheckMax;
            }
            else if (max < min)
            {
                Console.WriteLine("*** Maksimum deyer minimum deyerden kicik ola bilmez ***");
                goto CheckMax;
            }
            //Result--->
            int count = 0;
            foreach (Book item in library.FindAllBooksByPageCountRange(min, max))
            {
                Console.WriteLine(item);
                count++;
            }
            if (count == 0)
            {
                Console.WriteLine("*** Hec bir kitab tapilmadi ***");
            }
            else
            {
                Console.WriteLine($"*** {count} eded kitab tapildi ***");
            }
        }
        static void RemoveByNo(ref Library library)
        {
            ShowBooks(ref library);
            Console.WriteLine("Silmek istediyniz kitabin nomresini daxil edin :");
            string no = Console.ReadLine().Trim();
            int count = 0;
            foreach (Book item in library.books)
            {
                if (item.No.ToLower().Contains(no.ToLower()))
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("*** Daxil etdiyniz nomreli kitab tapilmadi ***");
                return;
            }
            Console.WriteLine($"\n*** \"{no}\" nomreli kitab ugurla silindi ***");
            library.RemoveByNo(no);
        }
    }
}
