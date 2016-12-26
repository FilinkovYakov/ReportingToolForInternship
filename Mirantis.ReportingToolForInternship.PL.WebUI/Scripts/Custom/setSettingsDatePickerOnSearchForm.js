/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../bootstrap.min.js" />
/// <reference path="../bootstrap-datepicker.min.js" />

$(document).ready(function () {
    var $datePickerFrom = $('#DateFrom').closest("div"),
        $datePickerTo = $('#DateTo').closest("div");

    $datePickerFrom.datepicker({
        format: 'dd.mm.yyyy',
        enableOnReadonly: true,
        autoclose: true,
        clearBtn: true
    });

    $datePickerTo.datepicker({
        format: 'dd.mm.yyyy',
        enableOnReadonly: true,
        autoclose: true,
        clearBtn: true
    });

    $datePickerFrom.on("changeDate", function (e) {
        $datePickerTo.datepicker('setStartDate', e.date);
    });

    $datePickerTo.on("changeDate", function (e) {
        $datePickerFrom.datepicker('setEndDate', e.date);
    });

    $datePickerFrom.on("clearDate", function () {
        $datePickerTo.datepicker('setStartDate', null);
    });

    $datePickerTo.on("clearDate", function () {
        $datePickerFrom.datepicker('setEndDate', null);
    });
});