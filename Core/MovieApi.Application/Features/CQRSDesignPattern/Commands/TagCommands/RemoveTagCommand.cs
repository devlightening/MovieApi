using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.TagCommands
{
    public class RemoveTagCommand
    {
        public int TagId { get; set; }
    }
}
