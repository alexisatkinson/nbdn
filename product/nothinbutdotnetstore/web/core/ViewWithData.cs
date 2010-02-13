using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewWithData<ViewModel> : IHttpHandler
    {
         ViewModel view_model { get; set; } 
    }
}