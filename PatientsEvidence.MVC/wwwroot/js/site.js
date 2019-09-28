// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {

    $('#patientsTable thead tr').clone(true).appendTo('#patientsTable thead');
    $('#patientsTable thead tr:eq(1) th').each(function (i) {
        if ($(this).hasClass("filterable")) {
            var title = $(this).text();
            $(this).html('<input type="text" class="form-control form-control-sm" placeholder="Search ' + title + '" />');

            $('input', this).on('keyup change', function () {
                if (table.column(i).search() !== this.value) {
                    table
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });
        }
        else {
            $(this).html('');
        }
    });

    var table = $('#patientsTable').DataTable({
        fixedHeader: true,
        "order": [],
        orderCellsTop: true,
        "pageLength": 10,
        "searching": true,
        dom: 'tip'
    });
});