/// <reference path="../jquery-1.10.2.min.js" />

$(function () {
    var $questionInput = $("#QuestionInput"),
        $questionButton = $("#AddQuestionButton"),
        questionValue;

    $(document).ready(function () {
        $questionButton.click(function () {
            getResultFromQuestionInput();
            clearQuestionInput();
            constructResultForm();
        })
    })

    function getResultFromQuestionInput() {
        questionValue = $questionInput.val();
    }

    function clearQuestionInput() {
        $questionInput.val("");
    }

    function constructResultForm() {
        var $newQuestionInput = $("<input>")
            .addClass("form-control")
            .attr("value", questionValue);

        $questionInput.before($newQuestionInput);
    }
});