window.onload = function () {
    listarSucursal();
}

var objSucursal;

function listarSucursal() {
    objSucursal = {
        url: "Sucursal/listarSucursal",
        cabeceras: ["Id Sucursal", "Nombre", "Dirección"],
        propiedades: ["idsucursal", "nombre", "direccion"]
    }
    pintar(objSucursal);
}

function BuscarSucursal() {
    var nombresucursal = get("txtNombreBusqueda");
    objSucursal.url = "Sucursal/filtrarSucursal/?nombre=" + nombresucursal
    pintar(objSucursal);
}

function LimpiarListaSucursal() {
    listarSucursal();
    set("txtNombreBusqueda", "");
}