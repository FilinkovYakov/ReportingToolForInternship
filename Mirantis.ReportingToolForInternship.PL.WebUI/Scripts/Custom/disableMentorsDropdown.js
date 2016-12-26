/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../bootstrap-select.min.js" />

$(document).ready(function () {
    var $typeOriginDrodown = $("#TypeOrigin"),
        $mentorsIdDropdown = $("#MentorsId");

    $typeOriginDrodown.change(function () {
        if ($typeOriginDrodown.val() == "Intern's") {
            $mentorsIdDropdown.val("");
            $mentorsIdDropdown.selectpicker("refresh");
            $mentorsIdDropdown.prop("disabled", true);
        } else {
            $mentorsIdDropdown.prop("disabled", false);
        }
    });
});