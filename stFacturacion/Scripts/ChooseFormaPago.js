$(function () {
    $('#pagoDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 300,
        modal: true,
        title: 'Añadir Forma Pago',
        buttons: {
            'Guardar': function () {
                var createFormaPagoForm = $('#createFormaPagoForm');
                if (createFormaPagoForm.valid()) {
                    $.post(createFormaPagoForm.attr('action'), createFormaPagoForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            // Add the new genre to the dropdown list and select it
                            $('#formaPagoid').append(
                                    $('<option></option>')
                                        .val(data.FormaPago.formaPagoid)
                                        .html(data.FormaPago.descripcionformapago)
                                        .prop('selected', true)  // Selects the new Genre in the DropDown LB
                                );
                            $('#pagoDialog').dialog('close');
                        }
                    });
                }
            },
            'Cancelar': function () {
                $(this).dialog('close');
            }
        }
    });

    $('#pagoAddLink').click(function () {
        var createFormUrl = $(this).attr('href');
        $('#pagoDialog').html('')
        .load(createFormUrl, function () {
            // The createGenreForm is loaded on the fly using jQuery load. 
            // In order to have client validation working it is necessary to tell the 
            // jQuery.validator to parse the newly added content
            jQuery.validator.unobtrusive.parse('#createFormaPagoForm');
            $('#pagoDialog').dialog('open');
        });

        return false;
    });
});	