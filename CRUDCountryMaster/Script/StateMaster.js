$(document).ready(function () {
    ShowStateMaster();
    $("#btnSave").click(function () {
        InsertUpdateStateMaster();
        ShowStateMaster();
    });
    $("#btnExportState").click(function () {
        StateMaster();
    });

});
function StateMaster() {
    $.post("/Master/StateExportToExcel")
}
function InsertUpdateStateMaster() {
    try {
        $.post("/Master/InsertUpdateStateMaster", {
            StateId: $("#hstID").val(),
            Country: $("#txtCountry").val().trim().split(":"),
            StateCode: $("#txtStateCode").val().trim(),
            StateName: $("#txtStateName").val().trim(),
            IsActive: $("#IsActive").is(":checked")
        }, function (data) {
            if (data.Status == 1 || data.Status == 2) {
                alert(data.Message);
                ShowStateMaster();
                ClearData();
            }
            else {
                alert(data.Message);
            }
            if (data.Focus != "") {
                $("#" + data.Focus).focus();
            }
        });
    }
    catch (e) {
        alert("Error in InsertUpdateStateMaster: " + e.message)
    }
}
function ShowStateMaster() {
    try {
        $.post("/Master/ShowStateMaster", {
        },
            function (data) {
                if (data.Message != "") {
                    alert(data.Message);
                }
                if (data.Grid != "") {
                    $("#dvGrid").html(data.Grid);
                }
            });
    } catch (e) {
        alert("Error in ShowStateMaster: " + e.message)
    }
}
function DeleteStateMaster(StateID) {
    try {
        $.post("/Master/DeleteStateMaster",
            { StateID: StateID },
            function (data) {
                alert(data.Message);
                ShowStateMaster();
            },
        );
    }
    catch (e) {
        alert("Error in ShowStateMaster: " + e.message)
    }
}
function EditStateMaster(StateId) {
    try {
        $.post("/Master/EditStateMaster",
            { StateId: StateId },
            function (data) {
                if (data.Message != "") {
                    alert(data.Message);
                }
                if (data.Status == "1") {
                    $("#hstID").val(data.StateId);
                    $("#txtCountry").val(data.Country);
                    $("#txtStateCode").val(data.StateCode);
                    $("#txtStateName").val(data.StateName);

                    if (data.IsActive == "YES") {           //IsActive name is according to the database
                        $("#IsActive").prop("checked", true)
                    }
                    else {
                        $("#IsActive").prop("checked", false)
                    }
                }
            });
    } catch (e) {
        alert("Error in ShowStateMaster: " + e.message)
    }
}
function ClearData() {
    $("#hstID").val("0");
    $("#txtCountry").val("");
    $("#txtStateCode").val("");
    $("#txtStateName").val("");
    $("#IsActive").prop("checked", false);
}