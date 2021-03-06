﻿using Atlassian.Stash.Api;
using Atlassian.Stash.Workers;

namespace Atlassian.Stash
{
    public class StashClient
    {
        private readonly HttpCommunicationWorker _httpWorker;

        public StashClient(string baseUrl, string base64Auth = null)
        {
            _httpWorker = new HttpCommunicationWorker(baseUrl, base64Auth);
            InjectDependencies();
        }

        public StashClient(string baseUrl, string username, string password)
        {
            _httpWorker = new HttpCommunicationWorker(baseUrl, username, password);
            InjectDependencies();
        }

        private void InjectDependencies()
        {
            this.Projects = new Projects(_httpWorker);
            this.Groups = new Groups(_httpWorker);
            this.Users = new Users(_httpWorker);
            this.Repositories = new Repositories(_httpWorker);
            this.Branches = new Branches(_httpWorker);
            this.Commits = new Commits(_httpWorker);
            this.PullRequests = new PullRequests(_httpWorker);
            this.Forks = new Forks(_httpWorker);
            this.DefaultReviewerConditions = new DefaultReviewerConditions(_httpWorker);
        }

        public Projects Projects { get; private set; }
        public Groups Groups { get; set; }
        public Users Users { get; private set; }
        public Repositories Repositories { get; private set; }
        public Branches Branches { get; private set; }
        public Commits Commits { get; private set; }
        public PullRequests PullRequests { get; private set; }
        public Forks Forks { get; private set; }
        public DefaultReviewerConditions DefaultReviewerConditions { get; private set; }

    }
}
