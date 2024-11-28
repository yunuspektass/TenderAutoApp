# TenderAuto Uygulaması

TenderAuto Uygulaması, ihale süreçlerini dijitalleştirerek başvuru, inceleme ve onay aşamalarını basit ve etkin bir şekilde yönetmek için tasarlanmıştır. İhale yönetiminde sıkça karşılaşılan karmaşıklıkları ortadan kaldıran bu uygulama, kullanıcıların süreçleri kolayca takip etmelerini sağlar. Hem küçük hem de büyük ölçekli organizasyonlar için uygun olan TenderAuto, katmanlı mimarisi sayesinde ölçeklenebilirlik, sürdürülebilirlik ve bakım açısından büyük avantajlar sunar.

---

### İhale Yönetiminde Kolaylık ve Verimlilik

- **Başvuru ve Yönetim Süreçlerini Basitleştirme:** TenderAuto, kullanıcıların hızlı ve kolay bir şekilde ihale başvurusu yapmalarını sağlar. Admin kullanıcılar, sistem üzerinden yeni ihaleler oluşturabilir, teklifleri değerlendirebilir ve ihale süreçlerini detaylı bir şekilde takip edebilir.
  
- **İnceleme ve Onay İşlemlerini Optimize Etme:** Çok aşamalı inceleme ve onay süreçleri uygulama üzerinden yönetilebilir, böylece karmaşık süreçler daha düzenli ve şeffaf bir şekilde ilerler. Bu, ihale sorumlularının iş yükünü azaltarak zaman kazandırır.

- **Gerçek Zamanlı Bildirimler:** İhalelerde yaşanan gelişmeler, son başvuru tarihleri gibi önemli bilgiler için kullanıcılara otomatik bildirimler gönderilir. Bu sayede kullanıcılar, ihale sürecindeki tüm aşamalardan anında haberdar olur.

---

### Teknoloji ile Güçlendirilmiş Bir Deneyim

- **Backend:** 
  - **ASP.NET Core:** RESTful API'lerin geliştirilmesinde kullanıldı. Performanslı ve güvenli bir altyapı sağlandı.
  - **Entity Framework Core:** Katmanlı mimari ile yapılandırılmış, Code First yaklaşımıyla veritabanı yönetimi yapılmıştır.
  - **AutoMapper:** Nesne dönüşümleri için kullanılarak kod kalitesini artırmıştır.
  - **CQRS (Command Query Responsibility Segregation):** Veri işleme ve sorgulama süreçlerini optimize etmiştir.

- **Frontend:** 
  - **Vue.js ve Nuxt.js:** Dinamik ve kullanıcı dostu bir arayüz oluşturulmuştur. Nuxt.js'nin sunucu tarafı render (SSR) desteğiyle SEO optimizasyonu sağlanmıştır.
  - **Vuetify:** Modern, mobil uyumlu ve kullanıcı dostu tasarımlar yapılmıştır.
  - **Frontend GitHub Deposu:** [TenderAutoAppUI](https://github.com/yunuspektass/TenderAutoAppUI)

- **Veritabanı:** 
  - **PostgreSQL:** Büyük veri kümelerinin işlenmesi ve yönetilmesi için yüksek performanslı bir veritabanı altyapısı sağlanmıştır.

- **Kimlik Doğrulama ve Güvenlik:** 
  - **JWT (Bearer Token):** Kullanıcı oturum yönetimi ve yetkilendirme işlemleri için güvenilir bir mekanizma geliştirilmiştir.
  - **Refresh Token:** Güvenli oturum yönetimi sağlanarak kullanıcı deneyimi geliştirilmiştir.
  - **BCrypt:** Kullanıcı parolalarının güvenli bir şekilde saklanması için şifreleme yapılmıştır.

- **E-posta Gönderimi:** 
  - **Mailtrap:** Test amaçlı e-posta gönderimleri yapılmıştır.

- **Container Tabanlı Çalışma:**
  - **Docker:** Uygulamanın farklı ortamlarda sorunsuz çalışabilmesi için container tabanlı yapı kullanılmıştır.

---

### Öne Çıkan Özellikler

- **İhale Başvuru Yönetimi:** Kullanıcılar, sistem üzerinden ihalelere kolayca başvurabilir, başvurularını takip edebilir ve teklif verebilirler. Bu, manuel süreçlerin yerini alarak zaman kazandırır ve hata oranını düşürür.
  
- **İnceleme ve Onay Süreci:** İhale sorumluları, teklifleri çok aşamalı bir süreçte inceleyebilir ve onaylayabilir. Tekliflerin durumu anlık olarak güncellenebilir ve her aşama kaydedilir.

- **Rol Tabanlı Yetkilendirme:** 
  - **Rol Tabanlı:** Kullanıcı rollerine göre yetkilendirme sağlanmıştır (Admin, Firma Temsilcisi, İhale Sorumlusu, Genel Kullanıcı).
  - **Politika Tabanlı:** Özel erişim kurallarıyla kullanıcı yetkileri özelleştirilmiştir.
  - **Kaynak Tabanlı:** Belirli verilere erişimi sınırlandırmak için kaynak bazlı erişim kontrolü uygulanmıştır.

- **Global Filtreleme ve Gerçek Zamanlı Bildirimler:** Kullanıcılar, tekliflerini filtreleyebilir ve ihale durum değişiklikleri hakkında anlık bildirimler alabilirler.

- **Şifreleme ve Güvenlik:** Kullanıcı parolaları, **BCrypt** ile güvenli bir şekilde şifrelenir. Kullanıcı oturumları ve yetkilendirme işlemleri **JWT** ile sağlanır.

- **Mobil Uyumlu ve Modern Tasarım:** Vuetify kullanılarak mobil uyumlu bir arayüz ve modern bir tasarım oluşturulmuştur.

- **Container Tabanlı Çalışma:** Docker entegrasyonu sayesinde uygulama, farklı ortamlarda kolayca çalıştırılabilir.

---

### Neden TenderAuto?

TenderAuto, ihale süreçlerinde yaşanan karmaşıklıkları en aza indirerek, kullanıcıların başvuru, inceleme ve onay işlemlerini daha hızlı ve etkili bir şekilde gerçekleştirmelerine olanak tanır. Hem güvenli hem de performans odaklı olan bu sistem, organizasyonel verimliliği artırarak organizasyonlar için ihale yönetiminde önemli bir çözüm sunar.
