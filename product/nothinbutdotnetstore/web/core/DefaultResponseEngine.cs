namespace nothinbutdotnetstore.web.core
{
    public class DefaultResponseEngine : ResponseEngine
    {
        ViewRegistry view_registry;
        ViewFactory view_factory;
        ViewHandler view_handler;

        public DefaultResponseEngine(ViewRegistry view_registry, ViewFactory view_factory, ViewHandler view_handler)
        {
            this.view_registry = view_registry;
            this.view_handler = view_handler;
            this.view_factory = view_factory;
        }

        public void display<Item>(Item item)
        {
            var view_information = view_registry.get_view_for<Item>();
            var view = (ViewWithData<Item>) view_factory(view_information.path, typeof (ViewWithData<Item>));
            view.view_model = item;
            view_handler(view, true);
        }

    }
}