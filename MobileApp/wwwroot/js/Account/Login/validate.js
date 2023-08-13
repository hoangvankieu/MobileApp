$(document).ready(function () {
    $(".validate-form").validate({
        rules: {
            Username: {
                required: true,
                minlength: 3
            },
            Password: {
                required: true,
                minlength: 6
            },
        },
        messages: {
            Username: {
                required: "Nhập tài khoản",
                minlength:"Tài khoản độ dài ít nhất từ 3 kí tự"
            },
            
            Password: {
                required: "Vui lòng nhập mật khẩu",
                minlength: "Mật khẩu độ dài ít nhất từ 6 kí tự "
            },
        }
        
    });
});