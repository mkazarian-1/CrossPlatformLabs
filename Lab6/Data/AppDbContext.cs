using Lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Data
{
    public class AppDbContext  : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet для кожної таблиці
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<RefAddressType> RefAddressTypes { get; set; }
        public DbSet<RegularOrder> RegularOrders { get; set; }
        public DbSet<RegularOrderProduct> RegularOrderProducts { get; set; }
        public DbSet<ActualOrder> ActualOrders { get; set; }
        public DbSet<ActualOrderProduct> ActualOrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryRoute> DeliveryRoutes { get; set; }
        public DbSet<DeliveryRouteLocation> DeliveryRouteLocations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<RefPaymentMethod> RefPaymentMethods { get; set; }
        public DbSet<RefOrderStatus> RefOrderStatuses { get; set; }
        public DbSet<RefDeliveryStatus> RefDeliveryStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Налаштування для CustomerAddress (Composite Key)
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(ca => new { ca.CustomerId, ca.AddressId }); // Composite Key

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Customer)
                .WithMany(c => c.CustomerAddresses)
                .HasForeignKey(ca => ca.CustomerId);

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Address)
                .WithMany(a => a.CustomerAddresses)
                .HasForeignKey(ca => ca.AddressId);

            // Налаштування для RegularOrderProduct (Composite Key)
            modelBuilder.Entity<RegularOrderProduct>()
                .HasKey(rop => new { rop.RegularOrderId, rop.ProductId });

            modelBuilder.Entity<RegularOrderProduct>()
                .HasOne(rop => rop.RegularOrder)
                .WithMany(ro => ro.RegularOrderProducts)
                .HasForeignKey(rop => rop.RegularOrderId);

            modelBuilder.Entity<RegularOrderProduct>()
                .HasOne(rop => rop.Product)
                .WithMany(p => p.RegularOrderProducts)
                .HasForeignKey(rop => rop.ProductId);

            // Налаштування для ActualOrderProduct (Composite Key)
            modelBuilder.Entity<ActualOrderProduct>()
                .HasKey(aop => new { aop.ActualOrderId, aop.ProductId });

            modelBuilder.Entity<ActualOrderProduct>()
                .HasOne(aop => aop.ActualOrder)
                .WithMany(ao => ao.ActualOrderProducts)
                .HasForeignKey(aop => aop.ActualOrderId);

            modelBuilder.Entity<ActualOrderProduct>()
                .HasOne(aop => aop.Product)
                .WithMany(p => p.ActualOrderProducts)
                .HasForeignKey(aop => aop.ProductId);

            // Налаштування для DeliveryRouteLocation (Composite Key)
            modelBuilder.Entity<DeliveryRouteLocation>()
                .HasKey(drl => new { drl.DeliveryRouteId, drl.DeliveryRouteLocationId });

            modelBuilder.Entity<DeliveryRouteLocation>()
                .HasOne(drl => drl.DeliveryRoute)
                .WithMany(dr => dr.DeliveryRouteLocations)
                .HasForeignKey(drl => drl.DeliveryRouteId);

            // Налаштування для Delivery
            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.ActualOrder)
                .WithMany(ao => ao.Deliveries)
                .HasForeignKey(d => d.ActualOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.DeliveryStatus)
                .WithMany()
                .HasForeignKey(d => d.DeliveryStatusId);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.DriverEmployee)
                .WithMany(e => e.Deliveries)
                .HasForeignKey(d => d.DriverEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Truck)
                .WithMany(t => t.Deliveries)
                .HasForeignKey(d => d.TruckId);

            // Налаштування для інших таблиць
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);

            modelBuilder.Entity<ActualOrder>()
                .HasOne(ao => ao.RefOrderStatus)
                .WithMany()
                .HasForeignKey(ao => ao.RefOrderStatusId);



        }

        public void SeedDatabase()
        {

            // Seed RefOrderStatus
            var refOrderStatuses = new List<RefOrderStatus>();
            for (int i = 1; i <= 20; i++)
            {
                refOrderStatuses.Add(new RefOrderStatus
                {
                    RefOrderStatusDescription = $"Status {i}"
                });
            }
            RefOrderStatuses.AddRange(refOrderStatuses);

            // Seed RefAddressType
            var refAddressTypes = new List<RefAddressType>();
            for (int i = 1; i <= 20; i++)
            {
                refAddressTypes.Add(new RefAddressType
                {
                    RefAddressTypeDescription = $"Address Type {i}"
                });
            }

            RefAddressTypes.AddRange(refAddressTypes);

            //Seed RefDeliveryStatus
            var refDeliveryStatuses = new List<RefDeliveryStatus>();
            for (int i = 1; i <= 20; i++)
            {
                refDeliveryStatuses.Add(new RefDeliveryStatus
                {
                    RefDeliveryStatusDescription = $"Delivery Status {i}"
                });
            }
            RefDeliveryStatuses.AddRange(refDeliveryStatuses);

            // Seed RefPaymentMethod
            var refPaymentMethods = new List<RefPaymentMethod>();
            for (int i = 1; i <= 20; i++)
            {
                refPaymentMethods.Add(new RefPaymentMethod
                {
                    RefPaymentMethodDescription = $"Payment Method {i}"
                });
            }

            RefPaymentMethods.AddRange(refPaymentMethods);


            var suppliers = new List<Supplier>();
            for (int i = 1; i <= 50; i++)
            {
                suppliers.Add(new Supplier
                {
                    SupplierDetails = $"Supplier Details {i}"
                });
            }

            Suppliers.AddRange(suppliers);

            // Seed Products
            var products = new List<Product>();
            for (int i = 1; i <= 100; i++)
            {
                products.Add(new Product
                {
                    ProductName = $"Product {i}",
                    ProductPrice = 10m + i,
                    ProductDescription = $"Description for Product {i}",
                    
                    Supplier = suppliers[i%10]
                });
            }

            Products.AddRange(products);

            // Seed Addresses
            var addresses = new List<Address>();
            for (int i = 1; i <= 60; i++)
            {
                addresses.Add(new Address
                {
                    Line1 = $"Address Line 1 - {i}",
                    City = $"City {i}",
                    ZipPostcode = $"123{i:D3}",
                    Country = "USA"
                });
            }

            Addresses.AddRange(addresses);

            // Seed Trucks
            var trucks = new List<Truck>();
            for (int i = 1; i <= 20; i++)
            {
                trucks.Add(new Truck
                {
                    TruckLicenceNumber = $"TRUCK-{i:D4}",
                    TruckDetails = $"Details for Truck {i}"
                });
            }

            Trucks.AddRange(trucks);

            // Seed Employees
            var employees = new List<Employee>();
            for (int i = 1; i <= 70; i++)
            {
                employees.Add(new Employee
                {
                    EmployeeName = $"Employee {i}",
                    EmployeePhone = $"555-{1000 + i}",
                    EmployeeAddress = addresses[i % 20]
                });
            }

            Employees.AddRange(employees);

            // Seed ActualOrders
            var actualOrders = new List<ActualOrder>();
            for (int i = 1; i <= 100; i++)
            {
                actualOrders.Add(new ActualOrder
                {
                    RefOrderStatus =refOrderStatuses[i % 10],
                    ActualOrderDate = DateTime.UtcNow.AddDays(-i),
                    OrderDetails = $"Order Details {i}"
                });
            }

            ActualOrders.AddRange(actualOrders);

            // Seed ActualOrderProducts
            var actualOrderProducts = new List<ActualOrderProduct>();
            var usedCombinations = new HashSet<(int ActualOrderId, int ProductId)>();
            for (int i = 1; i <= 40; i++)
            {
                int actualOrderId = (i % 10);
                int productId = (i % 10);

                if (!usedCombinations.Contains((actualOrderId, productId)))
                {
                    actualOrderProducts.Add(new ActualOrderProduct
                    {
                        ActualOrder = actualOrders[actualOrderId],
                        Product = products[productId]
                    });
                    usedCombinations.Add((actualOrderId, productId));
                }
            }

            ActualOrderProducts.AddRange(actualOrderProducts);

            var customers = new List<Customer>();
            for (int i = 1; i <= 70; i++)
            {
                customers.Add(new Customer
                {
                    CustomerName = $"Customer {i}",
                    CustomerPhone = $"555-{2000 + i}",
                    CustomerEmail = $"customer{i}@example.com",
                    DateBecameCustomer = DateTime.UtcNow.AddYears(-i % 10),
                    OtherCustomerDetails = $"Details for Customer {i}",
                    RefPaymentMethod = refPaymentMethods[(i % 10)]
                });
            }

            Customers.AddRange(customers);

            // Seed CustomerAddress

            var customerAddresses = new List<CustomerAddress>();
            var usedCustomerCombinations = new HashSet<(int CustomerId, int AddressId)>();

            for (int i = 1; i <= 100; i++)
            {
                int customerId = (i % 50);
                int addressId = (i % 50);

                if (!usedCustomerCombinations.Contains((customerId, addressId)))
                {

                    customerAddresses.Add(new CustomerAddress
                    {
                        Customer =customers[customerId],
                        Address =addresses[addressId],
                        RefAddressType = refAddressTypes[(i % 5)],
                        DateFrom = DateTime.UtcNow.AddYears(-(i % 5)),
                        DateTo = DateTime.UtcNow.AddYears(-(i % 5 - 1))
                    });

                    usedCustomerCombinations.Add((customerId, addressId));
                }
            }

            CustomerAddresses.AddRange(customerAddresses);



            // Seed RegularOrder
            var regularOrders = new List<RegularOrder>();

            for (int i = 1; i <= 100; i++)
            {
                regularOrders.Add(new RegularOrder
                {
                    Distributor =customers[(i % 50)],
                    OrderDetails = $"Order Details for RegularOrder {i}"
                });
            }

            RegularOrders.AddRange(regularOrders);

            // Seed RegularOrderProduct
            var regularOrderProducts = new List<RegularOrderProduct>();
            var usedRegularOrderCombinations = new HashSet<(int RegularOrderId, int ProductId)>();

            for (int i = 1; i <= 50; i++)
            {
                int regularOrderId = (i % 50);
                int productId = (i % 50);

                if (!usedRegularOrderCombinations.Contains((regularOrderId, productId)))
                {

                    regularOrderProducts.Add(new RegularOrderProduct
                    {
                        RegularOrder =regularOrders[regularOrderId],
                        Product =products[productId]
                    });

                    usedRegularOrderCombinations.Add((regularOrderId, productId));
                }
            }

            RegularOrderProducts.AddRange(regularOrderProducts);


            // Seed DeliveryRoute
            var deliveryRoutes = new List<DeliveryRoute>();
            for (int i = 1; i <= 30; i++)
            {
                deliveryRoutes.Add(new DeliveryRoute
                {
                    DeliveryRouteName = $"Route {i}",
                    OtherDeliveryRouteDetails = $"Details for Route {i}"
                });
            }
            ;
            DeliveryRoutes.AddRange(deliveryRoutes);


            // Seed DeliveryRouteLocation
            var deliveryRouteLocations = new List<DeliveryRouteLocation>();
            var usedRegularAddressIdCombinations = new HashSet<(int DeliveryRouteId, int ProductId)>();
            for (int i = 1; i <= 20; i++)
            {
                int deliveryRouteId = (i % 20);
                int addressId = (i % 20);

                if (!usedRegularAddressIdCombinations.Contains((deliveryRouteId, addressId)))
                {
                    deliveryRouteLocations.Add(new DeliveryRouteLocation
                    {
                        DeliveryRoute =deliveryRoutes[deliveryRouteId],
                        Address = addresses[addressId],
                        LocationName = $"Location {i}",
                        OtherLocationDetails = $"Details for Location {i}"
                    });

                    usedRegularAddressIdCombinations.Add((deliveryRouteId, addressId));
                }
            }

            DeliveryRouteLocations.AddRange(deliveryRouteLocations);

            var deliveries = new List<Delivery>();
            for (int i = 1; i <= 30; i++)
            {
                deliveries.Add(new Delivery
                {
                    ActualOrder = actualOrders[(i % 10)],
                    DeliveryStatus =refDeliveryStatuses[(i % 9)],
                    DriverEmployee =employees[(i % 9)],
                    Truck = trucks[(i % 5)],
                    DeliveryRouteLocation = deliveryRouteLocations[(i % 9)], // Ensure this matches a seeded DeliveryRouteLocationId
                    DeliveryDate = DateTime.UtcNow.AddDays(-i),
                    OtherDeliveryDetails = $"Delivery details for Delivery {i}"
                });
            }

            Deliveries.AddRange(deliveries);


            SaveChanges();

  
        }
    }
}
