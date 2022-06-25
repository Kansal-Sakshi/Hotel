using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Models
{
    public class Hotel
    {
        [Key]
        public Guid ID { get; set; }
        public string VisitorsName { get; set; }
        public int VisitorsId { get; set; }
        public int VisitorsContact { get; set; }
        public string Checkintime { get; set; }
        public string Checkouttime { get; set; }
    }

}
