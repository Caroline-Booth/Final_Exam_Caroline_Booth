<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProjectDetails.aspx.cs" Inherits="Booth_Caroline_HW4.ProjectDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
     <table>
            <tr>
               
                <td>
                    <h2><asp:Label ID="lblProjectName" runat="server" Text="Project Name"></asp:Label></h2>
                    <p><asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label></p>
                    <p><asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label></p>
                    <p><asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label></p>
                <td>
               <tr>
           
        </table>

   
     
</asp:Content>
