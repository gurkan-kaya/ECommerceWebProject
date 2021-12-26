Yaptığımız proje, bir sinema bileti satış websitesidir. 

Projede 2 tip kullanıcı rolü bulunmaktadır. 
Kullanıcı -> filmelere dair sinema salonu, kategori, oyuncular, seans saati, yönetmen, fiyat gibi detayları görüntüleyip bilet satın alabilir, sepetini ve siparişlerini görüntüleyebilir. 
Admin -> film, yönetmen, oyuncu, sinema salonu üzerinde ekleme, silme, güncelleme işlemleri yapabilir, tüm üyeleri görüntüleyebilir, kullanıcıların verdikleri siparişleri kontrol edebilir. 

Veritabanında Sinema, Yönetmen, Film, Oyuncu, FilmOyuncu, Sipariş, Kullanıcı, Sepet, SiparisFilm tabloları ve Identity tabloları yer almaktadır. FilmOyuncu tablosu, Film ve Oyuncu modelleri arasındaki many to many ilişkiden ortaya çıkan ara tablodur, Oyuncu ve Film ID’lerini tutar. SiparisFilm tablosu da benzer şekilde oluşmuştur. 

Projede kayıt ve giriş yapmak için sayfalar bulunmaktadır, kayıt olan tüm üyeler admin tarafından görüntülenebilmektedir. Admin ve Kullanıcının yetkilerindeki farklılıklar Authorization ile belirlenmiştir. 
Admin olmayan kullanıcı, ekranda admin yönetimi butonlarını göremediği gibi linke URL yazarak da bu alanlara erişemez, AccessDenied view sayfasına yönlendirilir. 

Kullanıcı sepete film eklemek isterse Login sayfasına yönlendirilir. [Authorize] ile erişmek için giriş yapılması gereken actionlar belirlenmiştir, giriş yapmayı gerektirmeyen alanlar ise [AllowAnonymus] niteliği ile anonim kullanıcılara açık hale getirilmiştir. 

Veritabanındaki Sinema modeli için bir API hizmeti sunulmuştur. Bu API aracılığıyla GET, POST, PUT, DELETE işlemlerinin yapılması sağlanmış ve Postman üzerinden kontrol edilmiştir. 

Projede çoklu dil desteği bulunmaktadır. Çoklu dil desteği, Asp.Net Core’da bulunan Localization konseptiyle sağlanmıştır. Resx dosyalarına iki dilde yazılan veriler sayesinde view sayfalarında bulunan ve data annotationlardan gelen kelimeler kullanıcının navbardaki dropdowndan seçeği dile göre değişmektedir. Çoklu dil desteğinin sağlanmasında Cookie yaklaşımı kullanılmıştır.
