<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarDatos.aspx.cs" Inherits="Tp_PromoWeb_Equipo_4A.AgregarDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="display: flex; flex-direction: column; justify-content: space-around; align-items: center; margin-top: 2em;">

        <div id="titulo" style="display: flex; flex-direction: column; justify-content: space-between; width: 100%; margin-bottom: 2em; margin-left: 5em";>
            <h3>Agrega tus datos</h3>
        </div>

        <div id="form" style="display: flex; flex-direction: row; justify-content: space-around; width: 100%;">

            <div class="col-1" id="columna1" style="width: 45%;">

   

                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtNombre" placeholder="Nombre" required="true" runat="server" />
                    <label for="nombre">Nombre *</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtApellido" placeholder="Apellido" required="true" runat="server" />
                    <label for="Apellido">Apellido *</label>
                </div>

                <div class="form-floating mb-3">
                    <asp:TextBox type="text" class="form-control" ID="txtDni" placeholder="Dni" required="true" runat="server" />
                    <label for="Dni">Dni *</label>
                </div>

                <div id="sexo">
                    <asp:RadioButtonList ID="rblist" runat="server">
                        <asp:ListItem Value="m" cssClass="w3-radio" id="rbtnM">Masculino</asp:ListItem>
                        <asp:ListItem Value="f" cssClass="w3-radio" id="rbtnF">Femenino</asp:ListItem>
                        <asp:ListItem Value="x" cssClass="w3-radio" id="rbtnX">Otro</asp:ListItem>
                    </asp:RadioButtonList>
                </div>

            </div>
            <div class="col-2" id="columna2" style="display: flex; flex-direction: column; justify-content: space-around; width: 45%;">

                <div class="form-floating mb-3">
                    <asp:TextBox type="text" ID="txtEmail" placeholder="name@example.com" CssClass="form-control" required="true" runat="server" />
                    <label for="Email">Email *</label>
                </div>

                <%--<div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtCelular" placeholder="Celular" runat="server" />
                    <label for="celular">Celular</label>
                </div>--%>

                    <div class="form-floating mb-3">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtDireccion" placeholder="Dirección" required="true" runat="server" />
                    <label for="Direccion">Dirección *</label>
                </div>
 
                     <div class="form-floating mb-3">
                     <asp:TextBox type="text" CssClass="form-control" ID="txtCiudad" placeholder="Ciudad" required="true" runat="server" />
                     <label for="Ciudad">Ciudad *</label>
                </div>

                     <div class="form-floating mb-3">
                     <asp:TextBox type="text" CssClass="form-control" ID="txtCP" placeholder="CP" required="true" runat="server" />
                     <label for="CP">Código Postal *</label>
                </div>


                   <%-- <div id="fecha-ls" style="padding-top:20px;">

                        <label for="fecha">Fecha *</label>
                        <asp:textbox type="date" id="fecha" class="form-select" AutoPostBack="true" onkeydown="return false;" runat="server"></asp:textbox>

                    </div> --%>
            </div>
        </div>
        <div id="agregar" class="col-3" style="display: flex; justify-content: end; width: 100%; margin-top: 2em; margin-right: 15em">
            <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-outline-success" OnClick="btnAgregar_Click" runat="server" />
            <asp:Button Text="Eliminar" CssClass="btn btn-outline-danger m-1" ID="btnEliminar" runat="server" />
        </div>
        <br />
        <div>
            <p>(*) Campos obligatorios</p>
        </div>
    </div>
</asp:Content>

    