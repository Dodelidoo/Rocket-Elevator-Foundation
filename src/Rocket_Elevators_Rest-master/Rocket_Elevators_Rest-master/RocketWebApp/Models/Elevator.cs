namespace RocketWebApp.Models
{
    public class Elevator
    {        
        public long Id { get; set; }
        public long Column_id { get; set; }
        public string Status { get; set; }
        public int Serial_number { get; set; }
        public string Model { get; set; }
        public string aType { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public string Inspection_certificate { get; set; }
        public string Installation_date { get; set; }
        public string Last_inspection_date { get; set; }
    }

    public class ElevatorBasic
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public int Serial_number { get; set; }
    }
}
