// See https://aka.ms/new-console-template for more information

using EksamensOpgaveCheckout;
using EksamensOpgaveCheckout.Models;

Console.WriteLine("Velkommen til Supermarkedsterminalen. Begynd at scan varer:");

BilligPrisBeregner billigPrisBeregner = new BilligPrisBeregner();
DyrPrisBeregner dyrPrisBeregner = new DyrPrisBeregner();

Scanner scanner = new Scanner();

// Først kører dette event metoden Indskannetvare i billig prisberegner, indtil vi "afslutter" scanningen.
// Viser os den scannede varer og totalprisen indtil videre.
scanner.ScannedItem += billigPrisBeregner.IndskannetVare;
// Herefter køre eventet Indskannetvare i den dyre prisberegner, der viser vores bon.
scanner.ScannedItem += dyrPrisBeregner.IndskannetVare;




while (scanner.StillScanning)
{
    Console.Write("Skriv varekode der skal scannes: ");
    var userInput = Console.ReadLine();
    scanner.Scan(userInput.ToUpper().ToCharArray()[0]);
}


