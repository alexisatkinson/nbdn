using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.domain.stubs
{
    public class StubRepository : Repository
    {
        public IEnumerable<Department> get_all_main_departments()
        {
            return create(100, x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Department> get_all_sub_departments_for(Department department)
        {
            return create(100, x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Product> get_all_products_in(Department department)
        {
            return create(100, x => new Product {name = x.ToString("Product 0")});
        }

        IEnumerable<Item> create<Item>(int number_to_create, Func<int, Item> factory)
        {
            return Enumerable.Range(1, number_to_create).Select(factory);
        }
    }
}