using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Famoser.YoutubeDataApiWrapper.Portable.RequestServices;
using Famoser.YoutubeDataApiWrapper.Portable.RequestBuilders;
using Famoser.YoutubeDataApiWrapper.Portable.Util;

using Google.Apis.Discovery;
using Google.Apis.Download;
using Google.Apis.Http;
using Google.Apis.Json;
using Google.Apis.Logging;
using Google.Apis.Requests;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util;
using Google.Apis;

using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Client;

namespace MyVideos
{
	

	/*using Google.Apis.Auth.OAuth2;
	using Google.Apis.Services;
	using Google.Apis.Upload;
	using Google.Apis.Util.Store;
	using Google.Apis.YouTube.v3;
	using Google.Apis.YouTube.v3.Data;*/

		/// <summary>
		/// YouTube Data API v3 sample: search by keyword.
		/// Relies on the Google APIs Client Library for .NET, v1.7.0 or higher.
		/// See https://developers.google.com/api-client-library/dotnet/get_started
		///
		/// Set ApiKey to the API key value from the APIs & auth > Registered apps tab of
		///   https://cloud.google.com/console
		/// Please ensure that you have enabled the YouTube Data API for your project.
		/// </summary>
		public class Search
		{
			[STAThread]
			static void Main(string[] args)
			{
				Console.WriteLine("YouTube Data API: Search");
				Console.WriteLine("========================");

				try
				{
					new Search().Run().Wait();
				}
				catch (AggregateException ex)
				{
					foreach (var e in ex.InnerExceptions)
					{
						Console.WriteLine("Error: " + e.Message);
					}
				}

				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
			}

			private async Task Run()
			{
				var youtubeService = new  YouTubeService(GetType().ToString(), "AIzaSyDd21dE45iyUtqOS3i3vRBgrdBHBML_sWc");
				var youtubeQuery = new YouTubeQuery();
				youtubeQuery.Uri = new Uri("https://www.googleapis.com/youtube/v3");
				var searchListRequest = youtubeService.GetPlaylist(youtubeQuery);//.Id = new AtomId("Xh_1pYNabc0");//.List("snippet,contentDetails");
																				 //searchListRequest.Q = "Google"; // Replace with your search term.
																				 //searchListRequest.MaxResults = 50;


			// Call the search.list method to retrieve results matching the specified query term.
				var searchListResponse = searchListRequest.Title;

				/*List<string> videos = new List<string>();
				List<string> channels = new List<string>();
				List<string> playlists = new List<string>();

				// Add each result to the appropriate list, and then display the lists of
				// matching videos, channels, and playlists.
				foreach (var searchResult in searchListResponse.Items)
				{
					switch (searchResult.Id.Kind)
					{
						case "youtube#video":
							videos.Add(string.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
							break;

						case "youtube#channel":
							channels.Add(string.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
							break;

						case "youtube#playlist":
							playlists.Add(string.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
							break;
					}
				}

				Console.WriteLine(string.Format("Videos:\n{0}\n", string.Join("\n", videos)));
				Console.WriteLine(string.Format("Channels:\n{0}\n", string.Join("\n", channels)));
				Console.WriteLine(string.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));*/
			}
		}
}
