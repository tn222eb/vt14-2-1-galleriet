<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Galleriet.Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Galleriet</title>
    <link href="~/Content/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <h1>Galleriet</h1>

            <%-- Text som visar att uppladdningen lyckades samt en stängknapp--%>
            <asp:Panel ID="ClosePanel" runat="server" Visible ="false">
                <asp:Label ID="SuccessLabel" runat="server"/>
                <asp:ImageButton ID="ImageCloseButton" runat="server" ImageUrl="Content/close.png" CausesValidation="False" OnClick="ImageCloseButton_Click" />
            </asp:Panel>
 
            <%-- Vald bild i större storlek--%>
            <asp:Panel ID="BigImagePanel" runat="server">
                <asp:Image ID="BigImage" runat="server" ImageUrl="~/Pictures/Chrysanthemum.jpg" Visible="false" />
            </asp:Panel>


            <%-- Thumbnagelsrepeater--%>
            <asp:Panel ID="ThumbRepeaterPanel" runat="server">
                <asp:Repeater ID="ThumbRepeater" runat="server" ItemType="Galleriet.Model.ThumbPic" SelectMethod="ThumbRepeater_GetData">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl='<%# Item.PicFileUrl %>'>
                            <asp:Image ID="ThumbsImage" runat="server" ImageUrl='<%# Item.ThumbPicUrl %>' />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:Repeater>
            </asp:Panel>

            <%-- Validering --%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="En fil måste väljas" Display="None" ControlToValidate="FileUpload"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Endast bilder av typerna gif, jpg eller png är tillåtna" ControlToValidate="FileUpload" Display="None" ValidationExpression=".*.(gif|jpg|png)"></asp:RegularExpressionValidator>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Fel inträffade! Korrigera felet och försök igen." />

            <%-- Fil att ladda upp och kommandoknapp--%>
            <asp:Panel ID="ButtonPanel" runat="server" GroupingText ="Ladda upp bild">
            <asp:FileUpload ID="FileUpload" runat="server" />
            <asp:Button ID="UploadButton" runat="server" Text="Ladda upp" OnClick="UploadButton_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
