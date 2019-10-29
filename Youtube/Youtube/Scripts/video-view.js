function subscribe(cid) {


    var totalSubscriber = parseInt($("#noOfSubscriber").text());

    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: '/subscription/unsubscribe/' + cid, // the url where we want to POST
    }).done(function () {

        if ($("#sub").hasClass("btn-danger")) {
            $('#sub').addClass('btn-info').removeClass('btn-danger');
            $('#sub').html("Subcribe");
            $("#noOfSubscriber").text(totalSubscriber - 1);
        }
        else if ($("#sub").hasClass("btn-info")) {
            $('#sub').addClass('btn-danger').removeClass(' btn-info');
            $('#sub').html("Unsubscribe");
            $("#noOfSubscriber").text(totalSubscriber + 1);
            insertNotification();

        }

        if ($("#unsub").hasClass("btn-danger")) {
            $('#unsub').addClass('btn-info').removeClass('btn-danger');
            $('#unsub').html("Subcribe");
            $("#noOfSubscriber").text(totalSubscriber - 1);
        }
        else if ($("#unsub").hasClass("btn-info")) {
            $('#unsub').addClass('btn-danger').removeClass('btn-info');
            $('#unsub').html("Unsubscribe");
            $("#noOfSubscriber").text(totalSubscriber + 1);
            insertNotification();
        }

    });
}


function insertNotification() {

    var notification = {
        NotifiedTo: $("#UserToNotify").val(),
        Content: "Subscribed your channel",
        Type: "Subscription",
        NotifiedBy: $("#UserId").val()
    }


    console.log(notification);
    $.ajax({
        type: 'POST', 
        url: '/Notification/Insert/',
        data: notification 
    })

}
