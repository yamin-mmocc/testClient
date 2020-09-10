<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Send.aspx.cs" Inherits="Test.View.Send" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="User_Name" HeaderText="To: Receiver Name" />
                    <asp:BoundField DataField="Department_Name" HeaderText="To: Department Name" />
                    <asp:BoundField DataField="Card_Type" HeaderText="Card" />
                    <asp:BoundField DataField="MessageText" HeaderText="Message" />
                    <asp:BoundField DataField="replyMsg" HeaderText="Re Message" />
                    <asp:BoundField DataField="CreatedDateTime" HeaderText="Date" />
                    <asp:BoundField DataField="Card_ID" HeaderText="Card_ID" Visible="False" />
                    <asp:BoundField DataField="Status_Code" HeaderText="Status_Code" Visible="False" />
                    <asp:BoundField DataField="Sender_ID" HeaderText="Sender_ID" Visible="False" />
                    <asp:BoundField DataField="Receiver_ID" HeaderText="Receiver_ID" Visible="False" />
                    <asp:BoundField DataField="User_ID" HeaderText="User_ID" Visible="False" />
                    <asp:BoundField DataField="Card_Style" HeaderText="Card_Style" Visible="False" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
