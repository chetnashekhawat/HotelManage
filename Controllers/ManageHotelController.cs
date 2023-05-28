using HotelBook.Models;
using HotelBook.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBook.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class ManageHotelController : ControllerBase
    {

        private readonly IHotelRepository _hotelRepository;

        public ManageHotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> FetchHotels()
        {
            try
            {
                var hotels = await _hotelRepository.GetAllHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Found BadRequest - " + ex);
                throw;


            }


        }

        [HttpGet("{Hid}")]
        public async Task<ActionResult<Hotel>> FetchById(int Hid)
        {
            try
            {
                var hotel = await _hotelRepository.GetHotelById(Hid);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return BadRequest("An error occurred while fetching the ho tel.");
            }
        }

        [HttpGet("location/{location}")]
        public async Task<ActionResult<List<Hotel>>> FetchByLocation(string location)
        {
            try
            {
                var hotels = await _hotelRepository.GetHotelsByLocation(location);
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return BadRequest("An error occurred while fetching hotels by location.");
            }
        }



        [HttpGet("price")]
        public async Task<ActionResult<List<Hotel>>> FetchByPrice(decimal minPrice, decimal maxPrice)
        {
            try
            {
                var hotels = await _hotelRepository.GetHotelsByPrice(minPrice, maxPrice);
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Found BadRequest - " + ex);
                throw;

            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InsertHotel(Hotel hotel)
        {
            try
            {

                await _hotelRepository.AddHotel(hotel);
                return Ok();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Found BadRequest - " + ex);
                throw;

            }
        }
        [Authorize]
        [HttpPut("{Hid}")]
        public async Task<IActionResult> PutHotel(int Hid, Hotel hotel)
        {
            try
            {
                if (Hid != hotel.Hid)
                {
                    return BadRequest();
                }

                await _hotelRepository.UpdateHotel(hotel);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Found BadRequest - " + ex);
                throw;
            }
        }
        [Authorize]
        [HttpDelete("{Hid}")]
        public async Task<IActionResult> RemoveHotel(int Hid)
        {
            try
            {
                await _hotelRepository.DeleteHotel(Hid);
                return Ok();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Found BadRequest - " + ex);
                throw;
            }
        }
    }
}
