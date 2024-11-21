using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipPostcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProvinceCounty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherAddressDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryRoutes",
                columns: table => new
                {
                    DeliveryRouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryRouteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDeliveryRouteDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryRoutes", x => x.DeliveryRouteId);
                });

            migrationBuilder.CreateTable(
                name: "RefAddressTypes",
                columns: table => new
                {
                    RefAddressTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefAddressTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAddressTypes", x => x.RefAddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RefDeliveryStatuses",
                columns: table => new
                {
                    RefDeliveryStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefDeliveryStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefDeliveryStatuses", x => x.RefDeliveryStatusId);
                });

            migrationBuilder.CreateTable(
                name: "RefOrderStatuses",
                columns: table => new
                {
                    RefOrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefOrderStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefOrderStatuses", x => x.RefOrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "RefPaymentMethods",
                columns: table => new
                {
                    RefPaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefPaymentMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefPaymentMethods", x => x.RefPaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    TruckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckLicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.TruckId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeAddressId = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherEmployeeDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_EmployeeAddressId",
                        column: x => x.EmployeeAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryRouteLocations",
                columns: table => new
                {
                    DeliveryRouteLocationId = table.Column<int>(type: "int", nullable: false),
                    DeliveryRouteId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherLocationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryRouteLocations", x => new { x.DeliveryRouteId, x.DeliveryRouteLocationId });
                    table.ForeignKey(
                        name: "FK_DeliveryRouteLocations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryRouteLocations_DeliveryRoutes_DeliveryRouteId",
                        column: x => x.DeliveryRouteId,
                        principalTable: "DeliveryRoutes",
                        principalColumn: "DeliveryRouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActualOrders",
                columns: table => new
                {
                    ActualOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefOrderStatusId = table.Column<int>(type: "int", nullable: false),
                    ActualOrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefOrderStatusId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualOrders", x => x.ActualOrderId);
                    table.ForeignKey(
                        name: "FK_ActualOrders_RefOrderStatuses_RefOrderStatusId",
                        column: x => x.RefOrderStatusId,
                        principalTable: "RefOrderStatuses",
                        principalColumn: "RefOrderStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualOrders_RefOrderStatuses_RefOrderStatusId1",
                        column: x => x.RefOrderStatusId1,
                        principalTable: "RefOrderStatuses",
                        principalColumn: "RefOrderStatusId");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBecameCustomer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherCustomerDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefPaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_RefPaymentMethods_RefPaymentMethodId",
                        column: x => x.RefPaymentMethodId,
                        principalTable: "RefPaymentMethods",
                        principalColumn: "RefPaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualOrderId = table.Column<int>(type: "int", nullable: false),
                    DeliveryStatusId = table.Column<int>(type: "int", nullable: false),
                    DriverEmployeeId = table.Column<int>(type: "int", nullable: false),
                    TruckId = table.Column<int>(type: "int", nullable: false),
                    DeliveryRouteLocationId = table.Column<int>(type: "int", nullable: false),
                    DeliveryRouteLocationDeliveryRouteId = table.Column<int>(type: "int", nullable: false),
                    DeliveryRouteLocationId1 = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherDeliveryDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefDeliveryStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryId);
                    table.ForeignKey(
                        name: "FK_Deliveries_ActualOrders_ActualOrderId",
                        column: x => x.ActualOrderId,
                        principalTable: "ActualOrders",
                        principalColumn: "ActualOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_DeliveryRouteLocations_DeliveryRouteLocationDeliveryRouteId_DeliveryRouteLocationId1",
                        columns: x => new { x.DeliveryRouteLocationDeliveryRouteId, x.DeliveryRouteLocationId1 },
                        principalTable: "DeliveryRouteLocations",
                        principalColumns: new[] { "DeliveryRouteId", "DeliveryRouteLocationId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Employees_DriverEmployeeId",
                        column: x => x.DriverEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_RefDeliveryStatuses_DeliveryStatusId",
                        column: x => x.DeliveryStatusId,
                        principalTable: "RefDeliveryStatuses",
                        principalColumn: "RefDeliveryStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_RefDeliveryStatuses_RefDeliveryStatusId",
                        column: x => x.RefDeliveryStatusId,
                        principalTable: "RefDeliveryStatuses",
                        principalColumn: "RefDeliveryStatusId");
                    table.ForeignKey(
                        name: "FK_Deliveries_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "TruckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    RefAddressTypeId = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => new { x.CustomerId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_RefAddressTypes_RefAddressTypeId",
                        column: x => x.RefAddressTypeId,
                        principalTable: "RefAddressTypes",
                        principalColumn: "RefAddressTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegularOrders",
                columns: table => new
                {
                    RegularOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributorId = table.Column<int>(type: "int", nullable: false),
                    OrderDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularOrders", x => x.RegularOrderId);
                    table.ForeignKey(
                        name: "FK_RegularOrders_Customers_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActualOrderProducts",
                columns: table => new
                {
                    ActualOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualOrderProducts", x => new { x.ActualOrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ActualOrderProducts_ActualOrders_ActualOrderId",
                        column: x => x.ActualOrderId,
                        principalTable: "ActualOrders",
                        principalColumn: "ActualOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualOrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegularOrderProducts",
                columns: table => new
                {
                    RegularOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularOrderProducts", x => new { x.RegularOrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_RegularOrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegularOrderProducts_RegularOrders_RegularOrderId",
                        column: x => x.RegularOrderId,
                        principalTable: "RegularOrders",
                        principalColumn: "RegularOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActualOrderProducts_ProductId",
                table: "ActualOrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualOrders_RefOrderStatusId",
                table: "ActualOrders",
                column: "RefOrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualOrders_RefOrderStatusId1",
                table: "ActualOrders",
                column: "RefOrderStatusId1");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_AddressId",
                table: "CustomerAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_RefAddressTypeId",
                table: "CustomerAddresses",
                column: "RefAddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RefPaymentMethodId",
                table: "Customers",
                column: "RefPaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ActualOrderId",
                table: "Deliveries",
                column: "ActualOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DeliveryRouteLocationDeliveryRouteId_DeliveryRouteLocationId1",
                table: "Deliveries",
                columns: new[] { "DeliveryRouteLocationDeliveryRouteId", "DeliveryRouteLocationId1" });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DeliveryStatusId",
                table: "Deliveries",
                column: "DeliveryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DriverEmployeeId",
                table: "Deliveries",
                column: "DriverEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_RefDeliveryStatusId",
                table: "Deliveries",
                column: "RefDeliveryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_TruckId",
                table: "Deliveries",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryRouteLocations_AddressId",
                table: "DeliveryRouteLocations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeAddressId",
                table: "Employees",
                column: "EmployeeAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularOrderProducts_ProductId",
                table: "RegularOrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularOrders_DistributorId",
                table: "RegularOrders",
                column: "DistributorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualOrderProducts");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "RegularOrderProducts");

            migrationBuilder.DropTable(
                name: "RefAddressTypes");

            migrationBuilder.DropTable(
                name: "ActualOrders");

            migrationBuilder.DropTable(
                name: "DeliveryRouteLocations");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RefDeliveryStatuses");

            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RegularOrders");

            migrationBuilder.DropTable(
                name: "RefOrderStatuses");

            migrationBuilder.DropTable(
                name: "DeliveryRoutes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RefPaymentMethods");
        }
    }
}
