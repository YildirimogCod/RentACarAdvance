# 🚗 RentACar - Kurumsal Seviye Araç Kiralama API Projesi

Bu proje, araç kiralama (rent a car) süreçlerini yönetmek için geliştirilmiş kurumsal düzeyde bir **ASP.NET Core Web API** uygulamasıdır. Proje, gerçek dünya senaryoları göz önünde bulundurularak **katmanlı mimari**, **clean architecture**, **CQRS**, **MediatR**, **JWT**, **Caching**, **Validation**, **Logging** gibi modern yapı ve yaklaşımlarla geliştirilmiştir.

---

## 🏗️ Mimariler ve Tasarım Prensipleri

- **Onion Architecture** (Domain Driven Design)
- **CQRS** + MediatR kullanımı
- **Entity Framework Core** + Code First
- **SOLID**, **DRY**, **KISS** prensipleri
- **Dependency Injection**

---

## 🧠 Kullanılan Teknolojiler

| Katman | Teknolojiler |
|--------|--------------|
| API    | ASP.NET Core Web API, JWT Auth, FluentValidation |
| Application | MediatR, AutoMapper, CachingBehavior, Business Rules |
| Domain | Clean DDD yapısı |
| Infrastructure | Entity Framework Core, PostgreSQL (veya SQL Server), Redis hazır |
| Cross-Cutting | Logging, Caching, Exception Handling, Validation |

---

## 🧩 Core.Packages Projesi

Tüm projelerde ortak olarak kullanılabilecek altyapı bileşenlerini içerir:

- `Caching` (IDistributedCache destekli, MediatR Pipeline içinde kullanılır)
- `ExceptionHandling` (global try/catch mekanizması)
- `BusinessRulesBase` (iş kuralları merkezi)
- `BaseResponse` / `Result` yapıları (sıfır if-else ile akış kontrolü)
- `CoreBehaviors` (pipeline davranışları - validation, caching, logging)

---

## 🔄 Caching Yapısı (Core.Application.Pipelines.Caching)

**Özellikler:**
- MediatR Pipeline davranışı olarak entegre edildi.
- `ICachableRequest` interface’i ile hangi isteklerin cacheleneceği belirleniyor.
- `ByPass` özelliği ile cache opsiyonel olarak devre dışı bırakılabiliyor.
- `SlidingExpiration` desteği var.
- `IDistributedCache` kullanıldığı için Redis desteğine hazır.

**Amaç:**  
Performansı artırmak ve veri tabanı yükünü azaltmak için sıklıkla erişilen sorgu sonuçları bellekte tutulur.

---

## 🔐 Güvenlik

- JWT Token tabanlı kullanıcı doğrulama
- Refresh token altyapısı eklemeye hazır
- Authorization attribute’ları ile endpoint bazlı koruma

---

## ⚙️ Özellikler

- [x] Araç ekleme, silme, güncelleme
- [x] Marka ve model yönetimi
- [x] Kiralama ve müşteri işlemleri
- [x] Gelişmiş hata yönetimi
- [x] Gelişmiş cache sistemi
- [x] Katmanlı yapı (API / Application / Domain / Infrastructure)

---

## 🚀 Çalıştırma

```bash
# 1. Bağımlılıkları yükleyin
dotnet restore

# 2. Veritabanı migrasyonlarını çalıştırın
dotnet ef database update --project Infrastructure

# 3. API'yi çalıştırın
dotnet run --project WebAPI
