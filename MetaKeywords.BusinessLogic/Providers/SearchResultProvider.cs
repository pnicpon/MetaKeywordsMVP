using HtmlAgilityPack;
using MetaKeywords.DataModel.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MetaKeywords.BusinessLogic.Providers
{
    public static class SearchResultProvider
    {
        public static List<MetaKeyword> GetSearchResult(string url)
        {
            // Set valid url
            if (url.StartsWith("http://") == false && url.StartsWith("https://") == false)
                url = "http://" + url;
            
            // HtmlAgilityPack
            var webGet = new HtmlWeb();
            var document = webGet.Load(url);
            var metaTags = document.DocumentNode.SelectNodes("//meta");
            if (metaTags != null)
            {
                // Get keywords list
                List<string> keywordsList = new List<string>();

                foreach (var tag in metaTags)
                {
                    var tagName = tag.Attributes["name"];
                    var tagContent = tag.Attributes["content"];
                    var tagProperty = tag.Attributes["property"];
                    if (tagName != null && tagContent != null && tagName.Value.ToLower() == "keywords")
                    {
                        // Add keywords to list
                        keywordsList.AddRange(tagContent.Value.Split(',').ToList());
                    }
                }

                // Get search result
                string innerText = document.DocumentNode.SelectSingleNode("//body").InnerText.ToLower();
                List<MetaKeyword> result = new List<MetaKeyword>();

                if (string.IsNullOrWhiteSpace(innerText) == false && keywordsList.Count != 0)
                {
                    foreach (string key in keywordsList)
                    {
                        if (string.IsNullOrWhiteSpace(key))
                            continue;

                        int count = 0;
                        foreach (Match match in Regex.Matches(innerText, key.Trim(), RegexOptions.IgnoreCase))
                            count++;

                        result.Add(new MetaKeyword { Keyword = key, Count = count });
                    }
                }

                return result;
            }

            return null;
        }
    }
}
