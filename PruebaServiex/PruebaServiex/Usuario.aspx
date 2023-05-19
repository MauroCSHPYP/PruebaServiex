<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="PruebaServiex.Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Usuario</title>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="https://jqueryui.com/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#<%=txtFechaNacimiento.ClientID%>").datepicker({ dateFormat: 'dd/mm/yy' });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScrtManagUsuario" runat="server" />
        <asp:UpdatePanel ID="updtFormUsuario" runat="server">
            <ContentTemplate>
                <table border="1" cellpadding="1" cellspacing="1" style="border-collapse: collapse">
                    <tr>
                        <td>
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" /></td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de nacimiento:" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSexo" runat="server" Text="Sexo:" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSexo" runat="server">
                                <asp:ListItem Text="M" Value="M" />
                                <asp:ListItem Text="F" Value="F" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnAddPerson" Text="Crear" runat="server" OnClick="btnAddPerson_Click" />
                        </td>
                    </tr>
                </table>
                <p>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" />
                </p>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
