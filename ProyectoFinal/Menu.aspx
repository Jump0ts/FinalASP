<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ProyectoFinal.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio de sesión</title>
	
	<link href='MenuStyle.css' rel="stylesheet" type="text/css" />
	<link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

	

</head>

<body class="p-3 mb-2 bg-primary text-white">
	<form id="form1" runat="server">
	<div id="login">

		<h1>Identifíquese</h1>

		

			<fieldset>

				<p>Usuario:<asp:TextBox runat="server" ID="txtUser" type="text" Width ="280px"/></p>

				<p>Contraseña:<asp:TextBox runat="server" ID="txtPass" type="password" Width ="280px"/></p> 

				<p><asp:Label ID="lblErrorUs" runat="server" Text="Usuario no encontrado." class="p-3 mb-2 bg-danger text-white" Visible="false"></asp:Label></p>
				
				<p><asp:Label ID="lblErrorPass" runat="server" Text="Contraseña incorrecta." class="p-3 mb-2 bg-danger text-white" Visible="false"></asp:Label></p>

				<p><asp:Button ID="btnIniciar" runat="server" CssClass="inicia" Text="Iniciar Sesión" OnClick="btnIniciar_Click"/></p>

				<p><asp:Button ID="btnInvitado" runat="server" CssClass="invitado" Text="Entrar como invitado" OnClick="btnInvitado_Click"/></p>

			</fieldset>
        </div>
    </form>
</body>
</html>
