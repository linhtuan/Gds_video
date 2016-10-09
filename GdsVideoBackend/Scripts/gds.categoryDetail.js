var categoryDetail = function() {

    var getCategoryDetails = function() {
        var model = {
            //pageIndex: pageSetting.page,
            //pageSize: pageSetting.pageSize,
            categoryTypeId: parseInt(gds.getQueryVariable('categoryTypeId')),
        };
        return $.ajax({
            url: '/CategoryDetail/GetCategoryGroup',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };

    var insertCategoryDetail = function(model) {
        return $.ajax({
            url: '/CategoryDetail/Insert',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: model
        });
    };

    var updateCategoryDetail = function(model) {
        return $.ajax({
            url: '/CategoryDetail/Update',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };

    var deleteCategoryDetail = function(model) {
        return $.ajax({
            url: '/CategoryDetail/Delete',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };

    var insertCategoryGroup = function (model) {
        return $.ajax({
            url: '/CategoryDetail/InsertCategoryGroup',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(model)
        });
    };

    var updateCategoryGroup = function (model) {
        return $.ajax({
            url: '/CategoryDetail/UpdateCategoryGroup',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(model)
        });
    };

    var deleteCategoryGroup = function (model) {
        return $.ajax({
            url: '/CategoryDetail/DeleteCategoryGroup',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };

    return {
        getCategoryDetails: function() {
            return getCategoryDetails();
        },
        insertCategoryDetail: function(model) {
            return insertCategoryDetail(model);
        },
        updateCategoryDetail: function(model) {
            return updateCategoryDetail(model);
        },
        deleteCategoryDetail: function(model) {
            return deleteCategoryDetail(model);
        },

        insertCategoryGroup: function (model) {
            return insertCategoryGroup(model);
        },
        updateCategoryGroup: function (model) {
            return updateCategoryGroup(model);
        },
        deleteCategoryGroup: function (model) {
            return deleteCategoryGroup(model);
        },
    };
}(categoryDetail);

function bindingCategoryDetails() {
    var binding = categoryDetail.getCategoryDetails();
    $.when(binding).then(function (result) {
        if (result.isSuccess) {
            $('#category_detail_Div').html('');
            $('#categoryGroupTemplate').tmpl(result.data).appendTo('#category_detail_Div');
        }
    });
}

function bindingCategoryDetailFrom(obj, type) {
    $('div.dz-success').remove();
    $('.file-upload-container').removeClass('dz-started');
    $('.file-upload-container').show();
    if (type == "add") {
        $('input').val('');
    } else {
        var rowId = $(obj).attr("data-id");
        $('#category-detail-form .category-detail-name').val($("#" + rowId + " .categorty-detail").text());
        $('#category-detail-form .category-detail-index').val($("#" + rowId + " .categorty-index").text());
        $("#category-detail-form #category-detail-id").val(rowId);
    }
}

function bindingCategoryTypoeGroupFrom(obj, type) {
    if (type == "add") {
        $('input').val('');
    } else {

    }
}

function deleteCategoryDetail(obj) {
    var rowId = $(obj).attr("data-id");
    var model = {
        categoryId: rowId
    };
    var deleteCate = categoryDetail.deleteCategoryDetail(model);
    $.when(deleteCate).then(function (result) {
        bindingCategoryDetails();
    });
}

$(document).on('click', '#group-save', function (event) {
    var groupDetailId = $("#category-group-form #category-type-group-id").val();
    var model = {
        CategoryTypeGroupId: parseInt(groupDetailId),
        CategoryTypeId: parseInt(gds.getQueryVariable('categoryTypeId')),
        CategoryTypeGroupName: $('#category-group-form .category-group-name').val(),
        CreateDateStr: $('#category-group-form category-type-group-create-date').val(),
        Index: parseInt($('#category-group-form .category-group-index').val())
    };
    if (groupDetailId == '' || groupDetailId == 0) {
        var insert = categoryDetail.insertCategoryGroup(model);
        $.when(insert).then(function (result) {
            if (result.isSuccess) {
                $('#categoryGroupTemplate').tmpl(result.data).appendTo('#category_detail_Div');
            }
        });
    } else {
        var update = categoryDetail.updateCategoryGroup(model);
    }
});

//$(document).on('click', '#save', function (event) {
//    var formModel = $('#category-detail-form').serializeObject();
//    console.log(formModel);
//    //var model = {
//    //    CategoryDetailId: $("#category-detail-form #category-detail-id").val(),
//    //    CategoryTypeId: parseInt(gds.getQueryVariable('categoryTypeId')),
//    //    CategoryDetailName: $('#category-detail-form .category-detail-name').val(),
//    //};
//    //var catDetailId = $("#category-detail-form #category-detail-id").val();
//    //if (catDetailId == '' || catDetailId == 0) {
//    //    var insert = categoryDetail.insertCategoryDetail(formModel);
//    //    $.when(insert).then(function (result) {
//    //        if (result.isSuccess) {
//    //            bindingCategoryDetails();
//    //        }
//    //    });
//    //} else {
//    //    var update = categoryDetail.updateCategoryDetail(model);
//    //    $.when(update).then(function (result) {
//    //        if (result.isSuccess) {
//    //            bindingCategoryDetails();
//    //        }
//    //    });
//    //    $('#add-new-category-detail').modal('hide');
//    //}
//});


$(document).ready(function () {
    bindingCategoryDetails();
});