$(document).ready(function () {
    var view = new AdminLogsController();
    view.InitView();

})


function AdminLogsController() {
    this.ViewName = "Logs";
    this.ApiService = "Logs";
    var self = this;


    this.InitView = function () {

        this.LoadTable();

    }

    this.LoadTable = function () {
        var ctrlActions = new ControlActions();
        var self = this;

        var urlService = ctrlActions.GetUrlApiService(this.ApiService + "/RetrieveAll");
        var columns = [];

        columns[0] = { 'data': null };
        columns[1] = { 'data': 'action' };
        columns[2] = { 'data': 'idAffected' };
        columns[3] = { 'data': 'oldData' };
        columns[4] = { 'data': 'newData' };
        columns[5] = { 'data': 'timeLog' };


        var table = $("#tblLogs").DataTable();
        
        
        if (table) {
            table.clear().destroy(); // Si la tabla existe, la limpiamos y destruimos
        }

        var table = $("#tblLogs").DataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns
           
        });
         
    }

}