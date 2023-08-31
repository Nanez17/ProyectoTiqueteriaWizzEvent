// recoveryController.js
function recoveryController() {
    this.ApiService = "Users";
    var self = this;

    this.InitView = function () {
       
    }

    this.Update = function (email, newPassword) {
        var serviceToUpdate = "https://localhost:7152/api/Users/UpdatePassword";

       
        var queryString = "Email=" + encodeURIComponent(email) + "&Password=" + encodeURIComponent(newPassword);

      
        var apiUrl = serviceToUpdate + "?" + queryString;

        
        $.ajax({
            url: apiUrl,
            type: 'PUT',
            success: function (data) {
              
                sweetAlertModule.showSuccessAlert('Cambio de Contrasena Exitoso', 'Tu contrasena ha sido cambiada exitosamente.');
                
                window.location.href = 'LoginUser';
            },
            error: function (xhr, status, error) {
              
                console.error('Error actualizando la contrasena:', error);
            }
        });
    }


    this.RetrieveByEmail = function (emailInput) {
        const apiUrl = 'https://localhost:7152/api/Users/RetrieveByEmail';

        $.ajax({
            url: apiUrl,
            type: 'GET',
            data: { email: emailInput },
            dataType: 'json',
            success: function (data) {
                x(data);
            },
            error: function (xhr, status, error) {
                console.error('Error retrieving data:', error);
            }
        });
    }
}


var validationModule = (function () {
    function validateEmail(email) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return email !== '' && emailRegex.test(email);
    }

    return {
        validateEmail: validateEmail
    };
})();


var sweetAlertModule = (function () {
    function showErrorAlert(title, text) {
        Swal.fire({
            icon: 'error',
            title: title,
            text: text,
        });
    }

    function showSuccessAlert(title, text) {
        Swal.fire({
            icon: 'success',
            title: title,
            text: text,
        });
    }

    function showOTPInput(onConfirm) {
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
            preConfirm: onConfirm
        });
    }

    function showNewPasswordInput(onConfirm) {
        Swal.fire({
            title: 'Solicitar nueva contrasena',
            input: 'password',
            inputAttributes: {
                autocapitalize: 'off'
            },
            showCancelButton: true,
            confirmButtonText: 'Guardar',
            showLoaderOnConfirm: true,
            preConfirm: onConfirm,
            allowOutsideClick: () => !Swal.isLoading()
        });
    }

    return {
        showErrorAlert: showErrorAlert,
        showSuccessAlert: showSuccessAlert,
        showOTPInput: showOTPInput,
        showNewPasswordInput: showNewPasswordInput
    };
})();

$(document).ready(function () {
    var view = new recoveryController();
    view.InitView();
});

function validateCorreo() {
    var email = $("#email").val();

    if (!validationModule.validateEmail(email)) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Ingresa un correo electronico valido!',
        })

        return;
    }
    var view = new recoveryController();
     view.RetrieveByEmail(email);
   
}
function x(user) {

    if (user) {
        const apiUrl = `OTP/GenerateEmail?email=${encodeURIComponent(user.email)}`;
        var ctrlActions = new ControlActions();
      
        ctrlActions.PostToAPI(apiUrl, user.email, function (valor,otpValue) {
            var otpValueString = otpValue.toString();
            sweetAlertModule.showOTPInput(function (otp) {
                if (otp === otpValueString) {
                    sweetAlertModule.showSuccessAlert('Codigo OTP valido', 'El codigo OTP es correcto. Verificacion exitosa.');
                    sweetAlertModule.showNewPasswordInput(function (newPassword) {
                        if (newPassword.length < 6) {
                            Swal.showValidationMessage('La contraseña debe tener al menos 6 caracteres');
                            return;
                        }
                        var recoveryCtrl = new recoveryController();
                        recoveryCtrl.Update(user.email, newPassword);
                    });
                } else {
                    Swal.showValidationMessage('Codigo OTP incorrecto. Por favor, ingrese el codigo correcto.');
                }
            });
        });
    }
}







