<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentList.aspx.cs" Inherits="Test.View.DepartmentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField="Department_ID" HeaderText="ID" />
                    <asp:BoundField DataField="Department_Name" HeaderText="Department Name" />
                    <asp:BoundField DataField="IsActive" HeaderText="IsActive" Visible="False" />
                    <asp:BoundField DataField="timestamp" HeaderText="Time Stamp" Visible="False" />
                </Columns>
            </asp:GridView>

            <asp:ListView ID="ListView1" runat="server"></asp:ListView>
        </div>
    </form>
</body>
</html>
