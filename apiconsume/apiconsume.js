$(function () {

        var email = "shuvro.pc.1994@gmail.com";
        var password = "000";
        var APIKEY = "75d13c00cdac0a73a1c54cd8de62b73e";

        $.ajax({
            url: 'http://localhost:62872/api/videos/getallmyvideos/'+APIKEY,
            method: 'GET',
            headers: {
                Authorization: 'Basic ' + btoa(email+':'+password)
            },
            success: function (myvideos) {

                "http://localhost:62210/Content/Uploads/Videos/Adele - Skyfall (Lyric Video) - YouTube.mp402Jan18062956PM.mp4"
                console.log(myvideos);
                var vdo ="";
                myvideos.forEach(function (item) {

                     vdo +="                <div style='margin-right: 150px' class=\"col-lg-3 col-md-4 col-sm-6\">\n" +
                        "                    <div class=\"video-item\">\n" +
                        "                        <div class=\"thumb\">\n" +
                        "                            <div class=\"hover-efect\"></div>\n" +
                        "                            <video poster="+item.poster+" width=\"304\" controls>\n" +
                        "                                <source src="+item.videoURL+" type=\"video/mp4\">\n" +
                        "                            </video>\n" +
                        "                        </div>\n" +
                        "                        <div style='width: 304px; height: 100px;' class=\"video-info\">\n" +
                        "                            <a target='_blank' style='font-size: 10px' href="+item.videoLink+" class=\"title\">"+item.title+"</a>\n" +
                        "                            <a target='_blank' class=\"channel-name\" href="+item.channelLink+">"+item.channelName+"<span>\n" +
                        "                            <i class=\"fa fa-check-circle\"></i></span></a>\n" +

                        "                            <span class=\"date\"><i class=\"fa fa-clock-o\"></i>"+item.uploadTime+"</span>\n" +
                        "                        </div>\n" +
                        "                    </div>\n" +
                        "                </div>";
                });




                $("#allmyvideos").html(vdo);


            },
            complete: function(xhr){
                if(xhr.status >= 400)
                {
                    $('#err').html(xhr.status + ": " + xhr.statusText);
                }
            }
        });

});