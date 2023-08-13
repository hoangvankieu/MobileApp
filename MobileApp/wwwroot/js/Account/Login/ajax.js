


function HandMadeLogin() {
    $("#loginForm").submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: "/Staff/Login",
            type: "POST",
            data: $(this).serialize(),
            success: function (result) {
                console.log(result.isSuccess);
                if (result.isSuccess === false) {

                    $("#successMessage").show();
                }
                else {
                    var x = result.jwt;
                    window.localStorage.setItem("jwt", x);
                    window.location.href = "/Home/Index";
                }
            }

        });
    });
}
function AutoLogin(jwt) {
    $.ajax({
        url: "/Home/Index",
        type: "GET",
       
        headers: {
            Authorization: "Bearer " + jwt
        },
        success: function (result) {    
            console.log(result);
            if (result.isSuccess === false) {
                window.location.href = "/Staff/Login";
            }
            else {
                window.location.href = "/Home/Index";
            }
        }
    });
}
$(document).ready(function () {
    var jwt = window.localStorage.getItem("jwt");
    if (jwt !== null) {
        AutoLogin(jwt);
    }
    else {
        HandMadeLogin();
    }
});

