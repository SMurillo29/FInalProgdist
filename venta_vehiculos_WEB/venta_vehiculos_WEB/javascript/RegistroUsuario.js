$(document).ready(function () {
    LlenarComboTipoInfraccion();
    $("#lstRol").on('change', function () {
        CalcularValorInfraccion();
    });

    $("#btnGrabar").click(function () {
        GrabarMulta();
    });
});

function LlenarComboTipoInfraccion() {
    var promise = LlenarComboControlador("../Comunes/ControladorCombos.ashx", "ROL", null, "#lstRol");
    if (promise) {
        promise.then(function (value) {
            //Se invoca el llenado del combo de producto
            CalcularValorInfraccion();
        });
    }
}

function CalcularValorInfraccion() {
    var arrValor = $("#lstTipoInfraccion").val().split('|');
    $("#txtValorInfraccion").val(arrValor[1]);
}

function GrabarMulta() {
    var Documento = $("#txtDocumento").val();
    var Nombre = $("#txtNombres").val();
    var Telefono = $("#txtTelefono").val();
    var Email = $("#txtEmail").val();
    var arrValor = $("#lstTipoInfraccion").val();
    var TipoInfraccion = arrValor[0];
    var FechaInfraccion = $("#txtFechaHora").val();
    var Valor = $("#txtValorInfraccion").val();
    var NombreAgente = $("#txtNombreAgente").val();
    var Comando = "Grabar";

    var MultaTransito = {
        IdTipoInfraccion: TipoInfraccion,
        FechaInfraccion: FechaInfraccion,
        ValorInfraccion: Valor,
        NombreAgente: NombreAgente
    }

    var DatosMulta = {
        IdUsuario: 0,
        Documento: Documento,
        Nombre: Nombre,
        Telefono: Telefono,
        Email: Email,
        Comando: Comando,
        MultaTransito
    }


    $.ajax({
        type: "POST",
        url: "../Controlador/ControladorMultas.ashx",
        contentType: "application/json",
        data: JSON.stringify(DatosMulta),
        dataType: "html",
        success: function (respuesta) {
            $("#dvMensaje").html(respuesta);
        },
        error: function (respuesta) {
            $("#dvMensaje").html("Error: " + respuesta);
        }
    });
}