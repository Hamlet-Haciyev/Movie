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
    if ($("#wrongPassword").length>0) {
        swal("Username or password is not correct!", "You clicked the button!", "error");
    }
    if ($("#RegisterExistError").length>0) {
        swal("This email is already registered!!", "You clicked the button!", "error");
    }
    if ($("#SuccessRegister").length > 0) {
        swal("You've been successfully registered!!", "You clicked the button!", "success");
    }
    if ($("#Failed").length > 0) {
        swal("The password is not in accordance with the terms!!", "You clicked the button!", "error");
    }
    
})

