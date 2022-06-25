using Hotel.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        private readonly HotelDbContext hotelDbContext;

        public HotelController(HotelDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;
        }


        //Get All Hotels
        [HttpGet]
        public async Task <IActionResult> GetAllHotels()
        {
            var hotels = await hotelDbContext.Hotels.ToListAsync();
           return Ok(hotels);
        }
        // Get single hotel
        [HttpGet]
        [Route("id:guid")]
        [ActionName("GetHotel")]
        public async Task<IActionResult> GetAllHotels([FromRoute] Guid id)
        {
            var hotels = await hotelDbContext.Hotels.FirstOrDefaultAsync(x=> x.Id == id);
            if(hotels!= null)
            {
                return Ok(hotels);
            }
            return NotFound ("hotel not found");
        }
        // Add hotel
        [HttpPost]

        public async Task<IActionResult> AddHotel([FromBody] hotel hotel)
        {
            hotel.Id = Guid.NewGuid();

            await hotelDbContext.Hotels.AddAsync(hotel);
            await hotelDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHotel), hotel.id, hotel);
        }
        //Updating A hotel
        [HttpPut]
        [Route("id:guid")]
        public async Task<IActionResult> UpdateHotel([FromRoute] Guid id, [FromBody] hotel hotel)
        {
            var existinghotels = await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Id == id);
            if(existinghotels != null)
            {
                existinghotels.VisitorsName = hotel.VisitorsName;
                existinghotels.VisitorsId = hotel.VisitorsId;
                existinghotels.VisitorsContact = hotel.Visitorscontact;
                existinghotels.Checkintime = hotel.Checkintime;
                existinghotels.Checkouttime = hotel.Checkouttime;
                await hotelDbContext.SaveChangesAsync();
                return Ok(existinghotels);
                   
            }
            return NotFound("Hotel not found");
        }

        //Delete A hotel
        [HttpDelete]
        [Route("id:guid")]
        public async Task<IActionResult> DeleteHotel([FromRoute] Guid id)
        {
            var existinghotels = await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Id == id);
            if (existinghotels != null)
            {
                hotelDbContext.Remove(existinghotels);
               await hotelDbContext.SaveChangesAsync();
                return Ok(existinghotels);

            }
            return NotFound("Hotel not found");
        }

    }
}
