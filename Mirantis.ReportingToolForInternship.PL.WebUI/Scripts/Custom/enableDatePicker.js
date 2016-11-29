/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../bootstrap-datepicker.min.js" />

$(document).ready(function () {
    $('.date').each(function () {
        $(this).datepicker({
            format: 'dd.mm.yyyy', enableOnReadonly: true
        });
    });
});