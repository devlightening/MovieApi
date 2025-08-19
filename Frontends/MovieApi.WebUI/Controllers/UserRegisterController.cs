using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.UserRegisterDtos;
using System.Text;
using System.Text.Json;

namespace MovieApi.WebUI.Controllers
{
    public class UserRegisterController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public UserRegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserRegisterDto createUserRegisterDto)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var jsonContent = JsonSerializer.Serialize(createUserRegisterDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/UserRegisters", content);

            if (response.IsSuccessStatusCode)
            {
                // Registration successful, redirect to login or another page
                return RedirectToAction("SignIn", "Login");
            }
            ViewBag.ErrorMessage = "Kayıt Başarısız Oldu , Lütfen Tekrar Deneyiniz..";
            return View();
        }
    }
}