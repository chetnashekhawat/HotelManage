using HotelBook.Models;
using HotelBook.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageRoomController : ControllerBase
    {


        private readonly IRoomsRepository _roomRepository;

        public ManageRoomController(IRoomsRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<IActionResult> FetchbyHotelId(int Hid)
        {

            try
            {
                var rooms = await _roomRepository.GetRoomsByHotelId(Hid);
                return Ok(rooms);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Found BadRequest - " + ex);
                throw;

            }
        }

        [HttpGet("{roomId}")]
        public async Task<IActionResult> FetchbyRoomId(int Hid, int Rid)
        {
            try
            {
                var room = await _roomRepository.GetRoomById(Rid);
                if (room == null || room.Hid != Hid)
                    return NotFound();

                return Ok(room);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Found BadRequest - " + ex);
                throw;

            }

        }


        [HttpGet("Total rooms available b/w inputprice")]
        public async Task<ActionResult<int>> CountRooms(decimal minPrice)
        {
            int roomCount = await _roomRepository.CountRoomsByPrice(minPrice);
            return Ok(roomCount);
        }

        [HttpGet("Availablerooms")]
        public async Task<ActionResult<List<Rooms>>> Availability()
        {
            var rooms = await _roomRepository.GetAvailableRooms();
            return Ok(rooms);
        }
        [Authorize]
        [HttpPost]

        public async Task<IActionResult> AddRoom(int Hid, Rooms room)
        {
            room.Hid = Hid;
            await _roomRepository.AddRoom(room);
            return CreatedAtAction(nameof(FetchbyRoomId), new { Hid, Rid = room.Rid }, room);
        }
        [Authorize]
        [HttpPut("{Rid}")]
        public async Task<IActionResult> UpdateRoom(int Hid, int Rid, Rooms room)
        {
            if (room.Hid != Hid || Rid != room.Rid)
            {
                return BadRequest();
            }

            await _roomRepository.UpdateRoom(room);
            return Ok();
        }
        [Authorize]
        [HttpDelete("{Rid}")]
        public async Task<IActionResult> RemoveRoom(int Rid)
        {
            await _roomRepository.DeleteRoom(Rid);
            return Ok();

        }


    }
}
