using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VillaAgency.Models.Entities;

namespace VillaAgency.Data;

public static class SeedData
{
    // ── PropertyType GUIDs ──
    private static readonly Guid LuxuryVillaTypeId  = Guid.Parse("a1b2c3d4-1111-1111-1111-000000000001");
    private static readonly Guid ApartmentTypeId    = Guid.Parse("a1b2c3d4-1111-1111-1111-000000000002");
    private static readonly Guid PenthouseTypeId    = Guid.Parse("a1b2c3d4-1111-1111-1111-000000000003");
    private static readonly Guid ModernCondoTypeId  = Guid.Parse("a1b2c3d4-1111-1111-1111-000000000004");
    private static readonly Guid VillaHouseTypeId   = Guid.Parse("a1b2c3d4-1111-1111-1111-000000000005");

    // ── Property GUIDs ──
    private static readonly Guid Prop1Id = Guid.Parse("b2c3d4e5-2222-2222-2222-000000000001");
    private static readonly Guid Prop2Id = Guid.Parse("b2c3d4e5-2222-2222-2222-000000000002");
    private static readonly Guid Prop3Id = Guid.Parse("b2c3d4e5-2222-2222-2222-000000000003");
    private static readonly Guid Prop4Id = Guid.Parse("b2c3d4e5-2222-2222-2222-000000000004");
    private static readonly Guid Prop5Id = Guid.Parse("b2c3d4e5-2222-2222-2222-000000000005");
    private static readonly Guid Prop6Id = Guid.Parse("b2c3d4e5-2222-2222-2222-000000000006");
    private static readonly Guid Prop7Id = Guid.Parse("b2c3d4e5-2222-2222-2222-000000000007");
    private static readonly Guid Prop8Id = Guid.Parse("b2c3d4e5-2222-2222-2222-000000000008");
    private static readonly Guid Prop9Id = Guid.Parse("b2c3d4e5-2222-2222-2222-000000000009");

    // ── Banner GUIDs ──
    private static readonly Guid Banner1Id = Guid.Parse("c3d4e5f6-3333-3333-3333-000000000001");
    private static readonly Guid Banner2Id = Guid.Parse("c3d4e5f6-3333-3333-3333-000000000002");
    private static readonly Guid Banner3Id = Guid.Parse("c3d4e5f6-3333-3333-3333-000000000003");

    // ── FAQ GUIDs ──
    private static readonly Guid Faq1Id = Guid.Parse("d4e5f6a7-4444-4444-4444-000000000001");
    private static readonly Guid Faq2Id = Guid.Parse("d4e5f6a7-4444-4444-4444-000000000002");
    private static readonly Guid Faq3Id = Guid.Parse("d4e5f6a7-4444-4444-4444-000000000003");

    // ── SiteSetting GUID ──
    private static readonly Guid SiteSetting1Id = Guid.Parse("e5f6a7b8-5555-5555-5555-000000000001");

    public static void Seed(ModelBuilder builder)
    {
        SeedPropertyTypes(builder);
        SeedBanners(builder);
        SeedProperties(builder);
        SeedPropertyImages(builder);
        SeedFAQs(builder);
        SeedSiteSettings(builder);
        SeedUsers(builder);
    }

    // ═══════════════════════════════════════════
    //  PROPERTY TYPES
    // ═══════════════════════════════════════════
    private static void SeedPropertyTypes(ModelBuilder builder)
    {
        builder.Entity<PropertyType>().HasData(
            new PropertyType
            {
                Id = LuxuryVillaTypeId,
                Name = "Luxury Villa",
                Description = "Premium luxury villas with exclusive designs and amenities.",
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            new PropertyType
            {
                Id = ApartmentTypeId,
                Name = "Apartment",
                Description = "Modern apartments in prime locations with great city views.",
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            new PropertyType
            {
                Id = PenthouseTypeId,
                Name = "Penthouse",
                Description = "High-rise penthouses with panoramic views and top-tier finishes.",
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            new PropertyType
            {
                Id = ModernCondoTypeId,
                Name = "Modern Condo",
                Description = "Contemporary condominiums with smart home features.",
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            new PropertyType
            {
                Id = VillaHouseTypeId,
                Name = "Villa House",
                Description = "Spacious villa houses with private gardens and pools.",
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            }
        );
    }

    // ═══════════════════════════════════════════
    //  BANNERS  (3 adet – template carousel)
    // ═══════════════════════════════════════════
    private static void SeedBanners(ModelBuilder builder)
    {
        builder.Entity<Banner>().HasData(
            new Banner
            {
                Id = Banner1Id,
                Tittle = "Hurry! Get the Best Villa for you",
                Category = "Toronto, Canada",
                Description = "Discover the finest villas in the heart of Toronto with stunning architecture and modern amenities.",
                ImageUrl = "/assets/images/banner-01.jpg",
                DisplayOrder = 1,
                LinkedinUrl = "#",
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            new Banner
            {
                Id = Banner2Id,
                Tittle = "Be Quick! Get the best villa in town",
                Category = "Melbourne, Australia",
                Description = "Explore premium villa options in Melbourne with world-class facilities.",
                ImageUrl = "/assets/images/banner-02.jpg",
                DisplayOrder = 2,
                LinkedinUrl = "#",
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            new Banner
            {
                Id = Banner3Id,
                Tittle = "Act Now! Get the highest level penthouse",
                Category = "Miami, South Florida",
                Description = "Exclusive penthouses in Miami offering breathtaking ocean views.",
                ImageUrl = "/assets/images/banner-03.jpg",
                DisplayOrder = 3,
                LinkedinUrl = "#",
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            }
        );
    }

    // ═══════════════════════════════════════════
    //  PROPERTIES  (9 adet – template'teki tüm property'ler)
    // ═══════════════════════════════════════════
    private static void SeedProperties(ModelBuilder builder)
    {
        builder.Entity<Property>().HasData(
            // 1 – Luxury Villa – $2,264,000
            new Property
            {
                Id = Prop1Id,
                Tittle = "Luxury Villa in Miami",
                Description = "A stunning luxury villa located at 18 Old Street Miami. Features 8 bedrooms, 8 bathrooms, and expansive living areas with modern finishes throughout.",
                Price = 2264000m,
                Address = "18 Old Street",
                City = "Miami",
                State = "OR",
                ZipCode = "97219",
                Bathrooms = 8,
                BedRooms = 8,
                Area = 545m,
                Floor = 3,
                Parking = "6 spots",
                TotalFlatSpace = 545m,
                IsFeatured = true,
                IsContractReady = true,
                PaymentProcess = "Bank",
                VideoUrl = "https://youtube.com",
                PropertyTypeId = LuxuryVillaTypeId,
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            // 2 – Luxury Villa – $1,180,000
            new Property
            {
                Id = Prop2Id,
                Tittle = "Luxury Villa in Florida",
                Description = "A beautiful luxury villa at 54 New Street Florida. Features 6 bedrooms, 5 bathrooms with gorgeous garden views and premium interior design.",
                Price = 1180000m,
                Address = "54 New Street",
                City = "Florida",
                State = "OR",
                ZipCode = "27001",
                Bathrooms = 5,
                BedRooms = 6,
                Area = 450m,
                Floor = 3,
                Parking = "8 spots",
                TotalFlatSpace = 450m,
                IsFeatured = true,
                IsContractReady = true,
                PaymentProcess = "Bank",
                VideoUrl = "https://youtube.com",
                PropertyTypeId = LuxuryVillaTypeId,
                CreatedDate = new DateTime(2025, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            // 3 – Luxury Villa – $1,460,000
            new Property
            {
                Id = Prop3Id,
                Tittle = "Luxury Villa in Portland",
                Description = "An elegant luxury villa at 26 Mid Street Portland. Features 5 bedrooms, 4 bathrooms with a spacious layout and premium finishes.",
                Price = 1460000m,
                Address = "26 Mid Street",
                City = "Portland",
                State = "OR",
                ZipCode = "38540",
                Bathrooms = 4,
                BedRooms = 5,
                Area = 225m,
                Floor = 3,
                Parking = "10 spots",
                TotalFlatSpace = 225m,
                IsFeatured = true,
                IsContractReady = true,
                PaymentProcess = "Bank",
                VideoUrl = "https://youtube.com",
                PropertyTypeId = LuxuryVillaTypeId,
                CreatedDate = new DateTime(2025, 1, 3, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            // 4 – Apartment – $584,500
            new Property
            {
                Id = Prop4Id,
                Tittle = "Modern Apartment in Portland",
                Description = "A stylish apartment at 12 Hope Street Portland. Features 4 bedrooms, 3 bathrooms on the 25th floor with amazing city panorama.",
                Price = 584500m,
                Address = "12 Hope Street",
                City = "Portland",
                State = "OR",
                ZipCode = "12650",
                Bathrooms = 3,
                BedRooms = 4,
                Area = 125m,
                Floor = 25,
                Parking = "2 cars",
                TotalFlatSpace = 185m,
                IsFeatured = false,
                IsContractReady = true,
                PaymentProcess = "Bank",
                VideoUrl = "https://youtube.com",
                PropertyTypeId = ApartmentTypeId,
                CreatedDate = new DateTime(2025, 1, 4, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            // 5 – Penthouse – $925,600
            new Property
            {
                Id = Prop5Id,
                Tittle = "Premium Penthouse in Portland",
                Description = "A premium penthouse at 34 Hope Street Portland. Features 4 bedrooms, 4 bathrooms on the 38th floor with stunning skyline views.",
                Price = 925600m,
                Address = "34 Hope Street",
                City = "Portland",
                State = "OR",
                ZipCode = "42680",
                Bathrooms = 4,
                BedRooms = 4,
                Area = 180m,
                Floor = 38,
                Parking = "2 cars",
                TotalFlatSpace = 320m,
                IsFeatured = false,
                IsContractReady = true,
                PaymentProcess = "Bank",
                VideoUrl = "https://youtube.com",
                PropertyTypeId = PenthouseTypeId,
                CreatedDate = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            // 6 – Modern Condo – $450,000
            new Property
            {
                Id = Prop6Id,
                Tittle = "Modern Condo in Portland",
                Description = "A contemporary condo at 22 Hope Street Portland. Features 3 bedrooms, 2 bathrooms with smart home technology and modern design.",
                Price = 450000m,
                Address = "22 Hope Street",
                City = "Portland",
                State = "OR",
                ZipCode = "16540",
                Bathrooms = 2,
                BedRooms = 3,
                Area = 165m,
                Floor = 26,
                Parking = "3 cars",
                TotalFlatSpace = 165m,
                IsFeatured = false,
                IsContractReady = true,
                PaymentProcess = "Bank",
                VideoUrl = "https://youtube.com",
                PropertyTypeId = ModernCondoTypeId,
                CreatedDate = new DateTime(2025, 1, 6, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            // 7 – Luxury Villa – $980,000
            new Property
            {
                Id = Prop7Id,
                Tittle = "Luxury Villa in Miami Beach",
                Description = "A grand luxury villa at 14 Mid Street Miami. Features 8 bedrooms, 8 bathrooms with expansive 550m2 living area and private pool.",
                Price = 980000m,
                Address = "14 Mid Street",
                City = "Miami",
                State = "OR",
                ZipCode = "36450",
                Bathrooms = 8,
                BedRooms = 8,
                Area = 550m,
                Floor = 3,
                Parking = "12 spots",
                TotalFlatSpace = 550m,
                IsFeatured = false,
                IsContractReady = true,
                PaymentProcess = "Bank",
                VideoUrl = "https://youtube.com",
                PropertyTypeId = LuxuryVillaTypeId,
                CreatedDate = new DateTime(2025, 1, 7, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            // 8 – Luxury Villa – $1,520,000
            new Property
            {
                Id = Prop8Id,
                Tittle = "Exclusive Villa in Miami",
                Description = "An exclusive luxury villa at 26 Old Street Miami. Features 12 bedrooms, 15 bathrooms, offering the ultimate luxury living experience.",
                Price = 1520000m,
                Address = "26 Old Street",
                City = "Miami",
                State = "OR",
                ZipCode = "12870",
                Bathrooms = 15,
                BedRooms = 12,
                Area = 380m,
                Floor = 3,
                Parking = "14 spots",
                TotalFlatSpace = 380m,
                IsFeatured = false,
                IsContractReady = true,
                PaymentProcess = "Bank",
                VideoUrl = "https://youtube.com",
                PropertyTypeId = LuxuryVillaTypeId,
                CreatedDate = new DateTime(2025, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            // 9 – Luxury Villa – $3,145,000
            new Property
            {
                Id = Prop9Id,
                Tittle = "Grand Villa in Miami",
                Description = "The most prestigious luxury villa at 34 New Street Miami. Features 10 bedrooms, 12 bathrooms with 860m2 of pure elegance.",
                Price = 3145000m,
                Address = "34 New Street",
                City = "Miami",
                State = "OR",
                ZipCode = "24650",
                Bathrooms = 12,
                BedRooms = 10,
                Area = 860m,
                Floor = 3,
                Parking = "10 spots",
                TotalFlatSpace = 860m,
                IsFeatured = true,
                IsContractReady = true,
                PaymentProcess = "Bank",
                VideoUrl = "https://youtube.com",
                PropertyTypeId = LuxuryVillaTypeId,
                CreatedDate = new DateTime(2025, 1, 9, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            }
        );
    }

    // ═══════════════════════════════════════════
    //  PROPERTY IMAGES
    // ═══════════════════════════════════════════
    private static void SeedPropertyImages(ModelBuilder builder)
    {
        builder.Entity<PropertyImage>().HasData(
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000001"), PropertyId = Prop1Id, ImageUrl = "/assets/images/property-01.jpg", IsMain = true, DisplayOrder = 1, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false },
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000002"), PropertyId = Prop2Id, ImageUrl = "/assets/images/property-02.jpg", IsMain = true, DisplayOrder = 1, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false },
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000003"), PropertyId = Prop3Id, ImageUrl = "/assets/images/property-03.jpg", IsMain = true, DisplayOrder = 1, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false },
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000004"), PropertyId = Prop4Id, ImageUrl = "/assets/images/property-04.jpg", IsMain = true, DisplayOrder = 1, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false },
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000005"), PropertyId = Prop5Id, ImageUrl = "/assets/images/property-05.jpg", IsMain = true, DisplayOrder = 1, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false },
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000006"), PropertyId = Prop6Id, ImageUrl = "/assets/images/property-06.jpg", IsMain = true, DisplayOrder = 1, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false },
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000007"), PropertyId = Prop7Id, ImageUrl = "/assets/images/property-03.jpg", IsMain = true, DisplayOrder = 1, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false },
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000008"), PropertyId = Prop8Id, ImageUrl = "/assets/images/property-02.jpg", IsMain = true, DisplayOrder = 1, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false },
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000009"), PropertyId = Prop9Id, ImageUrl = "/assets/images/property-01.jpg", IsMain = true, DisplayOrder = 1, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false },
            // Deal images (ek görseller)
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000010"), PropertyId = Prop4Id, ImageUrl = "/assets/images/deal-01.jpg", IsMain = false, DisplayOrder = 2, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false },
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000011"), PropertyId = Prop2Id, ImageUrl = "/assets/images/deal-02.jpg", IsMain = false, DisplayOrder = 2, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false },
            new PropertyImage { Id = Guid.Parse("f1a1a1a1-0001-0001-0001-000000000012"), PropertyId = Prop5Id, ImageUrl = "/assets/images/deal-03.jpg", IsMain = false, DisplayOrder = 2, CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, IsDeleted = false }
        );
    }

    // ═══════════════════════════════════════════
    //  FAQs  (3 adet – Featured accordion)
    // ═══════════════════════════════════════════
    private static void SeedFAQs(ModelBuilder builder)
    {
        builder.Entity<FAQ>().HasData(
            new FAQ
            {
                Id = Faq1Id,
                Question = "Best useful links?",
                Answer = "Get the best villa website template in HTML CSS and Bootstrap for your business. We provide you the best free CSS templates in the world. Please tell your friends about it.",
                DisplayOrder = 1,
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            new FAQ
            {
                Id = Faq2Id,
                Question = "How does this work?",
                Answer = "Dolor almesit amet, consectetur adipiscing elit, sed doesn't eiusmod tempor incididunt ut labore consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                DisplayOrder = 2,
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            },
            new FAQ
            {
                Id = Faq3Id,
                Question = "Why is Villa Agency the best?",
                Answer = "Dolor almesit amet, consectetur adipiscing elit, sed doesn't eiusmod tempor incididunt ut labore consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                DisplayOrder = 3,
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            }
        );
    }

    // ═══════════════════════════════════════════
    //  SITE SETTINGS
    // ═══════════════════════════════════════════
    private static void SeedSiteSettings(ModelBuilder builder)
    {
        builder.Entity<SiteSetting>().HasData(
            new SiteSetting
            {
                Id = SiteSetting1Id,
                PhoneNumber = "010-020-0340",
                Email = "info@villa.co",
                Address = "Sunny Isles Beach, FL 33160",
                MapEmbedUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d12469.776493332698!2d-80.14036379941481!3d25.907788681148624!2m3!1f357.26927939317244!2f20.870722720054623!3f0!3m2!1i1024!2i768!4f35!3m3!1m2!1s0x88d9add4b4ac788f%3A0xe77469d09480fcdb!2sSunny%20Isles%20Beach!5e1!3m2!1sen!2sth!4v1642869952544!5m2!1sen!2sth",
                VideoUrl = "https://www.youtube.com/watch?v=7HKq20ihNAU",
                SiteName = "Villa Agency",
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true,
                IsDeleted = false
            }
        );
    }

    // Seed(ModelBuilder builder) içine ekle:
    // SeedUsers(builder); 

    private static void SeedUsers(ModelBuilder builder)
    {
        var adminRoleId = "019c330e-6c3e-7ace-aa53-1dfe8fda644f"; // AppDbContext ile aynı olmalı
        var adminUserId = "019c330e-6c3e-7ace-aa53-1dfe8fda644e"; // Yeni bir ID

        var hasher = new PasswordHasher<AppilcationUser>();

        // 1. Admin Kullanıcısı
        var adminUser = new AppilcationUser
        {
            Id = adminUserId,
            UserName = "admin@villa.co",
            NormalizedUserName = "ADMIN@VILLA.CO",
            Email = "admin@villa.co",
            NormalizedEmail = "ADMIN@VILLA.CO",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            FirstName = "Admin",
            LastName = "User"
        };

        // Şifre: Admin123!
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

        builder.Entity<AppilcationUser>().HasData(adminUser);

        // 2. Rol Ataması (Admin Rolü)
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = adminRoleId,
            UserId = adminUserId
        });
    }


}
