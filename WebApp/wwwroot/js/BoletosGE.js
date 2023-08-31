$(document).ready(function () {
    const view = new BoletosGEController();

    const registerBtn = $('#registerBtn');
    const qrInfoCard = $('.card');
    const qrInfoText = $('#qrInfo');
    registerBtn.click(function () {
        retrieveInfoInput(view); 
    });
});

function BoletosGEController() {
    this.GetBoleto = function (id) {
        const url_get = `https://localhost:7152/api/Event/RetrieveByIdEvent?id=${id}`;

        return $.ajax({
            url: url_get,
            method: 'GET',
            contentType: 'application/json',
        });
    };

    this.UpdateStateBoleto = function (boleto) {
        const url_Up = `https://localhost:7152/api/Ticket/UpdateState?id=${id}`

        var ctrlActions = new ControlActions();
        ctrlActions.PutToAPI(url_Up, boleto, function (data) {

        });
    }
}

function retrieveInfoInput() {
    const view = new BoletosGEController();
    const qrInput = $('#qrInput').val(); // Get the input value
    view.GetBoleto(qrInput)
        .then(function (infoBoleto) {
            showDataBoleto(infoBoleto);
            view.UpdateStateBoleto(infoBoleto);
        })
        .catch(function (error) {
            console.error('Error:', error.statusText);
        });
}

function showDataBoleto(boleto) {
    qrInfoText.text(boleto);
    qrInfoCard.show();
}


