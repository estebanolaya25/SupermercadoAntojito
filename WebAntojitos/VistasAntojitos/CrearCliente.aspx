<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearCliente.aspx.cs" Inherits="WebAntojitos.VistasAntojitos.CrearCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 229px;
        }
        .auto-style3 {
            width: 296px;
        }
        .auto-style4 {
            width: 296px;
            height: 48px;
        }
        .auto-style5 {
            height: 48px;
        }
        .auto-style7 {
            width: 229px;
            height: 52px;
        }
        .auto-style8 {
            width: 296px;
            height: 52px;
        }
        .auto-style9 {
            height: 52px;
        }
        .auto-style11 {
            width: 229px;
            height: 48px;
        }
        .auto-style12 {
            width: 296px;
            height: 45px;
        }
        .auto-style13 {
            width: 229px;
            height: 45px;
        }
        .auto-style14 {
            height: 45px;
        }
        .auto-style15 {
            width: 296px;
            height: 50px;
        }
        .auto-style16 {
            width: 229px;
            height: 50px;
        }
        .auto-style17 {
            height: 50px;
        }
        .auto-style18 {
            width: 296px;
            height: 36px;
        }
        .auto-style19 {
            width: 229px;
            height: 36px;
        }
        .auto-style20 {
            height: 36px;
        }
        .auto-style21 {
            width: 296px;
            height: 49px;
        }
        .auto-style22 {
            width: 229px;
            height: 49px;
        }
        .auto-style23 {
            height: 49px;
        }
        .auto-style24 {
            height: 48px;
            width: 264px;
        }
        .auto-style25 {
            width: 264px;
        }
        .auto-style26 {
            height: 52px;
            width: 264px;
        }
        .auto-style27 {
            height: 45px;
            width: 264px;
        }
        .auto-style28 {
            height: 50px;
            width: 264px;
        }
        .auto-style29 {
            height: 36px;
            width: 264px;
        }
        .auto-style30 {
            height: 49px;
            width: 264px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style5" colspan="2">&nbsp; El cliente no se encuenta Registrado<br />
&nbsp;Por favor Ingrese Informacion del Cliente:</td>
                    <td class="auto-style24">Usuario:
                        <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style5"></td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style25">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style7">Documento:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtDocumento" runat="server" Width="119px"></asp:TextBox>
                    </td>
                    <td class="auto-style26"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style11">Nombres</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtNombre" runat="server" Width="269px"></asp:TextBox>
                    </td>
                    <td class="auto-style24"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td class="auto-style12"></td>
                    <td class="auto-style13">Apillidos</td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtApellidos" runat="server" Width="266px"></asp:TextBox>
                    </td>
                    <td class="auto-style27"></td>
                    <td class="auto-style14"></td>
                    <td class="auto-style14"></td>
                </tr>
                <tr>
                    <td class="auto-style15"></td>
                    <td class="auto-style16">Direccion</td>
                    <td class="auto-style17">
                        <asp:TextBox ID="txrDireccion" runat="server" Width="267px"></asp:TextBox>
                    </td>
                    <td class="auto-style28"></td>
                    <td class="auto-style17"></td>
                    <td class="auto-style17"></td>
                </tr>
                <tr>
                    <td class="auto-style18"></td>
                    <td class="auto-style19">Telefono</td>
                    <td class="auto-style20">
                        <asp:TextBox ID="txtTelefono" runat="server" Width="264px"></asp:TextBox>
                    </td>
                    <td class="auto-style29"></td>
                    <td class="auto-style20"></td>
                    <td class="auto-style20"></td>
                </tr>
                <tr>
                    <td class="auto-style21"></td>
                    <td class="auto-style22">Email</td>
                    <td class="auto-style23">
                        <asp:TextBox ID="txtEmial" runat="server" Width="264px"></asp:TextBox>
                    </td>
                    <td class="auto-style30"></td>
                    <td class="auto-style23"></td>
                    <td class="auto-style23"></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style25">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnCrearCliente" runat="server" OnClick="btnCrearCliente_Click" Text="Crear Cliente" />
                    </td>
                    <td class="auto-style25">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style25">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style25">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
