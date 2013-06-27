﻿using System.Net;
using Newtonsoft.Json.Linq;

namespace Stash
{
    class GetRepoRequest : StashRequestBase<Repository>
    {
        private readonly string _projectKey;
        private readonly string _repoName;

        public GetRepoRequest(string projectKey, string repoName, Settings settings) : base(settings)
        {
            _projectKey = projectKey;
            _repoName = repoName;
        }

        protected override void WriteRequestBody(HttpWebRequest request)
        {
        }

        protected override string ApiUrl
        {
            get
            {
                return string.Format("/rest/api/latest/projects/{0}/repos/{1}",
                                     _projectKey, _repoName);
            }
        }

        protected override string RequestMethod
        {
            get { return "GET"; }
        }

        protected override Repository ParseResponse(JObject json)
        {
            return Repository.Parse(json);
        }
    }
}
