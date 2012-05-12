$(function () {
    $('#tallaDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 300,
        modal: true,
        title: 'Añadir Talla',
        buttons: {
            'Guardar': function () {
                var createTallaForm = $('#createTallaForm');
                if (createTallaForm.valid()) {
                    $.post(createTallaForm.attr('action'), createTallaForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            // Add the new genre to the dropdown list and select it
                            $('#tallaId').append(
                                    $('<option></option>')
                                        .val(data.Talla.tallaId)
                                        .html(data.Talla.descripciontalla)
                                        .prop('selected', true)  // Selects the new Genre in the DropDown LB
                                );
                            $('#tallaDialog').dialog('close');
                        }
                    });
                }
            },
            'Cancelar': function () {
                $(this).dialog('close');
            }
        }
    });

    $('#tallaAddLink').click(function () {
        var createFormUrl = $(this).attr('href');
        $('#tallaDialog').html('')
        .load(createFormUrl, function () {
            // The createGenreForm is loaded on the fly using jQuery load. 
            // In order to have client validation working it is necessary to tell the 
            // jQuery.validator to parse the newly added content
            jQuery.validator.unobtrusive.parse('#createTallaForm');
            $('#tallaDialog').dialog('open');
        });

        return false;
    });
});	