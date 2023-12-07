using System.Collections;

namespace EksamensOpgaveCheckout.Models;

public class BilligPrisBeregner : PrisBeregner
{
    
    
    public override void Print(double total, List<GrupperedeVarer> varer)
    {
        Console.WriteLine("\nScanning færdig \n");
    }

    public override void PrintSum(double total, Vare vare)
    {
        Console.WriteLine($"Scannet vare: {vare.Navn}. \n Total pris: {total} kr" );
    }
}