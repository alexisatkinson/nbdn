using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewWithData<Model> : Page, ViewWithData<Model>
    {
        public Model view_model { get; set; }
    }
}