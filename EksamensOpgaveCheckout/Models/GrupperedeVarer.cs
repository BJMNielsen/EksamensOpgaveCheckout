namespace EksamensOpgaveCheckout.Models;

public class GrupperedeVarer
{
    public char VareKode { get; set; }

    public string VareNavn
    {
        get
        {
            if (Varer.Count > 0)
            {
                return Varer[0].Navn;
            }

            return "Ukendt Vare";
        }
    }

    public List<Vare> Varer { get; set; }
    public int Antal { get; set; }
}