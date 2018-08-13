using System;
using System.Collections.Generic;
using System.Net;
using TweetSharp;

namespace twitterApp
{
    internal class Program
    {
        private static string _consumerKey = "xxxx";
        private static string _consumerSecret = "xxxxx";
        private static string _accessToken = "xxxxxx";
        private static string _accessTokenSecret = "xxxxxxxxx";

        private static void Main(string[] args)
        {
            var _service = GetAuthenticatedService();
            IAsyncResult result = _service.BeginListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions { Count = 30 });
            IEnumerable<TwitterStatus> tweets = _service.EndListTweetsOnHomeTimeline(result);
            foreach (var tweet in tweets)
            {
                Console.WriteLine("{0} falou '{1}'", tweet.User.ScreenName, tweet.Text);
            }
        }

        private static TwitterService GetAuthenticatedService()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            service.TraceEnabled = true;
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            return service;
        }
    }
}