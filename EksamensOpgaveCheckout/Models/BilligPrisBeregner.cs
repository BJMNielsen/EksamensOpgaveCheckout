using System.Collections;

namespace EksamensOpgaveCheckout.Models;

public class BilligPrisBeregner : PrisBeregner
{
    public override void Print(double total, List<GrupperedeVarer> varer)
    {
        Console.WriteLine("Sum: " + total);
    }
    
}