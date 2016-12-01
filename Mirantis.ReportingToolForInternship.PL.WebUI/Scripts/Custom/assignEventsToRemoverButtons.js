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
    var $wrapper = $(button).closest(".form-group"),
        $composition = $(button).closest(".composition"),
        amountRemoverButtons = $composition.find(".btn-remover").size();

    $wrapper.find("input[type='text']").val("");
    if (amountRemoverButtons > 1) {
        lockAllFunctions();
        $wrapper.slideUp(500, function () {
            $(this).remove();
            unlockAllFunctions();
        });
    }
}