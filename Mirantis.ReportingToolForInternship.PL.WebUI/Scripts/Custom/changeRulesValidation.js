$(document).ready(function () {
    jQuery.validator.methods["date"] = function (value, element) { return true; } 
});

function validationActivities() {
    $("span[data-valmsg-for='Activities']")
            .removeClass("field-validation-error")
            .addClass("field-validation-valid")
            .text("");

    var isValid = true;
    $(".input-activity").each(function () {
        var value = $(this).val();
        if (value == "") {
            isValid = false;
        }
    });

    if (!isValid) {
        $("span[data-valmsg-for='Activities']")
            .removeClass("field-validation-valid")
            .addClass("field-validation-error")
            .text("Required at least one activity");
    }

    return isValid;
}