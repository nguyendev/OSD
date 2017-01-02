$(document).ready(function () {
    var handleDataTableButtons = function () {
        if ($("#datatable-buttons").length) {
            $("#datatable-buttons").DataTable({
                dom: "Bfrtip",
                buttons: [
                  {

                      extend: "copy",
                      className: "btn-sm btn-primary"

                  },
                  {
                      extend: "csv",
                      className: "btn-sm btn-primary"
                  },
                  {
                      extend: "excel",
                      className: "btn-sm btn-primary"
                  },
                  {
                      extend: "pdf",
                      className: "btn-sm btn-primary"
                  },
                  {
                      extend: "print",
                      className: "btn-sm btn-primary"
                  },
                ],
                responsive: true
            });
        }
    };

    TableManageButtons = function () {
        "use strict";
        return {
            init: function () {
                handleDataTableButtons();
            }
        };
    }();

    $('#datatable').dataTable();

    $('#datatable-keytable').DataTable({
        keys: true
    });

    $('#datatable-responsive').DataTable();

    $('#datatable-scroller').DataTable({
        ajax: "js/datatables/json/scroller-demo.json",
        deferRender: true,
        scrollY: 380,
        scrollCollapse: true,
        scroller: true
    });

    $('#datatable-fixed-header').DataTable({
        fixedHeader: true
    });

    var $datatable = $('#datatable-checkbox');

    $datatable.dataTable({
        'order': [[1, 'asc']],
        'columnDefs': [
          { orderable: false, targets: [0] }
        ]
    });
    $datatable.on('draw.dt', function () {
        $('input').iCheck({
            checkboxClass: 'icheckbox_flat-green'
        });
    });

    TableManageButtons.init();
});