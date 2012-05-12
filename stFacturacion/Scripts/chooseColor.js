$(function () {
    $('#colorDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 300,
        modal: true,
        title: 'Añadir Color',
        buttons: {
            'Guardar': function () {
                var createColorForm = $('#createColorForm');
                if (createColorForm.valid()) {
                    $.post(createColorForm.attr('action'), createColorForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            // Add the new genre to the dropdown list and select it
                            $('#colorId').append(
                                    $('<option></option>')
                                        .val(data.Color.colorId)
                                        .html(data.Color.descripcioncolor)
                                        .prop('selected', true)  // Selects the new Genre in the DropDown LB
                                );
                            $('#colorDialog').dialog('close');
                        }
                    });
                }
            },
            'Cancelar': function () {
                $(this).dialog('close');
            }
        }
    });

    $('#colorAddLink').click(function () {
        var createFormUrl = $(this).attr('href');
        $('#colorDialog').html('')
        .load(createFormUrl, function () {
            // The createGenreForm is loaded on the fly using jQuery load. 
            // In order to have client validation working it is necessary to tell the 
            // jQuery.validator to parse the newly added content
            jQuery.validator.unobtrusive.parse('#createColorForm');
            $('#colorDialog').dialog('open');
        });

        return false;
    });
});	