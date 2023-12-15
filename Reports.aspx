<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Booth_Caroline_HW4.Reports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
<asp:Panel ID="errorMsgPan" runat="server" Visible="False"> 
    Something went wrong
</asp:Panel>
<asp:Panel ID="ObservationTablePanel" runat="server" Visible="False">
            <asp:Repeater ID="ObservationTable" runat="server">
<HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Observation ID</th>
                                <th>Observation Date</th>
                                <th>Value</th>
                                <th> Notes</th>
                                <th> Tool ID</th>
                                <th>Latitude</th>
                                <th>Longitude</th>
                                <th>Report ID</th>
                            </tr>
                        </thead>
                        <tbody>
              </HeaderTemplate>
                <ItemTemplate>
                    <tr> 
                        <td><%# Eval("ObservationID") %></td>
                        <td><%# Eval("ObservedDate") %></td>
                        <td><%# Eval("Value") %></td>
                        <td><%# Eval("Notes") %></td>
                        <td><%# Eval("ToolID") %></td>
                        <td><%# Eval("Latitude") %></td>
                        <td><%# Eval("Longitude") %></td>
                        <td><%# Eval("ReportID") %></td>
                    </tr>
                </ItemTemplate>
               
                </asp:Repeater>
                <br />
                    <asp:Button ID="btnCreateNewObservation" runat="server" Text="New Observation" OnClick="btnStartNewObservation_Click" CssClass="btn btn-info" />
           
        </asp:Panel>

   </main>
     
</asp:Content>
