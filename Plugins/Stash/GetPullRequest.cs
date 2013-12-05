﻿using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Linq;
using System;

namespace Stash
{
    class PullRequest
    {
        //public string Ref { get; set; }
        public static PullRequest Parse(JObject json)
        {
            var request = new PullRequest
            {
                Id = json["id"].ToString(),
                Version = json["version"].ToString(),
                State = json["state"].ToString(),
                Title = json["title"].ToString(),
                Description = json["description"] != null ? json["description"].ToString() : "",
                Author = json["author"]["user"]["displayName"].ToString(),
                SrcProjectName = json["fromRef"]["repository"]["project"]["name"].ToString(),
                SrcRepo = json["fromRef"]["repository"]["name"].ToString(),
                SrcBranch = json["fromRef"]["displayId"].ToString(),
                DestProjectName = json["toRef"]["repository"]["project"]["name"].ToString(),
                DestProjectKey = json["toRef"]["repository"]["project"]["key"].ToString(),
                DestRepo = json["toRef"]["repository"]["name"].ToString(),
                DestBranch = json["toRef"]["displayId"].ToString(),
                CreatedDate = Convert.ToDouble(json["createdDate"].ToString().Substring(0,10))
                
            };
            var reviewers = json["reviewers"];

            if (!reviewers.HasValues)
                request.Reviewers = "None";
            else
            {
                reviewers.ForEach(r => request.Reviewers += r["user"]["displayName"] + "(" + r["approved"] + ")" + System.Environment.NewLine);
                if (request.Reviewers.EndsWith(", "))
                    request.Reviewers = request.Reviewers.Substring(0, request.Reviewers.Length - 2);
            }

            return request;
        }
        public string Id { get; set; }
        public string Version { get; set; }
        public string DestProjectKey { get; set; }
        public string State { get; set; }
        public string SrcProjectName { get; set; }
        public string DestProjectName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reviewers { get; set; }
        public string Author { get; set; }
        public string SrcRepo { get; set; }
        public string SrcBranch { get; set; }
        public string DestRepo { get; set; }
        public string DestBranch { get; set; }
        public double CreatedDate { get; set; }
        public string SrcDisplayName
        {
            get { return string.Format("{0}/{1}", SrcProjectName, SrcRepo); }
        }
        public string DestDisplayName
        {
            get { return string.Format("{0}/{1}", DestProjectName, DestRepo); }
        }
        public string DisplayName
        {
            get { return string.Format("#{0}: {1}, {2}", Id, Title, (ConvertFromUnixTimestamp(CreatedDate)).ToString("yyyy-MM-dd")); }
        }
        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }

    class GetPullRequest : StashRequestBase<List<PullRequest>>
    {
        private readonly string _projectKey;
        private readonly string _repoName;
        public GetPullRequest(string projectKey, string repoName, Settings settings)
            : base(settings)
        {
            _projectKey = projectKey;
            _repoName = repoName;
        }

        protected override object RequestBody
        {
            get { return null; }
        }

        protected override Method RequestMethod
        {
            get { return Method.GET; }
        }

        protected override string ApiUrl
        {
            get
            {
                return string.Format("/rest/api/latest/projects/{0}/repos/{1}/pull-requests?directions=incoming&order=oldest",
                                     _projectKey, _repoName);
            }
        }

        protected override List<PullRequest> ParseResponse(JObject json)
        {
            var result = new List<PullRequest>();
            foreach (JObject val in json["values"])
            {
                result.Add(PullRequest.Parse(val));
            }
            return result;
        }
    }
}
