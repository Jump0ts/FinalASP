<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagInv.aspx.cs" Inherits="ProyectoFinal.PagInv" %>
<%@ Register src="BarraBuscarInv.ascx" tagname="buscar" tagprefix="barra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body class="p-3 mb-2 bg-info text-white">
    <form id="form1" runat="server">
        <div class="container">
    
<section class="search-sec">
    <div class="container">
        
            <div class="row">
                <div class="col-lg-12">
                    <barra:buscar runat="server" ID="datos"/>
                    <div style="padding-left:400px">
                            <asp:Button runat="server" ID="btnBuscar" type="button" class="btn btn-danger wrn-btn" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
                        <asp:Button runat="server" ID="btnVolver" type="button" class="btn btn-danger wrn-btn" Text="Volver" OnClick="btnVolver_Click" ></asp:Button>
                    </div>
                </div>
            </div>
        
    </div>
</section>
            <div>
                <asp:GridView runat="server" ID="tabla" CssClass="table table-condensed table-hover" BackColor="White">
                    
                </asp:GridView>
                <asp:Label runat="server" ID="lblCoin" Text="No se ha encontrado ninguna coincidencia." CssClass="p-3 mb-2 bg-danger text-white" Visible="false"></asp:Label>
            </div>
            </div>
    </form>
</body>
</html>
