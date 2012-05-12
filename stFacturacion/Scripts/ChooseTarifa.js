$(function () {
    $('#tarifaDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 300,
        modal: true,
        title: 'Añadir Tarifa',
        buttons: {
            'Guardar': function () {
                var createTarifaForm = $('#createTarifaForm');
                if (createTarifaForm.valid()) {
                    $.post(createTarifaForm.attr('action'), createTarifaForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            // Add the new genre to the dropdown list and select it
                            $('#tarifaId').append(
                                    $('<option></option>')
                                        .val(data.Tarifa.tarifaId)
                                        .html(data.Tarifa.descripcion)                                      
                                        .prop('selected', true)  // Selects the new Genre in the DropDown LB
                                );
                            $('#tarifaDialog').dialog('close');
                        }
                    });
                }
            },
            'Cancelar': function () {
                $(this).dialog('close');
            }
        }
    });

    $('#tarifaAddLink').click(function () {
        var createFormUrl = $(this).attr('href');
        $('#tarifaDialog').html('')
        .load(createFormUrl, function () {
            // The createGenreForm is loaded on the fly using jQuery load. 
            // In order to have client validation working it is necessary to tell the 
            // jQuery.validator to parse the newly added content
            jQuery.validator.unobtrusive.parse('#createTarifaForm');
            $('#tarifaDialog').dialog('open');
        });

        return false;
    });
});	