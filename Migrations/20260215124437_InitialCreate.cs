using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VillaAgency.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tittle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ReadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MapEmbedUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    LastLogin = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tittle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    BedRooms = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    Parking = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalFlatSpace = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    IsContractReady = table.Column<bool>(type: "bit", nullable: false),
                    PaymentProcess = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PropertyTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "app",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "app",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "app",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "app",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "app",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImages_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banners",
                columns: new[] { "Id", "Category", "CreatedDate", "Description", "DisplayOrder", "ImageUrl", "IsActive", "LinkedinUrl", "Tittle", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("c3d4e5f6-3333-3333-3333-000000000001"), "Toronto, Canada", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Discover the finest villas in the heart of Toronto with stunning architecture and modern amenities.", 1, "/assets/images/banner-01.jpg", true, "#", "Hurry! Get the Best Villa for you", null },
                    { new Guid("c3d4e5f6-3333-3333-3333-000000000002"), "Melbourne, Australia", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Explore premium villa options in Melbourne with world-class facilities.", 2, "/assets/images/banner-02.jpg", true, "#", "Be Quick! Get the best villa in town", null },
                    { new Guid("c3d4e5f6-3333-3333-3333-000000000003"), "Miami, South Florida", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Exclusive penthouses in Miami offering breathtaking ocean views.", 3, "/assets/images/banner-03.jpg", true, "#", "Act Now! Get the highest level penthouse", null }
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "Id", "Answer", "CreatedDate", "DisplayOrder", "IsActive", "Question", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d4e5f6a7-4444-4444-4444-000000000001"), "Get the best villa website template in HTML CSS and Bootstrap for your business. We provide you the best free CSS templates in the world. Please tell your friends about it.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, true, "Best useful links?", null },
                    { new Guid("d4e5f6a7-4444-4444-4444-000000000002"), "Dolor almesit amet, consectetur adipiscing elit, sed doesn't eiusmod tempor incididunt ut labore consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, true, "How does this work?", null },
                    { new Guid("d4e5f6a7-4444-4444-4444-000000000003"), "Dolor almesit amet, consectetur adipiscing elit, sed doesn't eiusmod tempor incididunt ut labore consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, true, "Why is Villa Agency the best?", null }
                });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-1111-1111-1111-000000000001"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Premium luxury villas with exclusive designs and amenities.", true, "Luxury Villa", null },
                    { new Guid("a1b2c3d4-1111-1111-1111-000000000002"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Modern apartments in prime locations with great city views.", true, "Apartment", null },
                    { new Guid("a1b2c3d4-1111-1111-1111-000000000003"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High-rise penthouses with panoramic views and top-tier finishes.", true, "Penthouse", null },
                    { new Guid("a1b2c3d4-1111-1111-1111-000000000004"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Contemporary condominiums with smart home features.", true, "Modern Condo", null },
                    { new Guid("a1b2c3d4-1111-1111-1111-000000000005"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Spacious villa houses with private gardens and pools.", true, "Villa House", null }
                });

            migrationBuilder.InsertData(
                schema: "app",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "019c330e-6c3e-753c-bd9b-7e2e7ad57c19", null, "User", "USER" },
                    { "019c330e-6c3e-7ace-aa53-1dfe8fda644f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "SiteSettings",
                columns: new[] { "Id", "Address", "CreatedDate", "Email", "IsActive", "MapEmbedUrl", "PhoneNumber", "SiteName", "UpdatedDate" },
                values: new object[] { new Guid("e5f6a7b8-5555-5555-5555-000000000001"), "Sunny Isles Beach, FL 33160", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "info@villa.co", true, "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d12469.776493332698!2d-80.14036379941481!3d25.907788681148624!2m3!1f357.26927939317244!2f20.870722720054623!3f0!3m2!1i1024!2i768!4f35!3m3!1m2!1s0x88d9add4b4ac788f%3A0xe77469d09480fcdb!2sSunny%20Isles%20Beach!5e1!3m2!1sen!2sth!4v1642869952544!5m2!1sen!2sth", "010-020-0340", "Villa Agency", null });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Area", "Bathrooms", "BedRooms", "City", "CreatedDate", "Description", "Floor", "IsActive", "IsContractReady", "IsFeatured", "Parking", "PaymentProcess", "Price", "PropertyTypeId", "State", "Tittle", "TotalFlatSpace", "UpdatedDate", "VideoUrl", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("b2c3d4e5-2222-2222-2222-000000000001"), "18 Old Street", 545m, 8, 8, "Miami", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A stunning luxury villa located at 18 Old Street Miami. Features 8 bedrooms, 8 bathrooms, and expansive living areas with modern finishes throughout.", 3, true, true, true, "6 spots", "Bank", 2264000m, new Guid("a1b2c3d4-1111-1111-1111-000000000001"), "OR", "Luxury Villa in Miami", 545m, null, "https://youtube.com", "97219" },
                    { new Guid("b2c3d4e5-2222-2222-2222-000000000002"), "54 New Street", 450m, 5, 6, "Florida", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "A beautiful luxury villa at 54 New Street Florida. Features 6 bedrooms, 5 bathrooms with gorgeous garden views and premium interior design.", 3, true, true, true, "8 spots", "Bank", 1180000m, new Guid("a1b2c3d4-1111-1111-1111-000000000001"), "OR", "Luxury Villa in Florida", 450m, null, "https://youtube.com", "27001" },
                    { new Guid("b2c3d4e5-2222-2222-2222-000000000003"), "26 Mid Street", 225m, 4, 5, "Portland", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "An elegant luxury villa at 26 Mid Street Portland. Features 5 bedrooms, 4 bathrooms with a spacious layout and premium finishes.", 3, true, true, true, "10 spots", "Bank", 1460000m, new Guid("a1b2c3d4-1111-1111-1111-000000000001"), "OR", "Luxury Villa in Portland", 225m, null, "https://youtube.com", "38540" },
                    { new Guid("b2c3d4e5-2222-2222-2222-000000000004"), "12 Hope Street", 125m, 3, 4, "Portland", new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "A stylish apartment at 12 Hope Street Portland. Features 4 bedrooms, 3 bathrooms on the 25th floor with amazing city panorama.", 25, true, true, false, "2 cars", "Bank", 584500m, new Guid("a1b2c3d4-1111-1111-1111-000000000002"), "OR", "Modern Apartment in Portland", 185m, null, "https://youtube.com", "12650" },
                    { new Guid("b2c3d4e5-2222-2222-2222-000000000005"), "34 Hope Street", 180m, 4, 4, "Portland", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "A premium penthouse at 34 Hope Street Portland. Features 4 bedrooms, 4 bathrooms on the 38th floor with stunning skyline views.", 38, true, true, false, "2 cars", "Bank", 925600m, new Guid("a1b2c3d4-1111-1111-1111-000000000003"), "OR", "Premium Penthouse in Portland", 320m, null, "https://youtube.com", "42680" },
                    { new Guid("b2c3d4e5-2222-2222-2222-000000000006"), "22 Hope Street", 165m, 2, 3, "Portland", new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), "A contemporary condo at 22 Hope Street Portland. Features 3 bedrooms, 2 bathrooms with smart home technology and modern design.", 26, true, true, false, "3 cars", "Bank", 450000m, new Guid("a1b2c3d4-1111-1111-1111-000000000004"), "OR", "Modern Condo in Portland", 165m, null, "https://youtube.com", "16540" },
                    { new Guid("b2c3d4e5-2222-2222-2222-000000000007"), "14 Mid Street", 550m, 8, 8, "Miami", new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), "A grand luxury villa at 14 Mid Street Miami. Features 8 bedrooms, 8 bathrooms with expansive 550m2 living area and private pool.", 3, true, true, false, "12 spots", "Bank", 980000m, new Guid("a1b2c3d4-1111-1111-1111-000000000001"), "OR", "Luxury Villa in Miami Beach", 550m, null, "https://youtube.com", "36450" },
                    { new Guid("b2c3d4e5-2222-2222-2222-000000000008"), "26 Old Street", 380m, 15, 12, "Miami", new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), "An exclusive luxury villa at 26 Old Street Miami. Features 12 bedrooms, 15 bathrooms, offering the ultimate luxury living experience.", 3, true, true, false, "14 spots", "Bank", 1520000m, new Guid("a1b2c3d4-1111-1111-1111-000000000001"), "OR", "Exclusive Villa in Miami", 380m, null, "https://youtube.com", "12870" },
                    { new Guid("b2c3d4e5-2222-2222-2222-000000000009"), "34 New Street", 860m, 12, 10, "Miami", new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), "The most prestigious luxury villa at 34 New Street Miami. Features 10 bedrooms, 12 bathrooms with 860m2 of pure elegance.", 3, true, true, true, "10 spots", "Bank", 3145000m, new Guid("a1b2c3d4-1111-1111-1111-000000000001"), "OR", "Grand Villa in Miami", 860m, null, "https://youtube.com", "24650" }
                });

            migrationBuilder.InsertData(
                table: "PropertyImages",
                columns: new[] { "Id", "CreatedDate", "DisplayOrder", "ImageUrl", "IsActive", "IsMain", "PropertyId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000001"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/assets/images/property-01.jpg", true, true, new Guid("b2c3d4e5-2222-2222-2222-000000000001"), null },
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000002"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/assets/images/property-02.jpg", true, true, new Guid("b2c3d4e5-2222-2222-2222-000000000002"), null },
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000003"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/assets/images/property-03.jpg", true, true, new Guid("b2c3d4e5-2222-2222-2222-000000000003"), null },
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000004"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/assets/images/property-04.jpg", true, true, new Guid("b2c3d4e5-2222-2222-2222-000000000004"), null },
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000005"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/assets/images/property-05.jpg", true, true, new Guid("b2c3d4e5-2222-2222-2222-000000000005"), null },
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000006"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/assets/images/property-06.jpg", true, true, new Guid("b2c3d4e5-2222-2222-2222-000000000006"), null },
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000007"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/assets/images/property-03.jpg", true, true, new Guid("b2c3d4e5-2222-2222-2222-000000000007"), null },
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000008"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/assets/images/property-02.jpg", true, true, new Guid("b2c3d4e5-2222-2222-2222-000000000008"), null },
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000009"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "/assets/images/property-01.jpg", true, true, new Guid("b2c3d4e5-2222-2222-2222-000000000009"), null },
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000010"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "/assets/images/deal-01.jpg", true, false, new Guid("b2c3d4e5-2222-2222-2222-000000000004"), null },
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000011"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "/assets/images/deal-02.jpg", true, false, new Guid("b2c3d4e5-2222-2222-2222-000000000002"), null },
                    { new Guid("f1a1a1a1-0001-0001-0001-000000000012"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "/assets/images/deal-03.jpg", true, false, new Guid("b2c3d4e5-2222-2222-2222-000000000005"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_PropertyId",
                table: "PropertyImages",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "app",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "app",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "app",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "app",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "app",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "app",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "app",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "PropertyImages");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "app");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "app");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "app");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "app");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "app");

            migrationBuilder.DropTable(
                name: "PropertyTypes");
        }
    }
}
