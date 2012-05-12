$(function () {
    $('#ivaDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 300,
        modal: true,
        title: 'Añadir tipo de IVA',
        buttons: {
            'Guardar': function () {
                var createIvaForm = $('#createIvaForm');
                if (createIvaForm.valid()) {
                    $.post(createIvaForm.attr('action'), createIvaForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            // Add the new genre to the dropdown list and select it
                            $('#tipoivaId').append(
                                    $('<option></option>')
                                        .val(data.TipoIva.tipoivaId)
                                        .html(data.TipoIva.descripcion,
                                        data.TipoIva.porcentaje)
                                        .prop('selected', true)  // Selects the new Genre in the DropDown LB
                                );
                            $('#ivaDialog').dialog('close');
                        }
                    });
                }
            },
            'Cancelar': function () {
                $(this).dialog('close');
            }
        }
    });

    $('#ivaAddLink').click(function () {
        var createFormUrl = $(this).attr('href');
        $('#ivaDialog').html('')
        .load(createFormUrl, function () {
            // The createGenreForm is loaded on the fly using jQuery load. 
            // In order to have client validation working it is necessary to tell the 
            // jQuery.validator to parse the newly added content
            jQuery.validator.unobtrusive.parse('#createIvaForm');
            $('#ivaDialog').dialog('open');
        });

        return false;
    });
});	