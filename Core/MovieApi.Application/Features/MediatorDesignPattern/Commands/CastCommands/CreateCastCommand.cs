using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    public class CreateCastCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string? Biography { get; set; }
        public string? Overview { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }


    }
}
