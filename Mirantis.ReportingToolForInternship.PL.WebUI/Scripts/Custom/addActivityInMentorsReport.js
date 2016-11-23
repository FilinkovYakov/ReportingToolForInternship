/// <reference path="../jquery-1.10.2.min.js" />

$(document).ready(function () {
    var $activityInput = $("#ActivityInput"),
        $evaluationInput = $("#EvaluationInput"),
        $wrapperOnActivityInputAndEvaluation = $("#WrapperOnActivityInputAndEvaluationInput"),
        $addActivityButton = $("#AddActivityButton");

    $addActivityButton.click(function () {
        constructResultForm();
        clearActivityInputAndEvaluationInput();
    });

    function clearActivityInputAndEvaluationInput() {
        $activityInput.val("");
        $evaluationInput.val("");
    }

    function constructResultForm() {
        var $tempWrapper = $wrapperOnActivityInputAndEvaluation.clone();

        $tempWrapper.find("#AddActivityButton").each(function () {
            assignmentButtonToAbilityOfRemove($(this));
            $(this).addClass("btn-remover")
                .attr("value", "–");
        });

        $tempWrapper.find(".btn-remover").each(function () {
            assignmentButtonToAbilityOfRemove($(this));
        });

        $tempWrapper.find(".btn-add-question").each(function () {
            constructAdditionInfrastructure($(this));
        });

        $tempWrapper.removeAttr("id");
        $tempWrapper.find("*").each(function () {
            $(this).removeAttr("id");
        });

        $wrapperOnActivityInputAndEvaluation.before($tempWrapper);
        $wrapperOnActivityInputAndEvaluation.find(".btn-remover").each(function () {
            $(this).click();
        })
    };
});