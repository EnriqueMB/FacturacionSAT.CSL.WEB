var DatosEmisor = function () {
    "use strict";
    // Funcion para validar registrar
    var runValidator1 = function () {
        var form1 = $('#form-Emisor');
        var errorHandler1 = $('.errorHandler', form1);
        var successHandler1 = $('.successHandler', form1);
        $.validator.addMethod("validarImagen", function () {
            console.log(document.getElementById("Imagen").value);
            if (document.getElementById("Imagen").value === '') {
                if ((document.getElementById("Imagen").value === ''))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }, 'Debe seleccionar una imagen.');

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
                Descripcion: { required: true, texto: true, maxlength: 300 },
                ImagenB: { required: true }
            },
            messages: {
                Descripcion: { required: "Ingrese el nombre del banco.", texto: "Ingrese un nombre del banco.", maxlength: "El nombre del banco admite máximo 300 caracteres." },
                ImagenB: { required: "Seleccione una imagen del banco." }

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
    };

    var runEvents = function () {
        $("#IDCFDITIpoPersona").on("change", function () {
            var IDTipoPersona = $("#IDCFDITIpoPersona").val();
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
        
    }
    return {
        //main function to initiate template pages
        init: function () {
            runValidator1();
            runEvents();
        }
    };
}();