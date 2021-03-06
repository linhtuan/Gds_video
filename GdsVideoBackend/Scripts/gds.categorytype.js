﻿
var categoryTypeCtrl = function () {
    var parentPage = {
        total: 0,
        page: 1,
        pageSize: 50,
    };
    
    var getCategoryTypeParent = function () {
        var model = {
            categoryId: parseInt(gds.getQueryVariable('categoryId')),
            pageIndex: parentPage.page,
            pageSize: parentPage.pageSize,
        };
        return $.ajax({
            url: '/categorytype/getparent',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };
    
    var getParentPage = function () {
        return parentPage;
    };
    
    var setParentPage = function (thisPage) {
        parentPage = {
            total: thisPage.total,
            page: thisPage.page,
            pageSize: thisPage.pageSize,
        };
    };

    var saveCategoryType = function (form) {
        var formData = new FormData(form[0]);
        return $.ajax({
            url: '/categorytype/insert',
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            type: 'POST',
        });
    };
    
    var updateCategoryType = function (form) {
        var formData = new FormData(form[0]);
        return $.ajax({
            url: '/categorytype/update',
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            type: 'POST',
        });
    };

    var deleteCategoryType = function(model) {
        return $.ajax({
            url: '/categorytype/Update',
            type: 'POST',
            dataType: "json",
            data: model
        });
    };
    
    return {
        getCategoryTypeParent: function() {
            return getCategoryTypeParent();
        },

        getParentPage: function () {
            return getParentPage();
        },
        setParentPage: function (thisPage) {
            return setParentPage(thisPage);
        },
        saveCategoryType: function (form) {
            return saveCategoryType(form);
        },
        updateCategoryType: function (form) {
            return updateCategoryType(form);
        },
        deleteCategoryType: function (model) {
            return deleteCategoryType(model);
        },
    };
}(categoryTypeCtrl);


function bindingParent() {
    var parent = categoryTypeCtrl.getCategoryTypeParent();
    $.when(parent).then(function (result) {
        if (result.isSuccess) {
            $('#categoryTypeParent_Div').html('');
            callBackController.renderPaging(result.data.PageIndex, result.data.ItemCount);
            $('#categoryTypeParentTemplate').tmpl(result.data).appendTo('#categoryTypeParent_Div');
        }
    });
}


function deleteCategoryType(obj) {
    var rowId = $(obj).attr("data-id");
    var typeTable = $(obj).attr("data-type");
    var model = {
        categoryTypeId: rowId,
        type: typeTable
    };
    var deleteCate = categoryTypeCtrl.deleteCategoryType(model);
    $.when(deleteCate).then(function (result) {
        if (result.isSuccess) {
            if (result.type == "parent") {
                bindingParent();
            }
        }
    });
}

function bindingCategoryTypeDetail(obj) {
    var rowId = $(obj).attr("data-id");
    $('#category-type-parent-form .ibox-content').html('');
    $('#category-type-parent-form .ibox-content').html('<div class="click2edit wrapper p-md cateogry-type-content"></div>');
    $('#category-type-parent-form .category-type-id').val(rowId);
    $('#category-type-parent-form .category-type-name').val($("#" + rowId + " .category-type-name").text());
    $('#category-type-parent-form .price').val($("#" + rowId + " .price").attr('data-priceid'));
    $('#category-type-parent-form .age-order').val($("#" + rowId + " .age").attr('data-age'));
    $('#category-type-parent-form .author').val($("#" + rowId + " .author").attr('data-authorid'));
    $('#category-type-parent-form .categorytype-order').val($(obj).attr("data-categorytype-order"));
    $('#category-type-parent-form .cateogry-type-content').html($("#" + rowId + " .content-detail").html());
    var fileType = $("#" + rowId + " .category-type-name").attr('data-filetype');
    var file = $("#" + rowId + " .category-type-name").attr('data-file');
    document.getElementById("image-photo").src = "data:image/" + fileType + ";base64," + file;
}

$(document).on('click', '#save-parent', function (event) {
    $('#category-type-parent-form .category-id').val(parseInt(gds.getQueryVariable('categoryId')));
    $('#category-type-parent-form .content').val($('#category-type-parent-form .cateogry-type-content').code().replace(/^\s+|\s+$/g, ""));
    var form = $('#category-type-parent-form');
    if ($('#category-type-parent-form .category-type-id').val() == 0) {
        var saveCategoryType = categoryTypeCtrl.saveCategoryType(form);
        $.when(saveCategoryType).then(function(result) {
            if (result) {
                window.pageSetting = {
                    total: 0,
                    page: 1,
                    pageSize: 50,
                };
                categoryTypeCtrl.setParentPage(pageSetting);
                bindingParent();
            }
        });
    } else {
        var updateCategoryType = categoryTypeCtrl.updateCategoryType(form);
        $.when(updateCategoryType).then(function (result) {
            if (result) {
                window.pageSetting = {
                    total: 0,
                    page: 1,
                    pageSize: 50,
                };
                categoryTypeCtrl.setParentPage(pageSetting);
                bindingParent();
            }
        });
    }
    $('#add-new-category-type-parent').modal('hide');
});

$(document).on('click', '#category-type-parent .page-size', function (event) {
    var pageInfo = categoryTypeCtrl.getParentPage();
    pageInfo.pageSize = parseInt($(this).val());
    categoryTypeCtrl.setParentPage(pageInfo);
    bindingParent();
});


$('#replace-photo').on('click', function (event) {
    event.preventDefault();
    $('#replace-photo-tag').click();
});

$('#category-type-parent-form').on('change', '#replace-photo-tag', function () {
    var thisUrl = this;
    if (thisUrl.files && thisUrl.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#image-photo').attr('src', e.target.result);
        };
        reader.readAsDataURL(thisUrl.files[0]);
    }
});

$(document).on('click', '.category-type-box', function (event) {
    $('#category-type-parent-form .category-id').val('');
    $('#category-type-parent-form .content').val('');
    $('#category-type-parent-form .category-type-id').val('');
    $('#category-type-parent-form .category-type-name').val('');
    $("#category-type-parent-form .price option:first").attr('selected', 'selected');
    $("#category-type-parent-form .age-order option:first").attr('selected', 'selected');
    $("#category-type-parent-form .categorytype-order option:first").attr('selected', 'selected');
    $("#category-type-parent-form .author option:first").attr('selected', 'selected');
    $('#category-type-parent-form .ibox-content').html('');
    $('#category-type-parent-form .ibox-content').html('<div class="click2edit wrapper p-md cateogry-type-content"></div>');
    $('#category-type-parent-form #image-photo').attr('src', '');
});

$(document).ready(function () {
    categoryTypeCtrl.setParentPage(pageSetting);
    window.callback = bindingParent();
});