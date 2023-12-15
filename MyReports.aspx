<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyReports.aspx.cs" Inherits="Booth_Caroline_HW4.MyReports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" OnItemCommand="User_Delete">
    <main>
        <asp:Panel ID="MyReportsPanel" runat="server" Visible="false">
            <asp:Repeater ID ="ReportsTable" runat="server" OnItemCommand="User_Delete">
    <ItemTemplate>
                        <div class="report">

                            <p><%# Eval("ProjectName") %></p>
                            <p><a href="Reports.aspx?ID=<%# Eval("ReportID") %>"> View Report <%# Eval("ReportID") %> </a></p>
                           <asp:Button ID="btnDeleteReport" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ReportID") %>' Text= "Delete Report" CssClass="btn btn-info" />
                        </div>
    </ItemTemplate>
            </asp:Repeater>
        </asp:Panel>
           </main>  
</asp:Content>