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
![web1](https://user-images.githubusercontent.com/56433592/147689118-3529831d-c7c2-451d-8c91-e6481efaa1b0.PNG)
![web2](https://user-images.githubusercontent.com/56433592/147689128-4bb36786-5da2-45c7-8a85-34db92ba1ce4.PNG)
![web3](https://user-images.githubusercontent.com/56433592/147689131-8c48fbe5-be01-42af-8be0-4c83b7a0da51.PNG)
![web4](https://user-images.githubusercontent.com/56433592/147689133-6f554f42-8793-46b2-bba3-f3e456142eff.PNG)
![web5](https://user-images.githubusercontent.com/56433592/147689138-230744bb-732f-410c-a8fb-59f13b9718d8.PNG)
![web6](https://user-images.githubusercontent.com/56433592/147689140-bc4c251e-e1b9-4163-992a-e01cf451b8b8.PNG)
![web7](https://user-images.githubusercontent.com/56433592/147689142-19194cb3-2324-4052-8927-998e1351c9e0.PNG)
![web8](https://user-images.githubusercontent.com/56433592/147689144-f007198a-5f0f-4c26-8b37-9185930cce96.PNG)
![web9](https://user-images.githubusercontent.com/56433592/147689146-6331d6e8-d496-48d7-8eb4-04647ec5a691.PNG)
![web10](https://user-images.githubusercontent.com/56433592/147689149-3db63698-c899-4062-b38d-bbb9a5f8e2b6.PNG)
