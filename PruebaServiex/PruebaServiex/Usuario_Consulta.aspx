<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario_Consulta.aspx.cs" Inherits="PruebaServiex.Usuario_Consulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta de usuarios</title>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="https://jqueryui.com/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.txtFechaNac').datepicker({
                dateFormat: 'dd/mm/yy'
            });
            $("#<%=txtFechaNacimiento.ClientID%>").datepicker({ dateFormat: 'dd/mm/yy' });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:ScriptManager ID="ScrtManag_CRUD_Users" runat="server" />
        <asp:UpdatePanel ID="updtForm_CRUD_Users" runat="server">
            <ContentTemplate>--%>
        <asp:GridView ID="gvUsers" runat="server" DataKeyNames="Id" AutoGenerateColumns="false"
            EmptyDataText="No hay usuarios registrados" OnRowDataBound="gvUsers_RowDataBound"
            OnRowEditing="gvUsers_RowEditing" OnRowCancelingEdit="gvUsers_RowCancelingEdit"
            OnRowUpdating="gvUsers_RowUpdating" OnRowDeleting="gvUsers_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Id" Visible="false" />
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label ID="lblNombreGV" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombreGV" runat="server" MaxLength="100" Text='<%# Eval("Nombre") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha de nacimiento">
                    <ItemTemplate>
                        <asp:Label ID="lblFechaNacimientoGV" runat="server" Text='<%# Eval("FechaNacimiento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFechaNacimientoGV" runat="server" Text='<%# Bind("FechaNacimiento", "{0:dd/MM/yyyy}") %>' ToolTip="Fecha de nacimiento" CssClass="txtFechaNac"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sexo">
                    <ItemTemplate>
                        <asp:Label ID="lblSexoGV" runat="server" Text='<%# Eval("Sexo") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlSexoGV" runat="server">
                            <asp:ListItem Text="M" Value="M" />
                            <asp:ListItem Text="F" Value="F" />
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Actions" ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
        <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" />
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
    </form>
</body>
</html>
