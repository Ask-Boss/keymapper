﻿<%@ Page Language="C#" MasterPageFile="~/KMBlog.Master" AutoEventWireup="true" CodeBehind="post-edit.aspx.cs"
    Inherits="KMBlog.post_edit" Title="Post Editor" ValidateRequest="false" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        @import url('../kmblog.css');
    </style>

    <script language="javascript" type="text/javascript" src="../scripts/tiny_mce/tiny_mce.js"></script>

    <script language="javascript" type="text/javascript">
tinyMCoE.init({
    mode : "textareas",
    theme : "simple"
});
    </script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <h3 id="header">
        Blog Post Editor</h3>
    <form id="form1" runat="server">
        <div id="edit_title">
            Title: <asp:TextBox ID="blogtitle" runat="server" Width="40%" >
   
            </asp:TextBox>
        </div>
        <div id="edit_body">
            <textarea id="blogpost" cols="80" rows="20" runat="server" width="80%"></textarea>
        </div>
        <asp:Button ID="submit" Text="Save" OnClick="SavePost" runat="server" />
    </form>
</asp:Content>