using System.Collections.Generic;
using nothinbutdotnetstore.domain;

namespace nothinbutdotnetstore.web.application
{
    public class DepartmentsController
    {
        Repository repository;

        public DepartmentsController(Repository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Department> get_all_main_departments()
        {
            return repository.get_all_main_departments();
        }

        public IEnumerable<Department> get_all_subdepartments_in(Department department)
        {
            return repository.get_all_sub_departments_for(department);
        }
    }
}