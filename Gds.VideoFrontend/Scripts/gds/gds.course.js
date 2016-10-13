var courseController = function () {
    var getAuthor = function() {
        return $.ajax({
            url: '/course/getauthor/info',
            type: 'POST',
            dataType: 'json',
            data: { authorId: $('.author_id').val() }
        });
    };

    var getSuggest = function() {
        return $.ajax({
            url: '/course/suggest/info',
            type: 'POST',
            dataType: 'json',
            data: { cateId: $('.course_id').val() }
        });
    };

    return {        
        getAuthor: function() {
            return getAuthor();
        },
        getSuggest: function () {
            return getSuggest();
        },
    };

}(courseController);

function getAuthor() {
    var authorInfo = courseController.getAuthor();
    $.when(authorInfo).then(function (result) {
        if (result.isSuccess) {
            $("#author").html('');
            $('#authorTemplate').tmpl(result.data).appendTo('#author');
            $('#author-name').html(result.data.AuthorName);
        }
    });
}

function getSuggestCourse() {
    var authorInfo = courseController.getSuggest();
    $.when(authorInfo).then(function (result) {
        if (result.isSuccess) {
            $("#also-viewed").html('');
            $('#lectureHotTemplate').tmpl(result.data).appendTo('#also-viewed');
        }
    });
}

$(document).ready(function () {
    getAuthor();
    getLectureNotUrl();
    getSuggestCourse();
});