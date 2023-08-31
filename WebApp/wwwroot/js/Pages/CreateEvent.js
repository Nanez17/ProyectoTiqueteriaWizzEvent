function CreateEventController() {
    this.ViewName = "CreateEvent";
    this.ApiService = "Event";
    this.ApiServiceCategory = 'Category';

    this.InitView = function () {
        console.log("Create event view init");
        var view = new CreateEventController();
        view.AddContact();
        view.LoadCategories();
        view.LoadImages();


        $('#btnEnviar').on('click', function () {
            view.GetImages();
            if (view.Validation()) {
                view.CreateEvent();
            }
        });
    }

    this.Validation = function () {
        var view = new CreateEventController();
        var event = view.GetEvent();

        if (
            event.Name === "" ||
            event.Description === "" ||
            event.Slogan === "" ||
            event.EventDate === "" ||
            event.TotalTickets === "" ||
            event.Information === "" ||
            event.FreeTickets === ""
        ) {
            Swal.fire({
                icon: 'warning',
                title: 'Error...',
                text: 'Completa todos los campos para poder continuar...',
            });
            return false;
        }

        if ($('#table-contacts tr').length < 1) {
            Swal.fire({
                icon: 'warning',
                title: 'Error...',
                text: 'Completa los contactos para poder continuar...',
            });
            return false;
        }

        if ($('#stlCategory').val() === '') {
            alert('No hay categoria');
            return false;
        }

        return true;
    };

    this.CreateEvent = async function () {
        const url = 'https://localhost:7152/api/Event/CreateEvent';
        var view = new CreateEventController();
        var event = view.GetEvent();
        var checks = {
            checkEvent: false,
            checkContact: false,
            checkImage: false,
            checkCategory: false
        };

        var response1;

        try {
            response1 = await $.ajax({
                url: url,
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(event),
            });
            checks.checkEvent = true;
        } catch (error) {
            console.error('Error al crear el evento:', error.statusText);
        }

        const eventId = await view.GetIdEvent(response1);

        const [checkContacts, checkImages, checkCategory] = await Promise.all([
            view.CreateContacts(eventId),
            view.CreateImages(eventId),
            view.CreateCategory(eventId),
            view.CreateScenery(eventId)
        ]);

        checks.checkContact = checkContacts;
        checks.checkImage = checkImages;
        checks.checkCategory = checkCategory;

        console.log(checks);
        if (Object.values(checks).every(check => check === true)) {
            Swal.fire({
                icon: 'success',
                title: 'Evento creado correctamente',
                text: 'El evento se ha creado con éxito.',
            });
            setTimeout(function () {
                window.location.href = "https://localhost:7072/";
            }, 2000);
        } else {
            let errorMessages = [];

            if (!checks.checkEvent) {
                errorMessages.push('Error al crear el evento.');
            }

            if (!checks.checkContact) {
                errorMessages.push('Error al crear los contactos.');
            }

            if (!checks.checkImage) {
                errorMessages.push('Error al crear las imágenes.');
            }

            if (!checks.checkCategory) {
                errorMessages.push('Error al crear la categoría.');
            }
            const errorMessage = errorMessages.join('\n');

            Swal.fire({
                icon: 'error',
                title: 'Error al crear el evento',
                text: errorMessage,
            });
        }
    };

    this.CreateCategory = async function (idEvent) {
        var view = new CreateEventController();
        const apiUrl = 'https://localhost:7152/api/Event/AddCategoryToEvent?idCategory=' + view.GetCategory() + '&idEvent=' + idEvent;

        return new Promise(function (resolve, reject) {
            $.ajax({
                url: apiUrl,
                method: 'POST',
                dataType: 'json',
                success: function (data) {
                    console.log('Categoría agregada al evento correctamente.');
                    resolve(true);
                },
                error: function () {
                    console.error('Error al agregar la categoría al evento.');
                    resolve(false); 
                }
            });
        });
    };

    this.CreateImages = async function (idEvent) {
        var view = new CreateEventController();
        var images = view.GetImages();
        const url_images = 'https://localhost:7152/api/Event/AddImageToEvent';

        const promises = images.map(function (image) {
            return new Promise(function (resolve, reject) {
                image.idEvent = idEvent;
                $.ajax({
                    url: url_images,
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(image),
                    success: function (data) {
                        console.log('Imagen creada:', data);
                        resolve(true); 
                    },
                    error: function (error) {
                        console.error('Error al crear la imagen:', error.statusText);
                        resolve(false); 
                    }
                });
            });
        });

        return Promise.all(promises)
            .then(function (results) {
                return results.every(function (result) {
                    return result === true;
                });
            })
            .catch(function (error) {
                console.error('Error al crear imágenes:', error);
                return false;
            });
    };

    this.GetIdEvent = async function (event) {
        const url_get = 'https://localhost:7152/api/Event/RetrieveByIdEvent';
        
        try {
            response1 = await $.ajax({
                url: url_get,
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(event),
            });

            return response1.id;
        } catch (error) {
            console.error('Error:', error.statusText);
        }
    }

    this.CreateContacts = function (idEvent) {
        var view = new CreateEventController();
        var contacts = view.GetContacts();
        const url = 'https://localhost:7152/api/Event/AddContactToEvent';

        const promises = contacts.map(function (contact) {
            return new Promise(function (resolve, reject) {
                contact.idEvent = idEvent;
                $.ajax({
                    url: url,
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(contact),
                    success: function (data) {
                        console.log('Contacto creado:', data);
                        resolve(true);
                    },
                    error: function (error) {
                        console.log('Error al crear el contacto:', error);
                        resolve(false);
                    }
                });
            });
        });


        return Promise.all(promises)
            .then(function (results) {
                return results.every(function (result) {
                    return result === true;
                });
            })
            .catch(function (error) {
                console.error('Error al crear contactos:', error);
                return false; 
            });
    };

    this.CreateScenery = async function (idEvent) {
        var view = new CreateEventController();
        const selectElement = $('#sltScenery');
        const selectScenery = selectElement.val();
        const SceneryLocation = selectElement.find('option:selected').data('location');
        const apiUrl = 'https://localhost:7152/api/Scenery/CreateScenery';
        const apiUrlGetIdScenery = 'https://localhost:7152/api/Scenery/RetrieveByIdScenery?IdEvent=';

        const Scenery = {
            idEvent: idEvent,
            name: selectScenery,
            location: SceneryLocation
        };

        $.ajax({
            url: apiUrl,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(Scenery),
            success: function (response) {
                $.ajax({
                    url: apiUrlGetIdScenery + Scenery.idEvent,
                    type: 'POST',
                    success: function (response) {
                        console.log('Llamada exitosa para:', response);
                        view.CreateSectorAndSeats(response.id);
                    },
                    error: function (error) {
                        console.log('API error:', error);
                    }
                });

            },
            error: function (error) {
                console.error('API error:', error);
            }
        });
    }

    this.CreateSectorAndSeats = function (IdScenery) {
        var view = new CreateEventController();
        const urlCreateSector = 'https://localhost:7152/api/Scenery/CreateSectorToScenery';
        const urlGetSectorId = 'https://localhost:7152/api/Scenery/RetrieveByIdSector?';
        const urlCreateSeats = 'https://localhost:7152/api/Scenery/CreateSeatToSector?totalSeats=';

        var idScenery = 'IdScenery=' + IdScenery;

        var entries = [];

        $("#table-type-tickets tr:not(:first)").each(function () {
            var type = $(this).find("input[type=text]").val();
            var amount = parseInt($(this).find("input[type=number]").eq(0).val());
            var price = parseFloat($(this).find("input[type=number]").eq(1).val());

            entries.push({
                idScenery: IdScenery,
                name: type,
                price: price,
                state: 'Creado',
                seatsNumber: amount
            });
        });

        entries.forEach(function (entry) {
            $.ajax({
                url: urlCreateSector,
                type: 'POST',
                data: JSON.stringify(entry),
                contentType: 'application/json',
                success: function (response) {
                    $.ajax({
                        url: urlGetSectorId + idScenery + '&Sector=' + entry.name,
                        type: 'POST',
                        success: function (response) {
                            console.log('Llamada exitosa para:', response);
                            var seats = {
                                idScenery: IdScenery,
                                idSector: response.id,
                                name: entry.name.substring(0, 3).toUpperCase(),
                                state: 'Creado'
                            };

                            $.ajax({
                                url: urlCreateSeats + entry.seatsNumber,
                                type: 'POST',
                                data: JSON.stringify(seats),
                                contentType: 'application/json',
                                success: function (response) {
                                    console.log('Llamada exitosa para:', response);
                                },
                                error: function (error) {
                                    console.error('Error en la llamada para:', seats);
                                }
                            });
                        },
                        error: function (error) {
                            console.log('API error:', error);
                        }
                    });
                },
                error: function (error) {
                    console.error('Error en la llamada para:', entry);
                }
            });
        });
    }




    this.GetCategory = function () {
        const selectElement = $('#stlCategory');
        const selectedCategoryId = selectElement.val();
        const selectedCategoryName = selectElement.find('option:selected').text();

        if (selectedCategoryId && selectedCategoryName) {
            return selectedCategoryId;
        } else {
            return null;
        }
    }

    this.GetEvent = function () {
        var event = {
            name: $('#txtName').val(),
            slogan: $('#txtSlogan').val(),
            description: $('#txtDescription').val(),
            modality: $('#txtModality').val(),
            eventDate: $('#txtEventDate').val(),
            totalTickets: $('#txtTotalTickets').val(),
            information: $('#txtInformation').val(),
            paymentMethod: $('#stlPayment').val(),
            freeTickets: $('#txtFreeTickets').val(),
            ownedBy: 1,
            state: "CREATED"
        };

        return event;
    }

    this.GetContacts = function () {
        var contacts = [];

        $('#table-contacts tr:not(:first)').each(function () {
            var name = $(this).find('td:eq(0)').text();
            var textContact = $(this).find('td:eq(1)').text();

            contacts.push({ name: name, textContact: textContact });
        });

        return contacts;
    };

    this.AddContact = function () {
        $("#btnCreateContact").on('click', function () {
            const newRow = $("<tr>");

            newRow.append('<td>' + $('#txtContactName').val() + '</td>');
            newRow.append('<td>' + $('#txtContact').val() + '</td>');

            $('#txtContactName').val('');
            $('#txtContact').val('');

            $('#modalContact').modal('hide');

            $("#table-contacts").append(newRow);
        });

        $("#btnDeleteContact").on('click', function () {
            const rows = $("#table-contacts tr").not(':first');
            if (rows.length > 0) {
                rows.last().remove();
            }
        });
    }

    this.LoadCategories = function () {
        var view = new CreateEventController();

        var serviceToRetrieveCategory = this.ApiServiceCategory + "/RetrieveAllCategory";
        var ctrlActions = new ControlActions();
        var event = view.GetEvent();

        $.ajax({
            url: ctrlActions.GetUrlApiService(serviceToRetrieveCategory),
            method: 'GET',
            dataType: 'json',
            contentType: 'application/json', 
            success: function (data) {
                const selectElement = $('#stlCategory');
                selectElement.empty();
                selectElement.append('<option value="">Seleccione una categoría</option>');
                data.forEach(function (category) {
                    const option = $('<option></option>').val(category.id).text(category.name);

                    selectElement.append(option);
                });
            },
            error: function () {
                console.error('Error en la solicitud GET');
            }
        });
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

        return spamObjects;
    };

}

$(document).ready(function () {
    var view = new CreateEventController();
    view.InitView();
})