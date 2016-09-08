using Atlassian.Stash.Entities;
using Atlassian.Stash.Helpers;
using Atlassian.Stash.Workers;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Atlassian.Stash.Api.Entities;

namespace Atlassian.Stash.Api
{
    public class DefaultReviewerConditions
    {
        private const string ONE_REPOSITORY = "rest/default-reviewers/1.0/projects/{0}/repos/{1}";
        private const string CONDITION = ONE_REPOSITORY + "/condition";
        private const string MANY_CONDITIONS = ONE_REPOSITORY + "/conditions";
        private const string ONE_CONDITION = ONE_REPOSITORY + "/condition/{2}";
        
        private HttpCommunicationWorker _httpWorker;

        internal DefaultReviewerConditions(HttpCommunicationWorker httpWorker)
        {
            _httpWorker = httpWorker;
        }

        public async Task<List<DefaultReviewerCondition>> Get(string projectKey, string repositorySlug, RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(MANY_CONDITIONS, requestOptions, projectKey, repositorySlug);

            //ResponseWrapper<DefaultReviewCondition> response = await _httpWorker.GetAsync<ResponseWrapper<DefaultReviewCondition>>(requestUrl).ConfigureAwait(false);

            List<DefaultReviewerCondition> response = await _httpWorker.GetAsync<List<DefaultReviewerCondition>>(requestUrl).ConfigureAwait(false);

            return response;
        }

        public async Task<DefaultReviewerConditionRequest> Create(string projectKey, string repositorySlug, DefaultReviewerConditionRequest condition)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(CONDITION, null, projectKey, repositorySlug);

            DefaultReviewerConditionRequest response = await _httpWorker.PostAsync<DefaultReviewerConditionRequest>(requestUrl, condition).ConfigureAwait(false);

            return response;
        }

        public async Task Update(string projectKey, string repositorySlug, DefaultReviewerCondition condition)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(ONE_CONDITION, null, projectKey, repositorySlug, condition.Id);

            await _httpWorker.PutAsync<Object>(requestUrl, condition).ConfigureAwait(false);
        }
    }
}
