function lockAllFunctions() {
    setConditionReadonlyOnInputs(true);
    setConditionDisablingOnSelects(true);
    setConditionDisablingOnButtons(true);
}

function unlockAllFunctions() {
    setConditionReadonlyOnInputs(false);
    setConditionDisablingOnSelects(false);
    setConditionDisablingOnButtons(false);
}

function setConditionReadonlyOnInputs(value) {
    $("input").prop("disabled", value);
}

function setConditionDisablingOnSelects(value) {
    $("select").prop("disabled", value);
}

function setConditionDisablingOnButtons(value) {
    $(".btn").prop("disabled", value);
}