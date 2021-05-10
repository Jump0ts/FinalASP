<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BarraBuscarInv.ascx.cs" Inherits="ProyectoFinal.BarraBuscarInv" %>
<link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

<section class="search-sec">
    <div class="container">
        
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-12 p-0">
                            <asp:DropDownList runat="server" class="form-control search-slt" ID="listaTablas" OnSelectedIndexChanged="selectTabChange"  AutoPostBack="true">
                                
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 p-0">
                            <asp:DropDownList runat="server" class="form-control search-slt" ID="listaColum">
                                
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 p-0">
                            <asp:TextBox runat="server" ID="txtValor" type="text" class="form-control search-slt" placeholder="Atributo tabla"/>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 p-0">
                            <asp:Label runat="server" ID="lblWarn" Text="Debe introducir un código numérico." ForeColor="Red" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        
    </div>
</section>