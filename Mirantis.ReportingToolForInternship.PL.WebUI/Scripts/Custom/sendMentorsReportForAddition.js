/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="constructors.js" />
/// <reference path="clearInputs.js" />
/// <reference path="disableInputs.js" />

$(document).ready(function () {
    var $submitButton = $("#SubmitButton"),
        $saveAsDraftButton = $("#SaveAsDraftButton"),
        $mentorNameInput = $("#MentorName"),
        $internNameInput = $("#InternName"),
        $messageStatusReport = $("#MessageAboutStatusReport"),
        $typeInput = $("#TypeOccuring"),
        $dateInput = $("#Date");


    $submitButton.click(function () {
        if (isModelValidate()) {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/SubmitReport",
                data: JSON.stringify(reportVM),
                contentType: 'application/json; charset=utf-8',
                dataType: 'html',
                success: function (result) {
                    successFunction(result);
                }
            });
        }
    });

    $saveAsDraftButton.click(function () {
        if (isModelValidate()) {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/AddReportAsDraft",
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
        isValidForm = isValidForm && $mentorNameInput.valid();
        isValidForm = isValidForm && $internNameInput.valid();
        isValidForm = isValidForm && $typeInput.valid();
        isValidForm = isValidForm && $dateInput.valid();
        return isValidForm;
    }

    function constructReportVM() {
        var id = null;
        var mentorName = $mentorNameInput.val();
        var internName = $internNameInput.val();
        var typeOccuring = $typeInput.val();
        var date = $dateInput.val();
        var activities = constructActivities();
        var futurePlans = constructFuturePlans();
        return new ReportVM(id, mentorName, internName, typeOccuring, date, activities, futurePlans);
    }

    function constructFuturePlans() {
        var futurePlans = [];
        $(".input-future-plan").each(function (index) {
            var id = null;
            var description = $(this).val();
            futurePlans[index] = new FuturePlanVM(id, description);
        });

        return futurePlans;
    }

    function constructActivities() {
        var activities = [];
        $(".input-activity").each(function (index) {
            var id = null;
            var description = $(this).val();
            var evaluation = constructEvaluationByInputActivity($(this));
            var questions = null;
            activities[index] = new ActivityVM(id, description, evaluation, questions);
        });

        return activities;
    }

    function constructEvaluationByInputActivity(inputActivity) {
        var evaluation;
        $(inputActivity).parent().parent().parent().parent()
            .find(".input-evaluation")
            .each(function (index) {
                evaluation = $(this).val();
            })

        return evaluation;
    }
});