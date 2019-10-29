
function VideoApprovalStatusChange(videoId) {
    $.ajax({
        type: "POST",
        url: "/report/ChangeVideoApproval/" + videoId
    });
}

function ChannelStatusChange(channelId) {
    $.ajax({
        type: "POST",
        url: "/report/ChangeChannelStatus/" + channelId
    });
}


