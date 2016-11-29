﻿/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="constructors.js" />
/// <reference path="actionsAfterSuccessOfSendingReport.js" />
/// <reference path="changeRulesValidation.js" />
/// <reference path="validationActivities.js" />
/// <reference path="validationInternsActivities.js" />
/// <reference path="validationFuturePlans.js" />

$(document).ready(function () {
    var $submitButton = $("#SubmitButton"),
        $saveAsDraftButton = $("#SaveAsDraftButton"),
        $internNameInput = $("#InternName"),
        $messageStatusReport = $("#MessageAboutStatusReport"),
        $typeInput = $("#TypeOccuring"),
        $dateInput = $("#Date");

    $submitButton.click(function () {
        if (isModelValidate()) {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/SaveReportAsDraftAfterEditing",
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
                url: "/Report/SubmitReportAfterEditing",
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
        isValidForm = $internNameInput.valid() && isValidForm;
        isValidForm = $typeInput.valid() && isValidForm;
        isValidForm = $dateInput.valid() && isValidForm;
        isValidForm = validationActivitiesFromInternsReport() && isValidForm;
        isValidForm = validationFuturePlans() && isValidForm;
        return isValidForm;
    }

    function constructReportVM() {
        var id = $(".reportId").val();
        var mentorName = null;
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
            var id = constructIdByInput($(this), ".futurePlanId");
            var description = $(this).val();
            futurePlans[index] = new FuturePlanVM(id, description);
        });

        return futurePlans;
    }

    function constructIdByInput(input, classOfWrapperWithId) {
        var $wrapperId = $(input).siblings(classOfWrapperWithId);
        if ($wrapperId.length > 0) {
            return $wrapperId.val();
        }

        return null;
    }

    function constructActivities() {
        var activities = [];
        $(".input-activity").each(function (index) {
            var id = constructIdByInput($(this), ".activityId");
            var description = $(this).val();
            var evaluation = null;
            var questions = constructQuestionsByInputActivity($(this));
            activities[index] = new ActivityVM(id, description, evaluation, questions);
        });

        return activities;
    }

    function constructQuestionsByInputActivity(inputActivity) {
        var questions = [];
        $(inputActivity).parent().parent().parent()
            .find(".input-question")
            .each(function (index) {
                var id = constructIdByInput($(this), ".questionId");
                var description = $(this).val();
                questions[index] = new QuestionVM(description);
            })

        return questions;
    }
});