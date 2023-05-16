namespace FitnessTicketApp.Models.Domain
{
    public class BerletTipus
    {
        public Guid Id { get; set; } 

        public string Megnevezes { get; set; }

        public int Ar { get; set; }

        public int HanyNapigErvenyes { get; set; }

        public int HanyBelepesreErvenyes { get; set; }

        public bool Torolve { get; set; }

        public Guid Terem_Id {  get; set; }

        public int Hanyoratol { get; set; }

        public int Hanyoraig { get; set; }

        public int NapontaHanyszorHasznalhato { get; set; }
    }
}
