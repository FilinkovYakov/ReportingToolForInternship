$(document).ready(function () {
    var $datePickerFrom = $('#DateFrom').parent("div"),
        $datePickerTo = $('#DateTo').parent("div");

    $datePickerFrom.datetimepicker({
        format: 'DD.MM.YYYY',
        ignoreReadonly: true,
        sideBySide: true
    });

    $datePickerFrom.on('dp.change', function (e) {
        $datePickerTo.data("DateTimePicker").minDate(e.date)
    });

    $datePickerTo.datetimepicker({
        format: 'DD.MM.YYYY',
        ignoreReadonly: true,
        sideBySide: true,
    });
});