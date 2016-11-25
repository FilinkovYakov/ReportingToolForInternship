/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../bootstrap-select.min.js" />

$(document).ready(function () {
    var $typeOriginDrodown = $("#TypeOrigin"),
        $mentorsNameDropdown = $("#MentorName");

    $typeOriginDrodown.change(function () {
        if ($typeOriginDrodown.val() == "Intern's") {
            $mentorsNameDropdown.val("All");
            $mentorsNameDropdown.selectpicker("refresh");
            $mentorsNameDropdown.prop("disabled", true);
        } else {
            $mentorsNameDropdown.prop("disabled", false);
        }
    });
});