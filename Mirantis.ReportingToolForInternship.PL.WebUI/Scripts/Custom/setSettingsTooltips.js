$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

    $('input[data-toggle="tooltip"]').on('input', function () {
        var value = $(this).val();
        $(this).attr("data-original-title", value);
        $(this).tooltip('show');
    });
});

function refreshInputsTooltip(input) {
    $(input).attr("data-original-title", "");
    $(input).on('input', function () {
        var value = $(this).val();
        $(this).attr("data-original-title", value);
        $(this).tooltip('show');
    });
}