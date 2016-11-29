/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../bootstrap.min.js" />
/// <reference path="../bootstrap-datepicker.min.js" />

$(document).ready(function () {
    var $datePickerFrom = $('#DateFrom').closest("div"),
        $datePickerTo = $('#DateTo').closest("div");

    $datePickerFrom.datepicker({
        format: 'dd.mm.yyyy',
        ignoreReadonly: true
    });

    $datePickerTo.datepicker({
        format: 'dd.mm.yyyy',
        ignoreReadonly: true
    });

    $datePickerFrom.on("changeDate", function (e) {
        $datePickerTo.datepicker('setStartDate', e.date);
    });
});