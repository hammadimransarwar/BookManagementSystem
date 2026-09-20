using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace BookManagementSystem
{
    internal class BookDataAccess
    {
        public void AddBook(Book book)
        {
            FileStream fs = new FileStream("books.txt",FileMode.Append);
            StreamWriter fw=new StreamWriter(fs);
            string line = $"{book.Id}, {book.Title}, {book.Author}, {book.Price}";
            fw.WriteLine(line);
            fw.Close();
            fs.Close();
        }
        public List<Book> View_All_Book()
        {
            List<Book> Books_all=new List<Book>();
            FileStream fs = new FileStream("books.txt", FileMode.Open);
            StreamReader fr = new StreamReader(fs);
            String? line = fr.ReadLine();
            if (line == null)
                Console.WriteLine("No Books Found.");
            while (line != null)
            {
                String[] bookDetails = line.Split(',');
                bookDetails[0] = bookDetails[0].Trim();
                bookDetails[1] = bookDetails[1].Trim();
                bookDetails[2] = bookDetails[2].Trim();
                bookDetails[3] = bookDetails[3].Trim();
                Book b1 = new Book(int.Parse(bookDetails[0]), bookDetails[1], bookDetails[2], double.Parse(bookDetails[3]));
                Books_all.Add(b1);
                line = fr.ReadLine();
            }
            fr.Close();
            fs.Close();
            return Books_all;

        }
        public void Find_Book_by_ID()
        {
            Console.WriteLine("Enter Book ID to search:");
            String? id = Console.ReadLine();
            List<Book> Books_all = View_All_Book();
            for(int i = 0; i < Books_all.Count; i++)
            {
                if (id!=null && Books_all[i].Id == int.Parse(id))
                {
                    Books_all[i].DisplayInfo();
                    return;
                }
            }
            Console.WriteLine("Book not found.");
        }
        public void Create_Backup()
        {
            FileStream fr = new FileStream("books.txt", FileMode.Open);
            FileStream fw=new FileStream("books_backup.txt", FileMode.Create);
            int val = fr.ReadByte();
            if (val == -1)
            {
                Console.WriteLine("No data for Backup");
                return;
            }
            while (val != -1)
            {
                fw.WriteByte((byte)val);
                val = fr.ReadByte();
            }
            Console.WriteLine("Backup created successfully");
            fr.Close();
            fw.Close();

        }
    }
}
