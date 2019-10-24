<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallingProcedure1.aspx.cs" Inherits="AdoDotNetDummy.CallingProcedure1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div style="font-family: Arial;">
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Height="16px" style="margin-left: 32px"></asp:TextBox>
        <div style="margin-left: 40px">
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left: 27px" Width="131px">
                <asp:ListItem>Female</asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
            </asp:DropDownList>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Salary"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 30px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Employee Id"></asp:Label>
        <br />
    </form>
</body>
</html>
