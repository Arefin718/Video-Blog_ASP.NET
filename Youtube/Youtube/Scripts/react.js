
function UpdateReact(x, videoId, userId) {

    x.classList.toggle("fa-thumbs-down");

    $.ajax({
        type: "POST",
        data: {
            VideoId: videoId,
            UserId: userId
        },
        url: "/react/UpdateReact/"
    });
}