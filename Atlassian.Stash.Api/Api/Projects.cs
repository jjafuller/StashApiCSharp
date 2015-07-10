using Atlassian.Stash.Api.Entities;
using Atlassian.Stash.Api.Helpers;
using Atlassian.Stash.Api.Workers;
using System.Threading.Tasks;

namespace Atlassian.Stash.Api.Api
{
    public class Projects
    {
        private const string MANY_PROJECTS = "rest/api/1.0/projects";
        private const string ONE_PROJECT = "rest/api/1.0/projects/{0}";
        private const string GROUP_PERMISSIONS = "rest/api/1.0/projects/{0}/permissions/groups";
        private const string USER_PERMISSIONS = "rest/api/1.0/projects/{0}/permissions/users";
        private const string DEFAULT_PERMISSIONS = "rest/api/1.0/projects/{0}/permissions/{1}/all";

        private HttpCommunicationWorker _httpWorker;

        internal Projects(HttpCommunicationWorker httpWorker)
        {
            _httpWorker = httpWorker;
        }

        public async Task<ResponseWrapper<Project>> Get(RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(MANY_PROJECTS, requestOptions);

            ResponseWrapper<Project> response = await _httpWorker.GetAsync<ResponseWrapper<Project>>(requestUrl).ConfigureAwait(false);

            return response;
        }

        public async Task<Project> GetById(string projectKey)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(ONE_PROJECT, null, projectKey);

            Project response = await _httpWorker.GetAsync<Project>(requestUrl).ConfigureAwait(false);

            return response;
        }

        public async Task<Project> Create(Project project)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(MANY_PROJECTS);

            Project response = await _httpWorker.PostAsync<Project>(requestUrl, project).ConfigureAwait(false);

            return response;
        }

        public async Task Delete(string projectKey)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(ONE_PROJECT, null, projectKey);

            await _httpWorker.DeleteAsync(requestUrl).ConfigureAwait(false);
        }

        public async Task<ResponseWrapper<UserPermission>> GetUserPermissions(string projectKey, RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(USER_PERMISSIONS, requestOptions, projectKey);

            ResponseWrapper<UserPermission> response = await _httpWorker.GetAsync<ResponseWrapper<UserPermission>>(requestUrl);

            return response;
        }

        public async Task<ResponseWrapper<GroupPermission>> GetGroupPermissions(string projectKey, RequestOptions requestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(GROUP_PERMISSIONS, requestOptions, projectKey);

            ResponseWrapper<GroupPermission> response = await _httpWorker.GetAsync<ResponseWrapper<GroupPermission>>(requestUrl);

            return response;
        }
        
        public async Task SetDefaultPermission(string projectKey, string permission, bool allow)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(DEFAULT_PERMISSIONS, null, projectKey, permission);

            requestUrl += "?allow=" + allow.ToString().ToLower();

            await _httpWorker.PostAsync(requestUrl).ConfigureAwait(false);
        }

    }
}
