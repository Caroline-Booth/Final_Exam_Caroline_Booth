<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyReports.aspx.cs" Inherits="Booth_Caroline_HW4.MyReports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:Panel ID="MyReportsPanel" runat="server" Visible="false">
            <asp:Repeater ID ="ReportsTable" runat="server">
    <ItemTemplate>
                        <div class="report">

                            <p><%# Eval("ProjectName") %></p>
                            <p><a href="Reports.aspx?ID=<%# Eval("ReportID") %>"> View Report <%# Eval("ReportID") %> </a></p>

                        </div>
    </ItemTemplate>
            </asp:Repeater>
        </asp:Panel>
           </main>  
</asp:Content>