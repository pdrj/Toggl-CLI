using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TogglCmdLine.Model;
using TogglCmdLine.SharedTypes;

namespace TogglCmdLine.Network.Requests
{
    public class TimeEntryApi : BaseApiCall
    {
        private string CREATE_TIME_ENTRY_ENDPOINT (long workspaceId) => $"workspaces/{workspaceId}/time_entries";
        private string STOP_TIME_ENTRY_ENDPOINT (long timeEntryId) => $"time_entries/{timeEntryId}/stop";
        
        public async Task<CreateTimeEntryReply> createTimeEntry(long workspaceId, string description, Email email, Password password, ManualResetEvent resetEvent)
        {
            var timeEntry = new TimeEntry();
            timeEntry.Start = DateTimeOffset.UtcNow;
            timeEntry.Description = description;
            timeEntry.WorkspaceId = workspaceId;
            timeEntry.Billable = false;
            
            return await makeRequest<CreateTimeEntryReply>(CREATE_TIME_ENTRY_ENDPOINT(workspaceId), HttpMethod.Post, email, password, resetEvent, timeEntry);
        }

        public async Task<StopTimeEntryReply> stopTimeEntry(long timeEntryId, Email email, Password password, ManualResetEvent resetEvent)
        {
            // TODO: tried PUT/POST/GET 
            var timeEntry = new TimeEntry();
            timeEntry.Stop = DateTimeOffset.UtcNow;
//            timeEntry.WorkspaceId = 3605623;
//            timeEntry.Stop = DateTimeOffset.UtcNow;
//            timeEntry.Id = timeEntryId;
//            timeEntry.TagIds = new List<long>();
//            timeEntry.UserId = 5028821;
//            timeEntry.Id = -1;
//            timeEntry.Billable = false;

            return await makeRequest<StopTimeEntryReply>(STOP_TIME_ENTRY_ENDPOINT(timeEntryId), HttpMethod.Get, email, password, resetEvent);

        }

    }
}