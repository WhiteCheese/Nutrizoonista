window.onload = function () {
    listarCita();
    validarKeyPress("frmGuardarCita");
}

var objCita;

function listarCita() {
    objCita = {
        url: "Cita/listarCita",
        cabeceras: ["Id Cita", "Nombre Mascota", "Servicio", "Veterinario", "Sucursal", "Fecha", "Horario"],
        propiedades: ["idcita", "nombremascota", "nombreservicio", "nombreveterinario", "nombresucursal", "fecharegistro", "horario"],
        divContenedorTabla: "contenedorTabla",
        propiedadId: "idcita",
        editar: false,
        eliminar: false,
        descargar: true,
        popup: true,
        popupId: "staticBackdrop"
    }
    pintar(objCita);
}

function BuscarDatos() {
    //Objeto
    var formu = document.getElementById("frmBusqueda");
    var frm = new FormData(formu);
    fetchPost("Cita/filtrarCita", "json", frm, function (res) {
        document.getElementById("contenedorTabla").innerHTML = generarTabla(res);
    });
}

function LimpiarCita() {
    LimpiarDatos("frmBusqueda");
    listarCita();
}

function Descargar() {
    fetchPost("Cita/DescargarPDF", "json", frm, function (res) {

    });
}