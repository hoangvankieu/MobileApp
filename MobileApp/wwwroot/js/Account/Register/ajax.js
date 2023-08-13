
$(document).ready(function () {
    $("#registerForm").submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: "/Staff/Login",
            type: "POST",
            data: $(this).serialize(),
            success: function (result) {
                console.log("xin chào");
                if (result.isSuccess===false) {
                    $("#successMessage").show();
                }
                else {
                    window.location.href = "/Staff/Login";
                }
            }
            
        });
    });
});