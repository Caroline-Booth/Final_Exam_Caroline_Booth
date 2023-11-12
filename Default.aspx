<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Booth_Caroline_HW4._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <main>
       <asp:Repeater ID ="Institutions" runat="server">
           <ItemTemplate>
               <a href="ResearchAreas.aspx?id=<%# Eval("InstitutionID") %>"> 
                   <%# Eval("InstitutionName") %>
               </a>
                <br />
           </ItemTemplate>
       </asp:Repeater>
    </main>

</asp:Content>
