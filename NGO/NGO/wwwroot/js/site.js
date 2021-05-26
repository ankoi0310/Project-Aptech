removeSorting = () => {
    $('th:last-child').removeAttr("class");
}

showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            removeSorting();
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal("show");
        }
    })
}

jQueryAjaxPost = (form) => {
    //$('#editor').html() == "<p><br data-cke-filler=\"true\"></p>" ? $('#Content').val(null) : $('#Content').val($('#editor').html());
    removeSorting();
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#view-all").html(res.html);
                    setInterval('location.reload()', 100);
                    $("#form-modal").modal('hide');
                    $("#form-modal .modal-body").html('');
                    $("#form-modal .modal-title").html('');
                    alert("Submitted Succesfully");
                } else {
                    $("#form-modal .modal-body").html(res.html);
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    } catch (e) {
        console.log(e);
    }

    return false;
}

jQueryAjaxDelete = form => {
    removeSorting();
    if (confirm("Are you sure to delete this record?")) {
        try {
            $.ajax({
                type: "POST",
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $("#view-all").html(res.html);
                    setInterval('location.reload()', 100);
                    $.notify("Deleted successfully", { globalPosition: "top center", className: "success" });
                },
                error: function (err) {
                    console.log(err);
                }
            })
        } catch (e) {
            console.log(e);
        }
    }

    return false;
}