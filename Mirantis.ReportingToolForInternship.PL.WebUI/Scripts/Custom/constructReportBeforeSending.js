/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="constructors.js" />
/// <reference path="validationActivities.js" />
/// <reference path="validationMentorsActivities.js" />
/// <reference path="validationFuturePlans.js" />
/// <reference path="validationRecord.js" />

function constructRecordByJquery(obj) {
    if ($(obj) == undefined) {
        return null;
    }

    if ($(obj) == null) {
        return null;
    }

    if ($(obj).length == 0) {
        return null;
    }

    return $(obj).val();
}

function constructIdByInput(input, classOfWrapperWithId) {
    var $wrapperId = $(input).closest("div").find(classOfWrapperWithId);
    if ($wrapperId.length > 0) {
        return $wrapperId.val();
    }

    return null;
}

function constructReportVM() {
    var id = constructRecordByJquery($("#ReportId")),
        mentorsId = constructRecordByJquery($("#MentorsId")),
        internsId = constructRecordByJquery($("#InternsId")),
        typeOccuring = constructRecordByJquery($("#TypeOccuring")),
        date = constructRecordByJquery($("#Date")),
        activities = constructActivities(),
        futurePlans = constructFuturePlans();
    return new ReportVM(id, mentorsId, internsId, typeOccuring, date, activities, futurePlans);
}

function constructFuturePlans() {
    var futurePlans = [],
        indexer = 0;

    $(".input-future-plan").each(function () {
        var description = $(this).val();
        if (validationRecord(description)) {
            var id = constructIdByInput($(this), ".futurePlanId");;
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
        if (validationRecord(description)) {
            var id = constructIdByInput($(this), ".activityId");;
            var evaluation = constructEvaluationByInputActivity($(this));
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
            if (validationRecord(description)) {
                var id = constructIdByInput($(this), ".questionId");;
                questions[indexer] = new QuestionVM(id, description);
                indexer += 1;
            }
        })

    return questions;
}

function constructEvaluationByInputActivity(inputActivity) {
    var evaluation,
        indexer = 0;

    $(inputActivity).parent().parent().parent().parent()
        .find(".input-evaluation")
        .each(function () {
            evaluation = $(this).val();
        })

    if (!validationRecord(evaluation)) {
        return null;
    }

    return evaluation;
}