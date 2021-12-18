using BuyTicket.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Data
{
    public class BiletDbInitializer
    {
        public static void EklenecekVeriler(IApplicationBuilder ab)
        {
            using(var scope = ab.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<BiletDbContext>();

                //Veritabanının varlığından emin olmak için
                context.Database.EnsureCreated();

                //Eğer tablolarda hiç veri yoksa test verilerimizi ekliyoruz.
                if (!context.Sinemalar.Any())
                {
                    context.Sinemalar.AddRange(new List<Sinema>()
                    {
                        new Sinema()
                        {
                            SinemaAdi = "Cinemaximum Gordion AVM",
                            SinemaFotografi = "~/images/Sinemalar/cinemaximum.png",
                            SinemaHakkinda = "Mars Cinema Group; 2001 yılında teknoloji ve konforu, beklentilerin üzerinde hizmet anlayışı ile birleştirerek, " +
                                            "Türkiye’de farklı ve kendine özgü bir sinema deneyimi yaratma felsefesiyle kurulmuştur."+
                                            "Sunmuş olduğu hizmet ve teknolojik yenilikler ile 2013 yılında dünyanın en büyük sinema birliği olan " +
                                            "UNIC (International Union of Cinemas) tarafından “Uluslararası Yılın Sinema Grubu” ödülüne layık görülen Mars Cinema Group," +
                                            " 36 şehirde 97 sinema işletmesi ve 848 salon sayısı ile Türkiye’nin en büyük sinema zinciridir."
                        },
                        new Sinema()
                        {
                            SinemaAdi = "Sinema Yedi",
                            SinemaFotografi = "~/images/Sinemalar/sinemaYedi.jpg",
                            SinemaHakkinda = "Bizim misyonumuz, oda sineması veya kişiye özel sinema konseptiyle, " +
                            "filmseverlere güzel bir kültürel aktiviteyi mümkün olan en huzurlu ortamda, en kaliteli haliyle yaşatmaktır."
                        },
                        new Sinema()
                        {
                            SinemaAdi = "Cinema Pink 365 AVM",
                            SinemaFotografi = "~/images/Sinemalar/cinemapink.jpg",
                            SinemaHakkinda = "Sinema salonu işletmeciliğini bilinen kalıpların dışına çıkarmayı kendine hedef olarak belirleyen Cinema Pink,"+
                                                "öncelikle hem salonlarda, hem de fuaye alanlarında seyircinin rahatını ön planda tutmaktadır."+
                                                "Bunu sadece konfor olarak değil, gişe, cafe ve büfelerdeki fiyatlandırma politikasında da görmeniz mümkündür."+
                                                "‘’Kalite” ve “ucuzluğu” bir arada uygulamak bizim için her zaman öncelikli hedef olmuştur."
                        },
                        new Sinema()
                        {
                            SinemaAdi = "Prestige Sinema Dünyası Kentpark AVM",
                            SinemaFotografi = "~/images/Sinemalar/prestigeSinema.jpg",
                            SinemaHakkinda = "Hani biletinizi elinize aldığınızdaki o güzel tebesüm ile salonun yolunu tutarsınız ya, o rahat deri koltuklara oturduğunuzda, " +
                            "hiç tanımadığınız kişiler ile aynı keyfi paylaşırken, filmin sonunda salondan çıkarken, bu keyfin hiç bitmemesini istersiniz, " +
                            "üstelik bir sonraki güzel anılarınız için plan yapmaya başlarsınız; " +
                            "İşte tüm bu heyecan ve güzel anılara sahip olmanız için çalışan ekibimizi sizlerle tanıştırmak isteriz."
                        },
                        new Sinema()
                        {
                            SinemaAdi = "Büyülü Fener Sineması",
                            SinemaFotografi = "~/images/Sinemalar/buyulu-fener.jpg",
                            SinemaHakkinda = "1996 yılında, Ankara'da son dönemlerin en modern sineması Büyülü Fener inşa edildi." +
                            "Sinema 1999 yılında Ankara Film Festivali tarafından nitelikli sinemanın izlenmesine yaptığı katkılardan ötürü kitle İletişim Ödülü'ne layık bulundu. " +
                            "Sinemamızdaki salonların isimleri düzenlenen bir yarışmayla belirlendi. " +
                            "Atıf Yılmaz, Türkan Şoray ve Şener Şen gibi önemli sanatçıların isimleri salonlara verilerek, " +
                            "sanatçılarımız yaşarken onurlandırılmaya çalışıldı. Sinemamızın kurucusu ve sahibi İrfan Demirkol 1997 yılında Tempo dergisi tarafından " +
                            "Ankara'nın vazgeçilemeyen 100 kişisinden biri seçildi."
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Oyuncular.Any())
                {
                    context.Oyuncular.AddRange(new List<Oyuncu>()
                    {
                        new Oyuncu()
                        {
                            OyuncuAdSoyad = "Engin Günaydın",
                            OyuncuHakkinda = "Engin Günaydın, Türk komedyen, sinema ve tiyatro oyuncusu. " +
                            "Bir Demet Tiyatro ile televizyon hayatına başlayan, Aşkım Aşkım ve Zaga'da daha geniş kitlelere kendini tanıtan Günaydın " +
                            "2005 yılında Burhan Altıntop rolü ile Avrupa Yakası'nda patlama yaşar. Engin Günaydın, Garanti Bankası reklamında da oynadı.",
                            OyuncuFotografi = "~/images/Oyuncular/engingunaydin.png"

                        },
                        new Oyuncu()
                        {
                            OyuncuAdSoyad = "Binnur Kaya",
                            OyuncuHakkinda = "Ankara'da doğmuştur. Aslen Adanalıdır. 1995 yılında Bilkent Üniversitesi Müzik ve Sahne Sanatları Fakültesi Tiyatro Bölümünü bitirdi. " +
                            "Hemen ardından İstanbul'a yerleşen Kaya," +
                            " Ankara Sahnesi ve Karatahta isimli çocuk tiyatroları ve Bakırköy Belediye Tiyatrosunda çalıştı. İlk televizyon dizisi Kaynanalar'dır. " +
                            "Beşiktaş Kültür Merkezi oyuncu kadrosuna katıldı. 2007-2008 sezonunda Avrupa Yakası komedi dizisinin kadrosuna dahil oldu. " +
                            "2010'da Vavien filmindeki rolüyle 42. Sinema Yazarları Derneği Ödülleri'nde ve 3. Yeşilçam Ödülleri'nde " +
                            "En İyi Kadın Oyuncu ödüllerini kazandı. 2014 yılında ise 41. " +
                            "Magnum Altın Kelebek Ödülleri'nde Aramızda Kalsın adlı dizideki rolüyle En İyi Kadın Komedi Oyuncusu Seçilmiştir.",
                            OyuncuFotografi = "~/images/Oyuncular/binnurkaya.jpg"
                        },
                        new Oyuncu()
                        {
                            OyuncuAdSoyad = "Cem Yılmaz",
                            OyuncuHakkinda = "23 Nisan 1973 tarihinde İstanbul'da doğdu. Aslen Gürün, Sivaslıdır. " +
                            "İlköğrenimini Mehmet Âkif İlkokulunda tamamladı. Ortaokulda Bahçelievler Kâzım Karabekir Ortaokulunu, " +
                            "sonrasında da Etiler Anadolu Otelcilik ve Turizm Meslek Lisesi ve Boğaziçi Üniversitesi Turizm İşletmeciliği Bölümünü bitirdi."+
                            "Karikatüre olan ilgisi ve yeteneği sayesinde üniversite yıllarında Leman isimli mizah dergisinde çalışmaya başladı. İlk gösterisini dergide çalıştığı yıllarda, " +
                            "Leman Kültür Merkezinde gerçekleştirdi. Sonrasında Beşiktaş Kültür Merkezinde sahne almaya başladı ve burada düzenlediği " +
                            "gösteriler ile adını duyurmayı başararak günümüze kadar toplamda 4.000'den fazla kez sahneye çıktı.",
                            OyuncuFotografi = "~/images/Oyuncular/cemyilmaz.jfif"
                        },
                        new Oyuncu()
                        {
                            OyuncuAdSoyad = "Zafer Algöz",
                            OyuncuHakkinda = "Dedesi besteci Kemani Haydar Telhüner'dir. 1975 sezonunda Bursa Devlet Tiyatroları Genel Müdürlüğünde açılan " +
                            "Gençlik Kursları ile tiyatro eğitimi alan sanatçı, 1981 yılında Ankara Devlet Konservatuvarı Tiyatro Bölümünü kazandı. " +
                            "1985 yılında mezun olup aynı yıl Bursa Devlet Tiyatrosu'nda sanat yaşamına başladı."+
                            "1989 yılında İstanbul Devlet Tiyatroları’na tayin olan Algöz, birçok oyunda rol aldı, dizi ve sinema filmleri çevirdi. " +
                            "İstanbul Devlet Tiyatroları'nda oyuncu olarak çalışmaktadır. Ayrıca League of Legends adlı MOBA oyununda " +
                            "Türkiye sunucusu açılışa özel Gangplank adlı şampiyonun Barbaros adlı kostümünü seslendirmiştir.",
                            OyuncuFotografi = "~/images/Oyuncular/zaferalgoz.jpg"
                        },
                        new Oyuncu()
                        {
                            OyuncuAdSoyad = "Ozan Güven",
                            OyuncuHakkinda = "1975 yılında Almanya'da doğan Ozan Güven, Mimar Sinan Üniversitesi İstanbul Devlet Konservatuvarı'nın modern " +
                            "dans bölümünden mezun oldu. İzmir Belediye Konservatuvarı'nda oyunculuk dersleri aldı ve ardından " +
                            "Şahika Tekand Tiyatrosu'nda çalıştı. İkinci Bahar, Çiçeği Büyütmek, Koçum Benim," +
                            " Aslı ile Kerem, Bir İstanbul Masalı, Canım Ailem, Koyu Kırmızı, Muhteşem Yüzyıl ve Fi gibi televizyon dizilerinde rol aldı." +
                            " G.O.R.A, A.R.O.G, Yahşi Batı, Arif V 216 ve Pek Yakında filmlerinde yakın arkadaşı olan Cem Yılmaz'la oynadı.",
                            OyuncuFotografi = "~/images/Oyuncular/ozanguven.jpg"
                        },
                         new Oyuncu()
                        {
                            OyuncuAdSoyad = "Farah Zeynep Abdullah",
                            OyuncuHakkinda = "Farah Zeynep, üniversiteye başlamaya hazırlanırken Öyle Bir Geçer Zaman Ki adlı dizi için teklif aldı. " +
                            "İngiltere'deki okuluna dönmesine üç gün kala," +
                            " deneme çekimlerinde başarılı bulunduğunu ve Aylin rolüne seçildiğini öğrendi. " +
                            "Bu dizide dört çocuklu bir ailenin ikinci çocuğu olan Aylin'i canlandırdı. Daha sonra Yılmaz Erdoğan'ın filmi " +
                            "Kelebeğin Rüyası'nda oynadı. Bu filmde başrolleri Kıvanç Tatlıtuğ ve Mert Fırat ile paylaştı. 2014 senesinde " +
                            "Star TV'de yayınlanan Kurt Seyit ve Şura adlı dizide başrol oynadı. Ardından 14 Şubat 2014'te Kerem Deren'in yönetmenliğini üstlendiği " +
                            "Bi Küçük Eylül Meselesi filminde Engin Akyürek ile başrolü paylaştı. Çağan Irmak'ın yönettiği, 2014 yılının en başarılı filmlerinden olan" +
                            " Unutursam Fısılda filminde Hümeyra'nın da oynadığı Hatice (Ayperi) karakterinin gençliğini canlandırdı.",
                            OyuncuFotografi = "~/images/Oyuncular/farahzeynep.jfif"
                        },
                          new Oyuncu()
                        {
                            OyuncuAdSoyad = "Mehmet Günsür",
                            OyuncuHakkinda = "Oyunculuğa yedi yaşında çeşitli reklam filmlerinde oynayarak başladı. " +
                            "14 yaşındayken Okan Uysaler'in yönettiği Geçmiş Bahar Mimozaları adlı dizide Rutkay Aziz," +
                            " Filiz Akın ve Müşfik Kenter gibi oyuncularla rol aldı. İtalyan Lisesinden mezun olduktan sonra Marmara Üniversitesi " +
                            "İletişim Fakültesine girerek buradan mezun oldu. Bir müzik grubuyla konserler veren Günsür, dört yıl boyunca restoran işletmiştir." +
                            " Hamam filminin figürasyonunu yapan bir arkadaşının aracılığıyla seçmelere katıldı. Deneme çekiminin ardından role kabul edildi ve Ferzan Özpetek'in " +
                            "yönetmenliğindeki bu filmle adını geniş kitlelere duyurdu. Filmin ardından yalnızca oyunculuğa yönelme kararı aldı.",
                            OyuncuFotografi = "~/images/Oyuncular/mehmetgunsur.jpg"
                        },
                           new Oyuncu()
                        {
                            OyuncuAdSoyad = "Erdal Beşikçioğlu",
                            OyuncuHakkinda = "5 Ocak 1970 yılında, Ünyeli bir baba ve Kosova Priştine'den Ankara'ya göç etmiş " +
                            "Arnavut bir ailenin kızı olan bir annenin ilk çocuğu olarak Ankara'da dünyaya geldi." +
                            " Orta öğrenimini İzmir Özel Türk Kolejinde tamamladı." +
                            " İzmir Narlıdere Mehmet Seyfi Eraltay Lisesinden mezun oldu. 1989 yılında Hacettepe Üniversitesi Devlet Konservatuvarına girdi." +
                            " Konservatuvar eğitimi sırasında William Guskill ile yaratıcı drama üzerine atölye çalışmalarına katıldı. " +
                            "1993 yılında mezun oldu ve aynı yıl Devlet Tiyatrolarında oyuncu olarak göreve başladı." +
                            " 1995-96 sezonunda Diyarbakır Devlet Tiyatrosunda müdür vekili olarak görev aldı.",
                            OyuncuFotografi = "~/images/Oyuncular/erdalbesikcioglu.jpg"
                        },
                           new Oyuncu()
                        {
                            OyuncuAdSoyad = "Çağlar Ertuğrul",
                            OyuncuHakkinda = "13 Nisan 2009 tarihinde ilk kez Koç Üniversitesi'nde Romeolar ve Julietler adlı bir oyunda oynayarak sahne aldı. " +
                            "Ardından çeşitli oyunlarda sahneye çıktı. Üniversite'den mezun olduktan sonra " +
                            "Vahide Gördüm'ün 35 Buçuk Akademisi'nde 1 yıl eğitim gördü. 2012 yılında Alper Çağlar'ın yönettiği Dağ adlı bir askerî filmin baş rolünde yer aldı. " +
                            "Filmde Çağlar Ertuğrul'a Ufuk Bayraktar eşlik etti. Film 170.000 TL olan bütçesinin çok üzerinde 3 milyon TL hasılata ulaştı." +
                            " Bu filmin ardından tanındı. Benim İçin Üzülme dizisinden teklif gelmesiyle birlikte makine mühendisliğinden vazgeçip oyunculuk kariyerine odaklandı." +
                            " 2016-2017'de West Hollywood, Lee Strasberg Tiyatro ve Film Okulu'nda metot oyunculuğu ve doğaçlama komedi üzerine konservatuvar eğitimi aldı.",
                            OyuncuFotografi = "~/images/Oyuncular/caglarertugrul.jpg"
                        },
                            new Oyuncu()
                        {
                            OyuncuAdSoyad = "Doğu Demirkol",
                            OyuncuHakkinda = "Mersinli avukat bir anneyle Çerkes kökenli Balıkesirli doktor bir babanın oğlu olarak Ankara'da doğdu." +
                            " Ortaokulu Amasya’da liseyi ise Ankara’da okudu. Lisans eğitimi için İstanbul Üniversitesi Bilgisayar Mühendisliği bölümünü bitirdi."+
                            "Önceleri sosyal medya üzerinden çeşitli komedi video çalışmaları yapan Demirkol, 2012 yılında Yetenek Sizsiniz yarışmasına katıldı. " +
                            "2016 yılında BKM'de Açık Mikrofon adıyla gösteriler yaptı. " +
                            "Buradaki başarısından sonra Güldür Güldür adlı programa konuk olarak katılıp kısa bir stand-up gösterisi sundu."+
                            "2018 yılında Ali Atay'ın yönettiği Ölümlü Dünya filminde canlandırdığı Zafer karakteri ile sinema hayatı başladı." +
                            " Aynı yıl İlk gösterimi 71. Cannes Film Festivali'nde gerçekleştirilen Nuri Bilge Ceylan'ın yönettiği " +
                            "Ahlat Ağacı filminde Sinan Karasu karakteriyle başrolde yer aldı.",
                            OyuncuFotografi = "~/images/Oyuncular/dogudemirkol.png"
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Yonetmenler.Any())
                {
                    context.Yonetmenler.AddRange(new List<Yonetmen>()
                    {
                    new Yonetmen()
                    {
                        YonetmenAdSoyad = "Nuri Bilge Ceylan",
                        YonetmenHakkinda = "Nuri Bilge Ceylan, Türk yönetmen, senarist ve fotoğrafçı. " +
                        "1998 yılından itibaren çektiği uzun metrajlı filmler ile birçok ödül kazanmış ve uluslararası alanda tanınmıştır. " +
                        "Kış Uykusu filmi 2014 Cannes Film Festivali'nde Altın Palmiye Ödülü kazanmış ve sinema tarihinde bu ödülü kazanan ikinci Türk filmi olmuştur.",
                        YonetmenFotografi = "~/images/Yonetmenler/nuribilge.jpg"

                    },

                    new Yonetmen()
                    {
                        YonetmenAdSoyad = "Ozan Açıktan",
                        YonetmenHakkinda = "Ozan Açıktan, Eskişehir doğumlu Türk yönetmen ve senarist. ",
                        YonetmenFotografi = "~/images/Yonetmenler/ozanaciktan.jfif"

                    },

                    new Yonetmen()
                    {
                        YonetmenAdSoyad = "Serdar Akar",
                        YonetmenHakkinda = "1987'de Mimar Sinan Üniversitesi Sinema-TV Bölümüne girdi ve 2000 yılında okulu bitirdi. Türk yönetmen ve senaristtir. ",
                        YonetmenFotografi = "~/images/Yonetmenler/serdarakar.jpg"

                    },

                    new Yonetmen()
                    {
                        YonetmenAdSoyad = "Alper Çağlar",
                        YonetmenHakkinda = "Süleyman Alper Çağlar, Türk sinema yönetmeni ve senarist.",
                        YonetmenFotografi = "~/images/Yonetmenler/alpercaglar.jpg"

                    },


                    new Yonetmen()
                    {
                        YonetmenAdSoyad = "Ömer Faruk Sorak",
                        YonetmenHakkinda = "Ömer Faruk Sorak, görüntü ve video klip yönetmeni. " +
                        "1986 yılında Ankara Üniversitesi Basın Yayın Yüksekokulu'nu bitirdi. 1987-1995 yılları arasında TRT'de kameraman olarak çalıştı.",
                        YonetmenFotografi = "~/images/Yonetmenler/omerfaruksorak.jpg"
                        //yahsi bati, gora

                    },

                    new Yonetmen()
                    {
                        YonetmenAdSoyad = "Cem Yılmaz",
                        YonetmenHakkinda = "23 Nisan 1973 tarihinde İstanbul'da doğdu. Aslen Gürün, Sivaslıdır. " +
                            "İlköğrenimini Mehmet Âkif İlkokulunda tamamladı. Ortaokulda Bahçelievler Kâzım Karabekir Ortaokulunu, " +
                            "sonrasında da Etiler Anadolu Otelcilik ve Turizm Meslek Lisesi ve Boğaziçi Üniversitesi Turizm İşletmeciliği Bölümünü bitirdi."+
                            "Karikatüre olan ilgisi ve yeteneği sayesinde üniversite yıllarında Leman isimli mizah dergisinde çalışmaya başladı. İlk gösterisini dergide çalıştığı yıllarda, " +
                            "Leman Kültür Merkezinde gerçekleştirdi. Sonrasında Beşiktaş Kültür Merkezinde sahne almaya başladı ve burada düzenlediği " +
                            "gösteriler ile adını duyurmayı başararak günümüze kadar toplamda 4.000'den fazla kez sahneye çıktı.",
                            YonetmenFotografi = "~/images/Oyuncular/cemyilmaz.jfif"
                        //pek yakinda

                    },

                    new Yonetmen()
                    {
                        YonetmenAdSoyad = "Ali Atay",
                        YonetmenHakkinda = "Dursun Ali Atay, Türk oyuncu, müzisyen ve film yönetmeni.",
                        YonetmenFotografi = "~/images/Yonetmenler/aliatay.jpg"
                        //olumlu dunya

                    },

                    new Yonetmen()
                    {
                        YonetmenAdSoyad = "Çağan Irmak",
                        YonetmenHakkinda = "Çağan Irmak, Türk dizi ve film yönetmeni, senaryo yazarı. ",
                        YonetmenFotografi = "~/images/Yonetmenler/caganirmak.jpg"
                        //unutursam fisilda

                    },

                    new Yonetmen()
                    {
                        YonetmenAdSoyad = "Yağmur Taylan",
                        YonetmenHakkinda = "Yağmur Taylan, Bursa doğumlu Türk film yönetmeni.",
                        YonetmenFotografi = "~/images/Yonetmenler/yagmurtaylan.jpg"
                        //pek yakinda

                    }

                    });
                    context.SaveChanges();
                }

                if (!context.Filmler.Any())
                {
                    context.Filmler.AddRange(new List<Film>()
                    {
                        new Film()
                        {
                            FilmAdi = "Aile Arasında",
                            FilmHakkinda = "Nevrotik Fikret ile müzikhol vokalisti Solmaz komik bir tesadüfle tanışır. Solmaz'ın kızı Zeynep, " +
                            "Adanalı sevgilisiyle evlenmeye karar verince Fikret, kendini bir anda hayatının rolünü oynarken bulur.",
                            FilmUcreti = 25,
                            FilmFotografi = "~/images/Filmler/ailearasinda.jpg",
                            FilmBaslamaSaati1 = "19:30",
                            FilmBaslamaSaati2 = "21:45",
                            FilmBaslamaSaati3="23:00",
                            SinemaId = 1,
                            YonetmenId = 2,
                            FilmKategorisi = FilmKategorisi.Komedi
                            //engin
                        },

                        new Film()
                        {
                            FilmAdi = "Vavien",
                            FilmHakkinda = "Vavien, Engin Günaydın ve Binnur Kaya'nın başrollerini oynadığı film. 18 Aralık 2009'da vizyona girmiştir. " +
                            "Yönetmenliğini Taylan Biraderler olarak bilinen Yağmur ve Durul Taylan yapmıştır. Çekimleri Tokat'ın Erbaa ilçesinde yapıldı.",
                            FilmUcreti = 19,
                            FilmFotografi = "~/images/Filmler/vavien.jpg",
                            FilmBaslamaSaati1 = "09:15",
                            FilmBaslamaSaati2 = "12:30",
                            FilmBaslamaSaati3="15:00",
                            SinemaId = 2,
                            YonetmenId = 1,
                            FilmKategorisi = FilmKategorisi.Dram
                            //engin,binnur
                        },

                        new Film()
                        {
                            FilmAdi = "GORA",
                            FilmHakkinda = "Senaryosunu Cem Yılmaz'ın yazdığı, yönetmenliğini Ömer Faruk Sorak'ın yaptığı, " +
                            "bilim kurgu ve komedi türlerindeki 2004 çıkışlı Türk filmidir.",
                            FilmUcreti = 30,
                            FilmFotografi = "~/images/Filmler/gora.jpg",
                            FilmBaslamaSaati1 = "20:30",
                            FilmBaslamaSaati2 = "21:45",
                            FilmBaslamaSaati3="23:15",
                            SinemaId = 5,
                            YonetmenId = 5,
                            FilmKategorisi = FilmKategorisi.Komedi
                            //cem, ozan
                        },

                        new Film()
                        {
                            FilmAdi = "Yahşi Batı",
                            FilmHakkinda = "Yahşi Batı, Ömer Faruk Sorak'ın yönetmenliğini," +
                            " Cem Yılmaz'ın ise senaristliğini ve başrolünü üstlendiği, 2009 yılı yapımı bir Türk komedi-western filmidir. Filmde Cem Yılmaz, " +
                            "1881 yılında ABD başkanına Padişah'ın hediyesini vermek üzere gönderilen Teşkilat-ı Mahsusa üyesi ajan Aziz Vefa'yı canlandırmıştır. ",
                            FilmUcreti = 27,
                            FilmFotografi = "~/images/Filmler/yahsibati.jpg",
                            FilmBaslamaSaati1 = "15:45",
                            FilmBaslamaSaati2 = "18:00",
                            FilmBaslamaSaati3="21:15",
                            SinemaId = 4,
                            YonetmenId = 5,
                            FilmKategorisi = FilmKategorisi.Aksiyon
                            //cem, ozan,zafer
                        },

                        new Film()
                        {
                            FilmAdi = "Unutursam Fısılda",
                            FilmHakkinda = "Eski bir pop sanatçısı Alzheimer hastalığına yakalanınca eski evine dönüp anılarının içinde dolanır." +
                            " Şöhrete nasıl kavustugunu düşünürken hayatını mahvettiğine inandığı ablasıyla yüzleşir.",
                            FilmUcreti = 30,
                            FilmFotografi = "~/images/Filmler/unutursamfisilda.jpg",
                            FilmBaslamaSaati1 = "12:00",
                            FilmBaslamaSaati2 = "15:30",
                            FilmBaslamaSaati3="17:45",
                            SinemaId = 2,
                            YonetmenId = 9,
                            FilmKategorisi = FilmKategorisi.Dram
                            //farah,mehmet
                        },

                        new Film()
                        {
                            FilmAdi = "Çiçero",
                            FilmHakkinda = "Çiçero, yönetmenliğini Serdar Akar'ın gerçekleştirdiği 2019 çıkışlı biyografik drama filmidir." +
                            " II. Dünya Savaşı öncesinde Nazi Almanyası adına casusluk yapan ve " +
                            "Çiçero lakabıyla tanınan Elyesa Bazna isimli Arnavut casusun hayatını anlatan filmin başrolünde Erdal Beşikçioğlu yer almaktadır.",
                            FilmUcreti = 35,
                            FilmFotografi = "~/images/Filmler/cicero.jpg",
                            FilmBaslamaSaati1 = "16:30",
                            FilmBaslamaSaati2 = "18:00",
                            FilmBaslamaSaati3="22:00",
                            SinemaId = 1,
                            YonetmenId = 3,
                            FilmKategorisi = FilmKategorisi.Aksiyon
                            //erdal
                        },

                        new Film()
                        {
                            FilmAdi = "Ahlat Ağacı",
                            FilmHakkinda = "Ahlat Ağacı, yönetmenliğini Nuri Bilge Ceylan'ın gerçekleştirdiği, dram türündeki, 2018 çıkışlı sinema filmidir. " +
                            "Nuri Bilge Ceylan, filmin senaryosunu da eşi Ebru Ceylan ve Akın Aksu ile birlikte yazdı.",
                            FilmUcreti = 35,
                            FilmFotografi = "~/images/Filmler/ahlatagaci.jpg",
                            FilmBaslamaSaati1 = "10:30",
                            FilmBaslamaSaati2 = "14:15",
                            FilmBaslamaSaati3="16:00",
                            SinemaId = 3,
                            YonetmenId = 1,
                            FilmKategorisi = FilmKategorisi.Dram
                            //dogu
                        },

                         new Film()
                         {
                            FilmAdi = "Ölümlü Dünya",
                            FilmHakkinda = "Nesillerdir Haydarpaşa Garı'nda Anadolu Tat Lokantası'nı " +
                            "işleten Mermer Ailesi nesilden nesile kiralık katildir ve" +
                            " dünya çapında etkin olan dev bir organizasyon için çalışmaktadır.",
                            FilmUcreti = 35,
                            FilmFotografi = "~/images/Filmler/olumludunya.jpg",
                            FilmBaslamaSaati1 = "15:30",
                            FilmBaslamaSaati2 = "17:45",
                            FilmBaslamaSaati3="19:00",
                            SinemaId = 2,
                            YonetmenId = 8,
                            FilmKategorisi = FilmKategorisi.Komedi
                            //dogu
                         },

                         new Film()
                         {
                            FilmAdi = "Dağ 2",
                            FilmHakkinda = "Teröristlerin elinden kurtulan iki arkadaş, " +
                            "Kuzey Irak'ta bir terör örgütü tarafından kaçırılan bir gazeteciyi kurtarmak için özel bir time katılırlar.",
                            FilmUcreti = 35,
                            FilmFotografi = "~/images/Filmler/dag2.jpg",
                            FilmBaslamaSaati1 = "20:30",
                            FilmBaslamaSaati2 = "21:45",
                            FilmBaslamaSaati3="23:15",
                            SinemaId = 5,
                            YonetmenId = 4,
                            FilmKategorisi = FilmKategorisi.Aksiyon
                            //cağlar
                         },

                         new Film()
                         {
                            FilmAdi = "Pek Yakında",
                            FilmHakkinda = "Eşini mutlu etmek isteyen Zafer kaçak DVD satmayi keser ve bir bilim kurgu filmi çekmeye çalışır." +
                            " Kabiliyetleri sınırlı olan bir ekiple yola çıkan Zafer'i eğlenceli ve duygusal bir macera beklemektedir.",
                            FilmUcreti = 35,
                            FilmFotografi = "~/images/Filmler/pekyakinda.jpg",
                            FilmBaslamaSaati1 = "13:15",
                            FilmBaslamaSaati2 = "16:45",
                            FilmBaslamaSaati3="23:30",
                            SinemaId = 4,
                            YonetmenId = 7,
                            FilmKategorisi = FilmKategorisi.Komedi
                            //cem, ozan, zafer
                         }


                    });
                    context.SaveChanges();
                }
              

                if (!context.FilmlerOyuncular.Any())
                {
                    context.FilmlerOyuncular.AddRange(new List<FilmOyuncu>()
                    {
                        new FilmOyuncu()
                        {
                            FilmId = 1,
                            OyuncuId = 1
                        },

                        new FilmOyuncu()
                        {
                            FilmId = 2,
                            OyuncuId = 1
                        },

                        new FilmOyuncu()
                        {
                            FilmId = 2,
                            OyuncuId = 2
                        },

                        new FilmOyuncu()
                        {
                            FilmId = 3,
                            OyuncuId = 3
                        },

                        new FilmOyuncu()
                        {
                            FilmId = 3,
                            OyuncuId = 5
                        },

                        new FilmOyuncu()
                        {
                            FilmId = 4,
                            OyuncuId = 3
                        },
                        new FilmOyuncu()
                        {
                            FilmId = 4,
                            OyuncuId = 4
                        },
                        new FilmOyuncu()
                        {
                            FilmId = 4,
                            OyuncuId = 5
                        },

                          new FilmOyuncu()
                        {
                            FilmId = 5,
                            OyuncuId = 6
                        },

                           new FilmOyuncu()
                        {
                            FilmId = 5,
                            OyuncuId = 7
                        },

                         new FilmOyuncu()
                        {
                            FilmId = 6,
                            OyuncuId = 8
                        },

                        new FilmOyuncu()
                        {
                            FilmId = 7,
                            OyuncuId = 10
                        },

                        new FilmOyuncu()
                        {
                            FilmId = 8,
                            OyuncuId = 10
                        },

                        new FilmOyuncu()
                        {
                            FilmId = 9,
                            OyuncuId = 9
                        },

                        new FilmOyuncu()
                        {
                            FilmId = 10,
                            OyuncuId = 3
                        },
                        new FilmOyuncu()
                        {
                            FilmId = 10,
                            OyuncuId = 4
                        },
                        new FilmOyuncu()
                        {
                            FilmId = 10,
                            OyuncuId = 5
                        },

                    });
                    context.SaveChanges();
                }
            }




            
        }
    
        public static async Task KullaniciVeRolEkle(IApplicationBuilder ab)
        {
            using(var scope = ab.ApplicationServices.CreateScope())
            {
                var rm = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if(!await rm.RoleExistsAsync(Roller.Admin))
                {
                    await rm.CreateAsync(new IdentityRole(Roller.Admin));
                }
                if (!await rm.RoleExistsAsync(Roller.Kullanici))
                {
                    await rm.CreateAsync(new IdentityRole(Roller.Kullanici));
                }


                var um = scope.ServiceProvider.GetRequiredService<UserManager<Kullanici>>();
                var admin = await um.FindByEmailAsync("g181210102@sakarya.edu.tr");
                if (admin == null)
                {
                    var adminOlustur = new Kullanici()
                    {
                        AdSoyad = "Admin",
                        UserName = "admin",
                        Email = "g181210102@sakarya.edu.tr",
                        EmailConfirmed = true                   
                    };
                    await um.CreateAsync(adminOlustur, "123");
                    await um.AddToRoleAsync(adminOlustur, Roller.Admin);
                }

                var kullanici = await um.FindByEmailAsync("gurkankaya@gmail.com");
                if (kullanici == null)
                {
                    var kullaniciOlustur = new Kullanici()
                    {
                        AdSoyad = "Gurkan Kaya",
                        UserName = "gurkankaya",
                        Email = "gurkankaya@gmail.com",
                        EmailConfirmed = true
                    };
                    await um.CreateAsync(kullaniciOlustur, "123");
                    await um.AddToRoleAsync(kullaniciOlustur, Roller.Kullanici);
                }
            }
        }
    }
}
