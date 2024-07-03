using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public static int clientCount { get; set; } = 0; //bağlantı sağlanan client sayısını tutmak için bir değişken tanımladık

        // ---------------SignalR istatistik methodları burada tanımlanır.-----------------
        public async Task SendCategoryCount()
		{
			var value = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", value);
		}

		public async Task SendProductCount()
		{
			var value = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value);
		}

		public async Task SendActiveCategoryCount()
		{
			var value = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value);
		}
        public async Task SendPassiveCategoryCount()
        {
            var value = _categoryService.TPassiveCategoryCount(); //burada category service içerisindeki metodu çağırdık
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value); //burada ise client tarafındaki metodu çağırdık
        }
		public async Task SendProductCountByCategoryNameHamburger()
		{
			var value = _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value);
		}
        public async Task SendProductCountByCategoryNameDrink()
        {
            var value = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value);
        }
		public async Task SendProductAvg()
		{
			var value = _productService.TProductPriveAvg();
			await Clients.All.SendAsync("ReceiveProductAvg", value.ToString("0.00" + "₺"));
		}
		public async Task SendProductNameByMaxPrice()
		{
			var value = _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value);
		}
		public async Task SendProductNameByMinPrice()
		{
			var value = _productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value);	
		}
		public async Task SendProductByHamburgerAvg()
		{
			var value = _productService.TProductPriceByHamburgerAvg();
			await Clients.All.SendAsync("ReceiveProductByHamburgerAvg", value.ToString("0.00" + "₺"));
		}
		public async Task SendTotalOrderCount()
		{
			var value = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value);
		}
		public async Task SendActiveOrderCount()
		{
			var value = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value);
		}
		public async Task SendLastOrderPrice()
		{
			var value = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", value.ToString("0.00" + "₺"));
		}
		public async Task SendMoneyCasePrice()
		{
			var value = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveMoneyCasePrice", value.ToString("0.00" + "₺"));
		}
		public async Task SendTodayMoneyCasePrice()
		{
			var value = _orderService.TTodayTotalPrice();
			await Clients.All.SendAsync("ReceiveTodayMoneyCasePrice", value.ToString("0.00" + "₺"));
		}
		public async Task SendMenuTableCount()
		{
			var value = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value);
		}


		public async Task SendProgress()
		{
			var value = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00" + "₺"));

			var value2 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);

			var value3= _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value3);

			var value5 = _productService.TProductPriveAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", value5);

			var value6 = _productService.TProductPriceByHamburgerAvg();
			await Clients.All.SendAsync("ReceiveProductPriceByHamburgerAvg",value6);

            var value7 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value7);
        }

		public async Task GetBookingList()
		{
			var values = _bookingService.TGetListAll();
			await Clients.All.SendAsync("ReceiveBookingList", values);

        }

		public async Task SendNotification()
		{
			var value = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var notificationListByFalse = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
        }

        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
        }

		public async Task SendMessage(string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage",user,message);
		}

        public override async Task OnConnectedAsync() 
        {
			clientCount++; //bağlantı sağlandığında client sayısını bir arttır
			await Clients.All.SendAsync("ReceiveClientCount", clientCount); //bağlantı sağlandığında client sayısını gönder
            await base.OnConnectedAsync(); //bağlantı sağlandığında yapılacak işlemler
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
			clientCount--; //bağlantı kesildiğinde client sayısını bir azalt
			await Clients.All.SendAsync("ReceiveClientCount", clientCount); //bağlantı kesildiğinde client sayısını gönder
            await base.OnDisconnectedAsync(exception); //bağlantı kesildiğinde yapılacak işlemler //hata olursa exception döndür
        }

		public async Task GetApprovedPage()
		{
            var values2 = _bookingService.TStatusApproverPage();
            await Clients.All.SendAsync("ReceiveStatusApprovedPageList", values2);
        }
        public async Task GetCancelledPage()
        {
            var values2 = _bookingService.TStatusCancelledPage();
            await Clients.All.SendAsync("ReceiveStatusCancelledPageList", values2);
        }
    }
}
