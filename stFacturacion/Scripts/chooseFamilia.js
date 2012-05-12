$(function () {
    $('#familiaDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 300,
        modal: true,
        title: 'Añadir Familia',
        buttons: {
            'Guardar': function () {
                var createFamiliaForm = $('#createFamiliaForm');
                if (createFamiliaForm.valid()) {
                    $.post(createFamiliaForm.attr('action'), createFamiliaForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            // Add the new genre to the dropdown list and select it
                            $('#familiaId').append(
                                    $('<option></option>')
                                        .val(data.Familia.familiaId)
                                        .html(data.Familia.descripcionfamilia)
                                        .prop('selected', true)  // Selects the new Genre in the DropDown LB
                                );
                            $('#familiaDialog').dialog('close');
                        }
                    });
                }
            },
            'Cancelar': function () {
                $(this).dialog('close');
            }
        }
    });

    $('#familiaAddLink').click(function () {
        var createFormUrl = $(this).attr('href');
        $('#familiaDialog').html('')
        .load(createFormUrl, function () {
            // The createGenreForm is loaded on the fly using jQuery load. 
            // In order to have client validation working it is necessary to tell the 
            // jQuery.validator to parse the newly added content
            jQuery.validator.unobtrusive.parse('#createFamiliaForm');
            $('#familiaDialog').dialog('open');
        });

        return false;
    });
});	