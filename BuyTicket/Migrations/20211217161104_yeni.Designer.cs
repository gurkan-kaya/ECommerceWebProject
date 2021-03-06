// <auto-generated />
using BuyTicket.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuyTicket.Migrations
{
    [DbContext(typeof(BiletDbContext))]
    [Migration("20211217161104_yeni")]
    partial class yeni
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BuyTicket.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FilmAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmBaslamaSaati1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmBaslamaSaati2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmBaslamaSaati3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmFotografi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmHakkinda")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FilmKategorisi")
                        .HasColumnType("int");

                    b.Property<float>("FilmUcreti")
                        .HasColumnType("real");

                    b.Property<int>("SinemaId")
                        .HasColumnType("int");

                    b.Property<int>("YonetmenId")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.HasIndex("SinemaId");

                    b.HasIndex("YonetmenId");

                    b.ToTable("Filmler");
                });

            modelBuilder.Entity("BuyTicket.Models.FilmOyuncu", b =>
                {
                    b.Property<int>("OyuncuId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("OyuncuId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmlerOyuncular");
                });

            modelBuilder.Entity("BuyTicket.Models.Oyuncu", b =>
                {
                    b.Property<int>("OyuncuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OyuncuAdSoyad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("OyuncuFotografi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OyuncuHakkinda")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("OyuncuId");

                    b.ToTable("Oyuncular");
                });

            modelBuilder.Entity("BuyTicket.Models.Sinema", b =>
                {
                    b.Property<int>("SinemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SinemaAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SinemaFotografi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SinemaHakkinda")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("SinemaId");

                    b.ToTable("Sinemalar");
                });

            modelBuilder.Entity("BuyTicket.Models.Siparis", b =>
                {
                    b.Property<int>("SiparisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KullaniciEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiparisId");

                    b.ToTable("Siparisler");
                });

            modelBuilder.Entity("BuyTicket.Models.SiparisFilm", b =>
                {
                    b.Property<int>("SiparisFilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("Fiyat")
                        .HasColumnType("int");

                    b.Property<int>("SiparisId")
                        .HasColumnType("int");

                    b.HasKey("SiparisFilmId");

                    b.HasIndex("FilmId");

                    b.HasIndex("SiparisId");

                    b.ToTable("SiparisFilmler");
                });

            modelBuilder.Entity("BuyTicket.Models.Yonetmen", b =>
                {
                    b.Property<int>("YonetmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("YonetmenAdSoyad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("YonetmenFotografi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YonetmenHakkinda")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("YonetmenId");

                    b.ToTable("Yonetmenler");
                });

            modelBuilder.Entity("BuyTicket.Models.Film", b =>
                {
                    b.HasOne("BuyTicket.Models.Sinema", "Sinema")
                        .WithMany("Filmler")
                        .HasForeignKey("SinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuyTicket.Models.Yonetmen", "Yonetmen")
                        .WithMany("Filmler")
                        .HasForeignKey("YonetmenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sinema");

                    b.Navigation("Yonetmen");
                });

            modelBuilder.Entity("BuyTicket.Models.FilmOyuncu", b =>
                {
                    b.HasOne("BuyTicket.Models.Film", "Film")
                        .WithMany("FilmlerOyuncular")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuyTicket.Models.Oyuncu", "Oyuncu")
                        .WithMany("FilmlerOyuncular")
                        .HasForeignKey("OyuncuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Oyuncu");
                });

            modelBuilder.Entity("BuyTicket.Models.SiparisFilm", b =>
                {
                    b.HasOne("BuyTicket.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuyTicket.Models.Siparis", "Siparis")
                        .WithMany("SiparisFilmler")
                        .HasForeignKey("SiparisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Siparis");
                });

            modelBuilder.Entity("BuyTicket.Models.Film", b =>
                {
                    b.Navigation("FilmlerOyuncular");
                });

            modelBuilder.Entity("BuyTicket.Models.Oyuncu", b =>
                {
                    b.Navigation("FilmlerOyuncular");
                });

            modelBuilder.Entity("BuyTicket.Models.Sinema", b =>
                {
                    b.Navigation("Filmler");
                });

            modelBuilder.Entity("BuyTicket.Models.Siparis", b =>
                {
                    b.Navigation("SiparisFilmler");
                });

            modelBuilder.Entity("BuyTicket.Models.Yonetmen", b =>
                {
                    b.Navigation("Filmler");
                });
#pragma warning restore 612, 618
        }
    }
}
