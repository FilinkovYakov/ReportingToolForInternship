/// <reference path="../jquery-1.10.2.min.js" />

$(function () {
    var $activityInput = $("#ActivityInput"),
        $questionInput = $("#QuestionInput"),
        $wrapperActivityInputAndQuestionInput = $("#WrapperActivityInputAndQuestionInput"),
        $addActivityButton = $("#AddActivityButton"),
        activityValue;

    $(document).ready(function () {
        $addActivityButton.click(function () {
            constructResultForm();
            clearActivityInputAndQuestionInput();
        });
    })

    function clearActivityInputAndQuestionInput() {
        $activityInput.val("");
        $questionInput.val("");
    }


    function constructResultForm() {
        var $tempWrapper = $wrapperActivityInputAndQuestionInput.clone();
        $tempWrapper.removeAttr("id");
        $tempWrapper.find("input").each(function () {
            var id = $(this).attr("id");
            if (id == "ActivityInput") {
                $(this).addClass("input-activity");
            } else {
                $(this).addClass("input-question");
            }

            $(this).removeAttr("id");
        });
        $tempWrapper.find(".col-md-offset-2").removeClass("col-md-offset-2");

        $wrapperOfRemoverButton = constructWrapperOfRemoverButton();
        $tempWrapper.prepend($wrapperOfRemoverButton);
        $tempWrapper.removeClass("form-group-without-margin-bottom");

        $wrapperActivityInputAndQuestionInput.before($tempWrapper);
        $questionInput.siblings().remove();
    };
});

function constructRemoverButton() {
    $removerButton = $("<input>")
        .attr("type", "button")
        .attr("value", "–")
        .addClass("btn")
        .addClass("btn-default")
        .addClass("removerButton");

    $removerButton.click(function () {
        $wrapperButton = $(this).parent("div").parent("div");
        $wrapperButton.slideUp("slow", function () { $(this).remove(); })
    });

    return $removerButton;
}

function constructWrapperOfRemoverButton() {
    $removerButton = constructRemoverButton();
    $wrapperOnRemoverButton = $("<div></div>")
        .addClass("col-xs-1")
        .addClass("col-md-offset-1")
        .append($removerButton);
    return $wrapperOnRemoverButton;
}