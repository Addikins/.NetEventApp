using EventApp.Models;
using EventApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EventApp.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            var userEvent = new UserEvent
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = DateTime.Parse((string.Format("{0} {1}", viewModel.Date, viewModel.Time))),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _context.UserEvents.Add(userEvent);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}