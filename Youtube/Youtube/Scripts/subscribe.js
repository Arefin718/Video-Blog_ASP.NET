function subscribe(cid) {

        $.ajax({
            type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
            url: '/subscription/unsubscribe/' + cid, // the url where we want to POST
        }).done(function () {

            if ($("#sub").hasClass("btn-danger")) {
                $('#sub').addClass('btn-info').removeClass('btn-danger');
                $('#sub').html("Subcribe");
            }
            else if ($("#sub").hasClass("btn-info")) {
                $('#sub').addClass('btn-danger').removeClass(' btn-info');
                $('#sub').html("Unsubscribe");
            }

            if ($("#unsub").hasClass("btn-danger")) {
                $('#unsub').addClass('btn-info').removeClass('btn-danger');
                $('#unsub').html("Subcribe");
            }
            else if ($("#unsub").hasClass("btn-info")) {
                $('#unsub').addClass('btn-danger').removeClass('btn-info');
                $('#unsub').html("Unsubscribe");
            }



        });
}


function unsubscribe(cid, channelid) {

    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: '/subscription/unsubscribe/' + cid, // the url where we want to POST
    }).done(function () {

        $("#status_" + cid).hide();

    });
}

function confirm(cid) {
    $("#confirmDeleteButton").val(cid);
}



        


