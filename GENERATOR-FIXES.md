# Code Generator — Şablon Düzeltmeleri

Bu dosya, ExpressDesk360'ta bulunup düzeltilen ve **kaynağı Code Generator şablonları olan** kusurları listeler.
Buradaki düzeltmeler üreticiye taşınmazsa bir sonraki üretimde geri gelir.

Her madde: **Şablon → Ne üretiyor → Ne üretmeli**.

---

## 1. Controller / Create POST — parametre adı

**Ne üretiyor**
```csharp
[HttpPost]
public async Task<IActionResult> Create(CompanyCreateDto request)   // <-- "request"
{
    var result = await _companyService.CreateAsync(request);
```
View ise `asp-for="CreateModel.Name"` üretiyor → form alanı adı `CreateModel.Name`.
Model binder `request.` veya öneksiz arar, **hiçbir alan bağlanmaz**. 62 varlıkta ekleme çalışmıyordu.

Update şablonu doğru: parametre `updateModel`, önek `UpdateModel.` (eşleşiyor).

**Ne üretmeli** — parametre adı view önekiyle aynı olmalı:
```csharp
public async Task<IActionResult> Create(CompanyCreateDto createModel)
{
    var result = await _companyService.CreateAsync(createModel);
```

**Kural:** Create/Update POST parametre adı, ilgili formun `asp-for` önekiyle (case-insensitive) eşleşmeli.

---

## 2. Controller / Delete — HTTP verb JS ile uyuşmuyor

**Ne üretiyor**
```csharp
[HttpGet] public async Task<IActionResult> Delete(Guid id)
```
Oysa `requestManager.js` `Delete` için `DELETE` gönderiyor → **405 Method Not Allowed**, 62 varlıkta silme hiç çalışmıyordu.

**Ne üretmeli**
```csharp
[HttpDelete] public async Task<IActionResult> Delete(Guid id)
```

**Kural:** Üretilen action verb'ü, o action'ı çağıran JS istemcisinin gönderdiği verb ile birebir eşleşmeli. (Aksi halde hata derlemede değil, yalnızca çalışma anında 405 olarak görünür.)

> **Restore kasıtlı olarak `[HttpGet]`.** Durum değiştiren bir GET olduğu için normalde POST
> önerilir — `<img src="/Company/Restore?id=...">` gibi bir çapraz-origin isteğiyle tetiklenebilir
> ve cookie `SameSite=Lax` olduğundan üst düzey GET'lerde oturum çerezi gönderilir. Bu proje
> için bilinçli kabul edilmiş bir risk; CSRF korumasıyla birlikte tekrar değerlendirilebilir.

---

## 3. Index.cshtml / DataTables — kolon adı casing

**Ne üretiyor** — aynı dosyada karışık:
```js
{ data: 'CreateDateUtc' },   // PascalCase
{ data: 'isDeleted' },       // camelCase
```
JSON varsayılanı camelCase olduğu için PascalCase kolonlar `DataTables warning: Requested unknown parameter` verip tabloyu hiç render etmiyordu.

**Dikkat:** Sunucu tarafı sıralama `Columns[i].Data`'yı Dynamic LINQ property adı olarak kullanır — orada **PascalCase gerekir**. Kör toplu değiştirme sıralamayı bozar.

**Ne üretmeli** — iki seçenekten biri, tutarlı şekilde:
- datatavle kolonları vilgiyi camelcase Dynamic LINQ ise PascalCase işlesin
---

## 4. Entity — Identity türevlerinde üye gölgeleme

**Ne üretiyor**
```csharp
public class User : IdentityUser<Guid>, IEntity, ...
{
    public Guid Id { get; set; }              // CS0114 - IdentityUser<Guid>.Id'yi gizliyor
    public string UserName { get; set; }      // CS0114 - IdentityUser<Guid>.UserName'i gizliyor
```
EF ile `UserManager` farklı property'lere yazabilir; sinsi veri tutarsızlığı.

**Ne üretmeli** — taban sınıfta zaten var olan üyeleri **hiç üretme**. `IdentityUser<TKey>` türevleri için `Id`, `UserName`, `Email`, `PasswordHash`, `SecurityStamp` vb. atlanmalı.

**Kural:** Bir entity taban sınıftan türüyorsa, taban sınıfın public üyeleri yeniden bildirilmemeli.

---


## 8. Controller — güvenlik attribute'ları

**Ne üretiyor** — hiçbir `[Authorize]`. Authorization katmanı fiilen boş geliyor: `UseAuthorization()` çağrılıyor ama tek bir endpoint bile korunmuyordu.

**Ne üretmeli**
- Global `FallbackPolicy` (bu projede eklendi) + anonim kalması gerekenlerde `[AllowAnonymous]`.
- Rol bazlı politika üretimi opsiyonel bırakılabilir; bu projede kasıtlı olarak uygulanmadı (oturum açan her kullanıcı her metodu kullanabiliyor).

> **CSRF — henüz uygulanmadı.** Formlar token üretiyor ama sunucu doğrulamıyor. Durum
> değiştiren action'lar `[HttpPost]`/`[HttpDelete]`'e çevrildiği için GET üzerinden mutasyon
> riski kapandı, ancak çapraz-origin POST hâlâ mümkün. İleride açılırken gereken üç parça:
> `AutoValidateAntiforgeryTokenAttribute` global filtresi, `AddAntiforgery(o => o.HeaderName = ...)`,
> ve `requestManager.js`'in token'ı bu header'da göndermesi.

**Kural:** Statik dosya endpoint'leri (`MapStaticAssets`), health check ve API dokümantasyonu fallback policy'den **muaf** tutulmalı (`.AllowAnonymous()`), aksi halde CSS/JS bile Login'e yönlenir.

---

## 9. Repository — soft-delete ile query filter etkileşimi

**Ne üretiyor**
```csharp
public async Task RestoreAndSaveAsync(Expression<Func<TEntity, bool>> where, ...)
{
    var entities = await _context.Set<TEntity>().Where(where).ToListAsync(...);   // IgnoreQueryFilters YOK
```
Global filtre `!IsDeleted` olduğu için geri alınacak kayıtlar tam da sorgudan dışlananlar → **62 servisin tamamında Restore sessizce hiçbir şey yapmıyordu**, üstelik `Success` dönüyordu.

Ayrıca `Delete`/`Restore` etkilenen satır sayısı döndürmüyordu → var olmayan kayıt için de `Success`.

**Ne üretmeli**
- Restore sorgularında **her zaman** `IgnoreQueryFilters()`.
- `DeleteAndSaveAsync`/`RestoreAndSaveAsync` `Task<int>` dönmeli; servis `0` ise `Result.NotFound()` vermeli.

**Kural:** Soft-delete edilmiş kayda dokunan her sorgu `IgnoreQueryFilters()` kullanmalı.

---

## 10. Soft-delete interceptor — çocuklara yayılım

**Ne üretiyor** — yalnızca silinen kaydın kendisini `IsDeleted = true` yapıyor. Çocuklar yüklenmediği için EF cascade'i de devreye girmiyordu → yetim kayıtlar; çocuk listede görünüyor ama `Include(x => x.Parent)` `null` dönüyordu (parent query filter ile eleniyor).

Ayrıca `Audit → Archive → SoftDelete` sırası nedeniyle `AuditInterceptor` bu kayıtları hiç görmüyordu: `UpdatedBy`/`UpdateDateUtc` yazılmıyordu.

**Ne üretmeli** — interceptor, cascade yapılandırılmış koleksiyon navigasyonlarını yükleyip soft-delete'i çocuklara yaymalı ve denetim alanlarını kendisi doldurmalı. (Bu projede `SoftDeleteInterceptor` bu şekilde yeniden yazıldı.)

---

## 11. Dynamic LINQ — alan adı doğrulaması

**Ne üretiyor** — `Filter.Field` / `Sort.Field` istemciden gelip **doğrudan** ifade string'ine yazılıyordu:
```csharp
["contains"] = (f, i) => $"np({f}).Contains(@{i})"
```
`Operator`, `Logic`, `Dir` beyaz listede ama `Field` değil. `{"field":"User.PasswordHash","operator":"startswith"}` → dönen satır sayısı boolean oracle olarak kullanılıp hash karakter karakter çıkarılabiliyordu.

**Ne üretmeli** — alan adı hedef tipin property'lerine karşı doğrulanmalı, navigasyon derinliği sınırlanmalı, hassas alanlar kara listede olmalı. (Bu projede `DynamicFieldValidator` eklendi.)

**Kural:** İstemciden gelip **string olarak** bir ifadeye giren her değer beyaz listeye tabi olmalı.

---

## 12. Sayfalama / DataTables — sınırsız okuma

**Ne üretiyor**
```csharp
if (request.PageSize <= 0) request.PageSize = count;          // tüm tabloyu belleğe alır
query.Skip(req.Start).Take(req.Length);                        // Length = -1 ("All") ile patlar
var column = req.Columns[orderItem.Column];                    // dizi sınırı kontrol edilmiyor
orderList.Add($"{prop} {orderItem.Dir}");                      // Dir doğrulanmamış
```

**Ne üretmeli** — varsayılan sayfa boyutu + `MaxPageSize` üst sınırı, negatif/sıfır değerlerin clamp'lenmesi, dizi indeksi sınır kontrolü, `Dir` için `asc|desc` beyaz listesi.

---

## 13. View / Controller eşleşmesi

**Ne üretiyor** — `Views/Home/` ve `Views/Error/` üretilmiş ama `HomeController` **hiç üretilmemiş**. Varsayılan rota `{controller=Home}` 404 veriyordu.

**Ne üretmeli** — view üretilen her controller için controller da üretilmeli (ve tersi).

---

## 14. Kozmetik / kalite

| Bulgu | Ne üretmeli |
|---|---|
| Partial referansı büyük/küçük harf uyuşmazlığı: dosya `_SubMenu.cshtml`, referans `_subMenu.cshtml` | Linux'ta 500 verir; dosya adıyla birebir referans |
| `AllowedUserNameCharacters` mojibake ve iki projede farklı bozuk | UTF-8 çıktı, tek kaynaktan |

---