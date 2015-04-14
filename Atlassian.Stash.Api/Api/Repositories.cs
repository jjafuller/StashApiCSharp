﻿using Atlassian.Stash.Api.Entities;
using Atlassian.Stash.Api.Helpers;
using Atlassian.Stash.Api.Workers;
using System.Threading.Tasks;

namespace Atlassian.Stash.Api.Api
{
    public class Repositories
    {
        private const string MANY_REPOSITORIES = "rest/api/1.0/projects/{0}/repos";
        private const string ONE_REPOSITORY = "rest/api/1.0/projects/{0}/repos/{1}";
        private const string MANY_TAGS = "rest/api/1.0/projects/{0}/repos/{1}/tags";
        private const string MANY_FILES = "rest/api/1.0/projects/{0}/repos/{1}/files";
        private const string ONE_FILE = "rest/api/1.0/projects/{0}/repos/{1}/browse/{2}";
        private const string GROUP_PERMISSIONS = "rest/api/1.0/projects/{0}/repos/{1}/permissions/groups";
        private const string USER_PERMISSIONS = "rest/api/1.0/projects/{0}/repos/{1}/permissions/users";
        private const string BRANCHES = "rest/api/1.0/projects/{0}/repos/{1}/branches";

        private HttpCommunicationWorker _httpWorker;

        internal Repositories(HttpCommunicationWorker httpWorker)
        {
            _httpWorker = httpWorker;
        }
        public async Task<ResponseWrapper<Repository>> Get(string projectKey, RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(MANY_REPOSITORIES, requestOptions, projectKey);

            ResponseWrapper<Repository> response = await _httpWorker.GetAsync<ResponseWrapper<Repository>>(requestUrl);

            return response;
        }

        public async Task<Repository> GetById(string projectKey, string repositorySlug)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(ONE_REPOSITORY, null, projectKey, repositorySlug);

            Repository response = await _httpWorker.GetAsync<Repository>(requestUrl);

            return response;
        }

        public async Task<ResponseWrapper<Tag>> GetTags(string projectKey, string repositorySlug, RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(MANY_TAGS, requestOptions, projectKey, repositorySlug);

            ResponseWrapper<Tag> response = await _httpWorker.GetAsync<ResponseWrapper<Tag>>(requestUrl);

            return response;
        }

        public async Task<ResponseWrapper<string>> GetFiles(string projectKey, string repositorySlug, RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(MANY_FILES, requestOptions, projectKey, repositorySlug);

            ResponseWrapper<string> response = await _httpWorker.GetAsync<ResponseWrapper<string>>(requestUrl);

            return response;
        }

        public async Task<File> GetFileContents(string projectKey, string repositorySlug, string path, RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(ONE_FILE, requestOptions, projectKey, repositorySlug, path);
            File response = await _httpWorker.GetAsync<File>(requestUrl);

            return response;
        }

        public async Task<ResponseWrapper<UserPermission>> GetUserPermissions(string projectKey, string repositorySlug, RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(USER_PERMISSIONS, requestOptions, projectKey, repositorySlug);

            ResponseWrapper<UserPermission> response = await _httpWorker.GetAsync<ResponseWrapper<UserPermission>>(requestUrl);

            return response;
        }

        public async Task<ResponseWrapper<GroupPermission>> GetGroupPermissions(string projectKey, string repositorySlug, RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(GROUP_PERMISSIONS, requestOptions, projectKey, repositorySlug);

            ResponseWrapper<GroupPermission> response = await _httpWorker.GetAsync<ResponseWrapper<GroupPermission>>(requestUrl);

            return response;
        }

        public async Task<ResponseWrapper<Branch>> GetBranches(string projectKey, string repositorySlug, RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(BRANCHES, requestOptions, projectKey, repositorySlug);

            ResponseWrapper<Branch> response = await _httpWorker.GetAsync<ResponseWrapper<Branch>>(requestUrl);

            return response;
        }

        public async Task<Repository> Create(string projectKey, Repository repository)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(MANY_REPOSITORIES, null, projectKey);

            Repository response = await _httpWorker.PostAsync<Repository>(requestUrl, repository);

            return response;
        }

        public async Task Delete(string projectKey, string repositorySlug)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(ONE_REPOSITORY, null, projectKey, repositorySlug);

            await _httpWorker.DeleteAsync(requestUrl);
        }
    }
}
