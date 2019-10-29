//Generic delete function
function deleteConfirm(entity, successCallback) {

    var modal = $('#genericDeleteModal');
    modal.find('.modal-body .entityType').html(entity);
    modal.modal('show')
    $('#confirmDeleteButton').bind('click', function () {
        var deleteTextInput = modal.find('#deleteConfirmText');
        if (deleteTextInput.val() === 'Delete') {
            modal.modal('hide');
            successCallback();
        }
    })
};
$('#genericDeleteModal').on('hide.bs.modal', function () {
    var modal = $(this);
    var deleteTextInput = modal.find('#deleteConfirmText');
    deleteTextInput.val('');
});

//Local delete button callback
$('#unsub').on('click', function () {



    var entity = $('#SelectedUser').val();
    deleteConfirm(entity, myRandomSuccessCallBackFunction)
});
//local success callback
function myRandomSuccessCallBackFunction() {
    alert('user deleted');
}