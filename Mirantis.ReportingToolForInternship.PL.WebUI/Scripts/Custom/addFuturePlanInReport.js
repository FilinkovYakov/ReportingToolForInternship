/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="addActivityInReport.js" />


$(function () {
    var $futurePlanInput = $("#FuturePlanInput"),
        $wrapperInputFuturePlan = $("#WrapperInputFuturePlan"),
        futurePlanValue;

    $(document).ready(function () {
        $("#AddFuturePlanButton").click(function () {
            getResultFromFuturePlanInput();
            clearFuturePlanInput();
            constructResultForm();
        });
    })

    function getResultFromFuturePlanInput() {
        futurePlanValue = $futurePlanInput.val();
    }

    function clearFuturePlanInput() {
        $futurePlanInput.val("");
    }

    function constructResultForm() {
        //Method "constructWrapperOfRemoverButton" got from "addActivityInReport"
        var $removerButton = constructWrapperOfRemoverButton();
        var $outerWrapper = $("<div></div>").addClass("form-group");
        var $innerWrapper = $("<div></div>")
            .addClass("col-xs-10");
        var $newFuturePlanInput = $("<input>")
            .addClass("form-control")
            .addClass("input-future-plan")
            .attr("value", futurePlanValue);

        $innerWrapper.append($newFuturePlanInput);
        $outerWrapper.append($removerButton);
        $outerWrapper.append($innerWrapper);
        $wrapperInputFuturePlan.before($outerWrapper);
    };
});