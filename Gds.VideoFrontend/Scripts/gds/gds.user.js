var userCtrl = function () {

    var userLogin = function () {
        var model = { userName: $('#email').val(), passwords: $('#password').val() };
        return $.ajax({
            url: '/account/login',
            type: 'POST',
            dataType: 'json',
            data: model
        });
    }

    return {
        userLogin: function () {
            return userLogin();
        },
    };

}(userCtrl);

function onSignInCallback(response) {
    $(".login-error").empty();
    if (response.isSuccess) {
        window.location.href = response.action;
    } else {
        //$('#loader1').hide();
        $('.login-error').append(response.messages);
        $('.login-error').show();
        /*setTimeout(function() {
            $('.login-error').fadeOut();       
        }, 5000);*/
    }
}

function onSignInFailureCallback() {
    $('#loader1').hide();
}
