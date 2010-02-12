<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.domain" %>
<%@ Import Namespace="System.Collections.Generic" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Isle</p>

            <table>            
		<!-- for each of the main departments in the store -->
                  <%  
                    var departments = (IEnumerable<Department>)Context.Items["bla"];
                    foreach (var department in departments)
                    {
%>
        	<tr class="ListItem">
               		 <td>                     
                     <a href="blah.department?id=<%=department.name%>"><%=department.name%> </a>          
                     
                	</td>
           	 </tr>        
           	 <%
                    }%>
	    </table>            
</asp:Content>
