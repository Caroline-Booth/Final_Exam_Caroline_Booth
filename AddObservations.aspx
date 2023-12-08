<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddObservations.aspx.cs" Inherits="Booth_Caroline_HW4.AddObservations" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>

        <asp:TextBox ID="txtObservationNotes" runat="server" TextMode="MultiLine" Rows="4" Columns="30"></asp:TextBox>
        <asp:Label ID="lblReportID" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnSubmitObservation" runat="server" Text="Submit Observation" OnClick="SubmitObservation_Click" />

        

           </main>
     
</asp:Content>