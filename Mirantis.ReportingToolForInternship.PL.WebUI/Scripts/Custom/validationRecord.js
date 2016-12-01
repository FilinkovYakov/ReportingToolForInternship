/// <reference path="../jquery-1.10.2.min.js" />

function validationRecord(record) {
    if (record == undefined) {
        return false;
    }

    if (record == null) {
        return false;
    }

    if ($.trim(record) == "") {
        return false;
    }

    return true;
}