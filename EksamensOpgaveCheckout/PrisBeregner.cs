using System.Collections;
using System.Runtime.InteropServices;
using EksamensOpgaveCheckout.Models;

namespace EksamensOpgaveCheckout;

public abstract class PrisBeregner
{
    
    private List<Vare> scannedeVarer = new List<Vare>();

    
    public void IndskannetVare(Vare vare)
    {
        if (vare == null)
        {
            Console.WriteLine("Scanning færdig");
            //færdig
            // her skal dyre beregner være
            (double total, List<GrupperedeVarer> result) = BeregnPrisForVarer(scannedeVarer);
            Print(total, result);
        }
        else
        {
            scannedeVarer.Add(vare);
        }
    }
    
    public abstract void Print(double total, List<GrupperedeVarer> varer);


    public (double totalPris, List<GrupperedeVarer>) BeregnPrisForVarer(List<Vare> scannedeVarer)
    {
        double TotalPris = 0;
        var grupperedeVarer = scannedeVarer.GroupBy(v => v.VareKode)
            .Select(group => new GrupperedeVarer
            {
                VareKode = group.Key,
                Varer = group.ToList(),
                Antal = group.Count()
            }).ToList();

        foreach (var gruppe in grupperedeVarer)
        {
            double samletPris = 0;
            if (gruppe.VareKode == 'Z') // Tomat-tilbuddet
            {
                int antalTilNormalPris = gruppe.Antal % 3;
                int antalTilTilbudspris = gruppe.Antal / 3 * 2;
                double prisen = (antalTilNormalPris + antalTilTilbudspris) * gruppe.Varer[0].Pris;
                TotalPris += prisen;
            }
            else
            {
                TotalPris += gruppe.Varer.Sum(v => v.Pris);
            }
            
        }
        
        return (TotalPris, grupperedeVarer);
    }
}