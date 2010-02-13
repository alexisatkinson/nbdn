using System.Security.Principal;
using System.Threading;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public class SecurityCheck : InvocationInterceptor
    {
        Criteria<IPrincipal> criteria;

        public SecurityCheck(Criteria<IPrincipal> criteria)
        {
            this.criteria = criteria;
        }

        public void intercept(Invocation invocation)
        {
            if (criteria.is_satisfied_by(Thread.CurrentPrincipal)) invocation.resume();
        }
    }
}