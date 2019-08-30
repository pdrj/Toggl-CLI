using System.Collections.Generic;
using CommandLine;

namespace TogglCmdLine.Options
{
    // TODO move to own files
    public class Options
    {
        [Option('u', Required = true, HelpText = "Your Toggl email")]
        public string Username { get; set; }
        
        [Option('p', Required = true, HelpText = "Your Toggl password")]
        public string Password { get; set; }
    }

    [Verb("workspace", HelpText = "Work with a workspace")]
    public class WorkspaceOptions : Options
    {
        [Option(Required = false)]
        public long Id { get; set; }
        
        [Option(Required = false, HelpText = "List all workspaces")]
        public bool Get { get; set; }
    }
    
    [Verb("time", HelpText = "Work with a time entry")]
    public class TimeOptions : Options
    {
        [Option(Required = false, HelpText = "The id of time entry you want to work with")]
        public long Id { get; set; }
        
        [Option(Required = false, HelpText = "Start new time entry")]
        public bool Start { get; set; }
        
        [Option(Required = false, HelpText = "Stop a time entry")]
        public bool Stop { get; set; }
        
        [Option(Required = false, HelpText = "Id of the workspace")]
        public long WorkspaceId { get; set; }
        
        [Option(Required = false, HelpText = "Description of the time entry", Default = "")]
        public string Description { get; set; }
    }
    
    [Verb("project", HelpText = "Work with projects")]
    public class ProjectOptions : Options
    {
        [Option(Required = false, HelpText = "List all projects")]
        public bool Get { get; set; }
    }
}