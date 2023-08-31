

function validarFormulario() {
    var view = new createUserController();
    // Obtener valores de los campos
    const nombre = document.getElementById('nombre').value;
    const apellidos = document.getElementById('apellidos').value;
    const tipoIdentificacion = document.getElementById('tipoIdentificacion').value;
    const numeroIdentificacion = document.getElementById('numeroIdentificacion').value;
    const email = document.getElementById('email').value;
    const telefono = document.getElementById('telefono').value;
    const cedulaImagen = view.GetImages();
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirmPassword').value;
    const ubicacion = document.getElementById('address').value;


    if (!nombre || !apellidos || !tipoIdentificacion || !numeroIdentificacion || !email || !telefono || !cedulaImagen || !password || !confirmPassword) {
        mostrarError('Todos los campos son requeridos.');
        return false;
    }

    if (nombre.length > 50) {
        mostrarError('El nombre no puede tener más de 50 caracteres.');
        return false;
    }

    if (apellidos.length > 50) {
        mostrarError('Los apellidos no pueden tener más de 50 caracteres.');
        return false;
    }

    if (tipoIdentificacion !== 'nacional' && tipoIdentificacion !== 'extranjero') {
        mostrarError('Seleccione un tipo de identificación válido.');
        return false;
    }

    if (!/^[0-9]+-[0-9]{4}-[0-9]{4}$/.test(numeroIdentificacion)) {
        mostrarError('Número de identificación inválido. Debe tener el formato x-xxxx-xxxx y solo contener números.');
        return false;
    }

    if (!/^[\w.-]+@[a-z\d.-]+\.[a-z]{2,}$/i.test(email)) {
        mostrarError('El email ingresado no es válido.');
        return false;
    }

    if (!/^[876]\d{3}-\d{4}$/.test(telefono)) {
        mostrarError('El teléfono ingresado no tiene el formato correcto.');
        return false;
    }

    if (!ubicacion) {
        mostrarError('La ubicacion es requerida.');
        return false;
    }


    /*if (!/(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+,-./:;<=>?@[\\]^_`{|}~])(?!.*(1234|abcd)).{8,}/.test(password)) {
        mostrarError('La contraseña no cumple con los requisitos mínimos.');
        return false;
    }*/

    if (password !== confirmPassword) {
        mostrarError('Las contraseñas no coinciden.');
        return false;
    }

    Swal.fire({
        title: 'Validacion',
        text: '¿Deseas validar tu correo o tu telefono?',
        showCancelButton: true,
        confirmButtonText: 'Correo',
        cancelButtonText: 'Telefono',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {

            validacionOTPCorreo();
        } else if (result.dismiss === Swal.DismissReason.cancel) {

            validacionOTPTelefono();
        }
    });

    return true;
}


function crearUsuario() {
    if (validarFormulario()) {
        var view = new createUserController();
        imagen = view.GetImages();

        const user = {
            Nombre: document.getElementById('nombre').value,
            Apellidos: document.getElementById('apellidos').value,
            TipoIdentificacion: document.getElementById('tipoIdentificacion').value,
            NumeroIdentificacion: document.getElementById('numeroIdentificacion').value,
            Email: document.getElementById('email').value,
            Telefono: document.getElementById('telefono').value,
            CedulaImagen: imagen.url,
            Password: document.getElementById('password').value,
            ConfirmPassword: document.getElementById('confirmPassword').value,
            ubicacion: document.getElementById('address').value
        };

        var ctrlActions = new ControlActions();
        var serviceToDelete = "Users" + "/CreateGE";

        ctrlActions.PostToAPI(serviceToDelete, user, function (data) {

            mostrarExito('Usuario creado correctamente.');

        });
    }
}


function mostrarError(mensaje) {
    Swal.fire({
        icon: 'error',
        title: 'Error',
        text: mensaje,
    });
}

function mostrarExito(mensaje) {
    Swal.fire({
        icon: 'success',
        title: 'Buen trabajo',
        text: mensaje,
    });
}


const form = document.querySelector('form');



function validacionOTPCorreo() {

    var email = document.getElementById('email').value

    const apiUrl = `OTP/GenerateEmail?email=${encodeURIComponent(email)}`;
    var ctrlActions = new ControlActions();

    ctrlActions.PostToAPI(apiUrl, "", function (valueTrue, otpValue) {

        var otpValueString = otpValue.toString();
        Swal.fire({
            title: 'Ingrese el codigo OTP',
            input: 'text',
            inputAttributes: {
                autocapitalize: 'off'
            },
            showCancelButton: true,
            confirmButtonText: 'Verificar',
            cancelButtonText: 'Cancelar',
            showLoaderOnConfirm: true,
            preConfirm: (otp) => {

                if (otp === otpValueString) {

                    Swal.fire({
                        icon: 'success',
                        title: 'Codigo OTP valido',
                        text: 'El codigo OTP es correcto. Verificacion exitosa.',
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        if (result.isConfirmed) {

                            crearUsuario();
                        }
                    });
                } else {

                    Swal.showValidationMessage('Codigo OTP incorrecto. Por favor, ingrese el codigo correcto.');
                }
            }
        });


    });
}
function validacionOTPTelefono() {
    var phone = document.getElementById('telefono').value

    var ctrlActions = new ControlActions();
    const apiUrl = `OTP/GeneratePhone?phone=${encodeURIComponent(phone)}`;
    ctrlActions.PostToAPI(apiUrl, "", function () {

        var otpValueString = otpValue.toString();
        Swal.fire({
            title: 'Ingrese el codigo OTP',
            input: 'text',
            inputAttributes: {
                autocapitalize: 'off'
            },
            showCancelButton: true,
            confirmButtonText: 'Verificar',
            cancelButtonText: 'Cancelar',
            showLoaderOnConfirm: true,
            preConfirm: (otp) => {

                if (otp === otpValueString) {

                    Swal.fire({
                        icon: 'success',
                        title: 'Codigo OTP valido',
                        text: 'El codigo OTP es correcto. Verificacion exitosa.',
                        confirmButtonText: 'OK'
                    }).then((result) => {
                        if (result.isConfirmed) {

                            crearUsuario();
                        }
                    });
                } else {

                    Swal.showValidationMessage('Codigo OTP incorrecto. Por favor, ingrese el codigo correcto.');
                }
            }
        });
    });

}

$("#btn-siguiente").click(function () {

    validarFormulario();
})

$(document).ready(function () {
    var view = new createUserController();
    view.InitView();
})

function createUserController() {

    this.InitView = function () {
        var view = new createUserController();
        view.LoadImages();
    }
    this.LoadImages = function () {
        console.log('boton');
        const container = $("#container-images-names");
        const myWidget = cloudinary.createUploadWidget(
            {
                cloudName: 'eventwizz',
                uploadPreset: 'ml_default'
            },
            (error, result) => {
                if (!error && result && result.event === "success") {
                    const badge1 = $("<span></span>")
                        .addClass("badge rounded-pill bg-info")
                        .text(result.info.original_filename)
                        .attr("data-url", result.info.secure_url);

                    container.append(badge1);
                }
            }
        );

        $('#btnLoadImages').on('click', function () {
            myWidget.open();
        });
    }

    this.GetImages = function () {
        var spamObjects = [];

        var spamElements = $("#container-images-names .badge");

        spamElements.each(function () {
            var spamObject = {
                name: $(this).text(),
                url: $(this).attr("data-url")
            };

            spamObjects.push(spamObject);
        });

        return spamObjects[0]; // Devolver el arreglo spamObjects
    };
}