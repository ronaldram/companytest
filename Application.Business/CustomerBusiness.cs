using System.Collections.Generic;

namespace Application.Business
{
    public class CustomerBusiness
    {
        public IReadOnlyList<CustomerModel> GetAll()
        {
            var customers = new List<CustomerModel>
            {
                new CustomerModel(){Name="Jorge", Age = 10},
                new CustomerModel(){Name="Jorge", Age = 10}
            };
            return customers;
        }
    }

    public class CustomerModel
    {
        public string Name { get; set; }
        public byte Age { get; set; }
    }
}
