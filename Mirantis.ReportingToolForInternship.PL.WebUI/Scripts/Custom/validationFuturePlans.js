function validationFuturePlans() {
    var $errorMessage = $("span[data-valmsg-for='FuturePlans']");
    $errorMessage.removeClass("field-validation-error")
                 .addClass("field-validation-valid")
                 .text("");

    counterNotEmptyStrings = 0;
    $(".input-future-plan").each(function () {
        var futurePlan = $(this).val();
        if (futurePlan != "") {
            counterNotEmptyStrings++;
        }
    });

    if (counterNotEmptyStrings == 0) {
        $errorMessage.removeClass("field-validation-valid")
                     .addClass("field-validation-error")
                     .text("Required at least one feature plan");
        return false;
    }

    return true;
}