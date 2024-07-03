using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingStatusApprover(int id);
        void TBookingStatusCancelled(int id);
        List<Booking> TStatusApproverPage();
        List<Booking> TStatusCancelledPage();
    }
}

