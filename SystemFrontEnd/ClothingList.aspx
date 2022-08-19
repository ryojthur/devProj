<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClothingList.aspx.cs" Inherits="ClothingList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 799px">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Your Wardrobe:" Font-Size="40" Font-Underline="true"></asp:Label>
        <div>
        </div>
        <asp:ListBox ID="lstClothingList" runat="server" Height="664px" OnSelectedIndexChanged="lstClothingList_SelectedIndexChanged" Width="40%" margin-left="1000px" BorderWidth="10px" Padding="1000px"></asp:ListBox>
        <p style="margin-left: 400px">
            &nbsp;</p>
        <p style="margin-left: 40px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="AddItem" runat="server" OnClick="AddItem_Click" Text="Add Item" Height="8%" Width="12%" BorderWidth="7px"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete Item" Height="8%" Width="12%" BorderWidth="7px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
