using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubResponseEngine : ReponseEngine
    {
        public void handle<Item>(Item item)
        {
            HttpContext.Current.Items.Add("bla", item);
            HttpContext.Current.Server.Transfer("/views/DepartmentBrowser.aspx");
        }
    }
}