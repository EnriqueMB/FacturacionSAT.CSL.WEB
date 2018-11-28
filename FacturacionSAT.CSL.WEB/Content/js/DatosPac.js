var DatosPac = function () {
    "use strict";
    //Funcion para validad Nuevo CFDIDatosPac
    var runValidator1 = function () {
        var form1 = $('#form-DatosPac');
        var errorHandler1 = $('.errorHandler', form1);
        var successHandler1 = $('.successHandler', form1);

        $('#form-DatosPac').validate({
            errorElement: "span", // contain the error msg in a span tag
            errorClass: 'help-block color',
            errorLabelContainer: $("#validation_summary"),
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.attr("name") == "dd" || element.attr("name") == "mm" || element.attr("name") == "yyyy") {
                    error.insertAfter($(element).closest('.form-group').children('div'));
                } else if (element.attr("type") == "text") {
                    error.insertAfter($(element).closest('.input-group').children('div'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
            rules: {
                Descripcion: { required: true, descripcion: true },
                UserPac: { required: true, texto: true},
                PasswordPac: { required: true, minlength:3, maxlength:25},
                UserPacTest: { required: true },
                PasswordPacTest: { required: true, minlength: 3, maxlength:25}
            },
            messages: {
                Descripcion: { required: "El Campo Descripción es Requerido", descripcion: "El formato de Descripción no Cumple con los Parametros"},
                UserPac: { required: "El Campo UserPac es Requerido", texto:"Ingrese un UserPac valido" },
                PasswordPac: { required: "El Campo PasswordPac es Requerido", minlength: "El campo PasswordPac solo admite 3  caracteres como Mínimo", maxlength: "El campo PasswordPac solo admite 25  caracteres como Máximo" },
                UserPacTest: { required: "El Campo UserPacTest es Requerido", texto: "Ingrese un UserPacTest valido" },
                PasswordPacTest: { required: "El Campo PasswordPacTest es Requerido", minlength: "El campo PasswordPacTest solo admite 3  caracteres como Mínimo", maxlength: "El campo PasswordPacTest solo admite 25  caracteres como Máximo" }
            },
            invalidHandler: function (event, validator) { //display error alert on form submit
                successHandler1.hide();
                errorHandler1.show();
                //$("#validation_summary").text(validator.showErrors());
            },
            highlight: function (element) {
                $(element).closest('.help-block').removeClass('valid');
                // display OK icon
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error').find('.symbol').removeClass('ok').addClass('required');
                // add the Bootstrap error class to the control group
            },
            unhighlight: function (element) { // revert the change done by hightlight
                $(element).closest('.form-group').removeClass('has-error');
                // set error class to the control group
            },
            success: function (label, element) {
                label.addClass('help-block valid');
                label.removeClass('color');
                // mark the current input as valid and display OK icon
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success').find('.symbol').removeClass('required').addClass('ok');
            },
            submitHandler: function (form) {
                successHandler1.show();
                errorHandler1.hide();
                form.submit();
                //this.submit();
            }
        });       
    }
    var runPassword = function () {
      
            $('#show_password').hover(function show() {
                //Cambiar el atributo a texto
                $('#PasswordPac').attr('type', 'text');
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            },
                function () {
                    //Cambiar el atributo a contraseña
                    $('#PasswordPac').attr('type', 'password');
                    $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
                });

            $('#show_password1').hover(function show() {
                //Cambiar el atributo a texto
                $('#PasswordPacTest').attr('type', 'text');
                $('.icon1').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            },
                function () {
                    //Cambiar el atributo a contraseña
                    $('#PasswordPacTest').attr('type', 'password');
                    $('.icon1').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
                });       
    }

    return {
        init: function () {
            runValidator1();
            runPassword();
        }
    };
}();
