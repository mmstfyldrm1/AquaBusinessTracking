$(function () {
    "use strict";

    if ($.fn.DataTable.isDataTable('#example')) {
        $('#example').DataTable().destroy();
    }
    $('#example').DataTable();

    if ($.fn.DataTable.isDataTable('#example2')) {
        $('#example2').DataTable().destroy();
    }
    var table = $('#example2').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'print']
    });

    table.buttons().container()
        .appendTo('#example2_wrapper .col-md-6:eq(0)');
});