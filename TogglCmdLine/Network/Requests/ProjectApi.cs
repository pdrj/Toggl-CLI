using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TogglCmdLine.Model;
using TogglCmdLine.SharedTypes;

namespace TogglCmdLine.Network.Requests
{
    public class ProjectApi: BaseApiCall
    {
        private readonly string PROJECTS_ENDPOINT = "me/projects";
        
        public async Task<List<Project>> getProjects(Email email, Password password, ManualResetEvent resetEvent)
        {
            return await makeRequest<List<Project>>(PROJECTS_ENDPOINT, HttpMethod.Get, email, password, resetEvent);
        }
        
        

    }
}