using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.domain.stubs
{
    public class StubRepository : Repository
    {
        public IEnumerable<Department> get_all_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<SubDepartment> get_all_sub_departments_for(Department department)
        {
            return Enumerable.Range(1, 100).Select(x => new SubDepartment { name = x.ToString("Department 0") });
        }

        public Department get_main_department(int department_id)
        {
            return new Department();
        }
    }
}