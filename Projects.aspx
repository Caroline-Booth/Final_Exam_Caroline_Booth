<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Projects.aspx.cs" Inherits="Booth_Caroline_HW4.Projects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
            <main>
       <asp:Repeater ID ="Project" runat="server">
           <ItemTemplate>
               <a href="ProjectDetails.aspx?id=<%# Eval("ProjectID") %>"> 
                   <%# Eval("ProjectName") %>
               </a>
                <br />
           </ItemTemplate>
       </asp:Repeater>
    </main>

</asp:Content>