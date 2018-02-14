function notifyMsg(title, msg, type) {
    var notify = $.notify({
        // options
        icon: 'glyphicon glyphicon-' + type + '-sign',
        title: title,
        message: msg,
        target: '_blank'
    }, {
            // settings
            element: 'body',
            position: null,
            type: type,
            allow_dismiss: true,
            newest_on_top: true,
            showProgressbar: false,
            placement: {
                from: "top",
                align: "center"
            },
            offset: 20,
            spacing: 10,
            z_index: 1031,
            delay: 5000,
            timer: 1000,
            url_target: '_blank'
        });

    return notify;
}