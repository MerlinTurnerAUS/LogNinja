(function () {
    var snoopHub = $.connection.snoopHub;

    $.connection.hub.start()
        .done(function () {
            $.connection.hub.logging = false;
            $.connection.hub.log("Connection established");
            snoopHub.server.sigTest("SignalR connection established! Building list...");
            populateList();
        })
        .fail(function () {
            writeToPage("Error connecting to SignalR");
        });

    snoopHub.client.announce = function (message) {
        writeToPage(message);
    };

    snoopHub.client.addLogEntry = function (logEntry) {

        var rowHTML = "<tr><td>";

        rowHTML = rowHTML + logEntry.PCName + "</td><td>" + logEntry.ServiceName + "</td><td>" + logEntry.DB + "</td><td>" + logEntry.ConnStr + "</td><td>" + logEntry.Location + "</td></tr>"; // + "</td><td>" + logEntry.Status 
        $('#ESMachines tbody').append(rowHTML);
    };


    var writeToPage = function (message) {
        $("#welcome-messages").empty();
        $("#welcome-messages").append(message + "<br />");
    };

    $("#click-me").on("click", function () {
        populateList();
    });

    var populateList = function () {
        $('#ESMachines tbody').empty();
        snoopHub.server.getESMachineDetails();
        snoopHub.server.sigTest("");
    };
})();