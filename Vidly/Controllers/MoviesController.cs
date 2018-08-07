using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		// GET: Movies/Random
		public ActionResult Random()
		{
			var movie = new Movie() { Name = "Shrek!" };
			var customers = new List<Customer>
			{
				new Customer {Name="John"},
				new Customer {Name="Kelly"}
			};

			var viewModel = new RandomMovieViewModel
			{
				Movie = movie,
				Customers = customers
			};

			return View(viewModel);
		}

		public ActionResult Edit(int id)
		{
			return Content("id = " + id);
		}

		public ActionResult Index(int? pageIndex, string sortBy)
		{
			if (!pageIndex.HasValue)
				pageIndex = 1;
			if (string.IsNullOrWhiteSpace(sortBy))
				sortBy = "Name";
			return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
		}

		[Route("movies/released/{year:regex(\\d{4}):range(1900,2020)}/{month:regex(\\d{2}):range(01,12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}
	}
}