<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleCreate.aspx.cs" Inherits="Test.View.RoleCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Role"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txtRole" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnRole" runat="server" Height="26px" OnClick="btnRole_Click" Text="Create" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
