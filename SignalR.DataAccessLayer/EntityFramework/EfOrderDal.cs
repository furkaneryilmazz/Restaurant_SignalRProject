using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.Description == "Müşteri Masada").Count(); //ne yapıyoruz? siparişlerin içerisindeki açıklama kısmında "Müşteri Masada" olan siparişlerin sayısını alıyoruz.
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault(); //ne yapıyoruz? son eklenen siparişin fiyatını alıyoruz.
        }

        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.Date == DateTime.Today).Sum(y => y.TotalPrice); //ne yapıyoruz? bugünün tarihindeki siparişlerin toplam fiyatını alıyoruz.
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();   
            return context.Orders.Count(); //ne yapıyoruz? siparişlerin sayısını alıyoruz.
        }
    }
}
