<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Galleriet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Galleriet</title>
    <link href="~/Content/Style.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Galleriet</h1>
        <div>
            <%-- Fil att ladda upp --%>
            <asp:FileUpload ID="FileUpload" runat="server" />
            <%-- Validering --%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="En fil måste väljas" Display="None" ControlToValidate="FileUpload"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Endast bilder av typerna gif, jpg eller png är tillåtna" ControlToValidate="FileUpload" Display="None" ValidationExpression=".*(gif|GIF|jpg|JPG|png|PNG)"></asp:RegularExpressionValidator>
            <%-- ValidationSummary--%>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Fel inträffade! Korrigera felet och försök igen." />
            <asp:Button ID="UploadButton" runat="server" Text="Ladda upp" OnClick="UploadButton_Click" />

            <%-- Thumbnagelsrepeater--%>
            <asp:Repeater ID="ThumbRepeater" runat="server" ItemType="Galleriet.Model.ThumbPic" SelectMethod="ThumbRepeater_GetData">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink" runat="server">
                        <asp:Image ID="ThumbsImage" runat="server" />
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
