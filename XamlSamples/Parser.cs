using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace MyVideos
{
	public class Parser
	{
		private string FileName;
		private string KeySymbols;
		private string KeySymbolsParsed;

		private Dictionary<string, string> SymsToParse = new Dictionary<string, string>
		{
			{"&#58", ":"},
			{"&#47", "/"},
			{"&#46", "."},
			{"&#63", "?"},
			{"&#61", "="}
		};

		public Parser(string fileName)
		{
			FileName = fileName;
			KeySymbols = "https&#58;&#47;&#47;www&#46;youtube&#46;com&#47;watch&#63;v&#61;";
			KeySymbolsParsed = "https://www.youtube.com/watch?v=";
		}

		public Dictionary<string, string> GetVideos()
		{
			var result = new Dictionary<string, string>();

			FileStream file = new FileStream(FileName, FileMode.Open, FileAccess.Read);
			StreamReader filereader = new StreamReader(file);

			string fullDocument = filereader.ReadToEnd();
			string currentReference;
			string currentVideo;
			int currentVideoStartPos = fullDocument.IndexOf(KeySymbols, StringComparison.Ordinal);
			int currentVideoEndPos;
			while (currentVideoStartPos != 0)
			{
				try
				{
					fullDocument = fullDocument.Substring(currentVideoStartPos);
					currentVideoEndPos = fullDocument.IndexOf("</p>", StringComparison.Ordinal);

					currentVideo = fullDocument.Substring(currentVideoStartPos + KeySymbols.Length, currentVideoEndPos);
					currentReference = KeySymbolsParsed + currentVideo;
					result.Add(currentReference, currentVideo);

					currentVideoStartPos = fullDocument.IndexOf(KeySymbols, StringComparison.Ordinal);
				}
				catch (Exception ex)
				{
					Debug.WriteLine("inWhile bad args..." + ex.Message);
				}
			}
			return result;
		}
	}
}
