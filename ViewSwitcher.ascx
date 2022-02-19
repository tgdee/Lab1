<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ViewSwitcher.ascx.cs" Inherits="Lab2.ViewSwitcher" %>
<div id="viewSwitcher">
    <%: CurrentView %> view | <a href="<%: SwitchUrl %>" data-ajax="false">Switch to <%: AlternateView %></a>
</div>