<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InboxHome.aspx.cs" Inherits="Test.View.InboxHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CommandName="Select"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="User_Name" HeaderText="Sender Name" />
                    <asp:BoundField DataField="Department_Name" HeaderText="Sender Department Name" />
                    <asp:BoundField DataField="Card_Type" HeaderText="Card" />
                    <asp:BoundField DataField="MessageText" HeaderText="MessageText" />
                    <asp:BoundField DataField="CreatedDateTime" HeaderText="Date" />
                    <asp:BoundField DataField="replyMsg" HeaderText="replyMsg" Visible="False" />
                    <asp:BoundField DataField="SendLog_ID" HeaderText="SendLog_ID" Visible="False" />
                    <asp:BoundField DataField="Card_ID" HeaderText="Card_ID" Visible="False" />
                    <asp:BoundField DataField="Status_Code" HeaderText="Status_Code" Visible="False" />
                    <asp:BoundField DataField="Sender_ID" HeaderText="Sender_ID" Visible="False" />
                    <asp:BoundField DataField="Receiver_ID" HeaderText="Receiver_ID" Visible="False" />
                    <asp:BoundField DataField="User_ID" HeaderText="User_ID" Visible="False" />
                    <asp:BoundField DataField="Department_ID" HeaderText="Department_ID" Visible="False" />
                    <asp:BoundField DataField="Card_Style" HeaderText="Card_Style" />
                    <asp:ButtonField Text="View" CommandName="Select" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <%--<asp:Label ID="Label2" runat="server" Text=""></asp:Label>--%>
        </div>
    </form>
</body>
</html>
