<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Test._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/jquery.maskedinput.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.phoneClass').change(function () {
                $(".phoneClass").mask("(800) 999-9999");
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblPhone" runat="server" Text="Label">Phone: </asp:Label>
            <asp:TextBox ID="txtPhone" CssClass="phoneClass" runat="server"></asp:TextBox>
            <asp:CustomValidator runat="server" Display="Dynamic" ID="phoneValidator"
                ForeColor="Red" ErrorMessage="" ValidationGroup="" OnServerValidate="phoneValidator_ServerValidate">  
            </asp:CustomValidator>
              <asp:Label ID="Label1" runat="server" ForeColor ="Red" Visible="false" Text="Label"> </asp:Label>
            <div style="margin-left: 50px; margin-top: 5px;">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            </div>

        </div>
    </form>

</body>
</html>
