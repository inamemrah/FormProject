var Warning = {
    init: function()
    {

    },

    SuccessWarning: function () {
        $('#Panel_Warning').modal('show');
        $("#Panel_Warning .status .modal-title").html("SUCCESS");
        setTimeout(Warning.CloseWarning, 2000);
    },


    ErrorWarning: function () {
        $('#Panel_Warning').modal('show');
        $("#Panel_Warning .status .modal-title").html("ERROR");
        setTimeout(Warning.CloseWarning, 2000);
    },

    CloseWarning: function () {
        $('#Panel_Warning').modal('hide');
    }
}