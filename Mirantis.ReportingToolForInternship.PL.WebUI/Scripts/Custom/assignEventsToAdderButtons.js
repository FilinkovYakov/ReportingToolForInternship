/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="assignEventsToRemoverButtons.js" />
/// <reference path="setSettingsTooltips.js" />

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

        $newWrapper.find('input[data-toggle="tooltip"]').each(function () {
            refreshInputsTooltip($(this));
        });

        cleanTextInInputsInnerWrapper($newWrapper);
        $wrapper.after($newWrapper);

        cleanHiddenIDs($newWrapper);
    });
}

function cleanHiddenIDs(wrapper) {
    $(wrapper).find(".activityId:hidden").remove();
    $(wrapper).find(".futurePlanId:hidden").remove();
    $(wrapper).find(".questionId:hidden").remove();
}

function cleanTextInInputsInnerWrapper(wrapper) {
    var $input = $(wrapper).find("input[type='text']");
    $input.each(function (index) { $(this).val(""); });
}