var DatosEmisor = function () {
    "use strict";
    // Funcion para validar registrar
    var runValidator1 = function (Opcion) {
        if (Opcion == 1) {
            var form1 = $('#form-Emisor');
            var errorHandler1 = $('.errorHandler', form1);
            var successHandler1 = $('.successHandler', form1);
            $.validator.addMethod("validarImagen", function () {
                if (document.getElementById("filename1").value === '') {
                    if ((document.getElementById("filename1").value === ''))
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }, 'Debe seleccionar una imagen.');
            $.validator.addMethod("validarCER", function () {
                if (document.getElementById("filename2").value === '') {
                    if ((document.getElementById("filename2").value === ''))
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }, 'Debe seleccionar el archivo .CER.');
            $.validator.addMethod("validarKEY", function () {
                console.log(document.getElementById("filename3").value);
                if (document.getElementById("filename3").value === '') {
                    if ((document.getElementById("filename3").value === ''))
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }, 'Debe seleccionar el archivo .KEY.');
            $('#form-Emisor').validate({
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
                    IDCFDITIpoPersona: { required: true },
                    IDCFDIRegimenFiscalDetalle: { required: true },
                    RazonSocial: { required: true },
                    RFC: { required: true, rfc: true },
                    Correo: { required: true, email: true },
                    Password: { required: true, maxlength: 35 },
                    Direccion: { required: true, direccion: true, maxlength: 350 },
                    filename1: { validarImagen: true, ImagenRequerida: true },
                    filename2: { validarCER: true, imagenExtesionCERSat: true },
                    filename3: { validarKEY: true, imagenExtesionKEYSat: true },
                    PasswordArchivoKEY: { required: true, maxlength: 35 },
                    CodigoPostal: { required: true }
                },
                messages: {
                    IDCFDITIpoPersona: { required: "Seleccione un tipo de persona" },
                    IDCFDIRegimenFiscalDetalle: { required: "Seleccione un regimen fiscal" },
                    RazonSocial: { required: "Ingrese la razón social del emisor" },
                    RFC: { required: "Ingrese el RFC del emisor", rfc: "Revise el formato de RFC es incorrecto XAXX010101000 " },
                    Correo: { required: "Ingrese el correo del emisor", email: "Revise el formato de correo es incorrecto EJEMPLO@DOMINIO.COM" },
                    Password: { required: "Ingrese el password del correo", maxlength: "La password del correo solo admite máximo 35 caracteres." },
                    Direccion: { required: "Ingrese la dirección del emisor.", direccion: "Revise el formato de texto es incorrecto.", maxlength: "La dirección solo admite máximo 350 caracteres." },
                    filename1: { validarImagen: "Seleccione una imagen.", ImagenRequerida: "Imagen. Solo archivos con formato PNG, JPG, JPEG y BMP." },
                    filename2: { validarCER: "Debe seleccionar el archivo .CER.", imagenExtesionCERSat: "Seleccionar un archivo con extensión .CER" },
                    filename3: { validarKEY: "Debe seleccionar el archivo .KEY.", imagenExtesionKEYSat: "Seleccionar un archivo con extención .KEY" },
                    PasswordArchivoKEY: { required: "Ingrese el password del archivo .KEY", maxlength: "La password del archivo key solo admite máximo 35 caracteres." },
                    CodigoPostal: { required: "Ingrese el código postal del emisor" }
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
        else
        {
            var form1 = $('#form-Emisor');
            var errorHandler1 = $('.errorHandler', form1);
            var successHandler1 = $('.successHandler', form1);
            $('#form-Emisor').validate({
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
                    IDCFDITIpoPersona: { required: true },
                    IDCFDIRegimenFiscalDetalle: { required: true },
                    RazonSocial: { required: true },
                    RFC: { required: true, rfc: true },
                    Correo: { required: true, email: true },
                    Password: { required: true, maxlength: 35 },
                    Direccion: { required: true, direccion: true, maxlength: 350 },
                    CodigoPostal: { required: true }
                },
                messages: {
                    IDCFDITIpoPersona: { required: "Seleccione un tipo de persona" },
                    IDCFDIRegimenFiscalDetalle: { required: "Seleccione un regimen fiscal" },
                    RazonSocial: { required: "Ingrese la razón social del emisor" },
                    RFC: { required: "Ingrese el RFC del emisor", rfc: "Revise el formato de RFC es incorrecto XAXX010101000 " },
                    Correo: { required: "Ingrese el correo del emisor", email: "Revise el formato de correo es incorrecto EJEMPLO@DOMINIO.COM" },
                    Password: { required: "Ingrese el password del correo", maxlength: "La password del correo solo admite máximo 35 caracteres." },
                    Direccion: { required: "Ingrese la dirección del emisor.", direccion: "Revise el formato de texto es incorrecto.", maxlength: "La dirección solo admite máximo 350 caracteres." },
                    CodigoPostal: { required: "Ingrese el código postal del emisor" }
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
    };

    var runEvents = function () {
        $("#IDCFDITipoPersona").on("change", function () {
            var IDTipoPersona = $("#IDCFDITipoPersona").val();
            GetRegimenFiscalX(IDTipoPersona);
        });
    }
    function GetRegimenFiscalX(IDTipoPersona) {
        $.ajax({
            url: "/Admin/CFDIDatosEmisor/ObtenerRegimenFiscalPersona/",
            data: { IDTipoPersona: IDTipoPersona },
            async: false,
            dataType: "json",
            type: "POST",
            error: function () {
                Mensaje("Ocurrió un error al cargar el combo", "1");
            },
            success: function (result) {
                $("#IDCFDIRegimenFiscalDetalle option").remove();
                for (var i = 0; i < result.length; i++) {
                    $("#IDCFDIRegimenFiscalDetalle").append('<option value="' + result[i].IDCFDIRegimenFiscalDetalle + '">' + result[i].C_RegimenFiscal + '</option>');
                }
                $('#IDCFDIRegimenFiscalDetalle.select').selectpicker('refresh');
            }
        });
    }

    var runPaswword = function () {
        $('#show_password').hover(function show() {
            //Cambiar el atributo a texto
            $('#Password').attr('type', 'text');
            $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
        },
            function () {
                //Cambiar el atributo a contraseña
                $('#Password').attr('type', 'password');
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
            });
        $('#show_password1').hover(function show() {
            //Cambiar el atributo a texto
            $('#PasswordArchivoKEY').attr('type', 'text');
            $('.icon1').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
        },
            function () {
                //Cambiar el atributo a contraseña
                $('#PasswordArchivoKEY').attr('type', 'password');
                $('.icon1').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
            });
    }
    return {
        //main function to initiate template pages
        init: function (Opcion) {
            runValidator1(Opcion);
            runPaswword();
            runEvents();
        }
    };
}();