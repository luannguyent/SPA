using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Entities;
using BookingSystem.Service.Model;

namespace BookingSystem.Service.Contracts
{
    public interface IReservationService
    {
        int SaveReservation(Reservation reservation);
        List<ReservationModel> GetReservations();
        List<Reservation> GetReservationByUserId();
        int UpdateReservation(int id, string commments, string actionType);
        string GetUserIdByReservationId(int id);
        bool CanCreateReservation(DateTime startDate);
    }
}
