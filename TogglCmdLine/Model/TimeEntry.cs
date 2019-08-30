using System;
using System.Collections.Generic;

namespace TogglCmdLine.Model
{
    public class TimeEntry
    {
        public long WorkspaceId { get; set; }
        public long Id { get; set; }

        public long? ProjectId { get; set; }

        public long? TaskId { get; set; }

        public bool Billable { get; set; }

        public DateTimeOffset Start { get; set; }
        public DateTimeOffset Stop { get; set; }

        public long? Duration { get; set; }

        public string Description { get; set; }

        public IEnumerable<long> TagIds { get; set; } = new List<long>();

//        public long UserId { get; set; }

        public string CreatedWith => "CLI";
    }
}