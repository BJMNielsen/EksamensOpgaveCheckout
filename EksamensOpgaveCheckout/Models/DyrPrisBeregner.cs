namespace EksamensOpgaveCheckout.Models;

public class DyrPrisBeregner : PrisBeregner
{
    public override void Print(double total, List<GrupperedeVarer> varer)
    {
        foreach (var v in varer)
        {
          Console.WriteLine("skriv for denne linie");  
        }
        Console.WriteLine("Ialt " + total);
    }

}