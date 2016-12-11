/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="constructors.js" />
/// <reference path="constructReportBeforeSending.js" />

var isInputChanged = false;

$("a").click(function (event) {
    if (IsHideMessageAboutSuccessOperation() && isInputChanged) {
        event.preventDefault();
        var targetLink = event.target.href;
        $("#MessageAboutUpload").modal("show");
        $("#ConfirmRedirect").click(function () {
            window.location.href = targetLink;
        })
    }
});

$("input").change(function () {
    isInputChanged = true;
});

//function isModelContainSomethingElements() {
//    var isContain = false;
//    $(".input-activity").each(function () {
//        if ($(this).val() != "") {
//             isContain = true;
//        }
//    });

//    if (!isContain) {
//        $(".input-evaluation").each(function () {
//            if ($(this).val() != "") {
//                isContain = true;
//            }
//        });
//    }

//    if (!isContain) {
//        $(".input-question").each(function () {
//            if ($(this).val() != "") {
//                isContain = true;
//            }
//        });
//    }

//    if (!isContain) {
//        $(".input-future-plan").each(function () {
//            if ($(this).val() != "") {
//                isContain = true;
//            }
//        });
//    }

//    return isContain;
//}

function IsHideMessageAboutSuccessOperation() {
    var innerHtml = $("#MessageAboutSuccessOperation").html().trim();
    return innerHtml == "";
}