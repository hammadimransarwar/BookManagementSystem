using BookManagementSystem;
using System;
class Program
{
    static void Main(string[] args)
    {
        BookDataAccess b = new BookDataAccess();
        Console.WriteLine("Welcome to the Book Management System!");
        bool isExit = false;
        while (!isExit)
        {
            DisplayMenu();
            Console.WriteLine("Enter your choice:");
            string? choice = Console.ReadLine();
            if (choice == "1")
            {
                add_book(b);
            }
            else if (choice == "2")
            {
                view_book(b);
            }
            else if (choice == "3")
            {
                find_book_by_id(b);
            }
            else if (choice == "4")
            {
                create_backup(b);
            }
            else if (choice == "5")
            {
                isExit = true;
                Console.WriteLine("Exiting the program. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
    static void DisplayMenu()
    {
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. View All Books");
        Console.WriteLine("3. Find Book by ID");
        Console.WriteLine("4. Create Backup");
        Console.WriteLine("5. Exit");
    }
    static void add_book(BookDataAccess b)
    {
        Console.WriteLine("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Book Title: ");
        string? title = Console.ReadLine();
        Console.WriteLine("Enter Book Author: ");
        string? author = Console.ReadLine();
        Console.WriteLine("Enter Book Price: ");
        double price = double.Parse(Console.ReadLine());
        Book b1=new Book(id, title, author, price);
        b.AddBook(b1);
    }
    static void view_book(BookDataAccess b)
    {
        List<Book> books = b.View_All_Book();
        for(int i = 0; i < books.Count; i++)
            books[i].DisplayInfo();        
    }
    static void find_book_by_id(BookDataAccess b)
    {
        b.Find_Book_by_ID();
    }
    static void create_backup(BookDataAccess b)
    {
        b.Create_Backup();
    }

}   