window.onload = function () {
    listarVeterinario();
    validarKeyPress("frmGuardarVeterinario");
}

var objVeterinario;

function listarVeterinario() {
    objVeterinario = {
        url: "Veterinario/listarVeterinario",
        cabeceras: ["Id Veterinario", "Nombre", "Dni", "Celular"],
        propiedades: ["idveterinario", "nombre", "dni", "celular"],
        divContenedorTabla: "contenedorTabla",
        propiedadId: "idveterinario",
        editar: true,
        eliminar: true,
        popup: true,
        popupId: "staticBackdrop"
    }
    pintar(objVeterinario);
}

function BuscarDatos() {
    //Objeto
    var formu = document.getElementById("frmBusqueda");
    var frm = new FormData(formu);
    fetchPost("Veterinario/filtrarVeterinario", "json", frm, function (res) {
        document.getElementById("contenedorTabla").innerHTML = generarTabla(res);
    });
}

function LimpiarVeterinario() {
    LimpiarDatos("frmBusqueda");
    listarVeterinario();
}

function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarVeterinario")
    //Valido los datos
    if (errores != "") {
        Errores(errores)
        return;
    }

    Confirmacion(undefined, "Desea guardar el veterinario", function () {
        var formu = document.getElementById("frmGuardarVeterinario");
        var frm = new FormData(formu);
        fetchPost("Veterinario/guardarDatos", "text", frm, function (res) {
            if (res == "1") {
                Exito();
                listarVeterinario();
                LimpiarDatos("frmGuardarVeterinario");
                document.getElementById("btnCerrarModal").click();
            }
            else
                Errores();
        });
    });
}

function Eliminar(id) {
    Confirmacion(undefined, "Desea eliminar el veterinario", function () {
        fetchGet("Veterinario/eliminarVeterinario/?id=" + id, "text", function (data) {
            if (data == "1") {
                Exito("Se elimino correctamente");
                listarVeterinario();
            } else
                Errores();
        });
    });
}

function Editar(id) {
    LimpiarDatos("frmGuardarVeterinario")
    //Nuevo
    if (id == 0) {
        setI("lbltitulo", "Agregar Veterinario")
    }

    //Editar
    else {
        setI("lbltitulo", "Editar Veterinario")
        recuperarGenerico("Veterinario/recuperarVeterinario/?id=" + id, "frmGuardarVeterinario")
    }
}