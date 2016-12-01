/// <reference path="disableInputs.js" />

$(document).ready(function () {
    $(".btn-remover-activity").each(function () {
        assignmentButtonToAbilityOfRemoveActivity($(this))
    });
});

function assignmentButtonToAbilityOfRemoveActivity(button) {
    $(button).click(function () {
        removeActivity(button);
    });
}

function removeActivity(button) {
    var $wrapperButton = $(button).closest(".activity"),
         $activities = $(".activity"),
         amountRemoverButtons = $activities.find(".btn-remover-activity").size();

    if (amountRemoverButtons > 1) {
        lockAllFunctions();
        $wrapperButton.slideUp("slow", function () {
            $(this).remove();
            unlockAllFunctions();
        });
    }
}