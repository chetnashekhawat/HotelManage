using System.ComponentModel.DataAnnotations;

namespace HotelBook.Models
{
    public class Rooms
    {


        [Key]
        public int Rid { get; set; }
        public int Hid { get; set; }
        public string? RoomNumber { get; set; }
        public string? Type { get; set; }
        public decimal RPrice { get; set; }
        public int Capacity { get; set; }

        public string? Availability { get; set; }

        public Hotel Hotel { get; set; }

    }
}
