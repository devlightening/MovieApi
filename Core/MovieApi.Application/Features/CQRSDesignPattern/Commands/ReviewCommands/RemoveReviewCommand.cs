﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.ReviewCommands
{
    public class RemoveReviewCommand
    {
        public int ReviewId { get; set; }
    }
}
