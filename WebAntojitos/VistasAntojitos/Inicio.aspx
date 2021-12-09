<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebAntojitos.VistasAntojitos.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <style type="text/css">
        .auto-style1 {
            width: 151px;
        }
        .auto-style2 {
            height: 53px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div class="container">
    <div class="row justify-content-center pt-5 mt-5">
        <div class="col-md-6 formulario">
            <div class="form-group text-center">
                <h1 class="text-green">
                    <asp:Label ID="Label1" runat="server" Text="Supermercado Antojitos"></asp:Label></h1>
            </div>
            <div class="form-group text-center">
                <table class="w-100">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="2">Iniciar Session</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>
            <div class="form-group mx-sm-5">
                Ingrese Usuario&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="txtUsuario" runat="server" Width="231px"></asp:TextBox>
                <br />
                <br />
            </div>
            <div class="form-group mx-sm-5">
                Ingrese Contraseña
                <asp:TextBox ID="txtClave" runat="server" Width="229px"  TextMode="Password" ></asp:TextBox>
                <br />
            </div>
            <div class="row justify-content-center pt-2 mt-2">
                <table class="w-100">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td class="auto-style1">
                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" style="height: 26px" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
           </div>

            <div> 
          <h1><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></h1>
         </div>

        </div>

        



    </div>






</div>
    </form>
</body>
</html>
