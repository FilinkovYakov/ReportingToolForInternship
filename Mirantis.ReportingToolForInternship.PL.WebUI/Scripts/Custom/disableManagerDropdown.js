/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../bootstrap-select.min.js" />

$(document).ready(function () {
    var $typeOriginDrodown = $("#TypeOrigin"),
        $managerIdDropdown = $("#ManagerId");

    $typeOriginDrodown.change(function () {
		if ($typeOriginDrodown.val() === "Engineer's") {
			$managerIdDropdown.val("");
			$managerIdDropdown.selectpicker("refresh");
			$managerIdDropdown.prop("disabled", true);
        } else {
			$managerIdDropdown.prop("disabled", false);
        }
    });
});