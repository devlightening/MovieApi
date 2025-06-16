using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailRelatedMoviesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Here you would typically fetch related movies from a service or database
            // For now, we will return an empty view
            return View();
        }
    }
}
