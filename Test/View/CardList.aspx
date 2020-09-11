<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardList.aspx.cs" Inherits="Test.View.CardList" %>

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
                    <asp:BoundField DataField="Card_Type" HeaderText="Card Type" />
                    <asp:TemplateField HeaderText="Card Style" Visible="False">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Card_Style") %>'  Width="200" Height="200"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="IsActive" HeaderText="IsActive" Visible="False" />
                    <asp:BoundField DataField="timestamp" HeaderText="Time Stamp" />
                    <asp:BoundField DataField="Card_ID" HeaderText="Card ID" />
                </Columns>

            </asp:GridView>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
