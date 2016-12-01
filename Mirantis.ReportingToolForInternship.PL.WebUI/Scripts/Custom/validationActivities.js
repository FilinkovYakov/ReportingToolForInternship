/// <reference path="validationRecord.js" />

function validationAllActivities() {
    var $errorMessage = $("span[data-valmsg-for='Activities']"),
        counterCorrectActivities = 0;

    $errorMessage.removeClass("field-validation-error")
                .addClass("field-validation-valid")
                .text("");

    $(".input-activity").each(function () {
        var activitysDescription = $(this).val();
        if (validationRecord(activitysDescription)) {
            counterCorrectActivities++;
        }
    });

    if (counterCorrectActivities == 0) {
        $errorMessage.removeClass("field-validation-valid")
                     .addClass("field-validation-error")
                     .text("Required at least one activity");
        return false;
    }

    return true;
}