var categoryController = function() {
    var getCourse = function() {
        var model = {
            pageIndex: pageSetting.page,
            pageSize: pageSetting.pageSize,
            category: window.categoryRouter
        };
        return $.ajax({
            url: '/category/GetCourses',
            type: 'Post',
            dataType: 'json',
            data: model
        });
    };

    return {
        getCourse: function() {
            return getCourse();
        },
    };
}(categoryController);

function bindingCourse() {
    var courses = categoryController.getCourse();
    $.when(courses).then(function (result) {
        if (result.isSuccess) {
            callBackController.renderPaging(result.data.PageIndex, result.data.PageCount);
            $('#courses-result').html('');
            $('#cousesResultTemplate').tmpl(result.data).appendTo('#courses-result');
        }
    });
}

$(document).ready(function () {
    window.callback = bindingCourse();
});