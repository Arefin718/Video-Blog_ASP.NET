var figure = $(".video").hover(hoverVideo, hideVideo);

function hoverVideo(e) {
    $('video', this).get(0).play();
    $('video', this).get(0).muted = true;
}

function hideVideo(e) {
    $('video', this).get(0).pause();
}

var videos = $(".uploaded-video");
var dura = $(".video-duration");




for (var i = 0; i < videos.length; i++) {
    // videos[i].currentTime = 10;
    // $(dura[i]).html(videos[i].duration);
}


window.setInterval(function (t) {

    for (var i = 0; i < videos.length; i++) {
        if (videos[i].readyState > 0) {

            var minutes = parseInt(videos[i].duration / 60, 10);
            var seconds = videos[i].duration % 60;


            $(dura[i]).html(minutes + ":" + seconds.toFixed(0));
            clearInterval(t);
        }
    }

}, 100);


function Private(cid) {

    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: '/video/private/' + cid, // the url where we want to POST
    }).done(function () {

        if ($("#private_"+cid).hasClass('btn-warning')) {
            $('#private_'+cid).addClass('btn-success').removeClass('btn-warning');
            $("#private_" + cid).html("Public");

            $("#publicPoster_"+cid).attr('poster', '~/Content/images/private.png');
            $("#privatePoster_"+cid).attr('poster', '~/Content/images/private.png');


           

            //<img src="~/Content/images/private.png" />
        }
        else if ($("#private_" + cid).hasClass("btn-success")) {
            $('#private_'+cid).addClass('btn-warning').removeClass('btn-success');
            $("#private_" + cid).html("Private");

            $("#publicPoster_" + cid).attr('poster', '@item.Poster');
            $("#privatePoster_" + cid).attr('poster', '@item.Poster');


        }


        if ($("#public_" + cid).hasClass("btn-warning")) {
            $('#public_' + cid).addClass('btn-success').removeClass('btn-warning');

            $("#public_" + cid).html("Public");
            $("#publicPoster_" + cid).attr('poster', '~/Content/images/private.png');
            $("#privatePoster_" + cid).attr('poster', '~/Content/images/private.png');

        }
        else if ($("#public_" + cid).hasClass("btn-success")) {
            $('#public_' + cid).addClass('btn-warning').removeClass('btn-success');
            $("#public_" + cid).html("Private");
            $("#publicPoster_" + cid).attr('poster', '@item.Poster');
            $("#privatePoster_" + cid).attr('poster', '@item.Poster');

        }

    });
}