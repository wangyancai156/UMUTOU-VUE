
jQuery(document).ready(function() {

    $('.page-container form').submit(function(){
        var username = $(this).find('.username').val();
        var password = $(this).find('.password').val();
        if(username == '') {
            $(this).find('.error').fadeOut('fast', function(){
                $(this).css('top', '27px');
            });
            $(this).find('.error').fadeIn('fast', function(){
                $(this).parent().find('.username').focus();
            });
            return false;
        }
        if(password == '') {
            $(this).find('.error').fadeOut('fast', function(){
                $(this).css('top', '96px');
            });
            $(this).find('.error').fadeIn('fast', function(){
                $(this).parent().find('.password').focus();
            });
            return false;
        }
    });

    $('.page-container form .username, .page-container form .password').keyup(function(){
        $(this).parent().find('.error').fadeOut('fast');
    });

});

$(function () {
    //输入框 回车登录
    $("#vcode").keydown(function (ev) {
        var keyCode = ev.which;
        if (keyCode == 13) {
            loginSub();
        }
    });
    // 切换验证码
    $("#verifyCode").click(function () {
        var _src = $(this).attr("src") + "&dom" + Math.random();
        $(this).attr("src", _src);
    });


})

