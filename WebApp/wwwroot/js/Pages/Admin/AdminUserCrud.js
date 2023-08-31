$(document).ready(function () {
    var view = new AdminUserCrudController();
    view.InitView();

})

function AdminUserCrudController() {
    this.ViewName = "Admin-Users";
    this.ApiService = "Users";
    var self = this;
    var rolNameCellIndex = 6;

    this.InitView = function () {

        this.LoadTable();

    }

    this.delete = function (id) {

        var user = {
            id: id,
            nombre: "string",
            apellidos: "string",
            tipoIdentificacion: "string",
            numeroIdentificacion: "string",
            email: "string",
            telefono: "string",
            cedulaImagen: "string",
            password: "string",
            confirmPassword: "string",
            ubicacion: "string"
        }

        var ctrlActions = new ControlActions();
        var serviceToDelete = self.ApiService + "/Delete";
        ctrlActions.DeleteToAPI(serviceToDelete, user, function (data) {
            console.log("deleted")
            self.LoadTable();
        });
    };
    this.RetrieveUserId = function (id, callback) {
        const apiUrl = `https://localhost:7152/api/Users/RetrieveByID?id=${id}`;

        fetch(apiUrl)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                callback(null, data);
            })
            .catch(error => {
                console.error('An error occurred while retrieving role data:', error);
                callback(error, null);
            });
    };

    this.Update = function (user) {


        var ctrlActions = new ControlActions();
        var serviceToDelete = self.ApiService + "/Update";

        ctrlActions.PutToAPI(serviceToDelete, user, function (data) {

            self.LoadTable();
        });

    }

    

    this.retrieveRolById = function (id) {
        const apiUrl = `https://localhost:7152/api/Role/RetrieveByID?id=${id}`;

        return new Promise((resolve, reject) => {
            fetch(apiUrl)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    resolve(data);
                })
                .catch(error => {
                    console.error('Error retrieving role by ID:', error);
                    reject(error);
                });
        });
    };

    this.getRoleName = function (id) {
        return self.retrieveRolById(id)
            .then(role => {
                if (role && role.rolName) {
                    return role.rolName;
                } else {
                    throw new Error('Role Name Not Available');
                }
            })
            .catch(error => {
                console.error('Error getting role name:', error);
                throw new Error('Role Name Error');
            });
    };





    this.LoadTable = function () {
        var ctrlActions = new ControlActions();
        var self = this;

        var urlService = ctrlActions.GetUrlApiService(this.ApiService + "/RetrieveAll");


        var columns = [];

      
        columns[0] = { 'data': 'nombre' };
        columns[1] = { 'data': 'apellidos' };
        columns[2] = { 'data': 'tipoIdentificacion' };
        columns[3] = { 'data': 'numeroIdentificacion' };
        columns[4] = { 'data': 'email' };
        columns[5] = { 'data': 'telefono' };
        columns[6] = {
            'data': null,
            'render': function (data, type, row) {
                var randomRoleIndex = Math.floor(Math.random() * 3); // Generate a random index between 0 and 2
                var roles = ["Administrador", "Cliente General", "Gestor de Eventos"];
                var roleName = roles[randomRoleIndex];
                return roleName;
            }
        };


        columns[7] = {
            'data': null,
            'render': function (data, type, row) {
                return '<button class="btn btn-primary btn-sm btn-edit" data-id="' + row.id + '">Update</button>' +
                    '<button class="btn btn-danger btn-sm btn-delete" data-id="' + row.id + '">Delete</button>';
            }
        };


        var table = $("#tblUsers").DataTable();

        if (table) {
            table.clear().destroy();
        }

        table = $("#tblUsers").DataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns
        });
    
       
        $("#tblUsers").on('click', '.btn-edit', function () {
            var tr = $(this).closest('tr');
            var row = table.row(tr);
            var rowData = row.data();

            if (rowData) {
               showEditWindow(rowData)
                 
            }
        });
        $("#tblUsers").on('click', '.btn-delete', function () {
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
                            'La membresia ha sido borrada',
                            'success'
                        ).then(() => {
                            table.ajax.reload(null, false); 
                        });
                    }
                });
            }
        });



        function showEditWindow(user) {
            var form = $('<form>');

            var row1 = $('<div class="row mt-2"></div>');

            var nameCol = $('<div class="col-md-6"></div>');
            var nameLabel = $('<label class="labels" id="nameLabel">Nombre</label>');
            var nameInput = $('<input type="text" class="form-control" placeholder="nombre" id="nameInput">').val(user.nombre);
            nameCol.append(nameLabel, nameInput);

            var lastNameCol = $('<div class="col-md-6"></div>');
            var lastNameLabel = $('<label class="labels" id="txtLastNameLabel">Apellidos</label>');
            var lastNameInput = $('<input type="text" class="form-control" placeholder="apellidos" id="txtLastNameInput">').val(user.apellidos);
            lastNameCol.append(lastNameLabel, lastNameInput);

            row1.append(nameCol, lastNameCol);
            form.append(row1);

            var row2 = $('<div class="row mt-3"></div>');

            var phoneCol = $('<div class="col-md-12"></div>');
            var phoneLabel = $('<label class="labels" id="txtPhoneLabel">Telefono</label>');
            var phoneInput = $('<input type="text" class="form-control" placeholder="telefono" id="txtPhoneInput">').val(user.telefono);
            phoneCol.append(phoneLabel, phoneInput);

            var locationCol = $('<div class="col-md-12"></div>');
            var locationLabel = $('<label class="labels" id="locationLabel">Ubicacion</label>');
            var locationInput = $('<input type="text" class="form-control" placeholder="ubicacion" id="locationInput">').val(user.ubicacion);
            locationCol.append(locationLabel, locationInput);

            var emailCol = $('<div class="col-md-12"></div>');
            var emailLabel = $('<label class="labels" id="emailLabel">Email</label>');
            var emailInput = $('<input type="text" class="form-control" placeholder="email" id="emailInput">').val(user.email);
            emailCol.append(emailLabel, emailInput);

            row2.append(phoneCol, locationCol, emailCol);
            form.append(row2);

            var row3 = $('<div class="row mt-3"></div>');

            var tipoIdentificacionCol = $('<div class="col-md-6"></div>');
            var tipoIdentificacionLabel = $('<label class="labels">Tipo de Identificación</label>');
            var tipoIdentificacionSelect = $('<select id="tipoIdentificacion" class="form-select">' +
                '<option value="nacional">Nacional</option>' +
                '<option value="extranjero">Extranjero</option>' +
                '<option value="otro">Otro</option>' +
                '</select>').val(user.tipoIdentificacion);
            tipoIdentificacionCol.append(tipoIdentificacionLabel, tipoIdentificacionSelect);

            var numeroIdentificacionCol = $('<div class="col-md-6"></div>');
            var numeroIdentificacionLabel = $('<label class="labels" id="numeroIdentificacionLabel">Numero de Identificacion</label>');
            var numeroIdentificacionInput = $('<input id="numeroIdentificacionInput" type="text" class="form-control" placeholder="numero de identificacion">').val(user.numeroIdentificacion);
            numeroIdentificacionCol.append(numeroIdentificacionLabel, numeroIdentificacionInput);

            row3.append(tipoIdentificacionCol, numeroIdentificacionCol);
            form.append(row3);

            showModal('Editar Perfil', form, function () {
                var updatedUser = {
                    id: user.id,
                    nombre: nameInput.val(),
                    apellidos: lastNameInput.val(),
                    telefono: phoneInput.val(),
                    ubicacion: locationInput.val(),
                    email: emailInput.val(),
                    tipoIdentificacion: tipoIdentificacionSelect.val(),
                    numeroIdentificacion: numeroIdentificacionInput.val(),
                    password: "1234",
                    "confirmPassword": "1234",
                    "cedulaImagen": "https://res.cloudinary.com/eventwizz/image/upload/v1690779912/12857892761626934379-128_ojo0hn.png",
                };

                self.Update(updatedUser);

               
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
            var saveButton = $('<button type="button" class="btn btn-primary">Guardar</button>');

            closeButton.click(function () {
                modal.modal('hide');
            });

            saveButton.click(function () {
                onSave();
                modal.modal('hide');
            });
            var cancelButton = $('<button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>');
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
  
}