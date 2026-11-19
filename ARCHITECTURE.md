# AiTech API & WebUI Project - Mimari ve Geliştirme Notları

Bu doküman, **AiTechAPIProject** çözümünde uygulanan modern **.NET 8 N-Tier (Çok Katmanlı) Mimarisi**, alınan mimari kararlar, uygulanan kurumsal **Best Practice** standartları ve bileşenler arasındaki veri akışını özetlemektedir.

---

## 🛠️ Teknoloji Yığını ve Kütüphaneler

* **Framework:** .NET 8 (C# 12)
* **Veritabanı & ORM:** SQL Server (Docker Container) & Entity Framework Core 8
* **Nesne Eşleme (Mapping):** Mapster (AutoMapper yerine hafif, güvenli ve yüksek performanslı)
* **Bağımlılık Enjeksiyonu (DI):** Scrutor (Assembly Scanning / Otomatik Servis Taraması)
* **Girdi Doğrulama (Validation):** FluentValidation & FluentValidation.AspNetCore
* **Hata Yönetimi:** .NET 8 Yerleşik `IExceptionHandler` & RFC 7807 `ProblemDetails`
* **İstemci İletişimi (WebUI):** Typed HttpClient Factory & `ConfigureHttpClientDefaults`
* **Dokümantasyon:** Swagger / OpenAPI

---

## 🏛️ Katmanlı Mimari ve Sorumluluklar

```
┌──────────────────────────────────────────────────────────┐
│                   AiTech.WebUI (MVC)                     │  ──► İstemci / Sunum Katmanı (HTML/Razor)
└────────────────────────────┬─────────────────────────────┘
                             │  HTTP / JSON (Typed HttpClient)
┌────────────────────────────▼─────────────────────────────┐
│                    AiTech.API (WebAPI)                   │  ──► REST API Giriş Kapısı (Controllers)
└────────────────────────────┬─────────────────────────────┘
                             │
┌────────────────────────────▼─────────────────────────────┐
│                   AiTech.Business                        │  ──► İş Mantığı, Servisler, Validasyonlar
└──────────────┬─────────────────────────────┬─────────────┘
               │                             │
┌──────────────▼─────────────┐ ┌─────────────▼─────────────┐
│      AiTech.DataAccess     │ │        AiTech.DTO         │  ──► Ortak Veri Transfer Modelleri
└──────────────┬─────────────┘ └───────────────────────────┘
               │
┌──────────────▼─────────────┐
│        AiTech.Entity       │  ──► Çekirdek Veritabanı Varlıkları (Sıfır Bağımlılık)
└────────────────────────────┘
```

---

## 📋 Alınan Kritik Mimari Kararlar ve Best Practice Standartları

### 1. Güvenlik ve Konfigürasyon
* **User Secrets:** Veritabanı bağlantı cümlesi (`SqlConnection`) ve hassas şifreler `appsettings.json`'dan temizlenerek **.NET User Secrets** içine taşındı. Git geçmişine şifre sızması engellendi.
* **Environment-Based API URL:** WebUI'ın API'ye erişim adresi (`ApiSettings:BaseUrl`) `appsettings.json`'a taşındı. Canlıya çıkıldığında kod derlenmeden sadece konfigürasyondan değiştirilebilir hale getirildi.

### 2. Veritabanı, Audit ve Soft Delete (EF Core 8)
* **BaseEntity:** Tüm varlıklar `Id`, `CreatedDate`, `UpdatedDate?` ve `IsDeleted` alanlarını içeren ortak `BaseEntity` sınıfından türetildi.
* **AuditDbContextInterceptor:** `DbContext` içine kod yığmak yerine, EF Core'un modern Interceptor yapısı kuruldu:
  * Yeni eklenen kayıtlarda: `CreatedDate = DateTime.UtcNow`, `UpdatedDate = null`, `IsDeleted = false`.
  * Güncellenen kayıtlarda: `UpdatedDate = DateTime.UtcNow` basılırken `CreatedDate`'in ezilmesi engellendi.
  * Silinen kayıtlarda: Fiziki `DELETE` iptal edilerek durum `EntityState.Modified` yapıldı ve `IsDeleted = true` basıldı.
* **Global Query Filter:** `AppDbContext` içinde tüm varlıklara otomatik olarak `WHERE IsDeleted = 0` filtresi uygulandı. Silinen kayıtlar hiçbir `GetAll` veya `GetById` sorgusunda listelenmez.

### 3. Haritalama ve DTO Mimarisi (Mapster)
* AutoMapper'ın bilinen güvenlik açığı (vulnerability) ve onlarca Profile sınıfı ameleliği yerine modern **Mapster** kütüphanesine geçildi.
* DTO'lar C# 12 `record` ve `IBaseDto` olarak tanımlandı. `GenericService` içinde tek satırda `.Adapt<T>()` ile eşleme sağlandı.

### 4. Girdi Doğrulama (FluentValidation)
* 10 varlığımız için toplam **20 adet validator** (`Create...Validator` ve `Update...Validator`) yazıldı.
* Karakter sınırları (Min/Max) ve boş geçilemez kuralları eklendi.
* `AddFluentValidationAutoValidation()` sayesinde Controller'lara tek bir satır dahi `if (!ModelState.IsValid)` yazılmasına gerek kalmadı. Hatalı istekler Controller metoduna girmeden otomatik `400 Bad Request` ile reddedilir.

### 5. Küresel Hata Yönetimi (.NET 8 `IExceptionHandler`)
* Servislerde var olmayan kayıtlar arandığında `NotFoundException` fırlatılır.
* `GlobalExceptionHandler` sınıfı bunu yakalayarak API tüketicisine standart **RFC 7807 ProblemDetails** formatında `404 Not Found` JSON döner. Sunucu çökmeleri (500) engellendi.

### 6. Dependency Injection ve Modüler Kayıt (Scrutor)
* Her servis veya repository için tek tek elle `AddScoped` yazılmadı.
* `Scrutor` kütüphanesi ile Assembly Scanning yapıldı; adının sonu `Repository` ve `Service` ile biten her somut sınıf otomatik olarak arayüzüne (`ICategoryService -> CategoryService`) bağlandı.

### 7. RESTful API Rotalama Standardı
* URL sonlarına `/GetAll`, `/DeleteCategory` gibi eylem isimleri yazılması engellendi.
* Kaynak odaklı REST standardı kuruldu:
  * `GET    /api/Categories`    ➡️ Tümünü Listele
  * `GET    /api/Categories/5`  ➡️ Tek Birini Getir
  * `POST   /api/Categories`    ➡️ Yeni Ekle
  * `PUT    /api/Categories`    ➡️ Güncelle
  * `DELETE /api/Categories/5`  ➡️ Sil (Soft Delete)

### 8. WebUI Typed HttpClient ve `BaseApiService` Mimarisi
* **ConfigureHttpClientDefaults (.NET 8):** `ServiceRegistrations.cs` içinde API Base URL'i tek merkezden tanımlandı.
* **BaseApiService<TResult, TCreate, TUpdate>:** 10 ayrı WebUI servisinde tekrar tekrar `HttpClient` istekleri yazmak yerine, tüm CRUD mantığı tek bir generic üst sınıfa toplandı.
* **ApiResult & ValidationProblemDetails:** API'deki FluentValidation'ın ürettiği Türkçe hata mesajları, WebUI tarafında `ApiResult` zarfı ile yakalanıp MVC'nin `ModelState`'ine tek satırda (`result.AddToModelState(ModelState)`) aktarılır. Kullanıcı formdaki inputun altında anında kırmızı hata mesajını görür.

---

## 📦 Projedeki 10 Ana Varlık (Entities)

1. **Category:** Proje kategorileri
2. **Project:** Portfolyo projeleri
3. **Banner:** Ana sayfa karşılama alanı
4. **About:** Hakkımızda ana başlığı ve açıklaması
5. **AboutItem:** Hakkımızda maddeleri / yetenekleri
6. **Feature:** Öne çıkan özellikler ve ikonlar
7. **Choose:** "Neden Bizi Seçmelisiniz" alanı
8. **FAQ:** Sıkça Sorulan Sorular
9. **Social:** Sosyal medya hesapları ve bağlantıları
10. **Testimonial:** Müşteri yorumları ve referanslar

---

## 🚀 Sonraki Adımlar (Roadmap)

- [x] N-Tier proje iskeleti ve EF Core entegrasyonu
- [x] Docker SQL Server ve User Secrets yapılandırması
- [x] Mapster ve Record DTO dönüşümü
- [x] EF Core 8 Interceptor ile Audit ve Soft Delete altyapısı
- [x] FluentValidation kural setleri (20 validator)
- [x] Global Exception Handler (.NET 8)
- [x] Backend API Controller'larının inşası
- [ ] WebUI `BaseApiService` ve `ApiResult` dosyalarının projeye fiziki olarak eklenmesi
- [ ] WebUI `CategoryController` ve Razor View'larının (`Index`, `Create`, `Update`) tamamlanması
- [ ] Kalan 9 entity için WebUI servislerinin ve arayüz ekranlarının üretilmesi
- [ ] JWT / Identity yetkilendirme altyapısı (Auth)
