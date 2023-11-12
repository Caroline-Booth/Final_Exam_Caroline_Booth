<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ResearchAreas.aspx.cs" Inherits="Booth_Caroline_HW4.ResearchAreas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <asp:Repeater ID="Research" runat="server">
            <ItemTemplate>
                <a href="Projects.aspx?ID=<%# Eval("ResearchID") %>">
                    <%# Eval("ResearchName") %>
                </a>
            <br />

            </ItemTemplate>
        </asp:Repeater>
    </main>

</asp:Content>