/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="constructors.js" />
/// <reference path="actionsAfterSuccessfullAdditionReport.js" />
/// <reference path="changeRulesValidation.js" />
/// <reference path="validationActivities.js" />
/// <reference path="validationInternsActivities.js" />
/// <reference path="validationFuturePlans.js" />

$(document).ready(function () {
    var $submitButton = $("#SubmitButton"),
        $saveAsDraftButton = $("#SaveAsDraftButton"),
        $internNameInput = $("#InternName"),
        $typeInput = $("#TypeOccuring"),
        $dateInput = $("#Date");

    $submitButton.click(function () {
        if (isModelValidate()) {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/SubmitReportAfterAddition",
                data: JSON.stringify(reportVM),
                contentType: 'application/json; charset=utf-8',
                dataType: 'html',
                success: function (result) {
                    alertAboutSuccessfullAddition(result);
                }
            });
        }
    });

    $saveAsDraftButton.click(function () {
        if (isModelValidate()) {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/AddReportAsDraftAfterAddition",
                data: JSON.stringify(reportVM),
                contentType: 'application/json; charset=utf-8',
                dataType: 'html',
                success: function (result) {
                    alertAboutSuccessfullAddition(result);
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
        var id = null;
        var mentorName = null;
        var internName = $internNameInput.val();
        var typeOccuring = $typeInput.val();
        var date = $dateInput.val();
        var activities = constructActivities();
        var futurePlans = constructFuturePlans();
        return new ReportVM(id, mentorName, internName, typeOccuring, date, activities, futurePlans);
    }

    function constructFuturePlans() {
        var futurePlans = [],
            indexer = 0;

        $(".input-future-plan").each(function () {
            var description = $(this).val();
            if (description != "") {
                var id = null;
                futurePlans[indexer] = new FuturePlanVM(id, description);
                indexer += 1;
            }
        });

        return futurePlans;
    }

    function constructActivities() {
        var activities = [],
            indexer = 0;

        $(".input-activity").each(function () {
            var description = $(this).val();
            if (description != "") {
                var id = null;
                var evaluation = null;
                var questions = constructQuestionsByInputActivity($(this));
                activities[indexer] = new ActivityVM(id, description, evaluation, questions);
                indexer += 1;
            }
        });

        return activities;
    }

    function constructQuestionsByInputActivity(inputActivity) {
        var questions = [],
            indexer = 0;

        $(inputActivity).parent().parent().parent().parent()
            .find(".input-question")
            .each(function () {
                var description = $(this).val();
                if (description != "") {
                    var id = null;
                    questions[indexer] = new QuestionVM(id, description);
                    indexer += 1;
                }
            })

        return questions;
    }
});