var author = function() {
    var getAuthor = function() {
        var model = {
            pageIndex: pageSetting.page,
            pageSize: pageSetting.pageSize,
        };
        return $.ajax({
            url: '/author/getauthors',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };

    var insertAuthor = function(form) {
        var formData = new FormData(form[0]);
        return $.ajax({
            url: '/author/insert',
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            type: 'POST',
        });
    };

    var updateAuthor = function(form) {
        var formData = new FormData(form[0]);
        return $.ajax({
            url: '/author/update',
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            type: 'POST',
        });
    };

    return {
        getAuthor: function() {
            return getAuthor();
        },
        insertAuthor: function(form) {
            return insertAuthor(form);
        },
        updateAuthor: function(form) {
            return updateAuthor(form);
        },
    };
}(author);

function bindingAuthor() {
    var binding = category.getCategory();
    $.when(binding).then(function (result) {
        if (result.isSuccess) {
            $('#author-div').html('');
            callBackController.renderPaging(result.data.PageIndex, result.data.ItemCount);
            $('#authorTemplate').tmpl(result.data).appendTo('#author-div');
        }
    });
}

function bindingAuthorFrom(obj) {
    var rowId = $(obj).attr("data-id");
    $('#author-form .author_name').val($("#" + rowId + " .author_name").text());
    $('#author-form .author-id').val(rowId);
    $('#author-form .author-content').html($("#" + rowId + " .author-detail").html());
    var fileType = $("#" + rowId + " .author_name").attr('data-filetype');
    var file = $("#" + rowId + " .author_name").attr('data-file');
    document.getElementById("image-photo").src = "data:image/" + fileType + ";base64," + file;
}

$(document).on('click', '#save', function (event) {
    var form = $('#author-form');
    $('#author-form .content').val($('#author-form .author-content').code().replace(/^\s+|\s+$/g, ""));
    if (model.CategoryId == 0) {
        var insert = author.insertAuthor(form);
        $.when(insert).then(function (result) {
            if (result.isSuccess) {
                bindingAuthor();
            }
        });
    } else {
        var update = author.updateAuthor(model);
        $.when(update).then(function (result) {
            if (result.isSuccess) {
                bindingAuthor();
            }
        });
    }
    $('#add-new-category').modal('hide');
});

$(document).on('click', '.author-type-box', function (event) {
    $('#author-form .author_name').val('');
    $('#author-form .author-id').val('');
    $('#author-form .author-content').html('');
    $('#author-form #image-photo').attr('src', '');
});

$(document).ready(function () {
    window.callback = bindingAuthor();
});