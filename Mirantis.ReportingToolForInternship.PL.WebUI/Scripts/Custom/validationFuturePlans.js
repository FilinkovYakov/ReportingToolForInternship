/// <reference path="validationRecord.js" />

function validationFuturePlans() {
    var $errorMessage = $("span[data-valmsg-for='FuturePlans']"),
        counterCorrectFuturePlans = 0;

    $errorMessage.removeClass("field-validation-error")
                 .addClass("field-validation-valid")
                 .text("");

    $(".input-future-plan").each(function () {
        var futurePlansDescription = $(this).val();
        if (validationRecord(futurePlansDescription)) {
            counterCorrectFuturePlans++;
        }
    });

    if (counterCorrectFuturePlans == 0) {
        $errorMessage.removeClass("field-validation-valid")
                     .addClass("field-validation-error")
                     .text("Required at least one feature plan");
        return false;
    }

    return true;
}