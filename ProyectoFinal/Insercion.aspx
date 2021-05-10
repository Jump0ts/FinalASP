<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insercion.aspx.cs" Inherits="ProyectoFinal.Inserción" %>
<%@ Register src="UsuarioIniciado.ascx" tagname="datosUsuarios" tagprefix="control" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body class="p-3 mb-2 bg-info text-white">
    <form id="form1" runat="server">
        <control:datosUsuarios runat="server" ID="controlUsuario" />
        <div style="padding-left:450px; padding-top:100px">
            <div>
                <div class="form-group row">
                    <asp:Label runat="server" Text="Tabla: " class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList runat="server" AutoPostBack="true" ID="listTabla" Width="200px" class="form-control search-slt" OnSelectedIndexChanged="tablas_SelectedIndexChanged">

                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div>
                <div class="form-group row">
                    <asp:Label runat="server" Text="Código: " class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtCod" class="form-control" Width="200px"></asp:TextBox>
                        <small id="warningCod" class="text-muted" runat="server" visible="false">
                          <asp:Label runat="server" Text="Debe introducir un código numérico." ForeColor="Red"></asp:Label>
                        </small>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label runat="server" Text="Nombre: " class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtNombre" class="form-control" Width="200px"></asp:TextBox>
                        <small id="warningNombre" class="text-muted" runat="server" visible="false">
                          <asp:Label runat="server" Text="Debe introducir siempre un nombre." ForeColor="Red"></asp:Label>
                        </small>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label runat="server" ID="lblPrecio" Text="Precio: " class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtPrecio" class="form-control" Width="200px"></asp:TextBox>
                        <small id="warningPrecio" class="text-muted" runat="server" visible="false">
                          <asp:Label runat="server" Text="Debe introducir siempre un precio válido." ForeColor="Red"></asp:Label>
                        </small>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label runat="server" ID="lblCod_F" Text="Nombre del Fabricante: " class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList runat="server" ID="listaFabricantes" Width="200px" class="form-control search-slt" OnSelectedIndexChanged="tablas_SelectedIndexChanged">

                        </asp:DropDownList>
                    </div>
                </div>
                <div style="padding-left:100px">
                <div class="form-group row">
                    <asp:Button runat="server" ID="btnInsertar" type="button" class="btn btn-danger wrn-btn" Text="Insertar" OnClick="btnInsertar_Click"></asp:Button>
                    <div class="col-sm-10">
                        <asp:Button runat="server" ID="btnLimpiar" type="button" class="btn btn-danger wrn-btn" Text="Limpiar" OnClick="btnLimpiar_Click"></asp:Button>
                    </div>
                 </div>
                    </div>
            </div>
        </div>
    </form>
</body>
</html>
