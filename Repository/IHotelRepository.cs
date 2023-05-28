
using HotelBook.Models;

namespace HotelBook.Repository
{
    public interface IHotelRepository
    {

        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int Hid);

        Task<List<Hotel>> GetHotelsByLocation(string location);
        Task<List<Hotel>> GetHotelsByPrice(decimal minPrice, decimal maxPrice);

        Task AddHotel(Hotel hotel);
        Task UpdateHotel(Hotel hotel);
        Task DeleteHotel(int Hid);


    }
}
