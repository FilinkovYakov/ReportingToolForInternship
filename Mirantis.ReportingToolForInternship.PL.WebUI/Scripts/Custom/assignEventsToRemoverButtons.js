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
        var $wrapperButton = $(button).closest(".form-group");
        $wrapperButton.slideUp("slow", function () { $(this).remove(); })
    }
}