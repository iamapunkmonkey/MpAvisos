$(document).ready(function () {

    console.log("test");
    $('#search-button').click(function (e) {

        var searchterm = $('#search').val();
        console.log(searchterm);

        $.ajax({
            url: 'http://search.twitter.com/search.json?q=' + searchterm + '&rpp=20&include_entities=false&result_type=recent',
            dataType: 'jsonp',
            type: 'GET',
            jsonpCallback: 'handle_tweets'
        });
    });

});

function handle_tweets(data) {
    
    //clear users from userdiv
    ClearUsersAndTweets();

    for (var i = 0; i < data.results.length; i++) {
        var tweet = data.results[i];
        var div = CreateUserDiv(tweet);
        $('#user-list').append(div);
        var li = AddTweetToTweetList(tweet);
        $('#tweet-list').append(li);
        console.log(tweet.from_user);
        console.log(tweet);
    }

}
//create the user div
//using tweet data
//prefix and append element tags
function CreateUserDiv(tweet, prefix, append) {

    //defaults 
    prefix = typeof prefix !== 'undefined' ? prefix : '';
    append = typeof append !== 'undefined' ? append : '';

    var div = $(prefix + '<div class="user"><a title="' + tweet.from_user + '" href="https://twitter.com/#!/' + tweet.from_user + '" target="_blank"><img width="48" height="48" src="' + tweet.profile_image_url + '"></img></a></div>');
    return div;
}

function AddTweetToTweetList(tweet) {
    var li = CreateUserDiv(tweet, '<li class="tweet">');
    li.append('<span>' + tweet.text + '</span></li>');
    return li;
}


//Clearing
function ClearUsersAndTweets() {
    $('.user').remove();
    $('.tweet').remove();
}