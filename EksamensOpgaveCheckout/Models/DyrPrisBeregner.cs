namespace EksamensOpgaveCheckout.Models;

public class DyrPrisBeregner : PrisBeregner
{
    public override void Print(double total, List<GrupperedeVarer> varer)
    {
        Console.WriteLine("Markus og Benjamin's supermarked");
        Console.WriteLine("Kvittering");

        // Her sortere vi vores grupperede vare efter varegruppe og derefter pris.
        var sorteredeVarer = from vare in varer
            orderby
                vare.VareGruppe,
                vare.EnkeltVarePris
            select vare;


        string vareGruppeNavn = "";
        string pastVareGruppeNavn = "";
        
        foreach (var vare in sorteredeVarer)
        {
            // Her sørger vi for at vores vare bliver viser under deres varegruppe i konsollen.
            vareGruppeNavn = Scanner.FindVareGruppeNavnUdFraVareGruppeNr(vare.VareGruppe);
            if (!vareGruppeNavn.Equals(pastVareGruppeNavn))
            {
                Console.WriteLine("VareGruppe: " + vareGruppeNavn);
            }
            Console.WriteLine($"{vare.Antal} x {vare.VareNavn}. Pris: {vare.SamletVarePris}");
            pastVareGruppeNavn = vareGruppeNavn;
        }

        Console.WriteLine($"I alt: {total} kr.");
    }

    public override void PrintSum(double total, Vare vare)
    {
    }
}