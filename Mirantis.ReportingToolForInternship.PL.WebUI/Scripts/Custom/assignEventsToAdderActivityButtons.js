/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="assignEventsToRemoverActivityButtons.js" />
/// <reference path="assignEventsToAdderButtons.js" />
/// <reference path="clearIDs.js" />

$(document).ready(function () {
    var $adderActivityButton = $(".btn-adder-activity");

    $adderActivityButton.each(function () {
        constructAdderActivityButtonInfrastructure($(this));
    });
});

function constructAdderActivityButtonInfrastructure(button) {
    $(button).click(function () {
        var $wrapper = $(button).closest(".activity");
        var $newWrapper = $wrapper.clone();
        var $input = $newWrapper.find("input[type='text']");

        $newWrapper.find(".btn-adder-activity").each(function () {
            constructAdderActivityButtonInfrastructure($(this));
        });

        $newWrapper.find(".btn-remover-activity").each(function () {
            assignmentButtonToAbilityOfRemoveActivity($(this));
        });

        $newWrapper.find(".btn-adder").each(function () {
            constructAdderButtonInfrastructure($(this));
        });

        $newWrapper.find(".btn-remover").each(function () {
            assignmentButtonToAbilityOfRemoveComposition($(this));
        });

        cleanTextInInputsInnerWrapper($newWrapper);
        $wrapper.after($newWrapper);

        cleanHiddenIDs($newWrapper);

        $newWrapper.find(".btn-remover:not(:last)").each(function () {
            removeWrapper($(this));
        });
    });
}