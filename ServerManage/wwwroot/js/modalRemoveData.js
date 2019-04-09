$(document).on('hidden.bs.modal', function (e) {
    $(e.target).removeData('bs.modal');
    if ($(e.target).attr('data-empty') === 'true') {
        $(".modal-content").empty();
    }
});