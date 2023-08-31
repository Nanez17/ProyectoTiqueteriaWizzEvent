function CreateCartController() {

    this.InitView = function () {
        console.log("Cart view init");
        var view = new CreateCartController();
        view.loadTableItems();


        $('#btnPay').click(function () {
            if ($('#tickets').text() === '0') {
                Swal.fire({
                    title: 'Oops!',
                    text: 'No tienes tickets en el carrito',
                    icon: 'error',
                    showConfirmButton: false
                });
            } else {
                Swal.fire({
                    title: 'Metodo de Pago',
                    text: '¿Que tipo de pago desea utilizar?',
                    showDenyButton: true,
                    confirmButtonText: 'SUNPE Movil',
                }).then((result) => {
                    if (result.isConfirmed) {
                        $('#modalPayTickets').modal('show');
                    }
                })
            }
        });

        $('#btnSendQR').click(function () {  
            if ($('#transactionInfo').text() === "") {
                Swal.fire({
                    title: 'Oops!',
                    text: 'Debes pagar para que se envie la factura.',
                    icon: 'error',
                    showConfirmButton: false
                });
            } else {
                view.sendQR();
            }
        });

        $('#btnDownloadQR').click(function () {
            view.generateQRCodeAndDownload('Hola');
        });

        $('#btnSendEmail').click(function () {
            view.sendInvoice();
        });

        $('#btnPayCart').click(function () {
            view.PayItemsCart();
        });

        $('#btnCleanCart').click(function () {
            Swal.fire({
                title: 'Limpiar Carrito',
                text: "¿Seguro desea limpiar los boletos de su carrito?",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Eliminar!'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        url: 'https://localhost:7152/api/CartItem/CleanCartItems?IdUser=' + localStorage.getItem('idUsuario'),
                        type: 'DELETE',
                        success: function (data) {
                            Swal.fire({
                                title: 'Eliminado!',
                                text: 'Tu carrito está vacío.',
                                icon: 'success',
                                showConfirmButton: false
                            });
                            setTimeout(function () {
                                location.reload();
                            }, 2000);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            console.error('Error en el llamado:', textStatus, errorThrown);
                        }
                    });


                }
            })
        });

    }

    this.generateQRCodeAndDownload = function (text) {
        const qrcode = new QRCode(0, {
            text: text,
            width: 128,
            height: 128,
        });

        const canvas = qrcode._oDrawing._el;
        const qrImageUrl = canvas.toDataURL("image/png");
        const link = document.createElement('a');
        link.href = qrImageUrl;
        link.download = 'codigo_qr.png';
        link.click();
    }

    this.sendInvoice = function () {
        if ($('#transactionInfo').text() === "") {
            Swal.fire({
                title: 'Oops!',
                text: 'Debes pagar para que se envie la factura.',
                icon: 'error',
                showConfirmButton: false
            });
        } else {
            var data = {
                nombre: $('#clientInfo').text(),
                numeroIdentificacion: $('#identificationInfo').text(),
                email: 'rjquiros21@gmail.com'
            };

            var message = "Client Information:\n" +
                "Name: " + data.nombre + "\n" +
                "Identification Number: " + data.numeroIdentificacion + "\n" +
                "Email: " + data.email + "\n" +
                "Number of Tickets: " + $('#tickets').text() + "\n" +
                "Total Price: ₡" + $('#ticketsPrice').text() + "\n" +
                "N° Transaccion: " + $('#transactionInfo').text() + "\n" +
                "Fecha de pago: " + $('#paymentDateInfo').text() + "\n"
                '<img src="~/imgs/ejemploqt.png" />';

            var data = {
                service_id: 'service_qfwx73m',
                template_id: 'template_lpw7q3q',
                user_id: 'mzK3YInAAZbOhzMSG',
                template_params: {
                    'to_name': data.nombre,
                    'from_name': data.email,
                    'message': message
                }
            };

            $.ajax('https://api.emailjs.com/api/v1.0/email/send', {
                type: 'POST',
                data: JSON.stringify(data),
                contentType: 'application/json'
            }).done(function () {
                Swal.fire({
                    title: 'Exitoso!',
                    text: 'Se ha enviado la factura a tu correo, por favor verifica.',
                    icon: 'success',
                    showConfirmButton: false
                });
            }).fail(function (error) {
                Swal.fire({
                    title: 'Oops!',
                    text: 'Ha ocurrido un error ' + JSON.stringify(error),
                    icon: 'error',
                    showConfirmButton: false
                });
            });
        }
    }

    this.getCartItemsData = function () {
        var cartItems = [];

        $('#tblCart tbody tr').each(function () {
            var nombre = $(this).find('#inputNombre').val();
            var correo = $(this).find('#inputCorreo').val();
            var seatId = $(this).find('td:eq(3)').text(); 

            cartItems.push({
                nombre: nombre,
                correo: correo,
                seatId: seatId
            });
        });

        return cartItems;
    };

    this.sendQR = function () {
        var view = new CreateCartController();
        var cartItems = view.getCartItemsData();

        cartItems.forEach(function (item) {
            var url = 'https://localhost:7152/api/CartItem/AsignSeatToClient?IdSeat=' + item.seatId + '&OwnerName=' + item.nombre + '&OwnerMail=' + item.correo;

            $.ajax({
                url: url,
                method: 'POST',
                success: function (response) {
                    console.log('Seat assigned for', item.nombre);
                    Swal.fire({
                        title: 'Exito!',
                        text: 'Se agregaron las personas',
                        icon: 'success',
                        showConfirmButton: false
                    });

                    var text = {
                        name: item.nombre,
                        mail: item.correo,
                        seatId: item.seatId
                    }

                    
                },
                error: function (error) {
                    console.error('Error assigning seat for', item.nombre, ':', error);
                }
            });
        });
    }

    this.loadTableItems = function () {
        var url = 'https://localhost:7152/api/CartItem/RetrieveAllCartItems?IdUser=' + localStorage.getItem('idUsuario');
        var columns = [];

        columns[0] = { 'data': 'eventName' };
        columns[1] = { 'data': 'eventDate' };
        columns[2] = { 'data': 'sectorName' };
        columns[3] = { 'data': 'seatId' };
        columns[4] = { 'data': 'seatName' };
        columns[5] = { 'data': 'seatPrice' };
        columns[6] = {
            'data': null,
            'render': function (data, type, row) {
                return '<input type="text" class="form-control" placeholder="Ingrese el nombre del dueño" id="inputNombre"/>'
            }
        };

        columns[7] = {
            'data': null,
            'render': function (data, type, row) {
                return '<input type="email" class="form-control" id="inputCorreo" aria-describedby="emailHelp" placeholder="Ingrese el correo del dueño"/>'
            }
        };

        var table = $("#tblCart").DataTable();

        if (table) {
            table.clear().destroy();
        }

        var table = $("#tblCart").DataTable({
            "ajax": {
                "url": url,
                "dataSrc": ""
            },
            "columns": columns,
            "initComplete": function () {
                var cantTickets = 0;
                var totalPrice = 0;

                table.data().each(function (row) {
                    cantTickets++;
                    totalPrice += row.seatPrice;
                });

                $('#tickets').text(cantTickets);
                $('#ticketsPrice').text(totalPrice);
                var view = new CreateCartController();
                view.loadModalPay();
            }
        });
    }

    this.loadModalPay = function loadModalContent() {
        $.ajax({
            url: 'https://localhost:7152/api/Users/RetrieveById?id=' + localStorage.getItem('idUsuario'),
            method: 'GET',
            dataType: 'json',
            success: function (data) {
                $('#clientInfo').text(data.nombre + ' ' + data.apellidos);
                $('#identificationInfo').text(data.numeroIdentificacion);
                $('#emailInfo').text(data.email);
                $('#numTicketsInfo').text($('#tickets').text());
                $('#totalPriceInfo').text('₡' + $('#ticketsPrice').text());
            },
            error: function (xhr, status, error) {
                console.error('Error en la solicitud Ajax:', error);
            }
        });
    }

    this.generateCustomId = function () {
        const segments = [8, 4, 4, 4, 12];
        const characters = 'abcdefghijklmnopqrstuvwxyzZ0123456789';
        let customId = '';

        segments.forEach((segmentLength, index) => {
            for (let i = 0; i < segmentLength; i++) {
                customId += characters.charAt(Math.floor(Math.random() * characters.length));
            }

            if (index < segments.length - 1) {
                customId += '-';
            }
        });

        return customId;
    }

    this.generateFormattedDate =  function () {
        const today = new Date();
        const year = today.getFullYear();
        const month = (today.getMonth() + 1).toString().padStart(2, '0');
        const day = today.getDate().toString().padStart(2, '0');
        const hours = today.getHours().toString().padStart(2, '0');
        const minutes = today.getMinutes().toString().padStart(2, '0');
        const seconds = today.getSeconds().toString().padStart(2, '0');
        const milliseconds = today.getMilliseconds().toString().padStart(3, '0');
        return `${year}-${month}-${day}T${hours}:${minutes}:${seconds}.${milliseconds}Z`;
    }

    this.PayItemsCart = function () {
        var view = new CreateCartController();
        const data = {
            "id": 0,
            "uban": "CRC186325665356954",
            "amount": $('#ticketsPrice').text(),
            "description": "Pago de ",
            "sender": $('#clientInfo').text(),
            "transactionId": view.generateCustomId(),
            "status": "OK",
            "transactionDate": view.generateFormattedDate()
        };

        var apiUrl = "https://localhost:7152/api/Sunpe/PaySunpeTransaction";

        $.ajax({
            url: apiUrl,
            type: "POST",
            data: JSON.stringify(data),
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                $.ajax({
                    url: 'https://localhost:7152/api/Sunpe/RetrieveIdSunpe?transactionId=' + data.transactionId,
                    type: "GET",
                    dataType: "json",
                    success: function (data2) {
                        console.log(data2.id);
                        $.ajax({
                            url: 'https://localhost:7152/api/CartItem/PayCartItem?idUser=' + localStorage.getItem('idUsuario') +'&idSunpe=' + data2.id,
                            type: "POST",
                            contentType: "application/json",
                            success: function (data3) {
                                Swal.fire(
                                    'Pago realizado!',
                                    'El carrito fue pagado con exito.',
                                    'success'
                                )
                                $('#transactionInfo').text(data.transactionId);
                                $('#paymentDateInfo').text(data.transactionDate);
                            },
                            error: function (xhr, status, error) {
                                console.log("Error al llamar a la API: " + error);
                            }
                        });
                    },
                    error: function (xhr, status, error) {
                        console.log("Error al llamar a la API: " + error);
                    }
                });
            },
            error: function (xhr, status, error) {
                console.log("Error al llamar a la API: " + error);
            }
        });

    }


}


$(document).ready(function () {
    var view = new CreateCartController();
    view.InitView();
})