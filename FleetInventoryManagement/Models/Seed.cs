namespace FleetInventoryManagement.Models
{
    public class Seed
    {
        public static Customer[] GetCustomers()
        {
            return new Customer[] {
                BobCustomer(),
                TomCustomer()
            };
        }

        private static Customer BobCustomer()
        {
            Customer customer = new Customer
            {
                Name = "Bob"
            };
            Fleet fleet = new Fleet()
            {
                Name = "MyFleet"
            };
            fleet.Vehicles = new Vehicle[] 
            {
                new Vehicle
                {
                    Name = "Car 1",
                    Make = "Toyota",
                    Model = "Coola",
                    Color = "Red"
                },
                new Vehicle
                {
                    Name = "Car 2",
                    Make = "BMW",
                    Model = "Arua",
                    Color = "White"
                },
                new Vehicle
                {
                    Name = "Car 3",
                    Make = "BMW",
                    Model = "Arua",
                    Color = "White"
                },
                new Vehicle
                {
                    Name = "Car 4",
                    Make = "Toyota",
                    Model = "Coola",
                    Color = "White"
                },
                new Vehicle
                {
                    Name = "Car 5",
                    Make = "Toyota",
                    Model = "Coola",
                    Color = "Red"
                },
                new Vehicle
                {
                    Name = "Car 6",
                    Make = "BMW",
                    Model = "Arua",
                    Color = "Grey"
                }
            };
            customer.Fleets = new Fleet[] { fleet };
            return customer;
        }

        private static Customer TomCustomer()
        {
            Customer customer = new Customer
            {
                Name = "Tom"
            };
            Fleet fleet1 = new Fleet
            {
                Name = "TestFleet"
            };
            Fleet fleet2 = new Fleet()
            {
                Name = "OperationFleet"
            };
            fleet1.Vehicles = new Vehicle[] 
            {
                new Vehicle
                {
                    Name = "Beta Car 1",
                    Make = "Tesla",
                    Model = "Model 3",
                    Color = "Red"
                },
                new Vehicle
                {
                    Name = "Beta Car 2",
                    Make = "Tesla",
                    Model = "Model 3",
                    Color = "White"
                },
                new Vehicle
                {
                    Name = "Beta Car 3",
                    Make = "Tesla",
                    Model = "Model Y",
                    Color = "Red"
                }
            };
            fleet2.Vehicles = new Vehicle[] 
            {
                new Vehicle
                {
                    Name = "Delta Car 1",
                    Make = "Jeep",
                    Model = "Jeep"
                },
                new Vehicle
                {
                    Name = "Delta Car 2",
                    Make = "Jeep",
                    Model = "Jeep"
                }
            };
            customer.Fleets = new Fleet[] { fleet1, fleet2 };
            return customer;
        }
    }
}