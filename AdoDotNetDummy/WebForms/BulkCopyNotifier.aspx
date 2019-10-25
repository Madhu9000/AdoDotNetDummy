<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkCopyNotifier.aspx.cs" Inherits="AdoDotNetDummy.WebForms.BulkCopyNotifier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Do Bulk Copy" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Bulk copy notifier"></asp:Label>
        <br />
    </form>
</body>
</html>
