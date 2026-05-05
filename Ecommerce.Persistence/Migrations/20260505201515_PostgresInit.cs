using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PostgresInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Slug = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OwnerEmail = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    OwnerName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Plan = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CustomerName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CustomerPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DeliveryAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProductName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ProductSku = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    DeliveryCharge = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OrderSource = table.Column<int>(type: "integer", nullable: false),
                    ChannelUserId = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    InternalNotes = table.Column<string>(type: "text", nullable: true),
                    ShopifyOrderId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    WhatsAppPhoneNumberId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    WhatsAppAccessToken = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    WhatsAppWebhookToken = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    MessengerPageToken = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    MessengerAppSecret = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    MessengerWebhookToken = table.Column<string>(type: "text", nullable: true),
                    PathaoClientId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PathaoClientSecret = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PathaoUsername = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    PathaoPassword = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PathaoStoreId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PathaoApiBaseUrl = table.Column<string>(type: "text", nullable: true),
                    ShopifyStoreUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ShopifyAccessToken = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ShopifyWebhookSecret = table.Column<string>(type: "text", nullable: true),
                    ShopifyApiVersion = table.Column<string>(type: "text", nullable: false),
                    DeliveryProvider = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantSettings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    PathaoConsignmentId = table.Column<string>(type: "text", nullable: true),
                    TrackingCode = table.Column<string>(type: "text", nullable: true),
                    RecipientName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    RecipientPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    RecipientAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    RecipientCity = table.Column<string>(type: "text", nullable: false),
                    CollectAmount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    DeliveryFee = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Weight = table.Column<decimal>(type: "numeric(10,3)", precision: 10, scale: 3, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PickupTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeliveredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RawResponse = table.Column<string>(type: "text", nullable: true),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CustomerPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CustomerEmail = table.Column<string>(type: "text", nullable: true),
                    ProductInterest = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IncomingMessage = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Source = table.Column<int>(type: "integer", nullable: false),
                    ChannelUserId = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ConvertedOrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_Orders_ConvertedOrderId",
                        column: x => x.ConvertedOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leads_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_OrderId",
                table: "Deliveries",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_TenantId",
                table: "Deliveries",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_ConvertedOrderId",
                table: "Leads",
                column: "ConvertedOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_Status",
                table: "Leads",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_TenantId",
                table: "Leads",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Status",
                table: "Orders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TenantId",
                table: "Orders",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TenantId_OrderNumber",
                table: "Orders",
                columns: new[] { "TenantId", "OrderNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_OwnerEmail",
                table: "Tenants",
                column: "OwnerEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_Slug",
                table: "Tenants",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TenantSettings_TenantId",
                table: "TenantSettings",
                column: "TenantId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "TenantSettings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
