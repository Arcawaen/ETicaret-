# E-TİCARET PROJESİ DETAYLI DOKÜMANTASYONU
## .NET 9.0 MVC - Katmanlı Mimari (N-Tier Architecture)

**Proje Adı:** ETicaret  
**Platform:** .NET 9.0 / ASP.NET Core MVC  
**Veritabanı:** SQL Server (EticaretDb)  
**Mimari:** 4 Katmanlı (Core, Data, Service, WebUI)  
**Son Güncelleme:** Mayıs 2026

---

## 1. PROJE MİMARİSİ VE KATMANLAR

Proje, Separation of Concerns (Sorumlulukların Ayrılması) prensibine uygun olarak 4 ayrı katmandan oluşmaktadır:

```
ETicaret (Solution)
├── Eticaret.Core        → Entity sınıfları ve arayüzler (Model katmanı)
├── Eticaret.Data         → Veritabanı bağlantısı, EF Core, Migration, Seed Data
├── Eticaret.Service      → İş mantığı servisleri (Repository Pattern)
└── ETicaret.WebUI        → MVC Controller, View, Admin Panel, UI
```

### 1.1. Eticaret.Core (Model Katmanı)
Bu katman, projenin temel veri yapılarını (Entity) barındırır. Hiçbir katmana bağımlılığı yoktur.

**Dosyalar:**
- `IEntity.cs` → Tüm entity sınıflarının uyguladığı temel arayüz. Sadece `int Id` property'si içerir.
- `AppUser.cs` → Kullanıcı bilgileri (Ad, Soyad, Email, Şifre, Telefon, IsAdmin, IsActive, UserGuid)
- `Product.cs` → Ürün bilgileri (Ad, Açıklama, Fiyat, Resim, Stok, Kategori, Marka, Aktiflik, Sıra No)
- `ProductImage.cs` → Ürüne ait ek resimler (ProductId, Image) - Bire-çok ilişki
- `Category.cs` → Kategori (Ad, Açıklama, Resim, ParentId ile alt kategori desteği, IsTopMenu, Sıra No)
- `Brand.cs` → Marka (Ad, Açıklama, Logo, Aktiflik, Sıra No)
- `Order.cs` → Sipariş (Sipariş No, Toplam Tutar, Müşteri, Fatura/Teslimat Adresi, Tarih, Durum)
- `OrderLine.cs` → Sipariş Satırı (Hangi sipariş, hangi ürün, miktar, birim fiyat)
- `CartLine.cs` → Sepet satırı (Product, Quantity) - Veritabanında tutulmaz, Session'da tutulur
- `Address.cs` → Adres (Başlık, Şehir, İlçe, Açık Adres, Fatura/Teslimat Adresi bayrakları)
- `Contact.cs` → İletişim formu (Ad, Soyad, Email, Telefon, Mesaj)
- `News.cs` → Kampanya/Haberler (Ad, Açıklama, Resim, Aktiflik)
- `Slider.cs` → Anasayfa slider (Başlık, Açıklama, Resim, Link)

**Sipariş Durumları (EnumOrderState):**
- Waiting (Onay Bekliyor)
- Approved (Onaylandı)
- Shipped (Kargoya Verildi)
- Completed (Tamamlandı)
- Cancelled (İptal Edildi)
- Returned (İade Edildi)

### 1.2. Eticaret.Data (Veri Erişim Katmanı)
Entity Framework Core kullanılarak veritabanı işlemlerinin yönetildiği katmandır.

**DatabaseContext.cs:**
- `DbSet<AppUser>`, `DbSet<Brand>`, `DbSet<Category>`, `DbSet<Contact>`, `DbSet<News>`, `DbSet<Product>`, `DbSet<ProductImage>`, `DbSet<Slider>`, `DbSet<Address>`, `DbSet<Order>` tanımlıdır.
- Bağlantı: `Server=DESKTOP-MRQ36BQ\SQLEXPRESS;Database=EticaretDb`
- `OnModelCreating` içinde `ApplyConfigurationsFromAssembly` ile tüm konfigürasyonlar otomatik uygulanır.

**Configuration Dosyaları (Seed Data dahil):**
- `AppUserConfiguration.cs` → Kullanıcı alanlarının uzunluk kısıtlamaları ve 1 adet Admin seed data
- `BrandConfiguration.cs` → Marka alanları ve 2 adet seed data (Asus, Monster)
- `CatagoryConfiguration.cs` → Kategori alanları ve 2 adet seed data (Elektronik, Bilgisayar)
- `ProductConfiguration.cs` → Ürün alanları ve 12 adet seed data (laptop, mouse, klavye vb.)
- `ContactConfiguration.cs` → İletişim formu alanları
- `NewsConfiguration.cs` → Kampanya alanları
- `SliderConfiguration.cs` → Slider alanları

### 1.3. Eticaret.Service (Servis Katmanı)
Generic Repository Pattern ile veri erişim işlemlerini soyutlar.

**IService<T> Arayüzü (Abstract):**
Senkron metotlar: `GetAll()`, `Get()`, `Find()`, `Add()`, `Update()`, `Delete()`, `SaveChanges()`
Asenkron metotlar: `FindAsync()`, `GetAsync()`, `GetAllAsync()`, `AddAsync()`, `SaveChangesAsync()`
Ekstra: `GetQueryable()` → LINQ sorguları için IQueryable döner

**Service<T> (Concrete):**
- `DatabaseContext` ve `DbSet<T>` kullanarak tüm CRUD işlemlerini gerçekleştirir.
- Generic yapıda olduğundan tüm entity'ler için tek bir servis sınıfı yeterlidir.

**ICartService / CartService:**
- Sepet işlemleri (Session tabanlı, veritabanında tutulmaz)
- `AddProduct()`, `UpdateProduct()`, `RemoveProduct()`, `TotalPrice()`, `ClearAll()`
- `List<CartLine>` olarak bellekte tutulan sepet yapısı

### 1.4. ETicaret.WebUI (Sunum Katmanı)

**Program.cs (Uygulama Başlangıç Noktası):**
- DI (Dependency Injection): `DatabaseContext`, `IService<> → Service<>` kaydı
- Authentication: Cookie tabanlı ("AdminAuth"), 5 gün süreli, HttpOnly ve SameSite.Strict korumalı
- Authorization: "AdminPolicy" ile admin sayfaları korunur (`RequireRole("Admin")`)
- Session: Sepet ve favoriler için aktif
- Routing: Admin Area (`/Admin/{controller}/{action}`) ve varsayılan route

---

## 2. KULLANICI TARAFLI ÖZELLİKLER (Frontend)

### 2.1. Anasayfa (HomeController)
- **Index:** Slider, kampanyalar ve öne çıkan ürünleri `HomePageViewModel` ile birleştirir
- **ContactUs:** İletişim formu (GET/POST), veritabanına kayıt
- **Privacy, Error, AccessDenied:** Standart sayfalar

### 2.2. Ürünler (ProductsController)
- **Index:** Ürün arama (isim veya açıklama üzerinden `q` parametresi ile filtreleme)
- **Details:** Ürün detay sayfası, ilişkili ürünler ve ek resimler (ProductImages) gösterilir

### 2.3. Kategoriler (CategoriesController)
- **Index:** Kategori ID'ye göre o kategoriye ait ürünleri listeler (Include ile Products çekilir)

### 2.4. Sepet ve Ödeme (CartController)
- **Index:** Sepet görüntüleme (Session'dan okunur)
- **Add:** Ürün ekleme (Session'a JSON olarak kayıt)
- **Update:** Miktar güncelleme
- **Remove:** Ürün çıkarma
- **Checkout (GET):** Ödeme sayfası - Kullanıcı adresleri ve sepet bilgileri
- **Checkout (POST):** İyzipay entegrasyonu ile gerçek ödeme işlemi
  - Kart bilgileri alınır
  - İyzipay API'sine istek gönderilir
  - Başarılıysa Order ve OrderLine kayıtları oluşturulur
  - Sepet temizlenir ve "Teşekkürler" sayfasına yönlendirilir
- **Thanks:** Sipariş başarı sayfası

### 2.5. Favoriler (FavoritesController)
- Session tabanlı favori listesi
- **Add:** Ürünü favorilere ekle
- **Remove:** Favorilerden çıkar
- **Index:** Favori listesini göster

### 2.6. Hesap Yönetimi (AccountController)
- **Index (GET/POST):** Kullanıcı profil bilgilerini görüntüle ve güncelle
- **MyOrders:** Kullanıcının kendi siparişlerini görüntüle (OrderLines ve Product dahil)
- **SignIn (GET/POST):** Giriş (Claims tabanlı kimlik doğrulama)
- **SignUp (GET/POST):** Kayıt (AppUser oluşturma)
- **SignOut:** Çıkış
- **PasswordRenew:** Şifre sıfırlama linki gönderme (e-posta ile)
- **PasswordChange:** Şifre değiştirme (link üzerinden gelen UserGuid ile doğrulama)

### 2.7. Adres Yönetimi (MyAddressesController)
- [Authorize] ile korunan sayfa
- **Index:** Kullanıcının kayıtlı adreslerini listele
- **Create:** Yeni adres ekle (AppUserId otomatik atanır)
- **Edit:** Adres düzenle (Teslimat/Fatura adresi bayrakları güncellenir)
- **Delete:** Adres sil

### 2.8. Kampanyalar/Haberler (NewsController)
- **Index:** Tüm kampanyaları listele
- **Details:** Kampanya detayı (sadece aktif olanlar)

### 2.9. Navigasyon ve Menü
- **Categories ViewComponent:** Üst menüdeki kategori dropdown'u dinamik olarak veritabanından çekilir
- `_Header.cshtml`: Kullanıcı Bilgilerim, Kayıtlı Adreslerim, Siparişlerim, Oturumu Kapat linkleri
- `_Layout.cshtml`: Bootstrap 5, Font Awesome, genel sayfa düzeni

---

## 3. ADMİN PANELİ (Area: Admin)

Admin paneline giriş `/Admin` üzerinden yapılır. `[Authorize(Policy = "AdminPolicy")]` ile korunur.

### 3.1. Ana Sayfa (MainController)
- **Index:** Sipariş istatistik kartları (Toplam, Bekleyen, Tamamlanan, İptal Edilen)
- Siparişler Datatables tablosunda listelenir (arama, sayfalama aktif)

### 3.2. Ürün Yönetimi (ProductsController)
- **Index:** Tüm ürünleri listele (Brand, Category dahil). Datatables aktif. Her ürün için Düzenle, Detay, Resimler ve Sil butonları mevcut.
- **Create:** Yeni ürün ekle (resim yükleme, Kategori ve Marka seçimi)
- **Edit:** Ürün güncelle (resim değiştirme/silme)
- **Details:** Ürün detayı
- **Delete:** Ürün silme (onay sayfası ile)

### 3.3. Ürün Resimleri (ProductImagesController)
- Bir ürüne birden fazla ek resim ekleme/düzenleme/silme imkanı
- **Index:** Tüm resimleri listele (productId parametresi ile filtreleme)
- **Create:** Yeni resim ekle (FileHelper ile dosya yükleme)
- **Edit:** Resim güncelle (resim değiştirme/silme)
- **Details:** Resim detayı
- **Delete:** Resim silme

### 3.4. Kategori Yönetimi (CategoriesController)
- Tam CRUD: Listeleme, Ekleme, Düzenleme, Detay, Silme
- Alt kategori desteği (ParentId)
- Resim yükleme

### 3.5. Marka Yönetimi (BrandsController)
- Tam CRUD: Listeleme, Ekleme, Düzenleme, Detay, Silme
- Logo yükleme

### 3.6. Sipariş Yönetimi (OrdersController)
- **Index:** Tüm siparişleri listele (Müşteri bilgileri dahil)
- **Details:** Sipariş detayı (OrderLines ile hangi ürünler alınmış)
- **Edit:** Sipariş durumunu güncelle
- **Delete:** Sipariş silme

### 3.7. Kullanıcı Yönetimi (AppUsersController)
- Kullanıcıları listele, düzenle, sil
- Şifreler maskelenmiş olarak gösterilir

### 3.8. Adres Yönetimi (AddressesController)
- Tüm kullanıcıların adreslerini yönet

### 3.9. İletişim Mesajları (ContactsController)
- Gelen iletişim formlarını listele, detay görüntüle, sil

### 3.10. Haber/Kampanya Yönetimi (NewsController)
- Tam CRUD: Kampanya ekleme/düzenleme/silme
- Resim yükleme

### 3.11. Slider Yönetimi (SlidersController)
- Anasayfa slider'ını yönet
- Resim yükleme

---

## 4. YARDIMCI SINIFLAR (Utils, Extensions, ViewComponents)

### 4.1. FileHelper.cs
- `FileLoaderAsync()`: IFormFile alır, `/wwwroot/Img/` altına kaydeder, dosya adını döner
- `FileRemover()`: Dosya silme işlemi

### 4.2. MailHelper.cs
- `SendMailAsync(Contact)`: İletişim formu verilerini e-posta olarak gönderir
- `SendMailAsync(email, subject, body)`: Şifre sıfırlama vb. için genel e-posta gönderimi
- SMTP ayarları şu an placeholder (mail.siteadi.com)

### 4.3. SessionExtensionMethods.cs
- `SetJson()`: Nesneyi JSON'a çevirip Session'a yazar (Newtonsoft.Json)
- `GetJson<T>()`: Session'dan JSON okuyup nesneye dönüştürür
- Sepet ve Favoriler bu extension metodlarla yönetilir

### 4.4. Categories ViewComponent
- Üst menüde dinamik kategori listesi oluşturur
- `IsTopMenu` ve `IsActive` filtresi ile çalışır

---

## 5. KULLANILAN TEKNOLOJİLER VE PAKETLER

| Teknoloji | Kullanım Amacı |
|-----------|---------------|
| .NET 9.0 | Ana framework |
| ASP.NET Core MVC | Web uygulama yapısı |
| Entity Framework Core | ORM - Veritabanı işlemleri |
| SQL Server | Veritabanı |
| Bootstrap 5 | CSS framework |
| Font Awesome | İkonlar |
| Newtonsoft.Json | Session JSON serialize/deserialize |
| Iyzipay | Online ödeme entegrasyonu |
| BCrypt.Net-Next | Şifre hashleme (güvenlik) |
| Simple Datatables | Admin tablo arama/sayfalama |
| Chart.js | Admin dashboard grafikleri |

---

## 6. VERİTABANI ŞEMASI

```
AppUsers (Id, Name, Surname, Email, Phone, Password, UserName, IsActive, IsAdmin, CreateDate, UserGuid)
    ↓ 1-N
Addresses (Id, Title, City, District, OpenAddress, IsActive, IsBillingAddress, IsDeliveryAddress, AppUserId)
    ↓ 1-N
Orders (Id, OrderNumber, TotalPrice, AppUserId, CustomerId, BillingAddress, DeliveryAddress, OrderDate, OrderState)
    ↓ 1-N
OrderLines (Id, OrderId, ProductId, Quantity, UnitPrice)

Categories (Id, Name, Description, Image, IsActive, IsTopMenu, ParentId, OrderNo)
    ↓ 1-N
Products (Id, Name, Description, Price, Image, IsActive, IsHome, ProductCode, CreateDate, Stock, CategoryId, BrandId, OrderNo)
    ↓ 1-N
ProductImages (Id, ProductId, Image)

Brands (Id, Name, Description, Logo, IsActive, CreateDate, OrderNo)
    ↓ 1-N (Products)

Contacts (Id, Name, Surname, Email, Phone, Message, CreateDate)
News (Id, Name, Description, Image, IsActive, CreateDate)
Sliders (Id, Title, Description, Image, Link)
```

---

## 7. YAPILMIŞ VE YAPILMAMIŞ ÖZELLİKLER

### TAMAMLANAN ÖZELLİKLER:
- [x] Katmanlı mimari (Core, Data, Service, WebUI)
- [x] Generic Repository Pattern (IService<T>)
- [x] Entity Framework Code First + Migrations + Seed Data
- [x] Cookie tabanlı Authentication/Authorization
- [x] Admin Panel (tüm CRUD işlemleri)
- [x] Ürün listeleme, arama, detay, kategoriye göre filtreleme
- [x] Sepet yönetimi (Session tabanlı)
- [x] Favori listesi (Session tabanlı)
- [x] İyzipay ödeme entegrasyonu
- [x] Sipariş oluşturma ve yönetimi
- [x] Kullanıcı kayıt, giriş, profil güncelleme
- [x] Şifre sıfırlama (e-posta ile link gönderme)
- [x] Adres yönetimi (Fatura/Teslimat adresi)
- [x] İletişim formu
- [x] Kampanya/Haber sistemi
- [x] Anasayfa Slider yönetimi
- [x] Ürüne çoklu resim ekleme (ProductImage)
- [x] Admin Datatables entegrasyonu
- [x] Dinamik admin dashboard (sipariş istatistikleri)
- [x] ViewComponent ile dinamik kategori menüsü
- [x] BCrypt ile şifre hashleme (güvenlik iyileştirmesi)
- [x] Admin paneli rol tabanlı erişim kontrolü (RequireRole)
- [x] Cookie güvenlik bayrakları (HttpOnly, SameSite)

### YAPILMAMIŞ / EKSİK ÖZELLİKLER:
- [ ] Ürün değerlendirme/yorum sistemi (Entity ve CRUD yok)
- [ ] Kupon/İndirim kodu sistemi
- [ ] Stok takibi (sipariş sonrası stok düşürme)
- [ ] E-posta SMTP ayarları gerçek değerlerle yapılandırılmadı (placeholder)
- [ ] İyzipay API anahtarları production değerleri girilmedi
- [ ] Kullanıcı rol yönetimi (şu an sadece IsAdmin bayrağı)
- [ ] Ürün varyantları (renk, beden vb.)
- [ ] Kargo takip entegrasyonu
- [ ] Raporlama ve gelişmiş analitik

---

## 8. DOSYA YAPISI ÖZET TABLOSU

### Frontend Controllers (8 adet):
| Controller | Dosya | İşlev |
|-----------|-------|-------|
| HomeController | Controllers/HomeController.cs | Anasayfa, İletişim, Hata |
| ProductsController | Controllers/ProductsController.cs | Ürün arama ve detay |
| CategoriesController | Controllers/CategoriesController.cs | Kategori ürünleri |
| CartController | Controllers/CartController.cs | Sepet ve ödeme (İyzipay) |
| FavoritesController | Controllers/FavoritesController.cs | Favoriler |
| AccountController | Controllers/AccountController.cs | Hesap, giriş, kayıt, şifre |
| MyAddressesController | Controllers/MyAddressesController.cs | Adres yönetimi |
| NewsController | Controllers/NewsController.cs | Kampanyalar |

### Admin Controllers (11 adet):
| Controller | Dosya | İşlev |
|-----------|-------|-------|
| MainController | Areas/Admin/Controllers/MainController.cs | Dashboard |
| ProductsController | Areas/Admin/Controllers/ProductsController.cs | Ürün CRUD |
| ProductImagesController | Areas/Admin/Controllers/ProductImagesController.cs | Ürün resimleri CRUD |
| CategoriesController | Areas/Admin/Controllers/CategoriesController.cs | Kategori CRUD |
| BrandsController | Areas/Admin/Controllers/BrandsController.cs | Marka CRUD |
| OrdersController | Areas/Admin/Controllers/OrdersController.cs | Sipariş yönetimi |
| AppUsersController | Areas/Admin/Controllers/AppUsersController.cs | Kullanıcı yönetimi |
| AddressesController | Areas/Admin/Controllers/AddressesController.cs | Adres yönetimi |
| ContactsController | Areas/Admin/Controllers/ContactsController.cs | İletişim mesajları |
| NewsController | Areas/Admin/Controllers/NewsController.cs | Kampanya CRUD |
| SlidersController | Areas/Admin/Controllers/SlidersController.cs | Slider CRUD |

---

## 9. ÖNEMLİ NOTLAR

1. **Veritabanı Bağlantısı:** `DatabaseContext.cs` içinde hardcoded olarak `DESKTOP-MRQ36BQ\SQLEXPRESS` sunucusuna bağlanır.
2. **Resim Yükleme:** Tüm resimler `wwwroot/Img/Products/` klasörüne `FileHelper` ile yüklenir.
3. **Session:** Sepet ve favoriler Session'da JSON olarak tutulur. Sunucu yeniden başlatılırsa kaybolur.
4. **Güvenlik:** Şifreler BCrypt algoritması ile hashlenmiş olarak veritabanında saklanır (detaylar Bölüm 10'da).
5. **İyzipay:** Sandbox modunda çalışır. Canlıya almak için `appsettings.json` içindeki `IyzicOptions` güncellenmeli.
6. **Build Durumu:** Proje 0 hata ile derlenir. Mevcut uyarılar nullable referans uyarılarıdır.

---

## 10. GÜVENLİK MİMARİSİ VE UYGULANAN KORUMALAR

Projenin güvenlik altyapısı aşağıdaki 4 ana başlık altında yapılandırılmıştır:

### 10.1. Şifre Güvenliği — BCrypt Hashleme

**Sorun:** Kullanıcı şifreleri başlangıçta veritabanında düz metin (plain text) olarak saklanıyordu. Bu durum, veritabanına erişen herkesin tüm kullanıcı şifrelerini doğrudan okuyabilmesi anlamına geliyordu.

**Çözüm:** `BCrypt.Net-Next` NuGet paketi (v4.2.0) projeye eklendi. BCrypt, Blowfish şifreleme algoritmasına dayanan, otomatik tuz (salt) ekleyen ve kaba kuvvet saldırılarına karşı tasarlanmış endüstri standardı bir şifre hashleme algoritmasıdır.

**Uygulanan Değişiklikler:**

**Dosya: `AccountController.cs`**

1. **Kayıt olurken (SignUpAsync metodu):** Kullanıcının girdiği şifre, veritabanına yazılmadan önce `BCrypt.Net.BCrypt.HashPassword()` ile hashlenir.
```csharp
appUser.Password = BCrypt.Net.BCrypt.HashPassword(appUser.Password);
await _service.AddAsync(appUser);
```

2. **Giriş yaparken (SignInAsync metodu):** Veritabanından sadece email ile kullanıcı çekilir, ardından girilen şifre `BCrypt.Net.BCrypt.Verify()` ile hash'e karşı doğrulanır.
```csharp
var account = await _service.GetAsync(x => x.Email == loginViewModel.Email & x.IsActive);
if (account == null || !BCrypt.Net.BCrypt.Verify(loginViewModel.Password, account.Password))
```

3. **Şifre değiştirirken (PasswordChange metodu):** Yeni şifre de hashlenerek kaydedilir.
```csharp
appUser.Password = BCrypt.Net.BCrypt.HashPassword(Password);
```

**Veritabanındaki Mevcut Şifreler:** Tüm mevcut kullanıcıların düz metin şifreleri tek seferlik bir migration script'i ile BCrypt hash'lerine dönüştürüldü.

**Sonuç:** Veritabanında artık şifreler `$2a$11$xKz...` gibi 60 karakterlik hash değerleri olarak saklanmaktadır. Bu hash'lerden orijinal şifreye geri dönüş matematiksel olarak imkansızdır.

### 10.2. Admin Paneli Erişim Kontrolü — Role-Based Authorization

**Sorun:** `AdminPolicy` içinde `RequireAuthenticatedUser()` kullanılıyordu. Bu, giriş yapmış herhangi bir müşterinin de tarayıcıya `/Admin` yazarak admin paneline erişebileceği anlamına geliyordu.

**Çözüm:** Policy tanımı `RequireRole("Admin")` olarak değiştirildi.

**Dosya: `Program.cs`**
```csharp
// Eski (GÜVENLİ DEĞİL):
options.AddPolicy("AdminPolicy", policy => policy.RequireAuthenticatedUser());

// Yeni (GÜVENLİ):
options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
```

**Nasıl Çalışır:** Kullanıcı giriş yaptığında Claims listesine `ClaimTypes.Role` eklenir. Admin kullanıcılar için bu değer `"Admin"`, normal müşteriler için `"Customer"` olarak atanır (`AccountController.cs` satır 118). `RequireRole("Admin")` sayesinde sadece `Admin` rolüne sahip kullanıcılar admin paneline erişebilir. Diğer kullanıcılar `AccessDenied` sayfasına yönlendirilir.

### 10.3. Cookie Güvenlik Bayrakları

**Sorun:** Authentication cookie'si (`AdminLogin`) için `HttpOnly` ve `SameSite` bayrakları ayarlanmamıştı. Bu durum XSS (Cross-Site Scripting) ve CSRF (Cross-Site Request Forgery) saldırılarına kapı açıyordu.

**Çözüm:** İki güvenlik bayrağı eklendi.

**Dosya: `Program.cs`**
```csharp
options.Cookie.HttpOnly = true;              // XSS koruması
options.Cookie.SameSite = SameSiteMode.Strict; // CSRF koruması
```

- **HttpOnly = true:** Cookie'ye JavaScript (`document.cookie`) ile erişimi engeller. Böylece bir XSS açığı olsa bile saldırgan kullanıcının oturum bilgisini çalamaz.
- **SameSite = Strict:** Cookie'nin yalnızca aynı site kaynaklı isteklerde gönderilmesini sağlar. Başka bir siteden yapılan isteklerde cookie eklenmez, böylece CSRF saldırıları engellenir.

### 10.4. Kimlik Doğrulama Akışı (Authentication Flow)

Kullanıcı giriş yaptığında oluşturulan Claims (kimlik bilgileri):

| Claim | Değer | Açıklama |
|-------|-------|----------|
| ClaimTypes.Name | Kullanıcı adı | Menüde gösterim için |
| ClaimTypes.Role | "Admin" veya "Customer" | Yetkilendirme kontrolü için |
| ClaimTypes.Email | Kullanıcı e-postası | Profil işlemleri için |
| "UserId" | Kullanıcı ID | Sipariş ilişkilendirme için |
| "UserGuid" | Benzersiz GUID | Güvenli kullanıcı tanımlama için |

Bu Claims, ASP.NET Core Data Protection API tarafından şifrelenmiş bir cookie içinde tarayıcıda saklanır. Cookie içeriği dışarıdan okunamaz ve değiştirilemez.

### 10.5. Güvenlik Özet Tablosu

| Güvenlik Önlemi | Kullanılan Teknoloji | Dosya |
|----------------|---------------------|-------|
| Şifre Hashleme | BCrypt.Net-Next (v4.2.0) | AccountController.cs |
| Rol Tabanlı Yetkilendirme | ASP.NET Core Authorization (RequireRole) | Program.cs |
| XSS Koruması | Cookie HttpOnly bayrağı | Program.cs |
| CSRF Koruması | Cookie SameSite.Strict + ValidateAntiForgeryToken | Program.cs, tüm POST formları |
| Oturum Şifreleme | ASP.NET Core Data Protection API | Otomatik (framework) |
| Form Doğrulama | ModelState + DataAnnotations | ViewModel sınıfları |
| Anti-Forgery Token | `[ValidateAntiForgeryToken]` attribute | Tüm POST action'lar |
