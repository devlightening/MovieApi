using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQuries
{
    public class GetCategoryByIdQuery
    {
        public int CategoryId { get; set; }
    }
}
