var categoryGroupCtrl = function () {

    var getCategoryGroup = function () {
        var model = {
            categoryTypeId: parseInt(gds.getQueryVariable('categoryTypeId')),
        };
        return $.ajax({
            url: '/categorydetail/getcategorygroup',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };

    var insertCateGroup = function(model) {
        return $.ajax({
            url: '/CategoryDetail/InsertCategoryGroup',
            type: 'POST',
            dataType: "json",
            data: model
        });
    };

    return {
        insertCateGroup: function (model) {
            return insertCateGroup(model);
        },
        getCategoryGroup: function () {
            return getCategoryGroup();
        },
    };
}(categoryGroupCtrl);


function bindingCategoryDetails() {
    var binding = categoryGroupCtrl.getCategoryGroup();
    $.when(binding).then(function (result) {
        if (result.isSuccess) {
            $('#category_detail_Div').html('');
            $('#categoryGroupTemplate').tmpl(result.data).appendTo('#category_detail_Div');
        }
    });
}

