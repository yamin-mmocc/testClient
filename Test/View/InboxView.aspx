<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InboxView.aspx.cs" Inherits="Test.View.InboxView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:Panel ID="inboxview_panel" runat="server"  Width="100%" style="margin-top:15px;">
               <asp:Label ID="from_lbl" runat="server" Text="From" Width="10%"></asp:Label>&nbsp;&nbsp;
               <asp:Label ID="sender_lbl" runat="server" Text="" ></asp:Label>&nbsp;&nbsp;
               <asp:Button ID="reply_btn" runat="server" Text="Reply"  style="margin-left:850px;"/>
               <br />
               <asp:Label ID="subj_lbl" runat="server" Text="Department" Width="10%" style="margin-top:20px;"></asp:Label>&nbsp;&nbsp;
               <asp:Label ID="subtext_lbl" runat="server" Text="" ></asp:Label><br />
               <asp:Label ID="img_lbl" runat="server" Text="Image" Width="10%" style="margin-top:20px;"></asp:Label>&nbsp;&nbsp;
               <asp:Image ID="TC_img" runat="server" Height="207px" Width="284px" style="position: absolute;" />
            </asp:Panel><br />
            <asp:Panel ID="replyview_panel" runat="server"  Width="100%" style="margin-top:200px;">
                   <asp:Label ID="enter_lbl" runat="server" Text="Enter Your Message"></asp:Label>&nbsp;&nbsp;<br />
                   <asp:TextBox ID="enter_txt" runat="server" TextMode="MultiLine" Height="102px" Width="1090px"></asp:TextBox><br />
                   <asp:Button ID="send_btn" runat="server" Text="Send" style="margin-left:1030px;"/>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
