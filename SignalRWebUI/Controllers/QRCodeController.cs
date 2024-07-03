using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            using(MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createQRCode = new QRCodeGenerator(); //// QR kod oluşturucusunu başlatma
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q); // Kullanıcıdan alınan değer ile QR kodu oluşturma

                using (Bitmap image = squareCode.GetGraphic(10)) // QR kodu bir Bitmap olarak oluşturma
                {
                    image.Save(memoryStream, ImageFormat.Png); // Bitmap'i MemoryStream'e PNG formatında 
                    ViewBag.QrCodeImage = "data:image/png;base64,"+Convert.ToBase64String(memoryStream.ToArray()); // MemoryStream'i Base64 string'e çevirme ve ViewBag'e ekleme
                }
            }
            return View();
        }
    }
}
