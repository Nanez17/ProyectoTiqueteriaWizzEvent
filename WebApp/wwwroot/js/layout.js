function mostrarOpcionesPorRol(rol) {
    $(".opciones").each(function () {
        const rolElemento = $(this).data("rol");
        if (rolElemento === rol) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
 
}
const rolUsuario = localStorage.getItem("rolUsuario");


$(document).ready(function () {

    if (rolUsuario) {
        // Si hay un rol de usuario en el localStorage, 
        $("#btnLogin").hide();
        $("#btnSingOut").show();
    } else {
        // Si no hay un rol de usuario en el localStorage, mostrar SignIn y ocultar SignUp
        $("#btnSingOut").hide();
        $("#btnLogin").show();

    }

    // Mostrar u ocultar otras opciones del nav según el rol de usuario
    mostrarOpcionesPorRol(rolUsuario);
});

function  CerrarSesion() {
    // Limpia el localStorage eliminando el valor asociado a la clave "usuario"
    localStorage.removeItem("idUsuario");
    localStorage.removeItem("rolUsuario")
    updateCart();
    // Redirecciona al usuario al index
    window.location.href = "index"; 
}


