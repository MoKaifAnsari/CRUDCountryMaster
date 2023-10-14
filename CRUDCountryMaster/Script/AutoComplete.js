function AutoComplete(ID, Type) {
    $("#" + ID).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/AutoComplete/Index",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term, Type: Type },
                success: function (data) {
                    response(data);
                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    });
}