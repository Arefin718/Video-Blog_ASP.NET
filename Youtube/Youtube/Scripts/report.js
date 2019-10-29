function submitReport() {


    // alert($('[name = type]:checked').val());


    // var VideoID = $("#reportedId").val();
    var UserID = $("#UserId_report").val();
    var Time = $("#Time_report").val();
    var type = $("#type").val();
    var detail = $("textarea#reportDetails").val();
    var content = $('[name=content]:checked').val();
    //alert(UserID + " - " + Postid + "- " + detail);
    var report;
    if (type == "video") {

        report = {
            UserId: UserID,
            videoId: $("#reportedId").val(),
            type: type,
            content: content,
            details: detail,
            time: Time
        }

    } else {
        report = {
            UserId: UserID,
            ChannelID: $("#reportedId").val(),
            type: type,
            content: content,
            details: detail,
            time: Time
        }
    }



    $.ajax({
        type: "POST",
        url: "/Report/Insert",
        data: report,
        success: function (data) {
            //alert(type + " " + Postid + " " + detail);
            $("#reportButton").attr('data-dismiss', 'modal');

        }
    }
    ).done(function () {

    });

    e.preventDefault();


}