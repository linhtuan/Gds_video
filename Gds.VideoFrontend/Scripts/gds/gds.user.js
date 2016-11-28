var userCtrl = function () {

    var userLogin = function () {
        var model = { userName: $('#login-modal .email').val(), passwords: $('#login-modal .password').val() };
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

$('.btn-login-submit').on("click", function () {
    var status = userCtrl.userLogin();
    $.when(status).then(function () {
        if (status == true) {
            $('#login-modal').modal('hide');
        }
        else {

        }
    });
});

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
