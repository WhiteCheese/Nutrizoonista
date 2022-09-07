window.onload = function () {
    listarServicio();
}

function filtrarServicio() {
    var nombre = get("txtNombreBusqueda");
    if (nombre == "") {
        listarServicio();
    } else {
        objGlobalServicio.url = "Servicio/filtrarServicio/?nombre=" + nombre
        pintar(objGlobalServicio);
    }
}

var objGlobalServicio;

function listarServicio() {
    objGlobalServicio = {
        url: "Servicio/listarServicio",
        cabeceras: ["Id servicio", "Nombre", "Descripcion"],
        propiedades: ["idservicio", "nombre", "descripcion"]
    }
    pintar(objGlobalServicio)

}