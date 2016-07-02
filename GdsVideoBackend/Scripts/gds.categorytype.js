
var categoryTypeCtrl = function() {
    var getCategoryTypeParent = function() {
        return $.ajax({
            url: '/categorytype/getprices',
            type: 'GET',
        });
    };
    var getCategoryTypeChildren = function() {
        return $.ajax({
            url: '/categorytype/getprices',
            type: 'GET',
        });
    };
    
    var getPrice = function () {
        return $.ajax({
            url: '/categorytype/getprices',
            type: 'GET',
        });
    };
    
    var getParentCategoryType = function () {
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
        getParentCategoryType: function () {
            return getParentCategoryType();
        },
        saveCategoryTypeParent: function (model) {
            return saveCategoryTypeParent(model);
        }
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

function getParentCategoryType() {
    var prices = categoryTypeCtrl.getParentCategoryType();
    $.when(prices).then(function (result) {
        var html = '';
        for (var i = 0; i < result.data.length - 1; i++) {
            var item = result.data[i];
            html += '<option value="' + item.Id + '">' + item.Name + '</option>';
        }
        $('.modal-body .parent-category-type-select').html(html);
    });
}


$(document).on('click', '#parent-tab', function (event) {
    if ($("#category-type-parent").hasClass('active')) return;

    $("#category-type-parent").addClass('active');
    $("#category-type-children").removeClass('active');
});

$(document).on('click', '#children-tab', function (event) {
    if ($("#category-type-children").hasClass('active')) return;

    getParentCategoryType();
    $("#category-type-parent").removeClass('active');
    $("#category-type-children").addClass('active');
});

$(document).on('click', '#save-parent', function (event) {

    var model = {
        CategoryId: 1,
        CategoryTypeName: $('#category-type-parent-form .category-type-name').val(),
        CategoryTypePriceId: 1,
        Content: $('#category-type-parent-form .cateogry-type-content').code().replace(/^\s+|\s+$/g, "")
    };
    //"'" + $('.cateogry-type-content').code().replace(/^\s+|\s+$/g, "") + "'" 
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
    $.when(saveCategoryType).then(function (data) {
        if (data) {

        }
    });
});

$(document).ready(function () {
    getPrice();
});