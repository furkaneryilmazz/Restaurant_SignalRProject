# Asp.Net Core Api SignalR ile QR Kodlu Sipariş Yönetimi
## QR Kodlu Sipariş Yönetimi Restoran

![SignalR-Restoran](https://github.com/furkaneryilmazz/Restaurant_SignalRProject/assets/133990378/e75ceaa7-70b6-4663-80c5-1eb1d4f644c9)

Projede ASP.NET Core 6.0 kullanılmış olup, vitrin ve yönetici panelleri bulunmaktadır. Bu projeyi Murat Yücedağ'ın Udemy'deki "ASP.NET Core API SignalR ile QR kodlu sipariş yönetimi" kursunu tamamlayarak geliştirdim. SignalR kütüphanesi, anlık bildirimler ve sepet işlemleri gibi fonksiyonlar için kapsamlı bir şekilde kullanılmıştır. Bu proje, restoran sistemine yönelik bir uygulama olup sipariş yönetimini sağlar. Arka planda bir API kullanılmış ve bu API, kullanıcı arayüzü tarafında tüketilmiştir. Rezervasyon işlemleri için kullanıcılara e-posta gönderilmektedir. SignalR, anlık bildirimler ve sepet işlemleri gibi fonksiyonlar için etkin bir şekilde kullanılmıştır. N-tier mimarisi tercih edilmiştir.

Projede, bir restoranın anlık sipariş aldığı, müşterilerin QR koduyla sipariş verebildiği, anlık bildirimler ve istatistiklerin yer aldığı gerçek zamanlı veri yönetimi bulunmaktadır. Müşteriler, oturdukları masaya göre sepetlerine ürün ekleyebilir veya çıkarabilirler. Sepet onaylandığında, sipariş anlık olarak mutfak bölümüne iletilir.

SignalR, sadece bildirimlerde değil, aynı zamanda siparişlerin anlık olarak şefe iletilmesi, istatistiklerin anlık olarak güncellenmesi ve masaların doluluk durumlarının anlık olarak gösterilmesinde de kullanılmıştır. Veritabanı olarak MSSQL kullanılmıştır ve güvenlik işlemlerinde Identity kullanılmıştır.

## Kullanılan Teknolojiler 
- ASP.NET Core 6.0
- SignalR
- Entity Framework Core
- Bootstrap
- QR Code Generator
- SMTP Mail Service
- ASP.NET Identity
- AJAX

 ## Özellikler
 - Müşterilerin yemek siparişi verebilmesi
 - Gerçek zamanlı sipariş güncellemeleri için SignalR entegrasyonu
 - Yöneticilere siparişler ve güncellemeler için e-posta bildirimleri
 - Kimlik doğrulama ve yetkilendirme için ASP.NET Identity sistemi
 - AJAX kullanarak asenkron veri alışverişi
 - Kullanıcıların profil bilgilerini güncelleme ve sipariş geçmişini görüntüleme
