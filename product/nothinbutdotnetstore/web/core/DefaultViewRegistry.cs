using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewRegistry : ViewRegistry
    {
        public View get_view_for<ItemToDisplay>()
        {
            throw new NotImplementedException();
        }
    }
}