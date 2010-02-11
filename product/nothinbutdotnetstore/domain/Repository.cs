using System.Collections.Generic;

namespace nothinbutdotnetstore.domain
{
    public interface Repository
    {
        IEnumerable<Department> get_all_main_departments();
    }
}