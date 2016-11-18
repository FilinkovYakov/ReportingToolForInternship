/// <reference path="../jquery-1.10.2.min.js" />

$(function () {
    var $submitButton = $("#SubmitButton"),
        $saveAsDraft = $("#SaveAsDraftButton"),
        $mentorNameInput = $("#MentorName"),
        $internNameInput = $("#InternName"),
        $messageStatusReport = $("#MessageAboutStatusReport"),
        $typeInput = $("#Type"),
        $dateInput = $("#Date");

    $(document).ready(function () {
        $submitButton.bind("click", function () {
            $mentorNameInput.valid();
            $internNameInput.valid();
            $typeInput.valid();
            $dateInput.valid();
        });

        $saveAsDraft.bind("click", function () {
            $mentorNameInput.valid();
            $internNameInput.valid();
            $typeInput.valid();
            $dateInput.valid();
        });

        $submitButton.click(function () {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/SubmitReport",
                data: JSON.stringify(reportVM),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    $messageStatusReport.html(data.message.toString())
                        .hide()
                        .slideToggle(1000)
                        .delay(2000)
                        .slideToggle(1000);
                }
            });
        });

        $saveAsDraft.click(function () {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/AddReportAsDraft",
                data: JSON.stringify(reportVM),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    $messageStatusReport.html(data.message.toString())
                        .hide()
                        .slideToggle(1000)
                        .delay(2000)
                        .slideToggle(1000);
                }
            })
        });
    })

    function ReportVM(mentorName, internName, type, date, activities, futurePlans) {
        this.MentorName = mentorName;
        this.InternName = internName;
        this.Type = type;
        this.Date = date;
        this.Activities = activities;
        this.FuturePlans = futurePlans;
    }

    function FuturePlanVM(description) {
        this.Description = description;
    }

    function ActivityVM(description, questions) {
        this.Description = description;
        this.Questions = questions;
    }

    function QuestionVM(description) {
        this.Description = description;
    }

    function constructReportVM() {
        var mentorName = $mentorNameInput.val();
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
            var questions = constructQuestionsByInputActivity($(this));
            activities[index] = new ActivityVM(description, questions);
        });

        return activities;
    }

    function constructQuestionsByInputActivity(inputActivity) {
        var questions = [];
        $(inputActivity).parent().parent()
            .find(".input-question")
            .each(function (index) {
                var description = $(this).val();
                questions[index] = new QuestionVM(description);
            })

        return questions;
    }
});