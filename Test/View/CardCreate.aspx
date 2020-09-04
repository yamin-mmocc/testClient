<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardCreate.aspx.cs" Inherits="Test.View.CardCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Card Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtcardname" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:FileUpload ID="ImgFileUpload" runat="server" />
&nbsp;<br />
            <br />
            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
            <br />
            <br />
            <br />
            <asp:Image ID="imgCard" runat="server" Height="75px" Width="115px" />
            <br />
            <br />
            <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
