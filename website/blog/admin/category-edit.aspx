﻿<%@ Page Language="C#" MasterPageFile="~/KMBlogAdmin.Master" AutoEventWireup="true" CodeBehind="category-edit.aspx.cs"
    Inherits="KMBlog.category_edit" Title="Edit A Category" %>

<%@ Register TagPrefix="category_edit" TagName="CategoryEditor" Src="~/Controls/category-editor.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h4>
        Edit Category</h4>
    <asp:Label runat="server" ID="lblCategoryDoesNotExist"></asp:Label>
    <category_edit:CategoryEditor ID="editcategory" runat="server" />
</asp:Content>