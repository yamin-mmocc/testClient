<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Test.View.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Department Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlDept" runat="server">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
            
            </div>

                <div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="User_ID" HeaderText="ID" />
                    <asp:BoundField DataField="User_Name" HeaderText="Name" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                    <asp:BoundField DataField="IsActive" HeaderText="IsActive" />
                    <asp:BoundField DataField="timestamp" HeaderText="Timestamp" />
                    <asp:BoundField DataField="Department_ID" HeaderText="Department ID" />
                    <asp:BoundField DataField="Department_Name" HeaderText="Department Name" />
                    <asp:BoundField DataField="Role_ID" HeaderText="Role ID" />
                    <asp:BoundField DataField="Role_Type" HeaderText="Role Name" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
