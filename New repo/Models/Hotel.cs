using System.ComponentModel.DataAnnotations;


namespace HotelBook.Models
{
    public class Hotel
    {
        [Key]
        public int Hid { get; set; }
        public string? hname { get; set; }


        public string? Hlocation { get; set; }

        public int Hprice { get; set; }


        public ICollection<Rooms> Rooms { get; set; }

    }
}
