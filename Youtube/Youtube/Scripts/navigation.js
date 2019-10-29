
var subInfo = $("#subscription-info");

var uid = $("#UserId").val();

$.ajax({
    type: 'GET', // define the type of HTTP verb we want to use (POST for our form)
    url: '/Notification/GetNotificationsByReportedToId/' + uid, // the url where we want to POST
}).done(function (data) {


    var notif = "";

    for (var i = 0; i < data.length; i++) {

        notif += "   <li>\n" +
            "                                    <div class=\"friend-requests-info\">\n" +
            "                                        <div class=\"thumb\"><a href=" + "/channel/mychannel/" + data[i].NotifiedByUser.Id + " ><img src=" + data[i].NotifiedByUser.Image + " alt=\"\"></a></div>\n" +
            "                                        <a href=" + "/channel/mychannel/" + data[i].NotifiedByUser.Id + " class=\"name\">" + data[i].NotifiedByUser.Name + " </a>\n" +
            "                                        <span>" + data[i].Content + "</span>\n" +
            "                                    </div>\n" +
            "                                </li>";
    }

    $("#newSub").html(data.length);
    $("#subscription-info").append(notif);

});






//toggle playlist

$("#showmyplaylist").click(function () {


    var UserId = $("#UserId").val();


    $.ajax({
        type: 'GET', // define the type of HTTP verb we want to use (POST for our form)
        url: '/playlist/GetPlaylistByUserId/' + UserId // the url where we want to POST
    }).done(function (data) {


        var notification = "";

        data.forEach(function (data) {

            notification += " <li><a href=\"/video/Playlist/" + data.Id + "\">" + data.Name + "</a></li>";
        });

        $("#myplaylist").html(notification);
    });

    $("#myplaylist").slideToggle();
});


//searchByName
$("#searchByName").keyup(function () {

    $.ajax({
        url: '/video/SearchByName',
        dataType: "json",
        data:
        {
            term: $("#searchByName").val(),
        },
        success: function (data) {
            var songs = "";

            data.forEach(function (result) {

                songs += "<li><a href=" + '/video/view/' + result.Id + "><img src=" + result.Poster + " /><span>" + result.Title + "</span></li>";
            })

            $("#searchedResultViewArea").html(songs);

        }

    })

});




//Total notification count
setInterval(function () {

    var UserId = $("#UserId").val();
    //$("#totalNotification").html(0);
    $.ajax({
        type: 'GET', // define the type of HTTP verb we want to use (POST for our form)
        url: '/Notification/getNewNotificationByUser/' + UserId // the url where we want to POST
    }).done(function (data) {
        // alert(data.length);
        $("#totalNotification").html(data.length);

    });




}, 3 * 100);


$(document).ready(function () {
    $("#showNotification").click(function () {

        var UserId = $("#UserId").val();

        $.ajax({
            type: 'GET', // define the type of HTTP verb we want to use (POST for our form)
            url: '/Notification/getNotificationByUser/' + UserId// the url where we want to POST

        }).done(function (data) {

            var notif = " ";
            // alert(data[2].NotifiedByUser.Name+" "+data[2].VideoId);
            for (var i = 0; i < data.length; i++) {

                notif += " <li>\n" +
                "  <div class=\"notification-info\" >\n" +
                "   <a href=" + "video/view/" + data[i].VideoId + ">\n" +

                "       <strong>" + data[i].NotifiedByUser.Name + "</strong>" + " " + data[i].Content + "\n" +
                 "      <h5 class=\"time\">" + data[i].Time + "</h5>\n" +
                  " </a>\n" +
               "</div>\n" +
                                    "   </li>";
            }

            $("#notificationList").append(notif);

            //  var notif = " ";
            $.ajax({
                type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
                url: '/Notification/Update/' + UserId// the url where we want to POST


            });


        });


    });
});