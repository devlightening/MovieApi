using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistersController : ControllerBase
    {
        private readonly CreaterUserRegisterCommandHandler _createrUserRegisterCommandHandler;

        public UserRegistersController(CreaterUserRegisterCommandHandler createrUserRegisterCommandHandler)
        {
            _createrUserRegisterCommandHandler = createrUserRegisterCommandHandler;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserRegister(CreateUserRegisterCommand command)
        {
            await _createrUserRegisterCommandHandler.Handle(command);
            return Ok("Kullanıcı Başarıyla Eklendi");
        }
    }
}
