using System.Collections;
using EksamensOpgaveCheckout.Models;

namespace EksamensOpgaveCheckout;

public class PrisBeregner
{
    public double TotalPris;
    
    public List<GrupperedeVarer> BeregnPrisForVarer(List<Vare> scannedeVarer)
    {
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
            Console.WriteLine($"Gruppe {gruppe.VareKode} {gruppe.Antal} {gruppe.Varer[0].Pris}");
        }
        Console.WriteLine($"TotalPris {TotalPris}");
        return grupperedeVarer;
    }
}