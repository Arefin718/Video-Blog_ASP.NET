function songToAddplaylist(songId) {
    
        $("#myplaylisttoaddvideo_" + songId).slideToggle();

}


function addtoplaylist(playlistId, videoId) {

    playlist = {
        PlayListId: playlistId,
        VideoId: videoId
    }

    $.ajax({
        type: "POST",
        url: "/PlaylistVideo/Insert",
        data: playlist,
        success: function (data) {

            console.log(data);

            if (data == true) {
                $("#unsuccessAlert").show();
            }
            else if (data == false) {
                $("#successAlert").show();
            }

        }

    });

   
}



