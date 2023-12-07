using System.Collections;
using System.Runtime.InteropServices;
using EksamensOpgaveCheckout.Models;

namespace EksamensOpgaveCheckout;

public abstract class PrisBeregner
{
    // Vi har lagt vores scannedeVarer her
    private List<Vare> _scannedeVarer = new List<Vare>();

    public abstract void Print(double total, List<GrupperedeVarer> varer);

    public abstract void PrintSum(double total, Vare vare);

    // Det her er vores "hoved" metode der køre når en vare skannes ind. Den kan bruges af både billig og dyr prisberegner.
    public void IndskannetVare(Vare vare)
    {
        if (vare == null)
        {

            // Hvis vare == Null dvs scanning er færdig, eller den får et forkert input
            // Så beregner vi den totale pris for alle varene, og returner den med listen af varene i en tuple.
            (double total, List<GrupperedeVarer> result) = BeregnPrisForVarer(_scannedeVarer);
            // Her printer vi resultatet.
            Print(total, result); //  Scanning færdig
        }
        else
        {
            // Vi adder varene til vores scannedeVarer liste
            _scannedeVarer.Add(vare);
            // Her giver vores BeregnPrisForVarer os en tuple tilbage, da vi gerne vil have både totalen og vores vare tilbage i en grupperet liste.
            (double total, List<GrupperedeVarer> result) = BeregnPrisForVarer(_scannedeVarer);
            PrintSum(total, vare);
        }
    }

    
    // returner en tuple.
    // tager imod en liste af varer og beregner prisen.
    public (double totalPris, List<GrupperedeVarer>) BeregnPrisForVarer(List<Vare> scannedeVarer)
    {
        double totalPris = 0;
        // Her gruppere vi varene baseret på deres varekode, som vi laver til hver gruppes "key".
        // Hver gruppe indeholder også en liste af vare (Varer) med denne varekode, og til sidst et "Antal" 
        var grupperedeVarer = scannedeVarer.GroupBy(v => v.VareKode)
            .Select(group => new GrupperedeVarer
            {
                VareKode = group.Key,
                Varer = group.ToList(),
                Antal = group.Count()
            }).ToList();

        foreach (var gruppe in grupperedeVarer)
        {
            // Her har vi tilføjet logic der gør at der gælder at 3 tomater fås for 2's pris.
            if (gruppe.VareKode == 'Z') // Tomat-tilbuddet
            {
                int antalTilNormalPris = gruppe.Antal % 3;
                int antalTilTilbudspris = gruppe.Antal / 3 * 2;
                double prisen = (antalTilNormalPris + antalTilTilbudspris) * gruppe.EnkeltVarePris;
                gruppe.SamletVarePris += prisen;
                totalPris += prisen;
            }
            else
            {
                gruppe.SamletVarePris += gruppe.EnkeltVarePris * gruppe.Antal;
                totalPris += gruppe.Varer.Sum(v => v.Pris);
            }
        }

        return (totalPris, grupperedeVarer);
    }
}