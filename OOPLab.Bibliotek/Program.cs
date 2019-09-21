using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab.Bibliotek
{
    class Program
    {
        static void Main(string[] args)
        {
            /*4. Biblioteket
                 Vi ska skapa ett bibliotekssystem. För att hantera utlåningar. Tänk er att vi har ett library. Som har ett antal books
              1. Skapa en klass Library Denna kanske behöver en array(List<>?)  med böcker En funktion för att AddBookToLibrary (kolla om titel redan finns. Isåfall plussa på antal för den! - annars skapa ny) En funktion för att BorrowBook En funktion för att ReturnBook
              2. Skapa en klass Book Funktioner kanske Borrow – låna ut om den finns inne GetCountInLibrary – hur många ex som finns inne  
                 GetBorrowedCount – hur många ex som är utlånade
                 Title TotalCount BorrowedCount 
              3. Skapa en MENY som a. Skapa ny bok b. Lånar ut bok (på titel) c. Lämnar tillbaka bok (på titel)*/

            var library = new Library();

            while (true)
            {
                Console.WriteLine("a. Skapa ny Bok");
                Console.WriteLine("b. Lånar ut bok (på titel)");
                Console.WriteLine("c. Lämnar tillbaka (på titel)");
                var input = Console.ReadLine();
                if (input == "a")// lägg till boken i books
                {
                    
                    Console.Write("Skapa Bok: ");
                    var inputBok = Console.ReadLine();
                    library.AddBookToLibrary(inputBok);

                    Console.WriteLine("Du har skapat boken");

                }
                else if (input == "b") // ta bort boken i books och lägg till i borrowedBooks
                {
                    Console.Write("Skriv bok att låna: ");
                    var bookToBorrow = Console.ReadLine();
                    if (library.BorrowBook(bookToBorrow) == null)
                    {
                        Console.WriteLine("Boken finns inte!");
                    }
                    else
                    {
                        Console.WriteLine($"Du har lånat boken!  Utlånade ex: {library.BorrowedCount(bookToBorrow)} Ex som finns att låna: {library.BookCount(bookToBorrow)}");
                        Console.ReadLine();
                    }
                    
                    
                }
                else if (input == "c") // tabort boken i borrowedbooks och lägg till bok i books
                {
                    Console.Write("Skriv bok att lämna tillbaka: ");
                    var bookToReturn = Console.ReadLine();
                    if (library.ReturnBook(bookToReturn))
                    {
                        Console.WriteLine("Boken är lämnad!");
                    }
                    else
                    {
                        Console.WriteLine("Något gick fel!");
                    }

                    
                    




                }
          
                
            }

        }
    }
}
