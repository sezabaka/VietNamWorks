namespace VietNamWorks.Data.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
