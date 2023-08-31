$(document).ready(function () {
    var view = new ProfileController();
    view.InitView();

    $('#compraMembresia').on('click', function () {
        view.displayMembresiasModal();
    });
});

function ProfileController() {
    this.ViewName = "Perfil";
    this.ApiService = "Users";
    var self = this;

    this.InitView = function () {
        var userId = localStorage.getItem("idUsuario");
        self.RetrieveUser(userId).then(function (user) {
            if (user) {
                self.updateUserInfoUI(user);
            }
        });
    };

    this.updateUserInfoUI = function (user) {
        $("#name").text(user.nombre);
        $("#email").text(user.email);
        $("#nameInput").val(user.nombre);
        $("#txtLastNameInput").val(user.apellidos);
        $("#txtPhoneInput").val(user.telefono);
        $("#locationInput").val(user.ubicacion);
        $("#emailInput").val(user.email);
        $("#tipoIdentificacion").val(user.tipoIdentificacion);
        $("#numeroIdentificacionInput").val(user.numeroIdentificacion);
    };

    this.Update = function (user) {
        var ctrlActions = new ControlActions();
        var serviceToUpdate = self.ApiService + "/Update";

        ctrlActions.PutToAPI(serviceToUpdate, user, function (data) {
            // Handle the response if needed
        });
    };

    this.RetrieveUser = async function (id) {
        const apiUrl = `https://localhost:7152/api/Users/RetrieveById?id=${id}`;

        try {
            const response = await fetch(apiUrl);
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            const data = await response.json();
            return data;
        } catch (error) {
            console.error('Error retrieving data:', error);
            return null;
        }
    };

    this.getMembresias = async function () {
        var urlMembresias = 'https://localhost:7152/api/Memberships/RetrieveAll';

        try {
            const response = await fetch(urlMembresias);
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            const data = await response.json();
            return data;
        } catch (error) {
            console.error('Error al obtener las membresías:', error);
            return [];
        }
    };

  
    this.displayMembresiasModal = async function () {
        var membresias = await self.getMembresias();

        var membresiasContainer = $('#membresiasContainer');
        membresiasContainer.empty(); // Limpiar el contenido existente

        membresias.forEach(membership => {
            var card = $('<div class="col-md-4 mb-3 card text-white bg-secondary">'); // Cada tarjeta ocupa 4 columnas en pantallas medianas y grandes
            var cardBody = $('<div class="card-body text-center">'); // Centra el contenido en la tarjeta

            var membershipName = $('<h5 class="card-title">' + membership.name + '</h5>');
            var membershipPrice = $('<p class="card-text">Precio: ' + membership.price + '</p>');

            var selectButton = $('<button class="btn btn-primary">Seleccionar</button>');
            selectButton.click(function () {
                self.handleMembershipSelection(membership); // Llama a la función handleMembershipSelection al hacer clic en el botón
            });

            cardBody.append(membershipName, membershipPrice, selectButton);
            card.append(cardBody);
            membresiasContainer.append(card);
        });

        // Abre el modal
        $('#membresiasModal').modal('show');
    };




    this.handleMembershipSelection = function (membership) {
        // Actualiza el contenido del elemento txtMembresia con el nombre de la membresía seleccionada
        $('#txtMembresia').text(membership.name);
        console.log('Membership selected:', membership);

        $('#membresiasModal').modal('hide');

    };




   
}