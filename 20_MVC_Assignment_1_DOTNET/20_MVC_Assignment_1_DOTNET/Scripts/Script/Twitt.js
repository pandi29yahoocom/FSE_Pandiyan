$(document).ready(function () {
    GetTwittdata();
    $('#btnTwitt').on('click', function () {
        if ($('#txtMessage').val() == '') {
            alert('Enter message')
            return;
        }
        else {
            PostTwitt();
        }
    });
    return false;
});

function PostTwitt() {
    $.ajax({
        type: 'POST',
        url: "Twitt",
        dataType: 'json',
        data: { 'msg': $('#txtMessage').val() },
        success: function (data) {
            $('#txtMessage').val('');
            loadTwitt(data);
        },
        error: function (ex) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
        }
    });
}

function GetTwittdata() {
    $.ajax
    ({
        type: 'POST',
        url: "GetTweets",
        dataType: 'json',
        data: {},
        success: function (data) {
            loadTwitt(data);
        },
        error: function (ex) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
        }
    });
}
function loadTwitt(data) {
    $(".tweetTr").remove();
    $.each(data.Tweets, function (i, item) {
        var rows = '<tr class="tweetTr">' +
            "<td class='hide'>" + item.tweetid + "</td>" +
            "<td >" + item.userid + "</td>" +
            "<td >" + item.message + "</td>" +
            "<td >" + item.created + "</td>" +
            "</tr>";
        $('#tblEmployeetbody').append(rows);
    });
    $('#totTweets').text(data.TweetsCnt);
    $('#totFollowing').text(data.FollowingCnt);
    $('#totFollowers').text(data.FollowersCnt);
}
