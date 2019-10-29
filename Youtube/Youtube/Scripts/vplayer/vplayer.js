$(function () {
    $("#playlist li").on("click", function () {
        $("#videoarea").attr({
            "src": $(this).attr("movieurl"),
            "poster": "",
            "autoplay": "autoplay"
        })
    })
    $("#videoarea").attr({
        "src": $("#playlist li").eq(0).attr("movieurl"),
        "poster": $("#playlist li").eq(0).attr("moviesposter")
    })

})



    function nextsongToPLay(currentVideoId) {

        var playlistSong = $(".songOfPlaylist")

        var songId = 0;

        for (var i = 0; i < playlistSong.length; i++){
            if (playlistSong[i].id == currentVideoId) {
                songId = i;
                break;
            }
  
        }

        window.location.href = "/video/view/" + playlistSong[songId+1].id;


    }
    
