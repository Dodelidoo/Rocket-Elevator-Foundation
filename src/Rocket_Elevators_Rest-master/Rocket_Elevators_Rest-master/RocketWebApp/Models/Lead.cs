using System;

namespace RocketWebApp.Models
{
    public class Lead
    {       
        public long Id { get; set; }
        public int? Customer_id { get; set; }
        public string Full_name { get; set; }
        public string Business_name { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public string Project_name { get; set; }
        public string Project_description { get; set; }
        public string Department_in_charge_of_elevators { get; set; }
        public string Message { get; set; }
        public string Attached_file { get; set; }
        public string File_name { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created_at { get; set; }
    }
}
