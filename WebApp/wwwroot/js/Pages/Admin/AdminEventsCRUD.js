$(document).ready(function () {
    var view = new AdminEventsController();
    view.InitView();

})

function AdminEventsController() {
    this.ViewName = "Eventos";
    this.ApiService = "Event";
    var self = this;


    this.InitView = function () {
        this.LoadTable();
    }


    this.Update = function (event) {


        var ctrlActions = new ControlActions();
        var serviceToDelete = self.ApiService + "/UpdateEvent";

        ctrlActions.PutToAPI(serviceToDelete, event, function (data) {

            self.LoadTable();
        });

    }


    this.delete = function (id) { 

        var event = {
            "id": id,
            "name": "string",
            "slogan": "string",
            "description": "string",
            "modality": "string",
            "eventDate": "string",
            "totalTickets": 0,
            "information": "string",
            "paymentMethod": "string",
            "freeTickets": 0,
            "ownedBy": 0,
            "state": "string"

        }

        var ctrlActions = new ControlActions();
        var serviceToDelete = self.ApiService + "/DeleteEvent";
        ctrlActions.DeleteToAPI(serviceToDelete, event, function (data) {
            console.log("deleted")
            self.LoadTable();
        });
    }; // falta desarrollar

    this.LoadTable = function () {
        var ctrlActions = new ControlActions();
        var self = this;

        var urlService = ctrlActions.GetUrlApiService("Event/RetrieveAllEvents");

        var columns = [];
        columns[0] = { 'data': 'name' };
        columns[1] = { 'data': 'slogan' };
        columns[2] = { 'data': 'description' };
        columns[3] = { 'data': 'modality' };
        columns[4] = { 'data': 'eventDate' };
        columns[5] = { 'data': 'totalTickets' };
        columns[6] = { 'data': 'information' };
        columns[7] = { 'data': 'paymentMethod' };
        columns[8] = { 'data': 'freeTickets' };
        columns[9] = { 'data': 'state' };
        columns[10] = {
            'data': null,
            'render': function (data, type, row) {
                return '<button class="btn btn-primary btn-sm btn-edit" data-id="' + row.id + '"><i class="fa-regular fa-pen-to-square"></i></button>' + "   " +
                    '<button class="btn btn-danger btn-sm btn-delete" data-id="' + row.id + '"><i class="fa-solid fa-trash-can "></i></button>';
            }
        };


        var table = $("#tblEvent").DataTable();
        if (table) {
            table.clear().destroy();
        }

        table = $("#tblEvent").DataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns
        });

        // Handle Edit button click
        $("#tblEvent").on('click', '.btn-edit', function () {
            var tr = $(this).closest('tr');
            var row = table.row(tr);
            var rowData = row.data();

            if (rowData) {
                var id = rowData.id;
                var name = rowData.name;
                var slogan = rowData.slogan;
                var description = rowData.description;
                var modality = rowData.modality;
                var eventDate = rowData.eventDate;
                var totalTickets = rowData.totalTickets;
                var information = rowData.information;
                var paymentMethod = rowData.paymentMethod;
                var freeTickets = rowData.freeTickets;
                var state = rowData.state;

                var event = {
                    id: id,
                    name: name,             
                    slogan: slogan,
                    description: description,
                    modality: modality,
                    eventDate: eventDate,
                    totalTickets: totalTickets,
                    information: information,
                    paymentMethod: paymentMethod,
                    freeTickets: freeTickets,
                    state: state
                };

                showEditWindow(event);
            }
        });


  
        $("#tblEvent").on('click', '.btn-delete', function () {
            var tr = $(this).closest('tr');
            var row = table.row(tr);
            var rowData = row.data();

            if (rowData) {
                var id = rowData.id;

                Swal.fire({
                    title: 'Esta seguro?',
                    text: 'Esta accion es irreversible!',
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Si, borrar',
                    cancelButtonText: 'Cancelar'
                }).then((result) => {
                    if (result.isConfirmed) {
                        self.delete(id);
                        Swal.fire(
                            'Borrado',
                            'El evento ha sido borrado',
                            'success'
                        ).then(() => {
                            table.ajax.reload(null, false);
                        });
                    }
                });
            }
        });
    };

    function showEditWindow(event) {
        var form = $('<form>');

        var nameLabel = $('<label for="inputName">Nombre:</label>');
        var nameInput = $('<input type="text" id="inputName" name="name" class="form-control">').val(event.name);
        form.append(nameLabel, nameInput);

        var sloganLabel = $('<label for="inputSlogan">Slogan:</label>');
        var sloganInput = $('<input type="text" id="inputSlogan" name="slogan" class="form-control">').val(event.slogan);
        form.append(sloganLabel, sloganInput);

        var descriptionLabel = $('<label for="inputDescription">Descripcion:</label>');
        var descriptionInput = $('<input type="text" id="inputDescription" name="description" class="form-control">').val(event.description);
        form.append(descriptionLabel, descriptionInput);

        var modalityLabel = $('<label for="inputModality">Modalidad:</label>');
        var modalitySelect = $('<select id="inputModality" name="modality" class="form-control"></select>');

        var optionPresencial = $('<option value="Presencial">Presencial</option>');
        var optionVirtual = $('<option value="Virtual">Virtual</option>');

        if (event.modality === 'Presencial') {
            optionPresencial.attr('selected', 'selected');
        } else if (event.modality === 'Virtual') {
            optionVirtual.attr('selected', 'selected');
        }

        modalitySelect.append(optionPresencial, optionVirtual);
        form.append(modalityLabel, modalitySelect);

        var eventDateLabel = $('<label for="inputEventDate">Fecha del evento:</label>');
        var eventDateInput;

        if (event.eventDate.includes(' ')) {
       
            var dateParts = event.eventDate.split(' ');
            var monthNames = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
            var month = monthNames.indexOf(dateParts[0]) + 1;
            var day = parseInt(dateParts[1], 10);
            var year = parseInt(dateParts[2], 10);

     
            var eventDate = new Date(year, month - 1, day);

            
            var eventDateValue = eventDate.toISOString().split('T')[0];

            eventDateInput = $('<input type="date" id="inputEventDate" name="eventDate" class="form-control">').val(eventDateValue);
        } else {
           
            var isoDate = event.eventDate.split('T')[0];
            var isoTime = event.eventDate.split('T')[1];
            var eventDateValue = isoDate + 'T' + isoTime; 

            eventDateInput = $('<input type="date" id="inputEventDate" name="eventDate" class="form-control">').val(eventDateValue);
        }

        form.append(eventDateLabel, eventDateInput);



        var totalTicketsLabel = $('<label for="inputTotalTickets">Total Tickets:</label>');
        var totalTicketsInput = $('<input type="text" id="inputTotalTickets" name="totalTickets" class="form-control">').val(event.totalTickets);
        form.append(totalTicketsLabel, totalTicketsInput);

        var informationLabel = $('<label for="inputInformation">Informacion:</label>');
        var informationInput = $('<input type="text" id="inputInformation" name="information" class="form-control">').val(event.information);
        form.append(informationLabel, informationInput);
        var paymentMethodLabel = $('<label for="inputPaymentMethod">Metodo de pago:</label>');
        var paymentMethodSelect = $('<select id="inputPaymentMethod" name="paymentMethod" class="form-control"></select>');

        var optionPaypal = $('<option value="Paypal">Paypal</option>');
        var optionSunpe = $('<option value="SUNPE">SUNPE</option>');
        var optionAmbas = $('<option value="PS">Ambas</option>');

        if (event.paymentMethod === 'Pay') {
            optionPaypal.attr('selected', 'selected');
        } else if (event.paymentMethod === 'SUN') {
            optionSunpe.attr('selected', 'selected');
        } else if (event.paymentMethod === 'PS') {
            optionAmbas.attr('selected', 'selected');
        }

        paymentMethodSelect.append(optionPaypal, optionSunpe, optionAmbas);
        form.append(paymentMethodLabel, paymentMethodSelect);
        var freeTicketsLabel = $('<label for="inputFreeTickets">Tiquetes cortesia:</label>');
        var freeTicketsInput = $('<input type="text" id="inputFreeTickets" name="freeTickets" class="form-control">').val(event.freeTickets);
        form.append(freeTicketsLabel, freeTicketsInput);

        var stateLabel = $('<label for="inputState">State:</label>');
        var stateInput = $('<input type="text" id="inputState" name="state" class="form-control">').val(event.state);
        form.append(stateLabel, stateInput);

        showModal('Editar Evento', form, function () {
            event.name = nameInput.val();
            event.slogan = sloganInput.val();
            event.description = descriptionInput.val();
            event.modality = modalitySelect.val();
            event.eventDate = eventDateInput.val();
            event.totalTickets = totalTicketsInput.val();
            event.information = informationInput.val();
            event.paymentMethod = paymentMethodSelect.val();
            event.freeTickets = freeTicketsInput.val();
            event.state = stateInput.val();

            self.Update(event);
        });
    }


    function showModal(title, content, onSave) {
        var modal = $('<div class="modal fade" tabindex="-1" role="dialog">');
        var modalDialog = $('<div class="modal-dialog" role="document">');
        var modalContent = $('<div class="modal-content">');

        var modalHeader = $('<div class="modal-header">');
        var titleElement = $('<h5 class="modal-title">' + title + '</h5>');
        var closeButton = $('<button type="button" class="close" data-dismiss="modal" aria-label="Close">');
        closeButton.html('<span aria-hidden="true">&times;</span>');
        modalHeader.append(titleElement, closeButton);

        var modalBody = $('<div class="modal-body">').append(content);

        var modalFooter = $('<div class="modal-footer">');
        var saveButton = $('<button type="button" class="btn btn-primary">Save</button>');

        closeButton.click(function () {
            modal.modal('hide');
        });

        saveButton.click(function () {
            onSave();
            modal.modal('hide');
        });
        var cancelButton = $('<button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>');
        modalFooter.append(saveButton, cancelButton);

        modalContent.append(modalHeader, modalBody, modalFooter);
        modalDialog.append(modalContent);
        modal.append(modalDialog);
        cancelButton.click(function () {
            modal.modal('hide');
        });

        modal.modal('show');
    }

}