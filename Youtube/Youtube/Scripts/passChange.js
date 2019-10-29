function passCheck() {
   
  
    if ($("#hiddenpass").val() == $("#oldpass").val()) {

        if ($("#pass").val().trim().length != 0 && $("#conpass").val().trim().length != 0) {

            if ($("#pass").val() == $("#conpass").val()) {
                $("#passwordConfirmForm").submit();
            }
            else {
                $("#errorMessage").html("Password doesn't match with new password");

            }
        }
        else {
            $("#errorMessage").html("Password Empty");
        }
    }
    else {
        $("#errorMessage").html("Old password does not match");
}
}