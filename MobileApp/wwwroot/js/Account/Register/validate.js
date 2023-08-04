$(document).ready(function () {
    $(".validate-form").validate({
        rules: {
            Username: {
                required: true,
                minlength: 3
            },
            HashPassword: {
                required: true,
                minlength: 6
            },
            ConfirmPassword: {
                required: true,
                equalTo: "#HashPassword"
            }
        },
        messages: {
            Username: {
                required: "Nhập tài khoản",
                minlength:"Tài khoản độ dài ít nhất từ 3 kí tự"
            },
            
            HashPassword: {
                required: "Vui lòng nhập mật khẩu",
                minlength: "Mật khẩu độ dài ít nhất từ 6 kí tự "
            },
            ConfirmPassword: {
                required: "Vui lòng nhập lại mật khẩu",
                equalTo: "Mật khẩu không khớp"
            }
        }
        
    });
});