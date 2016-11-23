/// <reference path="../jquery-1.10.2.min.js" />

$(document).ready(function () {
    var $activityInput = $("#ActivityInput"),
        $questionInput = $("#QuestionInput"),
        $wrapperOnActivityInputAndQuestionInput = $("#WrapperOnActivityInputAndQuestionInput"),
        $addActivityButton = $("#AddActivityButton");

    $addActivityButton.click(function () {
        constructResultForm();
        clearActivityInputAndQuestionInput();
    });

    function clearActivityInputAndQuestionInput() {
        $activityInput.val("");
        $questionInput.val("");
    }

    function constructResultForm() {
        var $tempWrapper = $wrapperOnActivityInputAndQuestionInput.clone();

        $tempWrapper.find("#AddActivityButton").each(function () {
            assignmentButtonToAbilityOfRemove($(this));
            $(this).addClass("btn-remover")
                .attr("value", "–");
        });

        $tempWrapper.find(".btn-remover").each(function () {
            assignmentButtonToAbilityOfRemove($(this));
        });

        $tempWrapper.find(".btn-add-question").each(function () {
            constructAdditionButtonInfrastructure($(this));
        });

        $tempWrapper.removeAttr("id");
        $tempWrapper.find("*").each(function () {
            $(this).removeAttr("id");
        });

        $wrapperOnActivityInputAndQuestionInput.before($tempWrapper);
        $wrapperOnActivityInputAndQuestionInput.find(".btn-remover").each(function () {
            $(this).click();
        })
    };
});