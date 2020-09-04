<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Test.View.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" style="margin-right: 0px">
                <Columns>
                    <asp:BoundField DataField="AAA" HeaderText="CCC" />
                    <asp:BoundField DataField="AAA" HeaderText="BBB" />
                    <asp:BoundField DataField="AAA" HeaderText="AAA" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
