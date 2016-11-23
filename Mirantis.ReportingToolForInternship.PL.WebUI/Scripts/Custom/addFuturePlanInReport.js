/// <reference path="../jquery-1.10.2.min.js" />


$(document).ready(function () {
    var $addFuturePlanButton = $("#AddFuturePlanButton"),
        $futurePlanInput = $("#FuturePlanInput"),
        $wrapperInputFuturePlan = $("#WrapperInputFuturePlan");

    $addFuturePlanButton.click(function () {
        constructResultForm();
        clearFuturePlanInput();
    });

    function clearFuturePlanInput() {
        $futurePlanInput.val("");
    }

    function constructResultForm() {
        var $tempWrapper = $wrapperInputFuturePlan.clone();

        $tempWrapper.find("#AddFuturePlanButton").each(function () {
            assignmentButtonToAbilityOfRemove($(this));
            $(this).addClass("btn-remover")
                .attr("value", "–");
        });

        $tempWrapper.removeAttr("id");
        $tempWrapper.find("*").each(function () {
            $(this).removeAttr("id");
        });

        $wrapperInputFuturePlan.before($tempWrapper);
    };
});