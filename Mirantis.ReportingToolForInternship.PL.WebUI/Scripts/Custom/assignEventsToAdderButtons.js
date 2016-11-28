/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="assignEventsToRemoverButtons.js" />

$(document).ready(function () {
    var $adderButton = $(".btn-adder");

    $adderButton.each(function () {
        constructAdderButtonInfrastructure($(this));
    });
});

function constructAdderButtonInfrastructure(button) {
    $(button).click(function () {
        var $wrapper = $(button).closest(".form-group");
        var $newWrapper = $wrapper.clone();

        $newWrapper.find(".btn-adder").each(function () {
            constructAdderButtonInfrastructure($(this));
        });

        $newWrapper.find(".btn-remover").each(function () {
            assignmentButtonToAbilityOfRemoveComposition($(this));
        });

        cleanTextInInputsInnerWrapper($newWrapper);

        $wrapper.after($newWrapper);
    });
}

function cleanTextInInputsInnerWrapper(wrapper) {
    var $input = $(wrapper).find("input[type='text']");
    $input.each(function (index) { $(this).val(""); });
}