var ConceptoDatos = function () {
    "use strict";
    //Funcion para validar nuevo dato concepto
    var runValidator1 = function () {
        var form1 = $('#form-dg');
        var errorHandler1 = $('.errorHandler', form1);
        var successHandler1 = $('.successHandler', form1);

        $('#form-dg').validate({
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
                "CFDI_Claveproducto.Descripcion": { required: true },
                "CFDI_ClaveUnidad.Nombre": { required: true },
                "CFDI_TipoProducto.TipoProducto": { required: true },
                "CFDI_ClaveDivision.Division": { required: true },
                "CFDI_Grupo.Grupo": {required: true},
                "CFDI_Clase.clase": {required: true},
                "Descripcion": {required:true}
               
            },
            messages: {
                "CFDI_Claveproducto.Descripcion": { required: "El Campo Clave Producto es Requerido"},
                "CFDI_ClaveUnidad.Nombre": { required: "El Campo Clave unidad es requerido"},
                "CFDI_TipoProducto.TipoProducto": { required: "El Campo Tipo producto" },
                "CFDI_ClaveDivision.Division": { required: "El Campo CFDI División es requerido " },
                "CFDI_Grupo.Grupo": { required: "El Campo CFDI Grupo es requerido" },
                "CFDI_Clase.clase": { required: "El Campo CFDI Clase es requerido" },
                "Descripcion": { required: "El Campo Descripción es requerido" }
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
    

    return {
        init: function () {
            runValidator1();
           
        }
    };
}();
