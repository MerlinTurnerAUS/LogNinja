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

        var rowHTML;

        if(logEntry.isError)
            rowHTML = "<tr  style='background-color: coral'><td>";
        else
            rowHTML = "<tr><td>";

        rowHTML = rowHTML + logEntry.timeStamp + "</td><td>" + logEntry.source + "</td><td>" + logEntry.status + "</td><td>" + logEntry.entryText + "</td><td>"; 
        $('#logEntries tbody').prepend(rowHTML);
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