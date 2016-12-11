/// <reference path="../jquery-1.10.2.min.js" />

function lockAllFunctions() {
    setConditionReadonlyOnInputs(true);
    setConditionDisablingOnSelects(true);
    setConditionDisablingOnButtons(true);
}

unlockAllFunctions();

function unlockAllFunctions() {
    setConditionReadonlyOnInputs(false);
    setConditionDisablingOnSelects(false);
    setConditionDisablingOnButtons(false);
}

function setConditionReadonlyOnInputs(value) {
    var $inputs = $("input");
    $inputs.prop("disabled", value);

    if (value) {
        $inputs.addClass("input-grey");
    } else {
        $inputs.removeClass("input-grey");
    }
}

function setConditionDisablingOnSelects(value) {
    $("select").prop("disabled", value);
}

function setConditionDisablingOnButtons(value) {
    var $buttons = $(".btn");
    $buttons.prop("disabled", value);

    if (value) {
        $buttons.removeClass("btn-default");
        $buttons.addClass("btn-grey");
    } else {
        $buttons.removeClass("btn-grey");
        $buttons.addClass("btn-default");
    }
}