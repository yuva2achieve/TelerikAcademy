using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Application.Controllers
{
    public class BaseController : Controller
    {
        const string HashTagRegex = @"#\S+";

        public BaseController(IUowData data)
        {
            this.Data = data;
        }

        protected HashSet<HashTag> GetTagsFromContent(string content, IEnumerable<HashTag> tags)
        {
            MatchCollection m = Regex.Matches(content, HashTagRegex);
            HashSet<HashTag> hashTags = new HashSet<HashTag>();
            foreach (var match in m)
            {
                string tagName = match.ToString();
                var tag = tags.FirstOrDefault(t => t.Name.ToLower() == tagName.ToLower());

                if (tag == null)
                {
                    tag = new HashTag() { Name = tagName };
                }

                if (!hashTags.Contains(tag))
                {
                    hashTags.Add(tag);
                }
            }

            return hashTags;
        }

        protected string ReplaceTagsInContent(Tweet tweet)
        {
            foreach (var hashTag in tweet.HashTags)
            {
                var parsedTag = this.ParseTagToAction(hashTag);
                tweet.Content = tweet.Content.Replace(hashTag.Name, parsedTag);
            }

            return tweet.Content;
        }

        protected string ParseTagToAction(HashTag tag)
        {
            StringBuilder sb = new StringBuilder();
            var url = Url.Action("Search", "Tags", new { id = tag.Id });
            sb.Append("<a href=\"");
            sb.Append(url);
            sb.Append("\" >" + HttpUtility.HtmlEncode(tag.Name) + "</a>");
            return sb.ToString();
        }

        protected IUowData Data { get; set; }
	}
}