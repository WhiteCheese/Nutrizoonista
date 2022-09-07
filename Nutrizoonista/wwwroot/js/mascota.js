window.onload = function () {
    listarMascota();
}

function filtrarMascota() {
    var nombre = get("txtNombreBusqueda");
    if (nombre == "") {
        listarMascota();
    } else {
        objGlobalMascota.url = "Mascota/filtrarMascota/?nombre=" + nombre
        pintar(objGlobalMascota);
    }
}

var objGlobalMascota;

function listarMascota() {
    objGlobalMascota = {
        url: "Mascota/listarMascota",
        cabeceras: ["Id Mascota", "Nombre", "Especie", "Género", "Edad"],
        propiedades: ["idmascota", "nombremascota", "especiemascota", "generomascota", "edadmascota"],
        propiedadId: "idmascota",
        editar: true,
        eliminar: true,
        popup: true,
        popupId: "staticBackdrop"
    }
    pintar(objGlobalMascota)
}

function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarMascota")
    //Valido los datos
    if (errores != "") {
        Errores(errores)
        return;
    }

    Confirmacion(undefined, "Desea guardar la mascota", function () {
        var formu = document.getElementById("frmGuardarMascota");
        var frm = new FormData(formu);
        fetchPost("Mascota/guardarDatos", "text", frm, function (res) {
            if (res == "1") {
                Exito();
                listarMascota();
                LimpiarDatos("frmGuardarMascota");
                document.getElementById("btnCerrarModal").click();
            }
            else
                Errores();
        });
    });
}

function Eliminar(id) {
    Confirmacion(undefined, "Desea eliminar la mascota", function () {
        fetchGet("Mascota/eliminarMascota/?id=" + id, "text", function (data) {
            if (data == "1") {
                Exito("Se elimino correctamente");
                listarMascota();
            } else
                Errores();
        });
    });
}

function Editar(id) {
    LimpiarDatos("frmGuardarMascota")
    //Nuevo
    if (id == 0) {
        setI("lbltitulo", "Agregar Mascota")
    }

    //Editar
    else {
        setI("lbltitulo", "Editar Mascota")
        recuperarGenerico("Mascota/recuperarMascota/?id=" + id, "frmGuardarMascota")
    }
}
