using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusApprover(int id);
        void BookingStatusCancelled(int id);
        List<Booking> StatusApproverPage();
        List<Booking> StatusCancelledPage();
    }
}
