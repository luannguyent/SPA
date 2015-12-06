using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Core.Helper;
using BookingSystem.DataAccess.Contracts;
using BookingSystem.Entities;
using BookingSystem.Service.Contracts;
using BookingSystem.Service.Model;

namespace BookingSystem.Service.Implements
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int SaveReservation(Reservation reservation)
        {
            _unitOfWork.Repository<Reservation>().Insert(reservation);
            _unitOfWork.SaveChanges();
            return reservation.Id;
        }

        public List<ReservationModel> GetReservations()
        {
            var reservations = _unitOfWork.Repository<Reservation>().GetAll();
            var properties = _unitOfWork.Repository<Property>().GetAll();
            var types = _unitOfWork.Repository<Entities.Type>().GetAll();
            var query = from reservation in reservations
                        join property in properties on reservation.PropertyId equals property.Id
                        join type in types on property.TypeId equals type.Id
                        select new ReservationModel
                        {
                            Description = reservation.Description,
                            ReservationNumber = reservation.ReservationNumber,
                            Id = reservation.Id,
                            StartDate = reservation.StartDate,
                            EndDate = reservation.EndDate,
                            PropertyName = property.Name,
                            TypeName = type.Name,
                            Status = reservation.Status,
                            UserName = reservation.UserName
                        };


            return query.ToList();
        }

        public List<Reservation> GetReservationByUserId()
        {
            throw new NotImplementedException();
        }

        public int UpdateReservation(int id, string commments, string actionType)
        {
            var reservations = _unitOfWork.Repository<Reservation>().GetAll().Where(c => c.Id == id).ToList();
            reservations.ForEach(c =>
            {
                switch (actionType)
                {
                    case ActionType.ApproveAction:
                        c.Status = Status.Approved;
                        break;
                    case ActionType.CancelAction:
                        c.Status = Status.Canceled;
                        break;
                    case ActionType.RejectAction:
                        c.Status = Status.Rejected;
                        break;
                    default:
                        c.Status = Status.Pending;
                        break;
                }
                c.Comment = commments;
            });
            return _unitOfWork.SaveChanges();
        }

        public string GetUserIdByReservationId(int id)
        {
            var reservation = _unitOfWork.Repository<Reservation>().GetAll().Where(c => c.Id == id);
            return reservation.FirstOrDefault().UserName;
        }

        public bool CanCreateReservation(DateTime startDate)
        {
            var query = _unitOfWork.Repository<Reservation>()
                .GetAll()
                .Where(c => c.StartDate >= startDate && c.EndDate <= startDate && c.Status == Status.Pending);
            var result = query.Any();
            return !result;
        }
    }
}
