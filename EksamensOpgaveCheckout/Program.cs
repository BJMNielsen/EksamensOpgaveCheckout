// See https://aka.ms/new-console-template for more information

using EksamensOpgaveCheckout;
using EksamensOpgaveCheckout.Models;

Console.WriteLine("Hej");

Scanner scanner = new Scanner();
BilligPrisBeregner billigPrisBeregner = new BilligPrisBeregner();

scanner.ScannedItem += billigPrisBeregner.BeregnPris;
//scanner.ScannedItem += dyrePrisBeregner.BeregnPris

scanner.Scan('A');
scanner.Scan('B');
scanner.Scan('#');

/*
S += scanner.Scan('A');
scanner.ScannedItem += scanner.Scan('Z');
List<Vare> scannedeVarer = scanner.ScannedeVarer;
scanner.ScannedItem += billigPrisBeregner.BeregnPris(scannedeVarer);

*/