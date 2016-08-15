
var category = function() {
    var getCategory = function() {
        var model = {
            pageIndex: pageSetting.page,
            pageSize: pageSetting.pageSize,
        };
        return $.ajax({
            url: '/categorys/GetCategorys',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };

    var insertCategory = function(model) {
        return $.ajax({
            url: '/categorys/AddCategory',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };
    
    var updateCategory = function (model) {
        return $.ajax({
            url: '/categorys/UpdateCategory',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };

    var deleteCategory = function (model) {
        return $.ajax({
            url: '/categorys/DeleteCategory',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };

    return {
        getCategory: function () {
            return getCategory();
        },
        insertCategory: function (model) {
            return insertCategory(model);
        },
        updateCategory: function (model) {
            return updateCategory(model);
        },
        deleteCategory: function (model) {
            return deleteCategory(model);
        },
    };
}(category);

function bindingCategory() {
    var binding = category.getCategory();
    $.when(binding).then(function (result) {
        if (result.isSuccess) {
            $('#category_Div').html('');
            callBackController.renderPaging(result.data.PageIndex, result.data.ItemCount);
            $('#categoryTemplate').tmpl(result.data).appendTo('#category_Div');
        }
    });
}

function bindingCategoryFrom(obj) {
    var rowId = $(obj).attr("data-id");
    $('#category-form .category-name').val($("#" + rowId + " .categorty").text());
    $('#category-form .category-detail').val($("#" + rowId + " .detail").text());
    $("#category-form #category-id").val(rowId);
}

function deleteCategory(obj) {
    var rowId = $(obj).attr("data-id");
    var model = {
        categoryId: rowId
    };
    var deleteCate = category.deleteCategory(model);
    $.when(deleteCate).then(function (result) {
        bindingCategory();
    });
}

$(document).on('click', '#save', function (event) {
    var model = {
        CategoryId: parseInt($("#category-form #category-id").val()),
        CategoryName: $('#category-form .category-name').val(),
        CategoryDetail: $('#category-form .category-detail').val(),
    };
    if (model.CategoryId == 0 || isNaN(model.CategoryId)) {
        var insert = category.insertCategory(model);
        $.when(insert).then(function (result) {
            if (result.isSuccess) {
                bindingCategory();
            }
        });
    } else {
        var update = category.updateCategory(model);
        $.when(update).then(function (result) {
            if (result.isSuccess) {
                bindingCategory();
            }
        });
    }
    $('#add-new-category').modal('hide');
});


$(document).on('click', '.category-box', function (event) {
    $('#category-form .category-name').val('');
    $('#category-form .category-detail').val('');
    $("#category-form #category-id").val('');
});

$(document).ready(function () {
    window.callback = bindingCategory();
});

