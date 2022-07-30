<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm12.aspx.cs" Inherits="WebApplication122.WebForm12" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">


        <div class="conainter" style="background-image:linear-gradient(180deg, #e6c63b, #030202);

                                       position:absolute;
                                       top:50%;
                                       left:50%;
                                       transform:translate(-50%,-50%); height: 309px;">

            <asp:TextBox ID="txtCode" runat="server" Enabled="False"></asp:TextBox>

            <asp:Button ID="btnGenerate" runat="server" Text="Generate QR Code" OnClick="btnGenerate_Click"/>
            <asp:Button ID="btnGenNumber" runat="server" Text="Generate Number" OnClick="btnGenNumber_Click"/>
            <hr/>
            <asp:image ID="imgQRCode" with="100px" height="210px" runat="server" Visible="false" Width="357px" style="align-items:center;" />
            <br/>
            <asp:Button ID="btnRead" runat="server" Text="Read QR Image" OnClick="btnRead_Click"/>

            <asp:Button ID="btnWriting" runat="server" Text="Read text" OnClick="btnWriting_Click"/>
            <br />
            <asp:Label ID="LbCode" runat="server" ></asp:Label>
            <br/>
            <br/>
            <asp:Label ID="lblQRCode" runat="server"></asp:Label> 
        
        </div>
    </form>
</body>
</html>
