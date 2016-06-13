<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="controller.aspx.cs" Inherits="Webtest2.controller" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Link Page</p>
        <asp:Button ID="CreateRecipe" runat="server" Text="Create Recipe" OnClick="CreateRecipe_Click" /><br /><br />
        <asp:Button ID="SearchRecipeViewSource" runat="server" Text="Search Recipe/ View Recipe Source" OnClick="SearchRecipeViewSource_Click" /><br /><br />
        <asp:Button ID="SearchRecipeAPI" runat="server" Text="Search Recipe from external source" OnClick="SearchRecipeAPI_Click" />

    </div>
    </form>
</body>
</html>
