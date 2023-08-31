function toggleAuthMethod() {
    const authMethod = document.getElementById("authMethod").value;
    const otpFields = document.getElementById("otpFields");

    if (authMethod === "otp_email" || authMethod === "otp_phone") {
        otpFields.style.display = "block";
    } else {
        otpFields.style.display = "none";
    }
}


function goBack() {
    window.location.href = 'UbicationUser';
}

function requestOTP() {
    const authMethod = document.getElementById("authMethod").value;
    const deliveryAddressInput = document.getElementById("deliveryAddress").value;

    if (authMethod === "otp_email" || authMethod === "otp_phone") {
        if (!deliveryAddressInput) {
            Swal.fire("Error", "Por favor ingrese la dirección de entrega (correo o teléfono).", "error");
            return;
        }

        const otpRequestData = {
            userId: parseInt(document.getElementById("userId").value),
            deliveryMethod: authMethod,
            deliveryAddress: deliveryAddressInput
        };

        fetch('/api/OTP/Generate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(otpRequestData)
        })
            .then(response => response.json())
            .then(data => {
                if (authMethod === "otp_email") {
                    Swal.fire("Éxito", "Código OTP enviado al correo electrónico.", "success");
                } else if (authMethod === "otp_phone") {
                    Swal.fire("Éxito", "Código OTP enviado al teléfono.", "success");
                }

                console.log('Código OTP generado y enviado:', data);
            })
            .catch(error => {
                console.error('Error al generar y enviar el código OTP:', error);
                Swal.fire("Error", "Error al generar y enviar el código OTP. Inténtelo nuevamente.", "error");
            });
    } else {
        Swal.fire("Error", "Por favor seleccione un método de autenticación válido.", "error");
    }
}

function validateOTP() {
    const otpInput = document.getElementById("otp").value;
    const userId = document.getElementById("userId").value;

    if (!otpInput) {
        Swal.fire("Error", "Por favor ingrese el código OTP.", "error");
        return;
    }

    const otpValidationData = {
        userId: parseInt(userId),
        otpCode: otpInput
    };

    fetch('/api/OTP/Validate', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(otpValidationData)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            if (data.valid) {
                Swal.fire("Éxito", "Código OTP válido. Redireccionando al usuario...", "success")
                    .then(() => {
                        // Perform the redirection here.
                    });
            } else {
                Swal.fire("Error", "Código OTP inválido. Inténtelo nuevamente.", "error");
            }
        })
        .catch(error => {
            console.error('Error al validar el código OTP:', error);
            Swal.fire("Error", "Error al validar el código OTP. Inténtelo nuevamente.", "error");
        });
}