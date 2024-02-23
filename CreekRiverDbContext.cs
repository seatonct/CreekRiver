using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // seed data with campsite types
    modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
    {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
    });

    modelBuilder.Entity<Campsite>().HasData(new Campsite[]
    {
        new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
        new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Cousin Eddy's Fun Town", ImageUrl="https://www.paragoncasinoresort.com/wp-content/uploads/2021/01/rv-park-hero.jpg"},
        new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "Bedrock", ImageUrl="https://static.wikia.nocookie.net/flinstones/images/1/16/Bedrock_in_The_Flintstones_and_WWE_-_StoneAge_SmackDown%21.png/revision/latest?cb=20200614065155"},
        new Campsite {Id = 4, CampsiteTypeId = 4, Nickname = "Margaritaville", ImageUrl="https://cdn.europosters.eu/image/750/posters/paradise-hammock-i8013.jpg"},
        new Campsite {Id = 5, CampsiteTypeId = 1, Nickname = "Mountain View", ImageUrl="https://i.dailymail.co.uk/i/pix/2011/05/26/article-1391089-0C47717600000578-155_1024x615_large.jpg"},
        new Campsite {Id = 6, CampsiteTypeId = 4, Nickname = "Sky Town", ImageUrl="https://worth-seeing.com/wp-content/uploads/2016/11/Monte-Piana.jpg"}
    });

    modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
    {
        new UserProfile {Id = 1, FirstName = "Joe", LastName = "Dirt", Email = "joedirt@thegunshow.net"}
    });

    modelBuilder.Entity<Reservation>().HasData(new Reservation[]
    {
        new Reservation {Id = 1, CampsiteId = 2, UserProfileId = 1, CheckinDate = new DateTime(2024, 3, 11), CheckoutDate = new DateTime(2024, 3, 14)}
    });
}
}