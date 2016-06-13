<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchtest.aspx.cs" Inherits="Webtest2.searchtest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="sadaf" runat="server" Text="hiii" />
		<asp:Button id="button1" runat="server" Text="Click me!" OnClick="button1Clicked" />
		<asp:Label id="ParseOutput" runat="server" ></asp:Label>
	    <asp:Label id="websiteAddress" runat="server" ></asp:Label>
	    <asp:TextBox id="textSearch" runat="server"></asp:TextBox>
	    <asp:TextBox id="textSearchTwo" runat="server"></asp:TextBox>
	    <asp:TextBox id="textSearchThree" runat="server"></asp:TextBox>
	    <asp:Label id="Label1" runat="server" ></asp:Label><br/><br/>HERE IS THE PARSED JSON
	    <asp:Label id="Label2" runat="server" ></asp:Label><br/>
	    <asp:Label id="Label3" runat="server" ></asp:Label><br/>
	    <asp:Label id="Label4" runat="server" ></asp:Label><br/>
	    <asp:Label id="Label5" runat="server" ></asp:Label><br/>
	    <asp:Label id="Label6" runat="server" ></asp:Label><br/>
	    <asp:Label id="Label7" runat="server" ></asp:Label><br/>
	    <asp:Label id="Label8" runat="server" ></asp:Label><br/>
	    <asp:ListBox id ="ListBox" runat="server" ></asp:ListBox>
    </div>
    </form>
</body>
</html>
