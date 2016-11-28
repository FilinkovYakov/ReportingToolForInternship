$(document).ready(function () {
    $('.date').each(function () {
        $(this).datetimepicker({
            format: 'DD.MM.YYYY', ignoreReadonly: true
        });
    });
});