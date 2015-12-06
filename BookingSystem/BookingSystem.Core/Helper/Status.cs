using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Core.Helper
{
    public class Status
    {
        public const string Pending = "Pending";
        public const string Approved = "Approved";
        public const string Rejected = "Rejected";
        public const string Canceled = "Canceled";
    }

    public class ActionType
    {
        public const string ApproveAction = "ApproveAction";
        public const string RejectAction = "RejectAction";
        public const string CancelAction = "CancelAction";
    }
}
