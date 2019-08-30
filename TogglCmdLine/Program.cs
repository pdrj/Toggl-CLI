using System;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using TogglCmdLine.Network.Requests;
using TogglCmdLine.Options;
using TogglCmdLine.Presenter;
using TogglCmdLine.SharedTypes;

namespace TogglCmdLine
{
    class Program
    {
        static ProjectApi projectApi = new ProjectApi();
        static WorkspaceApi workspaceApi = new WorkspaceApi();
        static TimeEntryApi timeEntryApi = new TimeEntryApi();
        static ManualResetEvent resetEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            var parsingResult = Parser.Default.ParseArguments<WorkspaceOptions, TimeOptions, ProjectOptions>(args)
                .WithParsed<WorkspaceOptions>(opts => RunWorkspaceTasks(opts))
                .WithParsed<TimeOptions>(opts => RunTimeTasks(opts))
                .WithParsed<ProjectOptions>(opts => RunProjectTasks(opts))
                .WithNotParsed(err => Console.Error.WriteLine(err));

            resetEvent.WaitOne();
        }

        static void RunWorkspaceTasks(WorkspaceOptions opts)
        {
            if (opts.Get)
            {
                var workspaces = workspaceApi.getWorkspaces(Email.From(opts.Username), Password.From(opts.Password),
                    resetEvent);
                CliPresenter.present(workspaces.Result);
            }
        }

        static async void RunTimeTasks(TimeOptions opts)
        {
            if (opts.Start && opts.WorkspaceId > 0)
            {
                Console.WriteLine("Starting a new time entry...");

                var createTimeEntryResponse = await timeEntryApi.createTimeEntry(
                    opts.WorkspaceId, opts.Description,
                    Email.From(opts.Username),
                    Password.From(opts.Password), resetEvent);

                Console.WriteLine($"Created time entry with id {createTimeEntryResponse.Id}");
            }

            if (opts.Stop && opts.Id > 0)
            {
                Console.WriteLine($"Stopping time entry with id {opts.Id}");

                var stopTimeEntryResponse = await timeEntryApi.stopTimeEntry(opts.Id,
                    Email.From(opts.Username),
                    Password.From(opts.Password), resetEvent
                );
            }
        }

        static void RunProjectTasks(ProjectOptions opts)
        {
            if (opts.Get)
            {
                var result =
                    projectApi.getProjects(Email.From(opts.Username), Password.From(opts.Password), resetEvent);
                CliPresenter.present(result.Result);
            }
        }

        // TODO get rid of resetEvent and use async main
//        static async Task MainAsync(string[] args)
//        {
//        }
    }
}