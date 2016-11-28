/// <reference path="disableInputs.js" />

$(document).ready(function () {
    $(".btn-remover").each(function () {
        assignmentButtonToAbilityOfRemoveComposition($(this))
    });
});

function assignmentButtonToAbilityOfRemoveComposition(button) {
    $(button).click(function () {
        removeWrapper(button);
    });
}

function removeWrapper(button) {
    var $composition = $(button).closest(".composition");
    var amountRemoverButtons = $composition.find(".btn-remover").size();
    if (amountRemoverButtons > 1) {
        var $wrapper = $(button).closest(".form-group");
        lockAllFunctions();
        $wrapper.slideUp(500, function () {
            $(this).remove();
            unlockAllFunctions();
        });
    }
}