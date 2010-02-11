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
    }
}