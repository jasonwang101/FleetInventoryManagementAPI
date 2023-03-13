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
            Vehicle vehicle1 = new Vehicle
            {
                Name = "Car 1",
                Make = "Toyota",
                Model = "Coola"
            };
            Vehicle vehicle2 = new Vehicle
            {
                Name = "Car 2",
                Make = "BMW",
                Model = "Arua"
            };

            fleet.Vehicles = new Vehicle[] { vehicle1, vehicle2 };
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
            Vehicle vehicle1 = new Vehicle
            {
                Name = "Beta Car 1",
                Make = "Tesla",
                Model = "Model 3"
            };
            fleet1.Vehicles = new Vehicle[] { vehicle1 };
            Vehicle vehicle2 = new Vehicle
            {
                Name = "Delta Car 1",
                Make = "Jeep",
                Model = "Jeep"
            };
            fleet2.Vehicles = new Vehicle[] { vehicle2 };
            customer.Fleets = new Fleet[] { fleet1, fleet2 };
            return customer;
        }
    }
}