using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Passwrod = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    IsBestSeller = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoicesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoicesDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoicesDetails_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicesDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<decimal>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "a34ed361-5e5c-4183-ad29-cc2b3d628757", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "d7f19512-c8fa-4c32-8059-4c4d8f9af28d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "ImagePath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 100, 0, "fb370491-b4bb-4236-9afc-6881a782515f", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(610), "appuser@gmail.com", false, null, false, null, null, null, "laksjdflaksj", null, false, null, false, "appuser@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "ImagePath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 101, 0, "2da40b52-b150-41f3-94a2-3344fe06b15a", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(654), "appuser2@gmail.com", false, null, false, null, null, null, "laksjdflaksj", null, false, null, false, "appuser2@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "ImagePath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 102, 0, "b3600ccc-0f63-4b12-8996-7d51644ea573", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(683), "appuser3@gmail.com", false, null, false, null, null, null, "laksjdflaksj", null, false, null, false, "appuser3@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "ImagePath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 103, 0, "8918c073-7845-4e99-88f5-c47e47c27568", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(706), "appuser4@gmail.com", false, null, false, null, null, null, "laksjdflaksj", null, false, null, false, "appuser4@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "ImagePath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 104, 0, "741a677c-4f3a-467c-aaa2-27ec16ad0586", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(727), "appuser5@gmail.com", false, null, false, null, null, null, "laksjdflaksj", null, false, null, false, "appuse54@gmail.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "Path" },
                values: new object[] { 1, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(31), "Electronices", "category_Fuji_Dash_Electronics_1x._SY304_CB432774322_.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "Path" },
                values: new object[] { 2, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(64), "Computers", "category-Fuji_Dash_PC_1x._SY304_CB431800965_.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "Path" },
                values: new object[] { 3, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(68), "Games", "category-games_Fuji_Desktop_Dash_Kindle_1x._SY304_CB639752818_.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "Path" },
                values: new object[] { 4, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(71), "Pets", "category-pets_Fuji_Dash_Pets_1X._SY304_CB639746743_.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 1, 1, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(218), true, "Sceptre 24 Professional Thin 75Hz 1080p LED Monitor 2x HDMI VGA Build-in Speakers, Machine Black (E248W-19203R Series)", "electronics-laptop_71rXSVqET9L._AC_UL320_.jpg", 200m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 2, 1, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(229), true, "Mobile", "electronics-mobile_81AeiqxHkwL._AC_UL320_.jpg", 100m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 3, 1, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(234), true, "Printer", "electronics-printer_61UdeL7aO-L._AC_UL320_.jpg", 400m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 4, 1, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(240), true, "EarPods", "electronices-headphones_7120GgUKj3L._AC_UL320_.jpg", 15m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 5, 1, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(246), true, "Batteries", "electronics-batteries_81ZnAYiX5sL._AC_UL320_.jpg", 5m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 6, 1, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(255), true, "Pen", "electronics-pen_21SPDoiRuGL._AC_UL320_.jpg", 250m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 7, 1, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(259), false, "Usb", "electronics-usb_71wrIZujPIL._AC_UL320_.jpg", 25m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 8, 2, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(263), true, "Player", "computers-player_71E4InwfcPL._AC_UL320_.jpg", 350m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 9, 3, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(267), true, "Computer", "games-controller_61X3uV04ztL._AC_UL320_.jpg", 25m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 10, 3, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(270), false, "Computer", "games-vr_61tE7IcuLmL._AC_UL320_.jpg", 90m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 11, 3, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(274), true, "Computer", "games-xbox_61JGKhqxHxL._AC_UL320_.jpg", 150m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsBestSeller", "Name", "Path", "Price" },
                values: new object[] { 12, 4, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(278), false, "Cat", "pets-cat_61ng2AAFZRL._AC_UL320_.jpg", 400m });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Text" },
                values: new object[] { 1, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1223), 1, "24 Ultra slim profile " });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Text" },
                values: new object[] { 2, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1228), 1, "Slim bezel with thin chassis. Power Range (V, A, Hz)- AC-DC Adapter Input 100 – 240 VAC, 50/60 Hz, 1.0A (Max.) Output - 12V DC, 2.5A. Power Consumption (Typical)- 25.4W. Neck/Stand Detachable: Yes " });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Text" },
                values: new object[] { 3, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1231), 1, "2 x HDMI Ports (convertible to DVI).Contrast Ratio:1000 : 1" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Text" },
                values: new object[] { 4, new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1234), 1, "VESA wall mount ready. HDMI Input Signal Support - 1920 x 1080 @ 75Hz, 1080/60p, 1080/60i, 720p, 480p, 480i, Built-in Speakers - 2 x 2W 8 Ohm.Mounting type: VESA Hole Pattern 100mm x 100mm" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 1, 100, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1040), null, 1, 4m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 2, 101, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1048), null, 1, 5m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 3, 102, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1051), null, 1, 1m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 4, 104, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1058), null, 1, 5m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 5, 104, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1061), null, 2, 2m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 6, 103, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1064), null, 2, 3m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 7, 104, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1067), null, 2, 5m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 8, 104, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1070), null, 3, 1m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 9, 102, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1073), null, 4, 4m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 10, 102, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1077), null, 4, 3m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 11, 104, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1080), null, 5, 5m });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "Body", "CreatedAt", "CustomerId", "ProductId", "Rating" },
                values: new object[] { 12, 104, "Well Done!", new DateTime(2022, 9, 17, 22, 42, 32, 7, DateTimeKind.Local).AddTicks(1083), null, 6, 5m });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ProductId",
                table: "Discounts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_AppUserId",
                table: "Invoices",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesDetails_CustomerId",
                table: "InvoicesDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesDetails_InvoiceId",
                table: "InvoicesDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesDetails_ProductId",
                table: "InvoicesDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AppUserId",
                table: "Reviews",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerId",
                table: "Reviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "InvoicesDetails");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
