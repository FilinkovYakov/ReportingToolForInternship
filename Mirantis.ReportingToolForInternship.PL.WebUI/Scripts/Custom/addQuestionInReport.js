/// <reference path="../jquery-1.10.2.min.js" />

$(document).ready(function () {
    var $addQuestionButton = $(".btn-add-question");

    $addQuestionButton.each(function () {
        constructAdditionButtonInfrastructure($(this));
    });
});

function constructAdditionButtonInfrastructure(questionButton) {
    $(questionButton).click(function () {
        $wrapperOnQuestionInput = $(questionButton).parent("div").parent("div"); //$("#WrapperQuestionInput"),
        $questionInput = $wrapperOnQuestionInput.find("input[type='text']"),
        constructResultForm($wrapperOnQuestionInput);
        clearQuestionInput($questionInput)
    });
}

function clearQuestionInput(questionInput) {
    $(questionInput).val("");
}

function constructResultForm(wrapperOnQuestionInput) {
    var $tempWrapper = $(wrapperOnQuestionInput).clone();

    $tempWrapper.removeAttr("id");
    $tempWrapper.find("*").each(function () {
        $(this).removeAttr("id");
    });

    $tempWrapper.find(".btn-add-question").each(function () {
        assignmentButtonToAbilityOfRemove($(this));
        $(this).removeClass("btn-add-question")
            .addClass("btn-remover")
            .attr("value", "–");
    });

    $(wrapperOnQuestionInput).before($tempWrapper);
}

function assignmentButtonToAbilityOfRemove(button) {
    $(button).click(function () {
        $wrapperButton = $(this).closest(".form-group");
        $wrapperButton.slideUp("slow", function () { $(this).remove(); })
    });
}