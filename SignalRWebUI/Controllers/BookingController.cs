using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public BookingController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7264/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, mediaType: "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7264/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _clientFactory.CreateClient(); //ne yaptık? client oluşturduk
            var responseMessage = await client.DeleteAsync($"https://localhost:7264/api/Booking/{id}"); //ne yaptık? client ile apiye istek attık
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7264/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //ne yaptık? responseMessage içerisindeki veriyi okuduk
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData); //ne yaptık? okuduğumuz veriyi ResultCategoryDto tipine çevirdik
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, encoding: Encoding.UTF8, mediaType: "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7264/api/Booking/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> BookingStatusApprover(int id)
        {
            var client = _clientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7264/api/Booking/BookingStatusApprover/{id}");
            
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> BookingStatusCancelled(int id)
        {
            var client = _clientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7264/api/Booking/BookingStatusCancelled/{id}");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BookingStatusApprovedPage()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7264/api/Booking/StatusApproverPage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStatusApprovedPageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> BookingStatusCancelledPage()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7264/api/Booking/StatusCancelledPage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStatusApprovedPageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
