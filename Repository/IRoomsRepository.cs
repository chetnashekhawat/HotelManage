
using HotelBook.Models;

namespace HotelBook.Repository
{
    public interface IRoomsRepository
    {


        Task<List<Rooms>> GetRoomsByHotelId(int Hid);
        Task<Rooms> GetRoomById(int Rid);

        Task<int> CountRoomsByPrice(decimal minPrice);
        Task<List<Rooms>> GetAvailableRooms();

        Task AddRoom(Rooms room);
        Task UpdateRoom(Rooms room);
        Task DeleteRoom(int Rid);
    }
}

