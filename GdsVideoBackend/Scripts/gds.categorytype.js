
var categoryTypeCtrl = function () {
    var parentPage = {
        total: 0,
        page: 1,
        pageSize: 50,
    };
    var childrenPage = {        
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
    var getCategoryTypeChildren = function () {
        var model = {
            categoryId: parseInt(gds.getQueryVariable('categoryId')),
            pageIndex: childrenPage.page,
            pageSize: childrenPage.pageSize,
        };
        return $.ajax({
            url: '/categorytype/getchildren',
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

    var getChildrenPage = function () {
        return childrenPage;
    };

    var setChildrenPage = function (thisPage) {
        childrenPage = {
            total: thisPage.total,
            page: thisPage.page,
            pageSize: thisPage.pageSize,
        };
    };

    var getParentCategoryTypeSelect = function () {
        return $.ajax({
            url: '/categorytype/getparentcategorytype',
            type: 'GET',
        });
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
    
    var saveCategoryTypeChildren = function (model) {
        return $.ajax({
            url: '/categorytype/InsertChildren',
            type: 'POST',
            dataType: "json",
            data: model
        });
    };

    var updateCategoryTypeChildren = function (model) {
        return $.ajax({
            url: '/categorytype/UpdateChildren',
            type: 'POST',
            dataType: "json",
            data: model
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
        getCategoryTypeChildren: function() {
            return getCategoryTypeChildren();
        },
        getParentCategoryTypeSelect: function () {
            return getParentCategoryTypeSelect();
        },
        getParentPage: function () {
            return getParentPage();
        },
        setParentPage: function (thisPage) {
            return setParentPage(thisPage);
        },
        getChildrenPage: function () {
            return getChildrenPage();
        },
        setChildrenPage: function (thisPage) {
            return setChildrenPage(thisPage);
        },
        saveCategoryType: function (form) {
            return saveCategoryType(form);
        },
        updateCategoryType: function (form) {
            return updateCategoryType(form);
        },
        saveCategoryTypeChildren: function (model) {
            return saveCategoryTypeChildren(model);
        },
        updateCategoryTypeChildren: function (model) {
            return updateCategoryTypeChildren(model);
        },
        deleteCategoryType: function (model) {
            return deleteCategoryType(model);
        },
    };
}(categoryTypeCtrl);

function getParentCategoryTypeSelect() {
    var prices = categoryTypeCtrl.getParentCategoryTypeSelect();
    $.when(prices).then(function (result) {
        var html = '';
        for (var i = 0; i < result.data.length; i++) {
            var item = result.data[i];
            html += '<option value="' + item.Id + '">' + item.Name + '</option>';
        }
        $('#category-type-children-form #parent-category-type-select').html(html);
    });
}

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

function bindingChildren() {
    var children = categoryTypeCtrl.getCategoryTypeChildren();
    $.when(children).then(function (result) {
        if (result.isSuccess) {
            $('#categoryTypeChildren_Div').html('');
            callBackController.renderPaging(result.data.PageIndex, result.data.ItemCount);
            $('#categoryTypeChildrenTemplate').tmpl(result.data).appendTo('#categoryTypeChildren_Div');
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
            } else {
                bindingChildren();
            }
        }
    });
}

function bindingCategoryTypeDetail(obj) {
    var rowId = $(obj).attr("data-id");
    var typeTable = $(obj).attr("data-type");
    if (typeTable == "parent") {
        $('#category-type-parent-form .category-type-id').val(rowId);
        $('#category-type-parent-form .category-type-name').val($("#" + rowId + " .category-type-name").text());
        $('#category-type-parent-form .price').val($("#" + rowId + " .price").attr('data-priceid'));
        $('#category-type-parent-form .age-order').val($("#" + rowId + " .age").attr('data-age'));
        $('#category-type-parent-form .cateogry-type-content').html($("#" + rowId + " .content-detail").html());
        var fileType = $("#" + rowId + " .category-type-name").attr('data-filetype');
        var file = $("#" + rowId + " .category-type-name").attr('data-file');
        document.getElementById("image-photo").src = "data:image/" + fileType + ";base64," + file;
    } else {
        $('#category-type-children-form .category-type-id').val(rowId);
        $('#category-type-children-form .category-type-name').val($("#" + rowId + " .category-type-name").text());
        $('#category-type-children-form .cateogry-type-content').html($("#" + rowId + " .content-detail").html());
    }
}

$(document).on('click', '#parent-tab', function (event) {
    if ($("#category-type-parent").hasClass('active')) return;
    window.pageSetting = {
        total: 0,
        page: 1,
        pageSize: 50,
    };
    categoryTypeCtrl.setParentPage(pageSetting);
    $("#category-type-parent").addClass('active');
    $("#category-type-children").removeClass('active');
    window.callback = bindingParent();
    bindingParent();
});

$(document).on('click', '#children-tab', function (event) {
    if ($("#category-type-children").hasClass('active')) return;
    getParentCategoryTypeSelect();
    window.pageSetting = {
        total: 0,
        page: 1,
        pageSize: 50,
    };
    categoryTypeCtrl.setParentPage(pageSetting);
    $("#category-type-parent").removeClass('active');
    $("#category-type-children").addClass('active');
    window.callback = bindingChildren();
    bindingChildren();
});

$(document).on('click', '#save-parent', function (event) {
    var form = $('#category-type-parent-form');
    $('#category-type-parent-form .category-id').val(parseInt(gds.getQueryVariable('categoryId')));
    $('#category-type-parent-form .content').val($('#category-type-parent-form .cateogry-type-content').code().replace(/^\s+|\s+$/g, ""));
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

$(document).on('click', '#save-children', function (event) {
    var model = {
        ParentId: $('#category-type-children-form .parent-category-type-select').val(),
        CategoryTypeId: $('#category-type-children-form .category-type-id').val(),
        CategoryId: parseInt(gds.getQueryVariable('categoryId')),
        CategoryTypeName: $('#category-type-children-form .category-type-name').val(),
        Content: $('#category-type-children-form .cateogry-type-content').code().replace(/^\s+|\s+$/g, ""),
    };
    if (model.CategoryTypeId == 0) {
        var saveCategoryType = categoryTypeCtrl.saveCategoryTypeChildren(model);
        $.when(saveCategoryType).then(function(result) {
            if (result.isSuccess) {
                window.pageSetting = {
                    total: 0,
                    page: 1,
                    pageSize: 50,
                };
                categoryTypeCtrl.setChildrenPage(pageSetting);
                bindingChildren();
            }
        });
    } else {
        var upateCategoryType = categoryTypeCtrl.updateCategoryTypeChildren(model);
        $.when(upateCategoryType).then(function (result) {
            if (result.isSuccess) {
                window.pageSetting = {
                    total: 0,
                    page: 1,
                    pageSize: 50,
                };
                categoryTypeCtrl.setChildrenPage(pageSetting);
                bindingChildren();
            }
        });
    }
    $('#add-new-category-type-children').modal('hide');
});

$(document).on('click', '#category-type-parent .page-size', function (event) {
    var pageInfo = categoryTypeCtrl.getParentPage();
    pageInfo.pageSize = parseInt($(this).val());
    categoryTypeCtrl.setParentPage(pageInfo);
    bindingParent();
});

$(document).on('click', '#category-type-children .page-size', function (event) {
    var pageInfo = categoryTypeCtrl.getChildrenPage();
    pageInfo.pageSize = parseInt($(this).val());
    categoryTypeCtrl.setChildrenPage(pageInfo);
    bindingChildren();
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

$(document).on('click', '#category-type-parent .category-type-box', function (event) {
    $('#category-type-parent-form .category-id').val('');
    $('#category-type-parent-form .content').val('');
    $('#category-type-parent-form .category-type-id').val(''),
    $('#category-type-parent-form .category-type-name').val(''),
    $("#category-type-parent-form .price option:first").attr('selected', 'selected');
    $("#category-type-parent-form .age-order option:first").attr('selected', 'selected');
    $('#category-type-parent-form .cateogry-type-content').html('');
    $('#category-type-parent-form #image-photo').attr('src', '');
});

$(document).on('click', '#category-type-children .category-type-box', function (event) {
    $('#category-type-children-form .category-type-name').val('');
    $('#category-type-children-form .category-type-id').val('0'),
    $("#category-type-children-form .parent-category-type-select option:first").attr('selected', 'selected');
    $('#category-type-children-form .cateogry-type-content').html('');
});

$(document).ready(function () {
    categoryTypeCtrl.setParentPage(pageSetting);
    categoryTypeCtrl.setChildrenPage(pageSetting);
    window.callback = bindingParent();
});