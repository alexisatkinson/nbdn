<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" CodeFile="DepartmentBrowser.aspx.cs" MasterPageFile="Store.master" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Isle</p>

            <table>            
            <% foreach (var department in this.view_model)
  {%>
        	<tr class="ListItem">
               		 <td>                     
                    <%= department.name %> 
                	</td>
           	 </tr>        
           	 <%
  }%>
	    </table>            
</asp:Content>
