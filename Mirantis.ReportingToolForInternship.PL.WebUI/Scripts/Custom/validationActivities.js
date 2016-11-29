function validationAllActivities() {
    var $errorMessage = $("span[data-valmsg-for='Activities']");
    $errorMessage.removeClass("field-validation-error")
                .addClass("field-validation-valid")
                .text("");

    var counterNotEmptyStrings = 0;
    $(".input-activity").each(function () {
        var activity = $(this).val();
        if (activity != "") {
            counterNotEmptyStrings++;
        }
    });

    if (counterNotEmptyStrings == 0) {
        $errorMessage.removeClass("field-validation-valid")
                     .addClass("field-validation-error")
                     .text("Required at least one activity");
        return false;
    }

    return true;
}