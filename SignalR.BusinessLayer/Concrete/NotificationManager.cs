using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> TGetAllNotificationByFalse()
        {
            var value =_notificationDal.GetAllNotificationByFalse();
            return value;   
        }

        public Notification TGetByID(int id)
        {
            var value = _notificationDal.GetByID(id);
            return value;
        }

        public List<Notification> TGetListAll()
        {
            var value = _notificationDal.GetListAll();
            return value;
        }

        public int TNotificationCountByStatusFalse()
        {
            var value = _notificationDal.NotificationCountByStatusFalse();
            return value;
        }

		public void TNotificationStatusChangeToFalse(int id)
		{
			_notificationDal.NotificationStatusChangeToFalse(id);
		}

		public void TNotificationStatusChangeToTrue(int id)
		{
			_notificationDal.NotificationStatusChangeToTrue(id);
		}

		public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
