/*
$( document ).ready(function() {

$("#commentform").submit(function (e) {


    if ($("#UserId").val() == 0) {
        window.location.href = "/User/Login";
    }

    var Postid = $("#PostId").val();
    var UserID = $("#UserId").val();
    var Time = $("#Time").val();
    var CommentDescription = $("#CommentDescription").val();

    var comment = {
        VideoId: Postid,
        UserId: UserID,
        CommentTime: Time,
        CommentContent: CommentDescription,
        ParentCommentId: null,
    }

    //console.log(comment);

    $.ajax({
        type: "POST",
        url: "/Comment/Insert",
        data: comment,
        success: function (data) {

            //    console.log(data.comment.Name);


            var newComment =
                "                            <li>\n" + "                  <div class=\"post_author\">\n" +
                "                                <div class=\"img_in\">\n" +
                "                                    <a href=\"#\"><img style='' src=" + data.comment.Image + " alt=\"\"></a>\n" +
                "                                </div>\n" +
                "                                <a href=\"#\" class=\"author-name\">" + data.comment.Name + "</a>\n" +
                "                                <time datetime=\"2017-03-24T18:18\">" + data.comment.CommentTime + "</time>\n" +
                "                            </div>\n" +
                "                            <p>" + data.comment.CommentContent + "</p>\n" +
                "<a onclick=\"dynamiccommentreply(" + data.comment.Id + ")\" style=\"cursor:pointer\" class=\"reply\">Reply</button>" +
                "                            </li>\n";

            $("#comment-display-area").prepend(newComment);


            $("#CommentDescription").val("");

            //Notification insert
            var notification = {
                NotifiedTo: $("#UserToNotify").val(),
                Content: "Commented on your video",
                Type: "comment",
                NotifiedBy: $("#UserId").val(),
                VideoId: Postid
            }


            // console.log(notification);
            $.ajax({
                type: 'POST',
                url: '/Notification/Insert/',
                data: notification
            }).done(function () {
                //  alert(Postid);
            });

        }
    }).done(function () {

        // var comment = document.getElementById('CommentDescription').value;




        

    });


    e.preventDefault();




});
});
function commentreply(parentCommentId) {
    $("#commentreplydiv_" + parentCommentId).slideToggle();
}
$( document ).ready(function() {
function commentreplysubmit(parentId, parentCommentUserId) {

    $("#commentreplyform_" + parentId).one('submit', function (e) {

        if ($("#UserId").val() == 0) {
            window.location.href = "/User/Login";
        }

        var Postid = $("#PostId_" + parentId).val();
        var UserID = $("#UserId_" + parentId).val();
        var Time = $("#Time_" + parentId).val();
        var CommentDescription = $("#CommentDescription_" + parentId).val();
        var PCommentId = parentId;

        var comment = {
            VideoId: Postid,
            UserId: UserID,
            CommentTime: Time,
            CommentContent: CommentDescription,
            ParentCommentId: PCommentId
        }
        //console.log(comment);


        $.ajax({
            type: "POST",
            url: "/Comment/Insert",
            data: comment,
            success: function (data) {
                // console.log(data);

                var newComment = "                         <li>\n" +
                    "                                <div class=\"post_author\">\n" +
                    "                                    <div class=\"img_in\">\n" +
                    "                                    <a href=\"#\"><img style='' src=" + data.comment.Image + " alt=\"\"></a>\n" +
                    "                                    </div>\n" +
                    "                                    <a href=\"#\" class=\"author-name\">" + data.comment.Name + "</a>\n" +
                    "                                    <time datetime=\"2017-03-24T18:18\">" + data.comment.CommentTime + "</time>\n" +
                    "                                </div>\n" +
                    "                                <p>" + data.comment.CommentContent + "</p>\n";


                //  $(newComment).appendTo("#replyforthecomment_" + data.comment.ParentCommentId);

                $("#replyforthecomment_" + data.comment.ParentCommentId).append(newComment);
                //$("#comment-display-area").prepend(newComment);
                $("#CommentDescription").val("");


                //Notification insert
                var notification = {
                    NotifiedTo: parentCommentUserId,
                    Content: "reply on your comment",
                    Type: "reply",
                    NotifiedBy: $("#UserId").val(),
                    VideoId: Postid
                }


                // console.log(notification);
                $.ajax({
                    type: 'POST',
                    url: '/Notification/Insert/',
                    data: notification
                }).done(function () {
                    // alert(Postid);
                });

            }
        }).done(function () {


            


        });

        e.preventDefault();
        return false;
    });

}
});
function dynamiccommentreply(commentId) {

    $('#dynamiccommentreplydiv_').attr('id', 'dynamiccommentreplydiv_' + commentId);
    $('#dynamiccommentreplyform_').attr('id', 'dynamiccommentreplyform_' + commentId);
    $('#PostId_').attr('id', 'PostId_' + commentId);
    $('#UserId_').attr('id', 'UserId_' + commentId);
    $('#Time_').attr('id', 'Time_' + commentId);
    $('#ParentCommentId_').attr('id', 'ParentCommentId_' + commentId);
    $('#ParentCommentId_').val(commentId);
    $('#CommentDescription_').attr('id', 'CommentDescription_' + commentId);



    $('#dynamiccommentreplydiv_' + commentId).attr("onKeyDown", "if (event.keyCode == 13) dynamiccommentreplysubmit(" + commentId + ");");

    $('#dynamiccommentreplydiv_' + commentId).slideToggle();
}
$( document ).ready(function() {
function dynamiccommentreplysubmit(parentId) {
    $("#dynamiccommentreplyform_" + parentId).one('submit', function (e) {

        if ($("#UserId").val() == 0) {
            window.location.href = "/User/Login";
        }

        var Postid = $("#PostId_" + parentId).val();
        var UserID = $("#UserId_" + parentId).val();
        var Time = $("#Time_" + parentId).val();
        var CommentDescription = $("#CommentDescription_" + parentId).val();
        var PCommentId = parentId;

        var comment = {
            VideoId: Postid,
            UserId: UserID,
            CommentTime: Time,
            CommentContent: CommentDescription,
            ParentCommentId: PCommentId
        }
        //console.log(comment);


        $.ajax({
            type: "POST",
            url: "/Comment/Insert",
            data: comment,
            success: function (data) {
                console.log(data);

                var newComment = "                        <ul class=\"children\">\n" +
                    "                            <li>\n" +
                    "                                <div class=\"post_author\">\n" +
                    "                                    <div class=\"img_in\">\n" +
                    "                                    <a href=\"#\"><img style='' src=" + data.comment.Image + " alt=\"\"></a>\n" +
                    "                                    </div>\n" +
                    "                                    <a href=\"#\" class=\"author-name\">" + data.comment.Name + "</a>\n" +
                    "                                    <time datetime=\"2017-03-24T18:18\">" + data.comment.CommentTime + "</time>\n" +
                    "                                </div>\n" +
                    "                                <p>" + data.comment.CommentContent + "</p>\n" +
                    "                            </li>\n" +
                    "                        </ul>";


                //  $(newComment).appendTo("#replyforthecomment_" + data.comment.ParentCommentId);

                $("#comment-display-area").append(newComment);

                //$("#comment-display-area").prepend(newComment);
                $("#CommentDescription").val("");

                //Notification insert
                var notification = {
                    NotifiedTo: parentCommentUserId,
                    Content: "reply on your comment",
                    Type: "reply",
                    NotifiedBy: $("#UserId").val(),
                    VideoId: Postid
                }


                // console.log(notification);
                $.ajax({
                    type: 'POST',
                    url: '/Notification/Insert/',
                    data: notification
                }).done(function () {
                    // alert(Postid);
                });
            }
        }).done(function () {


           


        });

        e.preventDefault();

    });


}
});
*/

$("#commentform").submit(function (e) {


    if ($("#UserId").val() == 0) {
        window.location.href = "/User/Login";
    }

    var Postid = $("#PostId").val();
    var UserID = $("#UserId").val();
    var Time = $("#Time").val();
    var CommentDescription = $("#CommentDescription").val();

    var comment = {
        VideoId: Postid,
        UserId: UserID,
        CommentTime: Time,
        CommentContent: CommentDescription,
        ParentCommentId: null,
    }

    //console.log(comment);

    $.ajax({
        type: "POST",
        url: "/Comment/Insert",
        data: comment,
        success: function (data) {

            //    console.log(data.comment.Name);


            var newComment =
                "                            <li>\n" + "                  <div class=\"post_author\">\n" +
                "                                <div class=\"img_in\">\n" +
                "                                    <a href=\"#\"><img style='' src=" + data.comment.Image + " alt=\"\"></a>\n" +
                "                                </div>\n" +
                "                                <a href=\"#\" class=\"author-name\">" + data.comment.Name + "</a>\n" +
                "                                <time datetime=\"2017-03-24T18:18\">" + data.comment.CommentTime + "</time>\n" +
                "                            </div>\n" +
                "                            <p>" + data.comment.CommentContent + "</p>\n" +
                "<a onclick=\"dynamiccommentreply(" + data.comment.Id + ")\" style=\"cursor:pointer\" class=\"reply\">Reply</button>" +
                "                            </li>\n";

            $("#comment-display-area").prepend(newComment);


            $("#CommentDescription").val("");

            //Notification insert
            var notification = {
                NotifiedTo: $("#UserToNotify").val(),
                Content: "Commented on your video",
                Type: "comment",
                NotifiedBy: $("#UserId").val(),
                VideoId: Postid
            }

          
            console.log(notification);
            $.ajax({
                type: 'POST',
                url: '/Notification/Insert',
                data: notification
            }).done(function () {
                //  alert(Postid);
            });
        }
    });


    e.preventDefault();




});

function commentreply(parentCommentId) {
    $("#commentreplydiv_" + parentCommentId).slideToggle();
}

function commentreplysubmit(parentId, parentCommentUserId) {

    $("#commentreplyform_" + parentId).one('submit', function (e) {

        if ($("#UserId").val() == 0) {
            window.location.href = "/User/Login";
        }

        var Postid = $("#PostId_" + parentId).val();
        var UserID = $("#UserId_" + parentId).val();
        var Time = $("#Time_" + parentId).val();
        var CommentDescription = $("#CommentDescription_" + parentId).val();
        var PCommentId = parentId;

        var comment = {
            VideoId: Postid,
            UserId: UserID,
            CommentTime: Time,
            CommentContent: CommentDescription,
            ParentCommentId: PCommentId
        }
        //console.log(comment);


        $.ajax({
            type: "POST",
            url: "/Comment/Insert",
            data: comment,
            success: function (data) {
                // console.log(data);

                var newComment = "                         <li>\n" +
                    "                                <div class=\"post_author\">\n" +
                    "                                    <div class=\"img_in\">\n" +
                    "                                    <a href=\"#\"><img style='' src=" + data.comment.Image + " alt=\"\"></a>\n" +
                    "                                    </div>\n" +
                    "                                    <a href=\"#\" class=\"author-name\">" + data.comment.Name + "</a>\n" +
                    "                                    <time datetime=\"2017-03-24T18:18\">" + data.comment.CommentTime + "</time>\n" +
                    "                                </div>\n" +
                    "                                <p>" + data.comment.CommentContent + "</p>\n";


                //  $(newComment).appendTo("#replyforthecomment_" + data.comment.ParentCommentId);

                $("#replyforthecomment_" + data.comment.ParentCommentId).append(newComment);
                //$("#comment-display-area").prepend(newComment);
                $("#CommentDescription").val("");

                //Notification insert
                var notification = {
                    NotifiedTo: parentCommentUserId,
                    Content: "reply on your comment",
                    Type: "reply",
                    NotifiedBy: $("#UserId").val(),
                    VideoId: Postid
                }


                // console.log(notification);
                $.ajax({
                    type: 'POST',
                    url: '/Notification/Insert/',
                    data: notification
                }).done(function () {
                    // alert(Postid);
                });
            }
        });

        e.preventDefault();
        return false;
    });

}

function dynamiccommentreply(commentId) {

    $('#dynamiccommentreplydiv_').attr('id', 'dynamiccommentreplydiv_' + commentId);
    $('#dynamiccommentreplyform_').attr('id', 'dynamiccommentreplyform_' + commentId);
    $('#PostId_').attr('id', 'PostId_' + commentId);
    $('#UserId_').attr('id', 'UserId_' + commentId);
    $('#Time_').attr('id', 'Time_' + commentId);
    $('#ParentCommentId_').attr('id', 'ParentCommentId_' + commentId);
    $('#ParentCommentId_').val(commentId);
    $('#CommentDescription_').attr('id', 'CommentDescription_' + commentId);



    $('#dynamiccommentreplydiv_' + commentId).attr("onKeyDown", "if (event.keyCode == 13) dynamiccommentreplysubmit(" + commentId + ");");

    $('#dynamiccommentreplydiv_' + commentId).slideToggle();
}

function dynamiccommentreplysubmit(parentId) {
    $("#dynamiccommentreplyform_" + parentId).one('submit', function (e) {

        if ($("#UserId").val() == 0) {
            window.location.href = "/User/Login";
        }

        var Postid = $("#PostId_" + parentId).val();
        var UserID = $("#UserId_" + parentId).val();
        var Time = $("#Time_" + parentId).val();
        var CommentDescription = $("#CommentDescription_" + parentId).val();
        var PCommentId = parentId;

        var comment = {
            VideoId: Postid,
            UserId: UserID,
            CommentTime: Time,
            CommentContent: CommentDescription,
            ParentCommentId: PCommentId
        }
        //console.log(comment);


        $.ajax({
            type: "POST",
            url: "/Comment/Insert",
            data: comment,
            success: function (data) {
                console.log(data);

                var newComment = "                        <ul class=\"children\">\n" +
                    "                            <li>\n" +
                    "                                <div class=\"post_author\">\n" +
                    "                                    <div class=\"img_in\">\n" +
                    "                                    <a href=\"#\"><img style='' src=" + data.comment.Image + " alt=\"\"></a>\n" +
                    "                                    </div>\n" +
                    "                                    <a href=\"#\" class=\"author-name\">" + data.comment.Name + "</a>\n" +
                    "                                    <time datetime=\"2017-03-24T18:18\">" + data.comment.CommentTime + "</time>\n" +
                    "                                </div>\n" +
                    "                                <p>" + data.comment.CommentContent + "</p>\n" +
                    "                            </li>\n" +
                    "                        </ul>";


                //  $(newComment).appendTo("#replyforthecomment_" + data.comment.ParentCommentId);

                $("#comment-display-area").append(newComment);

                //$("#comment-display-area").prepend(newComment);
                $("#CommentDescription").val("");


            }
        });

        e.preventDefault();

    });


}