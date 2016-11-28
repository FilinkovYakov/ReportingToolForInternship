/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="constructors.js" />
/// <reference path="actionsAfterSuccessOfSendingReport.js" />

$(document).ready(function () {
    var $remainButton = $("#RemainAsDraftButton"),
        $changeOnFinalVersionButton = $("#ChangeOnFinalVersionButton"),
        $internNameInput = $("#InternName"),
        $messageStatusReport = $("#MessageAboutStatusReport"),
        $typeInput = $("#TypeOccuring"),
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

    function constructReportVM() {
        var mentorName = null;
        var internName = $internNameInput.val();
        var typeOccuring = $typeInput.val();
        var date = $dateInput.val();
        var activities = constructActivities();
        var futurePlans = constructFuturePlans();
        return new ReportVM(mentorName, internName, typeOccuring, date, activities, futurePlans);
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
});