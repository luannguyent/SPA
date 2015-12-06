using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BookingSystem.Core.Helper;
using BookingSystem.DataAccess.UserManager;
using BookingSystem.Entities;
using BookingSystem.Service.Contracts;
using BookingSystem.Service.Model;
using BookingSystem.WebAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace BookingSystem.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Reservation")]
    public class ReservationController : ApiController
    {
        private IUserManager _userManager;
        private readonly IReservationService _reservationService;
        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }
        public ReservationController(IUserManager userManager,IReservationService reservationService)
        {
            _userManager = userManager;
            _reservationService = reservationService;
        }

        [Route("GetReservations")]
        public IHttpActionResult GetReservations()
        {
            List<ReservationModel> results = _reservationService.GetReservations();
            return Ok(results);
        }

        [Authorize]
        [Route("SaveReservation")]
        public IHttpActionResult SaveReservation(ReservationViewModel reservationViewModel)
        {
            var userName = Authentication.User.Identity.Name;
            var canCreate = _reservationService.CanCreateReservation(reservationViewModel.StartDate);
            var r = new Random();
            if (ModelState.IsValid && canCreate)
            {
                var reservation = new Reservation()
                {
                    ReservationNumber = "B" + r.Next(),
                    Description = reservationViewModel.Description,
                    PropertyId = reservationViewModel.SelectedProperty,
                    UserName = userName,
                    Status = Status.Pending,
                    StartDate = reservationViewModel.StartDate,
                    EndDate = reservationViewModel.EndDate
                };
                _reservationService.SaveReservation(reservation);
                return Ok("Success");
            }
            return BadRequest();
        }

        public IHttpActionResult GetReservationsByUserId(string userName)
        {
            var results = new List<Reservation>();
            return Ok(results);
        }

        [Authorize(Roles = "Administrator,User")]
        [Route("UpdateStatus")]
        [HttpPost]
        public IHttpActionResult UpdateStatus(ReservationViewModel reservationViewModel)
        {
            var actionType = reservationViewModel.ActionType;
            var userName = Authentication.User.Identity.Name;
            var hasAdmin = _userManager.IsAdministrator(Authentication.User.Identity.Name);
            if (!hasAdmin &&
                  (actionType == ActionType.ApproveAction || actionType == ActionType.RejectAction))
                return Unauthorized();
            if (userName != _reservationService.GetUserIdByReservationId(reservationViewModel.Id.Value) 
                && actionType == ActionType.CancelAction)
                return Unauthorized();
            var result = _reservationService.UpdateReservation(reservationViewModel.Id.Value,
                reservationViewModel.Comment, reservationViewModel.ActionType);
            return Ok(result > 0 ? "Successfully" : "Failed");
        }
    }
}
