$(document).ready(function () {
    ShowCountryMaster();

    $("#Save").click(function () {
        InsertUpdateCountryMaster();
        ShowCountryMaster();

        $('#MyForm')[0].reset();

        // DeleteCountryMaster(ID)
        return false;
    });
    $("#Export").click(function () {
        ExportToExcel();
    });
    $("#btnSearch").click(function () {
        ShowCountryMaster();
        return false;
    });

});

function ExportToExcel() {
    $.post("/Master/ExportToExcel");
}

function ClearData() {
    $("#hfCountryID").val("0");
    $("#ddlSearchColumn").val($("#ddlSearchColumn option:first").val());
    $("#ddlStart").val($("#ddlStart option:first").val());
    $("#txtSearch").val("");
    ShowCountryMaster();
}

function InsertUpdateCountryMaster() {
    try {
        $.post("/Master/InsertUpdateCountryMaster", {
            CountryID: $("#hfID").val(),
            CountryCode: $("#txtCountryCode").val(),
            CountryName: $("#txtCountryName").val(),
            IsActive: $("#IsActive").is(":checked"),
            StateRequired: $("#StateRequired").is(":checked"),
            PincodeRequired: $("#PincodeRquired").is(":checked")
        }, function (data) {
            if (data.Message != "") {
                alert(data.Message);
                ClearData();
            }
        });

    } catch (e) {
        alert("Error in InsertUpdateCountryMaster: " + e.message)
    }
}
function ShowCountryMaster() {
    try {
        $.post("/Master/ShowCountryMaster", {
            SearchColumn: $("#ddlSearchColumn").val(),
            StartValue: $("#ddlStart").val(),
            SearchValue: $("#txtSearch").val()
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

function DeleteCountryMaster(ID) {
    try {
        // if (alert("Do You want to Delete")) {


        $.post("/Master/DeleteCountryMaster",
            { ID: ID },

            function (data) {
                alert(data.Message);
                ShowCountryMaster();
            },
        );
        //  };

    }
    catch (e) {
        alert("Error in ShowDeleteMaster: " + e.message)
    }
}

function EditMaster(ID) {
    try {
        $.post("/Master/EditMaster",
            { ID: ID },
            function (data) {
                if (data.Message != "") {
                    alert(data.Message);
                }

                if (data.Status == "1") {
                    $("#hfID").val(data.CountryID);
                    //$("#txtCountryCode").attr('readonly', true);
                    $("#txtCountryCode").prop("disabled", true);
                    $("#txtCountryCode").attr("required", false);
                    $("#txtCountryCode").val(data.CountryCode);
                    $("#txtCountryName").val(data.CountryName);

                    if (data.IsActive == "YES") {           //IsActive name is according to the database
                        $("#IsActive").prop("checked", true)
                    }
                    else {
                        $("#IsActive").prop("checked", false)
                    }
                    if (data.State == "YES") {      //State name is according to the database
                        $("#StateRequired").prop("checked", true)
                    }
                    else {
                        $("#StateRequired").prop("checked", false)
                    }
                    if (data.Pincode == "YES") {                //Pincode name is according to the database
                        $("#PincodeRequired").prop("checked", true)
                    }
                    else {
                        $("#PincodeRequired").prop("checked", false)
                    }

                }
            });
    } catch (e) {
        alert("Error in ShowCountryMaster: " + e.message)
    }
}



