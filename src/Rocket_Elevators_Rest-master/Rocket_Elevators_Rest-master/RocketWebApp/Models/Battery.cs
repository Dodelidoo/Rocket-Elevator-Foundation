namespace RocketWebApp.Models
{
    public class Battery
    {  
        public long Id { get; set; }
        public string Status { get; set; }
        public long Building_id { get; set; }
        public long Admins_id { get; set; }
        public string AType { get; set; }
        public string Operation_certificate { get; set; }
        public string Informations { get; set; }
        public string Notes { get; set; }
    }
}
