
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

