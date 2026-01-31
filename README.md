

Bu proje, temel backend geliştirme prensiplerini, RESTful API oluşturma becerisini, katmanlı mimari anlayışını ve Entity Framework Core ile veritabanı işlemlerini ölçmek amacıyla hazırlanmıştır.

## Amaç

- REST API geliştirme becerisini ölçmek  
- Katmanlı mimari (Controller – Service – Repository) kullanımını değerlendirmek  
- EF Core ile temel CRUD işlemlerini uygulamak  
- Asenkron programlama ve temel SOLID farkındalığını göstermek  

---

## Kullanılan Teknolojiler

- **.NET 6+**
- **ASP.NET Core Web API**
- **C#**
- **Entity Framework Core**
- **PostgreSQL veya MSSQL**
- **Swagger (OpenAPI)**

---

## Proje Tanımı

### Product API

Tek bir mikro servis (monolith içinde katmanlı yapı) olarak geliştirilmiştir.

API aşağıdaki temel **CRUD** işlemlerini destekler:

- **Ürün Ekleme** → `POST /api/products`
- **Ürün Listeleme** → `GET /api/products`
- **Ürün Detay** → `GET /api/products/{id}`
- **Ürün Silme** → `DELETE /api/products/{id}`

---

## Mimari Yapı

Proje, **katmanlı mimari** prensiplerine uygun olarak yapılandırılmıştır:

Controller
↓
Service
↓
Repository
↓
Database (EF Core)


### Kullanılan Yapılar

- **Model**: Veritabanı entity’leri
- **DTO**: API request / response nesneleri
- **Controller**: HTTP isteklerinin yönetimi
- **Service**: İş kuralları
- **Repository**: Veritabanı erişimi

---

## Teknik Beklentiler

- Katmanlı mimari (Controller – Service – Repository)
- **SOLID** prensiplerine temel farkındalık  
  - Single Responsibility  
  - Dependency Injection
- **Asenkron programlama** (`async / await`)
- **EF Core Migration yönetimi**
  ```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
Exception Handling

Global exception middleware veya

Try-catch yapıları

Swagger ile API dokümantasyonu

Kurulum ve Çalıştırma
1.Projeyi Klonla
```git clone <repository-url>```

2.Veritabanı Ayarları
appsettings.json dosyasında connection string’i düzenle:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ProductDb;User Id=...;Password=...;"
}
```
3.Migration Oluştur ve Veritabanını Güncelle
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
4.Projeyi Çalıştır
```dotnet run```

Swagger Dokümantasyonu
Proje çalıştıktan sonra aşağıdaki adresten API dokümantasyonuna erişebilirsin:

```https://localhost:<port>/swagger```
