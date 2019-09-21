using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab.Bibliotek
{
    class Library
    {

        private Dictionary<string, int> books;

        private Dictionary<string, int> borrowedBooks;

        

        public Library()
        {
            books = new Dictionary<string, int>();
            borrowedBooks = new Dictionary<string, int>();
        }
        public void AddBookToLibrary(string newBook)
        {
            if (books.TryGetValue(newBook,out _))
            {
                int booksCount = books[newBook];
                books.Remove(newBook);
                books.Add(newBook, ++booksCount);
            }
            else
            {
                borrowedBooks.Add(newBook, 0);
                books.Add(newBook, 1);
            } 
        }
        public Book BorrowBook(string borrowBook)
        {
            if (books.TryGetValue(borrowBook, out _))
            {
                var booksCount = books[borrowBook];
                var borrowedCount = borrowedBooks[borrowBook];

                books.Remove(borrowBook);
                books.Add(borrowBook, --booksCount);
                borrowedBooks.Remove(borrowBook);
                borrowedBooks.Add(borrowBook, ++borrowedCount);

                return new Book { Titel = borrowBook };
            }
            else
            {
                return null;
            }
        }
        public bool ReturnBook(string bookToReturn)
        {

            if (borrowedBooks.TryGetValue(bookToReturn, out _))
            {
                var borrowedCount = borrowedBooks[bookToReturn];
                var booksCount = books[bookToReturn];

                if (borrowedCount > 0)
                {
                    borrowedBooks.Remove(bookToReturn);
                    borrowedBooks.Add(bookToReturn, --borrowedCount);
                    books.Remove(bookToReturn);
                    books.Add(bookToReturn, ++booksCount);
                    return true;

                }
                else
                {
                    return false;
                }
   
            }
            else
            {
                return false;
            }
            
        }
        public int BorrowedCount(string titel)
        {
            if (borrowedBooks.TryGetValue(titel, out _))
            {
                return borrowedBooks[titel];
                
            }
            else
            {
                return 0;
            }
           
        }
        public int BookCount(string titel)
        {
            if (books.TryGetValue(titel, out _))
            {
                var booksCount = books[titel];
                return booksCount;
            }
            else
            {
                return 0;
            }

        }
        
    }
}
