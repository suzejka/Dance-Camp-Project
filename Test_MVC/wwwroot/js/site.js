function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}

$(document).ready(function () {
    $('#myTable').DataTable({
        paging: true,
        searching: true,
        ordering: true
    });
});

$('#myNavTabs a').click(function (evt) {
    evt.preventDefault();
    $(this).tab('show');
});

$(document).ready(function () {
    $('#productsTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pl.json"
        }
    });
});

$(document).ready(function () {
    $('#participantsTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pl.json"
        }
    });
});

$(document).ready(function () {
    $('#organisersTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pl.json"
        }
    });
});

$(document).ready(function () {
    $('#cameraOperatorsTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        "info": false,
        dom: '<"top"f>rt<"bottom"p><"clear">',
        "pageLength": 5,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pl.json"
        }
    });
});

$(document).ready(function () {
    $('#musicConsoleOperatorsTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        "info": false,
        dom: '<"top"f>rt<"bottom"p><"clear">',
        "pageLength": 5,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pl.json"
        }
    });
});

$(document).ready(function () {
    $('#trainersTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pl.json"
        }
    });
});

$(document).ready(function () {
    $('#shopsTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        "info": false,
        dom: '<"top"f>rt<"bottom"p><"clear">',
        "pageLength": 5,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pl.json"
        }
    });
});

$(document).ready(function () {
    $('#openEventsTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        "info": false,
        dom: '<"top"f>rt<"bottom"p><"clear">',
        "pageLength": 5,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pl.json"
        }
    });
});

$(document).ready(function () {
    $('#trainersTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        "info": false,
        dom: '<"top"f>rt<"bottom"p><"clear">',
        "pageLength": 5,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pl.json"
        }
    });
});

$(document).ready(function () {
    $('#sponsorsTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        "info": false,
        dom: '<"top"f>rt<"bottom"p><"clear">',
        "pageLength": 5,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pl.json"
        }
    });
});

$(document).ready(function () {
    $('#camerasTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        "info": false,
        dom: '<"top"f>rt<"bottom"p><"clear">',
        "pageLength": 5,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.12.1/i18n/pl.json"
        }
    });
});

 