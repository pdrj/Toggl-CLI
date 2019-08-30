using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TogglCmdLine.Model;
using TogglCmdLine.SharedTypes;

namespace TogglCmdLine.Network.Requests
{
    public class WorkspaceApi : BaseApiCall
    {
        private readonly string WORKSPACES_ENDPOINT = "me/workspaces";

        public async Task<List<Workspace>> getWorkspaces(Email email, Password password, ManualResetEvent resetEvent)
        {
            return await makeRequest<List<Workspace>>(WORKSPACES_ENDPOINT, HttpMethod.Get, email, password, resetEvent);
        }
    }
}