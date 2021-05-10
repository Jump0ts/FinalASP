<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsuarioIniciado.ascx.cs" Inherits="ProyectoFinal.UsuarioIniciado" %>

    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
<div >
<section class="search-sec" style="background-color:aqua">
    <div class="container">
        
            <div class="row" style="padding-top:10px">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-12 p-0">
                            <asp:Label runat="server" ID="identificador" ForeColor="Black"></asp:Label>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 p-0">
                            <asp:Button runat="server" ID="btnInsercion" type="button" class="btn btn-success" Text="Insertar" OnClick="btnInsercion_Click" ></asp:Button>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 p-0">
                            <asp:Button runat="server" ID="btnMod" type="button" class="btn btn-success" Text="Modificar" OnClick="btnMod_Click" ></asp:Button>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 p-0">
                            <asp:Button runat="server" ID="btnElim" type="button" class="btn btn-success" Text="Eliminar" OnClick="btnElim_Click"  ></asp:Button>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 p-0">
                            <asp:Button runat="server" ID="btnCerrar" type="button" class="btn btn-danger wrn-btn" Text="Cerrar Sesión" OnClick="btnCerrar_Click" ></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        
    </div>
</section>
    </div>