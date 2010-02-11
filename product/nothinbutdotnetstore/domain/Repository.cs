using System.Collections.Generic;

namespace nothinbutdotnetstore.domain
{
    public interface Repository
    {
        IEnumerable<Department> get_all_main_departments();
        IEnumerable<SubDepartment> get_all_sub_departments_for(Department department);
        Department get_main_department(int department_id);
        SubDepartment get_sub_department(int department_id);
    }
}