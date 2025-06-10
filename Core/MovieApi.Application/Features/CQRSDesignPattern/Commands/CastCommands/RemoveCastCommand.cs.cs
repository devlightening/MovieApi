using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.CastCommands
{
    public class RemoveCastCommand
    {
        public int CastId { get; set; }
    }
}
