namespace EksamensOpgaveCheckout.Models;

public class GrupperedeVarer
{
    public char VareKode { get; set; }
    public double SamletVarePris { get; set; }

    public int VareGruppe
    {
        get
        {
            if (Varer.Count > 0)
            {
                return Varer[0].VareGruppe;
            }

            return 0;
        }
    }

    public double EnkeltVarePris
    {
        get
        {
            if (Varer.Count > 0)
            {
                return Varer[0].Pris;
            }

            return 0;
        }
    }

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