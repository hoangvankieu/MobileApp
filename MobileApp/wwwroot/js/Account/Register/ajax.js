
$(document).ready(function () {
    $("#registerForm").submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: "/Account/Register",
            type: "POST",
            data: $(this).serialize(),
            
            success: function (result) {
                if (result.isSuccess) {
                    $("#successMessage").show();
                }
            }
        });
    });
});