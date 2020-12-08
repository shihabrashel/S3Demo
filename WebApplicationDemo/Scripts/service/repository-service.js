var service = {
    getRootUrl: function () {
        var url = window.location.origin;
        var paths = window.location.pathname.substring(1, window.location.pathname.length).split('/');
        for (var i = 0; i < paths.length - 2; i++) {
            url += '/' + paths[i];
        }
        return url;
    },
    getReadingData: function () {
        if (!$('#building').val() || !$('#object').val() || !$('#data-field').val() || !$('#start-date').val() || !$('#end-date').val())
            return;
        $.ajax({
            type: "GET",
            url: service.getRootUrl() + "/Home/GetReadingData?buildingId="+$('#building').val()
                +"&objectId="+ $('#object').val()
                + "&dataFieldId="+ $('#data-field').val()
                + "&startDate="+ $('#start-date').val()
                + "&endDate="+ $('#end-date').val()
            ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                lineChartWrapper.renderReadingData(result);
            },
            error: function (xhr, status, exception) {
                console.log("Error: " + exception + ", Status: " + status);
            }
        });
    },
    getBuildingData: function () {
        $.ajax({
            type: "GET",
            url: service.getRootUrl() + "/Home/GetBuildings",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#building').empty();
                $.each(result, function (index, item) {
                    $('#building').append($('<option>', {
                        value: item.Id,
                        text: item.Name
                    }));
                });
                service.getObjectData();
            },
            error: function (xhr, status, exception) {
                console.log("Error: " + exception + ", Status: " + status);
            }
        });
    },
    getObjectData: function () {
        $.ajax({
            type: "GET",
            url: service.getRootUrl() + "/Home/GetObjects",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#object').empty();
                $.each(result, function (index, item) {
                    $('#object').append($('<option>', {
                        value: item.Id,
                        text: item.Name
                    }));
                });
                service.getDataFields();
            },
            error: function (xhr, status, exception) {
                console.log("Error: " + exception + ", Status: " + status);
            }
        });
    },
    getDataFields: function () {
        $.ajax({
            type: "GET",
            url: service.getRootUrl() + "/Home/GetDataFields",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#data-field').empty();
                $.each(result, function (index, item) {
                    $('#data-field').append($('<option>', {
                        value: item.Id,
                        text: item.Name
                    }));
                });
                service.getReadingData();
            },
            error: function (xhr, status, exception) {
                console.log("Error: " + exception + ", Status: " + status);
            }
        });
    }
}