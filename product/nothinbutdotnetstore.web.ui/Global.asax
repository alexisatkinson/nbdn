<%@ Application Language="C#" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application" %>
<script runat="server">
    public DefaultDependencyRegister register { get; private set; }

        private void Application_Start(object sender, EventArgs e)
        {
            register = new DefaultDependencyRegister();
        }


</script>
