var gds = function() {
    var getLecture = function(model) {
        return $.ajax({
            url: '/course/lectures/info',
            type: 'POST',
            dataType: 'json',
            data: model
        });
    };

    return {
        getLecture: function(model) {
            return getLecture(model);
        },
    };

}(gds);

function getLectureHasUrl() {
    var model = {
        hasUrl: true,
        categoryTypeId: $('.course_id').val(),
        urlRouter: $('.course_router').val(),
    };
    var lectures = gds.getLecture(model);
    $.when(lectures).then(function(result) {
        if (result.isSuccess) {
            $('#list-lecture-container').html('');
            console.log(result.data);
            $('#lectureContainerTemplate').tmpl(result.data).appendTo('#list-lecture-container');
        }
    });
}

function getLectureNotUrl() {
    var model = {
        hasUrl: false,
        categoryTypeId: $('.course_id').val(),
        urlRouter: $('.course_router').val(),
    };
    var lectures = gds.getLecture(model);
    $.when(lectures).then(function (result) {
        if (result.isSuccess) {
            $('#childred-template').html('');
            $('#lectureGroupTemplate').tmpl(result).appendTo('#childred-template');
        }
    });
}

$(document).on('click', '.login-authen', function (event) {
    var status = $(this).attr('data-toggle');
    if (status == 'down') {
        $(this).attr('data-toggle', 'modal');
        $('#login-form-authen').show();
    } else {
        $(this).attr('data-toggle', 'down');
        $('#login-form-authen').hide();
    }
});

$(document).ready(function () {
    $("[data-tt=tooltipLogin]").tooltip();
});