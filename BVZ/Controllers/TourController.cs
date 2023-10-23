using Azure;
using Azure.Core;
using BVZ.BVZ.Application;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Domain.Models.Visitors;
using BVZ.Models;
using BVZ.Models.Tour;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace BVZ.Controllers
{
    public class TourController : Controller
    {
        private readonly ILogger<TourController> _logger;
        private readonly TourService _tourService;

        public TourController(
            ILogger<TourController> logger,
            TourService tourService)
        {
            _logger = logger;
            _tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            var getTours = await _tourService.GetCurrentDayZooTours(DateTime.Today);
            if (!getTours.IsSuccess)
            {
                ErrorViewModel ewm = new ErrorViewModel();
                ewm.ValidationErrorMessage = "Det gick inte att hitta några " +
                    "tillgängliga turer för det aktuella datumet.";
                return View(ewm);
            }
            DisplayAllToursViewModel displayVM = new DisplayAllToursViewModel
            {
                ToursOfTheDay = getTours.Data
            };

            return View(displayVM);
        }


        [HttpPost]
        public async Task<IActionResult> BookingStepOne(Guid Id, int NrOfPersons, string hasTickets)
        {

            RegisterTicketsOrNamesViewModel bs1VM = new RegisterTicketsOrNamesViewModel
            {
                Id = Id,
                NrOfParticipants = NrOfPersons,
                HasTickets = hasTickets
            };

            return View("/views/Tour/Booking.cshtml", bs1VM);
        }

        [HttpPost]
        public async Task<IActionResult> BookTourWithTicket(
            List<string> tickets, 
            Guid Id, int NrOfPersons)
        {
            foreach (var ticket in tickets)
            {
                if (string.IsNullOrEmpty(ticket))
                {
                    ErrorViewModel eVM = new ErrorViewModel();
                    eVM.ValidationErrorMessage = "Du måste fylla i ett biljettnummer";
                    return View("/views/Tour/Booking.cshtml", eVM);
                }
            }

            // Service anrop för att se om plats finns för denna.
            var response = await _tourService.BookZooTour(Id, NrOfPersons, tickets, true);

            return await BookingResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> BookTourWithoutTicket(
            List<string> persons, 
            Guid Id, int NrOfPersons)
        {
            foreach (var person in persons)
            {
                if(string.IsNullOrEmpty(person))
                {
                    ErrorViewModel eVM = new ErrorViewModel();
                    eVM.ValidationErrorMessage = "Du måste fylla i namn";
                    return View("/views/Tour/Booking1.cshtml", eVM);
                }
            }
                
            // Service anrop för att se om plats finns för denna.
            var response = await _tourService.BookZooTour(Id, NrOfPersons, persons, false);

            return await BookingResponse(response);
        }

        private async Task<IActionResult> BookingResponse(ServiceResponse<List<Visitor>> response)
        {
            if (!response.IsSuccess)
            {
                ErrorViewModel eVM = new ErrorViewModel();

                if (response.UserInfo != null)
                {
                    eVM.ValidationErrorMessage = response.UserInfo;
                    return View("/views/Tour/index.cshtml", eVM);
                }
                if (response.ErrorMessage != null)
                {
                    eVM.RequestId = response.ErrorMessage;
                    return RedirectToAction("Error", "Home", eVM);
                }
            }

            BookingConfirmationViewModel bcVM = new BookingConfirmationViewModel
            {
                BookingSuccessful = true,
                Visitors = response.Data
            };

            return View("/views/Tour/BookingConfirmation.cshtml", bcVM);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}