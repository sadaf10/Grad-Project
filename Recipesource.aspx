<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recipesource.aspx.cs" Inherits="Webtest2.Recipesource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
  
</head>

<body>
    <form id="form1" runat="server">
   <div>
    <asp:Label ID="lblrecipename" runat="server" Text ="Search by recipe name:" AssociatedControlID="txtrecipeName"></asp:Label>
    <asp:TextBox ID="txtrecipename" runat="server" Enabled="true"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblrecipeType" runat="server" Text="Search by recipe Type" AssociatedControlID="txtrecipename"></asp:Label>
        <asp:TextBox ID="txtrecipeType" runat="server" Enabled="true"></asp:TextBox>
    </div>

    <div><asp:Button ID="btnfilterSearch" runat="server" Text="Search" OnClick="btnFilterSearch_OnClick" /></div>

        <asp:GridView ID="GridViewAllRecipes" runat="server" AllowPaging="true" AutoGenerateColumns="false" OnPageIndexChanging="GridviewAllRecipes_OnPageIndexChanging" OnRowCommand="GridViewAllRecipes_RowCommand" DataKeyNames="RecipeID">
        <Columns>
            <asp:TemplateField HeaderText="recipeName" runat="server">
                <ItemTemplate>
                    <asp:LinkButton ID="lbRecipeID" runat="server" Text='<%# Eval("Recipename") %>' commandname="ViewRecipe" CommandArgument='<%#Eval("RecipeID") %>' ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="RecipeID" HeaderText="Recipe ID" InsertVisible="false" ReadOnly="true" runat="server"/>
            <asp:BoundField DataField="RecipeType" HeaderText ="Recipe Type" InsertVisible="False" ReadOnly="True" runat="server"/>
            <asp:BoundField DataField="Difficulty" HeaderText ="Difficulty" InsertVisible="False" ReadOnly="True" runat="server"/>

            <asp:TemplateField ShowHeader="false">

                <ItemTemplate>

                    <asp:Label ID="lblRecipeIngredients" runat="server"></asp:Label>
                    
                </ItemTemplate>

                <HeaderTemplate>RecipeIngredient</HeaderTemplate>

            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnDelete" runat="server" commandName="btnDelete" Text="Delete" Visible="True" commandArgument='<%#Eval("RecipeID") %>'/>
            
            </ItemTemplate>
            <HeaderTemplate>Delete</HeaderTemplate>

            </asp:TemplateField>
        </Columns>
            </asp:GridView>



    </form>
</body>
</html>
