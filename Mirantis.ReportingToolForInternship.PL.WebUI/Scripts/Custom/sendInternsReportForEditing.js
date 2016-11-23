/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="constructors.js" />

$(document).ready(function () {
    var $remainButton = $("#RemainAsDraftButton"),
        $changeOnFinalVersionButton = $("#ChangeOnFinalVersionButton"),
        $addActivityButton = $("#AddActivityButton"),
        $addQuestionButton = $("#AddQuestionButton"),
        $addFuturePlanButton = $("#AddFuturePlanButton"),
        $internNameInput = $("#InternName"),
        $messageStatusReport = $("#MessageAboutStatusReport"),
        $typeInput = $("#Type"),
        $dateInput = $("#Date");

    $remainButton.click(function () {
        if (isModelValidate()) {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/RemainReportAsDraft",
                data: JSON.stringify(reportVM),
                contentType: 'application/json; charset=utf-8',
                dataType: 'html',
                success: function (result) {
                    successFunction(result);
                }
            });
        }
    });

    $changeOnFinalVersionButton.click(function () {
        if (isModelValidate()) {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/ChangeReportOnFinalVersion",
                data: JSON.stringify(reportVM),
                contentType: 'application/json; charset=utf-8',
                dataType: 'html',
                success: function (result) {
                    successFunction(result);
                }
            })
        }
    });

    function isModelValidate() {
        var isValidForm = true;
        isValidForm = isValidForm && $internNameInput.valid();
        isValidForm = isValidForm && $typeInput.valid();
        isValidForm = isValidForm && $dateInput.valid();
        return isValidForm;
    }

    function successFunction(result) {
        showMessageStatusReport(result);
        lockAllFunctions();
        bindingButtonAddReportWithEvent();
        $("select").prop()
    }

    function lockAllFunctions() {
        setConditionReadonlyOnInputs(true);
        setConditionDisablingOnSelects(true);
        setConditionDisablingOnButtons(true);
    }

    function unlockAllFunctions() {
        setConditionReadonlyOnInputs(false);
        setConditionDisablingOnSelects(false);
        setConditionDisablingOnButtons(false);
    }

    function setConditionReadonlyOnInputs(value) {
        $("input").attr("readonly", value);
    }

    function setConditionDisablingOnSelects(value) {
        $("select").prop("disabled", value);
    }

    function setConditionDisablingOnButtons(value) {
        $(".btn-remover").prop("disabled", value)
        $submitButton.prop("disabled", value);
        $saveAsDraftButton.prop("disabled", value);
        $addActivityButton.prop("disabled", value);
        $addQuestionButton.prop("disabled", value);
        $addFuturePlanButton.prop("disabled", value);
    }

    function bindingButtonAddReportWithEvent() {
        $("#AddReport").click(function () {
            $messageStatusReport.slideToggle(1000);
            unlockAllFunctions();
            $("input").attr("readonly", false);
            $(".btn-remover").click();
            clearInputs();
        });

        $("#SearchReports").click(function () {
            window.location.replace("/Report/Search");
        });
    }

    function showMessageStatusReport(result) {
        $messageStatusReport.html(result)
                        .hide()
                        .slideToggle(1000);
    }

    function constructReportVM() {
        var mentorName = null;
        var internName = $internNameInput.val();
        var type = $typeInput.val();
        var date = $dateInput.val();
        var activities = constructActivities();
        var futurePlans = constructFuturePlans();
        return new ReportVM(mentorName, internName, type, date, activities, futurePlans);
    }

    function constructFuturePlans() {
        var futurePlans = [];
        $(".input-future-plan").each(function (index) {
            var description = $(this).val();
            futurePlans[index] = new FuturePlanVM(description);
        });

        return futurePlans;
    }

    function constructActivities() {
        var activities = [];
        $(".input-activity").each(function (index) {
            var description = $(this).val();
            var evaluation = null;
            var questions = constructQuestionsByInputActivity($(this));
            activities[index] = new ActivityVM(description, evaluation, questions);
        });

        return activities;
    }

    function constructQuestionsByInputActivity(inputActivity) {
        var questions = [];
        $(inputActivity).parent().parent().parent()
            .find(".input-question")
            .each(function (index) {
                var description = $(this).val();
                questions[index] = new QuestionVM(description);
            })

        return questions;
    }

    function clearInputs() {
        $(".input-activity").val("");
        $(".input-question").val("");
        $(".input-future-plan").val("");
    }
});