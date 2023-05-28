using System.Security.Cryptography;
using HotelBook.Models;
using Microsoft.EntityFrameworkCore;


namespace HotelBook.Repository
{
    public class RoomRepository : IRoomsRepository
    {


        private readonly HotelBookingDbContext _context;

        public RoomRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task AddRoom(Rooms room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountRoomsByPrice(decimal minPrice)
        {

            return await _context.Rooms.CountAsync(r => r.RPrice > minPrice);

        }

        public async Task DeleteRoom(int Rid)
        {

            var room = await _context.Rooms.FindAsync(Rid);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Rooms>> GetAvailableRooms()
        {

            return await _context.Rooms.Where(r => r.Availability == "Available").ToListAsync();

        }

        public async Task<Rooms> GetRoomById(int Rid)
        {

            return await _context.Rooms.FindAsync(Rid);

        }

        public async Task<List<Rooms>> GetRoomsByHotelId(int Hid)
        {

            return await _context.Rooms.Where(r => r.Hid == Hid).ToListAsync();

        }

        public  async Task UpdateRoom(Rooms room)
        {

            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
