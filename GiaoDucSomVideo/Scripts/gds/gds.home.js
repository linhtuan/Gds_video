var homeController = function() {
    var getCategory = function() {
        return $.ajax({
            url: '/home/getcategorys',
            type: 'GET',
        });
    };
    return {
        getCategory: function() {
            return getCategory();
        },
    };
}(homeController);


function bindingCategory() {
    var category = homeController.getCategory();
    $.when(category).then(function (result) {
        $('#list-categories').html('');
        $('#wrap_courses_append').html('');
        $('#wrap_courses_sm_append').html('');
        $('#menuCoursesTemplate').tmpl(result).appendTo('#list-categories');
        //$('#menuCoursesTemplate').tmpl(result).appendTo('#list-categories');
        for (var i = 0; i < result.data.length; i++) {
            var categoryType = result.data[i];
            $('#coursesTemplate').tmpl(categoryType).appendTo('#wrap_courses_append');
            $('#coursesTemplateSM').tmpl(categoryType).appendTo('#wrap_courses_sm_append');
            if (i == 0) {
                $('.course_element').removeClass('hide');
            }
        }
    });
}

$(document).ready(function () {
    bindingCategory();
});