namespace EksamensOpgaveCheckout;

using Models;

public class Scanner
{
    public List<Vare> ScannedeVarer = new();

    public delegate void ScannedItemEventHandler(Vare vare);

    public event ScannedItemEventHandler ScannedItem;


    public void Scan(char vareKode)
    {
        // Simuler en delay
        Thread.Sleep(500);

        // Her tilføjer du logik til at skabe en Vare baseret på vareKode
        Vare vare = FindVareUdfraVarekode(vareKode);
        if (vare != null)
        {
            ScannedeVarer.Add(vare);
            // Her laver vi et check om den vare vi tilføjer er en vare der tilhøre VareGruppe 6, som er pantgruppen
            if (vare.VareGruppe == 6)
            {
                // I så fald tilføjer vi bare en VareKode pant til listen.
                Vare pant = FindVareUdfraVarekode('P');
                ScannedeVarer.Add(pant);
            }
        }


        // Udløs event med den skabte Vare
        ScannedItem?.Invoke(vare);
    }


    public Vare FindVareUdfraVarekode(char vareKode)
    {
        Vare vare = null;
        switch (vareKode)
        {
            case 'A':
                vare = new Vare { Navn = "Mælk", Pris = 10, VareKode = 'A', VareGruppe = 1 };
                break;
            case 'B':
                vare = new Vare { Navn = "Toastbrød", Pris = 12, VareKode = 'B', VareGruppe = 5 };
                break;
            case 'C':
                vare = new Vare { Navn = "Rugbrød", Pris = 14, VareKode = 'C', VareGruppe = 5 };
                break;
            case 'D':
                vare = new Vare { Navn = "Tyggegummi", Pris = 5, VareKode = 'D', VareGruppe = 5 };
                break;
            case 'E':
                vare = new Vare { Navn = "Cola", Pris = 7, VareKode = 'E', VareGruppe = 6 };
                break;
            case 'F':
                vare = new Vare { Navn = "Havregryn", Pris = 10, VareKode = 'F', VareGruppe = 5 };
                break;
            case 'G':
                vare = new Vare { Navn = "Øl", Pris = 8, VareKode = 'G', VareGruppe = 6 };
                break;
            case 'H':
                vare = new Vare { Navn = "Ris", Pris = 20, VareKode = 'H', VareGruppe = 5 };
                break;
            case 'I':
                vare = new Vare { Navn = "Pasta", Pris = 12, VareKode = 'I', VareGruppe = 5 };
                break;
            case 'J':
                vare = new Vare { Navn = "Tandpasta", Pris = 20, VareKode = 'J', VareGruppe = 8 };
                break;
            case 'K':
                vare = new Vare { Navn = "Hakkekød", Pris = 30, VareKode = 'K', VareGruppe = 2 };
                break;
            case 'L':
                vare = new Vare { Navn = "Svinekød", Pris = 20, VareKode = 'L', VareGruppe = 2 };
                break;
            case 'M':
                vare = new Vare { Navn = "Kylling", Pris = 25, VareKode = 'M', VareGruppe = 2 };
                break;
            case 'N':
                vare = new Vare { Navn = "Agurk", Pris = 9, VareKode = 'N', VareGruppe = 3 };
                break;
            case 'O':
                vare = new Vare { Navn = "Gulerod", Pris = 10, VareKode = 'O', VareGruppe = 3 };
                break;
            case 'P':
                vare = new Vare { Navn = "Pant", Pris = 1, VareKode = 'P', VareGruppe = 9 };
                break;
            case 'Q':
                vare = new Vare { Navn = "Kødpålæg", Pris = 15, VareKode = 'Q', VareGruppe = 2 };
                break;
            case 'R':
                vare = new Vare { Navn = "3 x Kødpålæg", Pris = 40, VareKode = 'R', VareGruppe = 2 };
                break;
            case 'S':
                vare = new Vare { Navn = "Tandbørste", Pris = 20, VareKode = 'S', VareGruppe = 8 };
                break;
            case 'T':
                vare = new Vare { Navn = "3 x Tandbørste", Pris = 55, VareKode = 'T', VareGruppe = 8 };
                break;
            case 'U':
                vare = new Vare { Navn = "Tun", Pris = 10, VareKode = 'U', VareGruppe = 2 };
                break;
            case 'V':
                vare = new Vare { Navn = "Mango", Pris = 8, VareKode = 'V', VareGruppe = 4 };
                break;
            case 'X':
                vare = new Vare { Navn = "Hytteost", Pris = 18, VareKode = 'X', VareGruppe = 1 };
                break;
            case 'Y':
                vare = new Vare { Navn = "Wokblanding", Pris = 12, VareKode = 'Y', VareGruppe = 3 };
                break;
            case 'Z':
                vare = new Vare { Navn = "Tomat", Pris = 3, VareKode = 'Z', VareGruppe = 3 };
                break;
            default:
                Console.WriteLine("Ukendt varekode");
                break;
        }

        return vare;
    }
}