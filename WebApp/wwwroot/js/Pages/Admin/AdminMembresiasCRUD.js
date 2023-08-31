$(document).ready(function () {
    var view = new AdminMembresiasCRUD();
    view.InitView();

})

function AdminMembresiasCRUD() {
    this.ViewName = "Membresias";
    this.ApiService = "Memberships";
    var self = this;

    this.InitView = function () {

        this.LoadTable();

        $("#btnCreate").click(function () {

            ValidateRegistry();
        });
    }

    this.Update = function (membership) {


        var ctrlActions = new ControlActions();
        var serviceToDelete = self.ApiService + "/Update";

        ctrlActions.PutToAPI(serviceToDelete, membership, function (data) {
            
            self.LoadTable();
        });

    }

    this.create = function () {

        var membership = {}
        membership.Id = "0"
        membership.Name = $("#inputName").val();
        membership.Price = $("#inputPrice").val();
        membership.TicketsToSellMin = $("#inputTicketsMin").val();
        membership.TicketsToSellMax = $("#inputTicketsMax").val();
        membership.Commission = $("#inputCommission").val();

        var ctrlActions = new ControlActions();
        var serviceToDelete = self.ApiService + "/Create";

        ctrlActions.PostToAPI(serviceToDelete, membership, function (data) {

            self.LoadTable();

            //limpio los espacios del form
            $("#inputName").val("");
            $("#inputPrice").val("");
            $("#inputTicketsMin").val("");
            $("#inputTicketsMax").val("");
            $("#inputCommission").val("");

        });
    }

    this.delete = function (id) {

        var membership = {
            id: id,
            name: "string",
            price: 0,
            ticketsToSell: 0,
            commission: 0
       
        }

        var ctrlActions = new ControlActions();
        var serviceToDelete = self.ApiService + "/Delete";
        ctrlActions.DeleteToAPI(serviceToDelete, membership, function (data) {
            console.log("deleted")
            self.LoadTable();
        });
    };

    this.LoadTable = function () {
        var ctrlActions = new ControlActions();
        var self = this;

        var urlService = ctrlActions.GetUrlApiService(this.ApiService + "/RetrieveAll");
        var columns = [];

        columns[0] = { 'data': 'name' };
        columns[1] = {
            'data': null,
            'render': function (data, type, row) {
                return row.ticketsToSellMin + '-' + row.ticketsToSellMax;
            }
        };

        columns[2] = { 'data': 'commission' };
        columns[3] = { 'data': 'price' };

        columns[4] = {
            'data': null,
            'render': function (data, type, row) {
                return '<button class="btn btn-primary btn-sm btn-edit" data-id="' + row.id + '"><i class="fa-regular fa-pen-to-square"></i></button>' +"   "+
                    '<button class="btn btn-danger btn-sm btn-delete" data-id="' + row.id + '"><i class="fa-solid fa-trash-can "></i></button>';
            }
        };


        var table = $("#tblMembresias").DataTable();

        if (table) {
            table.clear().destroy(); // Si la tabla existe, la limpiamos y destruimos
        }

        var table = $("#tblMembresias").DataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns
        });

        // Handle Edit button click
        $("#tblMembresias").on('click', '.btn-edit', function () {
            var tr = $(this).closest('tr');
            var row = table.row(tr);
            var rowData = row.data();

            if (rowData) {
                var id = rowData.id;
                var ticketsSellMin = rowData.ticketsToSellMin;
                var ticketsSellMax = rowData.ticketsToSellMax;
                var name = rowData.name;
                var commission = rowData.commission;
                var price = rowData.price;

            
                var membership = {
                    id: id,
                    name: name,
                    ticketsToSellMin: ticketsSellMin,
                    ticketsToSellMax: ticketsSellMax,
                    commission: commission,
                    price: price
                };
                showEditWindow(membership);
            }
        });

        // Handle Delete button click
        $("#tblMembresias").on('click', '.btn-delete', function () {
            var tr = $(this).closest('tr');
            var row = table.row(tr);
            var rowData = row.data();

            if (rowData) {
                var id = rowData.id;

                Swal.fire({
                    title: '¿Está seguro?',
                    text: '¡Esta acción es irreversible!',
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Sí, borrar',
                    cancelButtonText: 'Cancelar'
                }).then((result) => {
                    if (result.isConfirmed) {
                        self.delete(id);
                        Swal.fire(
                            'Borrado',
                            'La membresia ha sido borrada',
                            'success'
                        ).then(() => {
                            table.ajax.reload(null, false); // Refresh the table after successful deletion
                        });
                    }
                });
            }
        });
    };



    function showEditWindow(membership) {
        var form = $('<form>');

        var nameLabel = $('<label for="inputName">Name:</label>');
        var nameInput = $('<input type="text" id="inputName" name="name" class="form-control">').val(membership.name);
        form.append(nameLabel, nameInput);

        // Create a row for the range of tickets inputs
        var ticketsSellRow = $('<div class="row"></div>');

        var ticketsSellMinCol = $('<div class="col-md-6"></div>');
        var ticketsSellMinLabel = $('<label for="inputTicketsSellMin">Min Tickets to Sell:</label>');
        var ticketsSellMinInput = $('<input type="text" id="inputTicketsSellMin" name="ticketsSellMin" class="form-control">').val(membership.ticketsToSellMin);
        ticketsSellMinCol.append(ticketsSellMinLabel, ticketsSellMinInput);

        var ticketsSellMaxCol = $('<div class="col-md-6"></div>');
        var ticketsSellMaxLabel = $('<label for="inputTicketsSellMax">Max Tickets to Sell:</label>');
        var ticketsSellMaxInput = $('<input type="text" id="inputTicketsSellMax" name="ticketsSellMax" class="form-control">').val(membership.ticketsToSellMax);
        ticketsSellMaxCol.append(ticketsSellMaxLabel, ticketsSellMaxInput);

        ticketsSellRow.append(ticketsSellMinCol, ticketsSellMaxCol);
        form.append(ticketsSellRow);

        var commissionLabel = $('<label for="inputCommission">Commission:</label>');
        var commissionInput = $('<input type="text" id="inputCommission" name="commission" class="form-control">').val(membership.commission);
        form.append(commissionLabel, commissionInput);

        var priceLabel = $('<label for="inputPrice">Price:</label>');
        var priceInput = $('<input type="text" id="inputPrice" name="price" class="form-control">').val(membership.price);
        form.append(priceLabel, priceInput);

        showModal('Edit Membership', form, function () {
            membership.name = nameInput.val();
            membership.ticketsToSellMin = ticketsSellMinInput.val();
            membership.ticketsToSellMax = ticketsSellMaxInput.val();
            membership.commission = commissionInput.val();
            membership.price = priceInput.val();

            self.Update(membership);
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

function ValidateRegistry() {
    var isValid = true; // Initialize flag to true

    // Run all the validation functions and update the flag if any validation fails
    if (!validationName()) {
        isValid = false;
    }
    if (!validationTicketMin()) {
        isValid = false;
    }
    if (!validationTicketMax()) {
        isValid = false;
    }
    if (!validationCommission()) {
        isValid = false;
    }
    if (!validationPrice()) {
        isValid = false;
    }

    // Check the flag to see if all validations passed
    if (isValid) {
        var view = new AdminMembresiasCRUD();
        view.create();
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Verifica los espacios marcados'
        });
    }
}


function validationName() {
    
    var input = $("#inputName");

        if (input.val() === "" || input.val().length === 0) {
            input.removeClass("is-valid").addClass("is-invalid");
            return false;
        } else {
            input.removeClass("is-invalid").addClass("is-valid");
            return true;
        }
}

function validationTicketMin() {

    var input = $("#inputTicketsMin");

    if (input.val() === "" || input.val().length === 0) {
        input.removeClass("is-valid").addClass("is-invalid");
        return false;
    } else {
        input.removeClass("is-invalid").addClass("is-valid");
        return true;
    }
}

function validationTicketMax() {

    var input = $("#inputTicketsMax");

    if (input.val() === "" || input.val().length === 0) {
        input.removeClass("is-valid").addClass("is-invalid");
        return false;
    } else {
        input.removeClass("is-invalid").addClass("is-valid");
        return true;
    }
}

function validationCommission() {

    var input = $("#inputCommission");

    if (input.val() === "" || input.val().length === 0) {
        input.removeClass("is-valid").addClass("is-invalid");
        return false;
    } else {
        input.removeClass("is-invalid").addClass("is-valid");
        return true;
    }
}


function validationPrice() {

    var input = $("#inputPrice");

    if (input.val() === "" || input.val().length === 0) {
        input.removeClass("is-valid").addClass("is-invalid");
        return false;
    } else {
        input.removeClass("is-invalid").addClass("is-valid");
        return true;
    }
}

     