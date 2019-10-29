$('#formSubmit').click(function () {


    var redirectURL = $("#RedirectURL").val();
    var clientId = $("#clientId").val();
    var email = $("#email").val();
    var password = $("#password").val();

    $.ajax({
        url: 'http://localhost:62872/api/users/get/' + clientId,
        method: 'GET',
        headers: {
            Authorization: 'Basic ' + btoa(email + ":" + password)
        },
        success: function (user) {



            $.ajax({
                type: "POST",
                url: redirectURL,
                data: {
                    name: user.name,
                    address: user.address,
                    image: user.image,
                    email: user.email
                }
            }).done(function (msg) {

                window.open('', '_self', ''); window.close();
               
                });  
           
        }
    });
});