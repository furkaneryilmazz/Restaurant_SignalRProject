using Microsoft.EntityFrameworkCore;
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
        //    base anahtar kelimesi, bir sınıfın üst sınıfının(base class) kurucu metodunu çağırmak için kullanılır.Bu durumda, EfAboutDal sınıfı, GenericRepository<T> sınıfından kalıtım aldığı için, GenericRepository<T> sınıfının kurucu metodunu çağırmak için base anahtar kelimesi kullanılır.
        //EfAboutDal sınıfının kurucu metodu içindeki base(context) ifadesi, EfAboutDal sınıfının üst sınıfı olan GenericRepository<T> sınıfının kurucu metodunu çağırır. base(context) ifadesi, SignalRContext türünden bir nesne ile çağrıldığından, GenericRepository<T> sınıfının ilgili kurucu metoduna bu nesneyi ileterek GenericRepository<T> sınıfının kurucu metodunun çağrılmasını sağlar.
        //Bu şekilde, EfAboutDal sınıfı, GenericRepository<T> sınıfının kurucu metodunu çağırarak, bu sınıfın işlevselliğini ve özelliklerini kullanabilir ve genişletebilir. Bu tür bir yapı, miras alma (inheritance) yöntemiyle kodun tekrar kullanımını sağlar ve kodun daha sade ve bakımı kolay olmasını sağlar.
    public class EfProductDal : GenericRepository<Product>, IProductDal //
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList(); //Include metodu, ilişkili tabloları sorguya dahil etmek için kullanılır. Bu metot, veritabanında ilişkili tablolar arasındaki ilişkileri kullanarak, ilişkili tabloların verilerini sorguya dahil eder. products tablosundaki her bir kayıt için ilişkili olan category tablosundaki verileri sorguya dahil eder.
            return values;
        }

        public int ProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.Category.CategoryName == "İçecek").Select(y => y.ProductID).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.Category.CategoryName == "Hamburger").Select(y => y.ProductID).Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new SignalRContext();
            return context.Products.OrderByDescending(x => x.Price).Select(y => y.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            using var context = new SignalRContext();
            return context.Products.OrderBy(x => x.Price).Select(y => y.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductPriceByHamburgerAvg()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.Category.CategoryName == "Hamburger").Average(y => y.Price);
        }
    }
}
