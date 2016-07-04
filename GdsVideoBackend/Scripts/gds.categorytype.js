
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
    
    var getPrice = function () {
        return $.ajax({
            url: '/categorytype/getprices',
            type: 'GET',
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
    
    var saveCategoryTypeParent = function (model) {
        return $.ajax({
            url: '/categorytype/insert',
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
        getPrice: function () {
            return getPrice();
        },
        getParentCategoryTypeSelect: function () {
            return getParentCategoryTypeSelect();
        },
        saveCategoryTypeParent: function (model) {
            return saveCategoryTypeParent(model);
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
    };
}(categoryTypeCtrl);

function getPrice() {
    var prices = categoryTypeCtrl.getPrice();
    $.when(prices).then(function (result) {

        var html = '';
        for (var i = 0; i < result.data.length - 1; i++) {
            var item = result.data[i];
            html += '<option value="' + item.Id + '">' + item.Price + '</option>';
        }
        $('.modal-body .price').html(html);
    });
}

function getParentCategoryTypeSelect() {
    var prices = categoryTypeCtrl.getParentCategoryTypeSelect();
    $.when(prices).then(function (result) {
        var html = '';
        for (var i = 0; i < result.data.length - 1; i++) {
            var item = result.data[i];
            html += '<option value="' + item.Id + '">' + item.Name + '</option>';
        }
        $('.modal-body .parent-category-type-select').html(html);
    });
}

function bindingParent() {
    var parent = categoryTypeCtrl.getCategoryTypeParent();
    $.when(parent).then(function (result) {
        if (result.isSuccess) {
            callBackController.renderPaging(result.data.PageIndex, result.data.ItemCount);
            $('#categoryTypeParentTemplate').tmpl(result.data).appendTo('#categoryTypeParent_Div');
        }
    });
}

function bindingChildren() {
    var children = categoryTypeCtrl.getCategoryTypeChildren();
    $.when(children).then(function (result) {
        if (result.isSuccess) {
            callBackController.renderPaging(result.data.PageIndex, result.data.ItemCount);
            $('#categoryTypeChildrenTemplate').tmpl(result.data).appendTo('#categoryTypeChildren_Div');
        }
    });
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
    var model = {
        CategoryId: 1,
        CategoryTypeName: $('#category-type-parent-form .category-type-name').val(),
        CategoryTypePriceId: 1,
        Content: $('#category-type-parent-form .cateogry-type-content').code().replace(/^\s+|\s+$/g, "")
    };
    var saveCategoryType = categoryTypeCtrl.saveCategoryTypeParent(model);
    $.when(saveCategoryType).then(function (result) {
        if (result) {

        }
    });
});

$(document).on('click', '#save-children', function (event) {
    var model = {
        CategoryId: 1,
        CategoryTypeName: $('#category-type-children-form .category-type-name').val(),
        CategoryTypePriceId: 1,
        Content: $('#category-type-children-form .cateogry-type-content').code().replace(/^\s+|\s+$/g, "")
    };
    var saveCategoryType = categoryTypeCtrl.saveCategoryTypeParent(model);
    $.when(saveCategoryType).then(function (result) {
        if (result.isSuccess) {
           
        }
    });
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

$(document).ready(function () {
    getPrice();
    categoryTypeCtrl.setParentPage(pageSetting);
    categoryTypeCtrl.setChildrenPage(pageSetting);
    bindingParent();
    window.callback = bindingParent();
});