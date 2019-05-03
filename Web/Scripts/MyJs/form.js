var Form = {

    formDetail: null,

    init: function ()
    {
        $(".detail").on("click", Form.getFormDetail);
        $(".newForm").on("click", Form.newForm);
    },

    getFormDetail: function ()
    {
        let id = $(this).val();

        $.post('formDetail', { id: id }, function (data) {
            Form.formDetail = data;
        }, "json").done(Form.fillFormDetail);
    },


    fillFormDetail: function ()
    {
        $(".FormPage .Name").val(Form.formDetail.Name);
        $(".FormPage .Description").val(Form.formDetail.Description);
        $(".FormPage .FirstName").val(Form.formDetail.FirstName);
        $(".FormPage .LastName").val(Form.formDetail.LastName);
        $(".FormPage .Age").val(Form.formDetail.Age);
        $(".FormPage .Create").css("display", "none");
    },

    newForm: function ()
    {
        Form.clearForm();
    },

    clearForm: function ()
    {
        $(".FormPage .Name").val("");
        $(".FormPage .Description").val("");
        $(".FormPage .FirstName").val("");
        $(".FormPage .LastName").val("");
        $(".FormPage .Age").val("");
        $(".FormPage .Create").css("display", "block");
    }

}
