var Auth = {

    resultMessage: null,

    init: function ()
    {
        $(".signUp").on("click", Auth.SignUp);
        $(".login").on("click", Auth.Login);
    },

    SignUp: function ()
    {
        let UserName = $('.SignUpPage .UserName').val();
        let Password = $('.SignUpPage .Password').val();
        $.post('SignUp', { UserName: UserName, Password: Password }, function (result) {

            if (result == "Success")
                Warning.SuccessWarning();
            else
                Warning.ErrorWarning();
            
        }, "json");
    },

    Login: function ()
    {
        let UserName = $('.LoginPage .UserName').val();
        let Password = $('.LoginPage .Password').val();
        $.post('Login', { UserName: UserName, Password: Password }, function (result) {

            if (result == "Success")
                Warning.SuccessWarning();
            else 
                Warning.ErrorWarning();
            
        }, "json");
    },
}
