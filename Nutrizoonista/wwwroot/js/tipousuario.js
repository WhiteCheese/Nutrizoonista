window.onload = function () {
    listarTipoUsuario();
}

var objTipoUsuario;
function listarTipoUsuario() {
    objTipoUsuario = {
        url: "TipoUsuario/listarTipoUsuario",
        cabeceras: ["Id Tipo usuario", "Nombre", "Descripcion"],
        propiedades: ["idtipousuario", "nombre", "descripcion"]
    }
    pintar(objTipoUsuario)
}