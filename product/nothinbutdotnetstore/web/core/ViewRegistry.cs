using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewRegistry
    {
        View get_view_for<ItemToDisplay>();
    }
}