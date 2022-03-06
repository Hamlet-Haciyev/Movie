$(document).ready(function () {


    if ($("#notAdmin").length>0) {
        swal("You are not admin!", "You clicked the button!", "error");
    }

    if ($("#checkPswrd").length>0) {
        swal("Current password is wrong!", "You clicked the button!", "error");
    }
    if ($("#changeUserInfo").length>0) {
        swal("You are changed account info!", "You clicked the button!", "success");
    }
    if ($("#terms").length > 0) {
        swal("New password is not match in terms!", "You clicked the button!", "error");
    }
})

