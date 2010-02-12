using System.Collections.Generic;

namespace nothinbutdotnetstore.domain
{
    public interface Repository
    {
        IEnumerable<Department> get_all_main_departments();
        IEnumerable<Department> get_all_sub_departments_for(Department department);
        IEnumerable<Product> get_all_products_in(Department department);
    }
}