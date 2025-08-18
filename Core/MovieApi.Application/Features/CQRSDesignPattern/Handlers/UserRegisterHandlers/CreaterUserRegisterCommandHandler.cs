using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using MovieApi.Persistance.Context;
using MovieApi.Persistance.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers
{
    public class CreaterUserRegisterCommandHandler
    {
        private readonly MovieContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CreaterUserRegisterCommandHandler(MovieContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Handle(CreateUserRegisterCommand command)
        {
            try
            {
                var user = new AppUser()
                {
                    UserName = command.Username,
                    Email = command.Email,
                    Name = command.Name,
                    SurName = command.Surname // Entity'deki property name ile eşleştirdik
                };
                
                var result = await _userManager.CreateAsync(user, command.Password);
                
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Kullanıcı oluşturulamadı: {errors}");
                }
                
                // Kullanıcı başarıyla oluşturuldu, context'e ekleyelim
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir
                throw new Exception($"Kullanıcı kayıt işlemi başarısız: {ex.Message}");
            }
        }
            
    }
}
