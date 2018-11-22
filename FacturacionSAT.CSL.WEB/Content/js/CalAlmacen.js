var CatAlmacen = function () {
    "use strict";
    // Funcion para validar registrar
    var runValidator1 = function () {
        var form1 = $('#form-catalm');
        var errorHandler1 = $('.errorHandler', form1);
        var successHandler1 = $('.successHandler', form1);
       
        $('#form-catalm').validate({
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
                
                IDSucursal: { required: true },
                
                ClaveAlmacen: { required: true },
              
                Descripcion: { required: true },
                nombre: { required: true },
              
                //NombreRazonSocial: { required: true, texto: true, maxlength: 300 },
                //IDRegimenFiscal: { required: true },
                //RFC: { required: true, rfc: true },
                //Direccion: { direccion: true, maxlength: 300 },
                //FechaIngreso: { required: true },
                //NombreResponsable: { nombre: true, maxlength: 300 }, //{ nombre: true, maxlenght: 300 },
                //Celular: { telefono: true },
                //Telefono: { telefono: true },
                //CorreoElectronico: { required: true, email: true }

            },
            messages: {
                
                IDSucursal: { required: "Seleccione una sucursal." },
                
                ClaveAlmacen: { required: "Ingrese la clave del almacén" },
                Descripcion: { required: "Ingrese una descripción del almacén" },
                nombre: { required: "Ingrese un nombre del almacén" },
                
                //NombreRazonSocial: { required: "Ingrese el nombre o Razón social.", texto: "Ingrese un nombre o razón social válido.", maxlength: "El campo nombre o razón social admite máximo 300 caracteres." },
                //IDRegimenFiscal: { required: "Seleccione un régimen fiscal." },
                //RFC: { required: "Ingrese el RFC del cliente.", rfc: "Ingrese un RFC válido." },
                //Direccion: { direccion: "Ingrese un dirección válida.", maxlength: "El campo domicilio fiscal admite máximo 300 caracteres." },
                //FechaIngreso: { required: "Ingrese la fecha de inicio de relación." },
                //NombreResponsable: { nombre: "Ingrese un nombre de contacto válido.", maxlength: "El campo nombre de contacto admite máximo 300 caracteres." }, // { nombre: "Ingrese un nombre de contacto válido." , maxlenght:   }
                //Celular: { telefono: "Ingrese un número de celular válido." },
                //Telefono: { telefono: "Ingrese un número de teléfono válido." },
                //CorreoElectronico: { required: "Ingrese el correo electrónico del cliente.", email: "Ingrese un correo electrónico válido." }
            },
            invalidHandler: function (event, validator) { //display error alert on form submit
                successHandler1.hide();
                errorHandler1.show();
                //$("#validation_summary").text(validator.showErrors());
            },
            highlight: function (element) {
                $(element).closest('.help-block').removeClass('valid');
                // display OK icon
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error').find('.form-control-feedback').removeClass('glyphicon-ok').addClass('glyphicon-remove');
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
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success').find('.form-control-feedback').removeClass('glyphicon-remove').addClass('glyphicon-ok');
            },
            submitHandler: function (form) {
                successHandler1.show();
                errorHandler1.hide();
                form.submit();
                //this.submit();
            }
        });
    };

    var runElements = function () {
        $('#Fecha').datepicker({
            format: 'dd/mm/yyyy'
        });        
        //$('.bootstrap-select-searchbox').append("<span class='glyphicon form-control-feedback'></span>");
        //$('.bootstrap-select-searchbox').focusout(function () {
        //    console.log($(this).closest('.form-group').find('select'));
        //    console.log($('#IDSucursal'));
        //    $(this).closest('.form-group').find('select').trigger("focusout");
        //})
    };

    var runCombos = function () {

        $('#IDSucursal').on('change', function (event) {
            $("#IDVehiculo option").remove();
            var IdSucursal = $(this).val();
            getCatVehiculos(IdSucursal);
            //$(this).trigger("focusout");
        });
        function getCatVehiculos(IdSucursal) {
            $.ajax({
                url: "/Admin/EntregaCombustible/ObtenerComboVehiculos",
                data: { IDSucursal: IdSucursal },
                async: false,
                dataType: "json",
                type: "POST",
                error: function () {
                    Mensaje("Ocurrió un error al cargar el combo", "2");
                },
                success: function (result) {
                    for (var i = 0; i < result.length; i++) {
                        $("#IDVehiculo").append('<option value="' + result[i].IDVehiculo + '">' + result[i].Modelo + '</option>');
                    }
                    $('#IDVehiculo.select').selectpicker('refresh');
                }
            });
        }
    };

    var runFileInput = function () {
        
        //console.log(band);
        //if (!band)
        //{
        //console.log("IF");
        //    $('#UrlImagen64').fileinput({
        //        theme: 'fa',
        //        language: 'es',
        //        showUpload: false,
        //        uploadUrl: "#",
        //        showUploadedThumbs: false,
        //        overwriteInitial: false,
        //        maxFileCount: 1,
        //        allowedFileExtensions: ["png"],
        //        required: true
        //    })
        //}
        //else
        //{
        //console.log("else");
        //    $('#UrlImagen64').fileinput({
        //        theme: 'fa',
        //        language: 'es',
        //        showRemove: false,
        //        showClose: false,
        //        showUpload: false,
        //        uploadUrl: "#",
        //        autoReplace: true,
        //        overwriteInitial: true,
        //        showUploadedThumbs: false,
        //        maxFileCount: 1,
        //        initialPreview: [
        //            '<img class="file-preview-image" style="width: auto; height: auto; max-width: 100%; max-height: 100%;" src="data:image/png;base64,' + ImgTicket + '" />'
        //        ],
        //        initialPreviewConfig: [
        //            { caption: 'Ticket de combustible' }
        //        ],
        //        initialPreviewShowDelete: false,
        //        showRemove: false,
        //        showClose: false,
        //        layoutTemplates: { actionDelete: '' },
        //        allowedFileExtensions: ["png"],
        //        required: true
        //    })
        //}
        
    };

    return {
        //main function to initiate template pages
        init: function (band, img64 ) {
            runValidator1();
            runElements();
            runCombos();
            runFileInput();
        }
    };
}();