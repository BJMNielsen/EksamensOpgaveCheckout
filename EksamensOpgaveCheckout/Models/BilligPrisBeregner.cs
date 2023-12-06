using System.Collections;

namespace EksamensOpgaveCheckout.Models;

public class BilligPrisBeregner : PrisBeregner
{
    

    private List<Vare> scannedeVarer = new List<Vare>();
    // Antag dette er i PrisBeregner.cs eller i en af de specifikke prisberegnere

    public void BeregnPris(Vare vare)
    {
        if (vare == null)
        {
            Console.WriteLine("Scanning færdig");
            //færdig
            // her skal dyre beregner være
            BeregnPris(scannedeVarer);
        }
        else
        {
            scannedeVarer.Add(vare);
        }
    }
    

    public void BeregnPris(List<Vare> scannedeVarer)
    {
        BeregnPrisForVarer(this.scannedeVarer);

        Console.WriteLine($"Samlet pris: {TotalPris} kr.");
    }

}