using System;
using System.Collections;
using System.Collections.Generic;
using TogglCmdLine.Model;

namespace TogglCmdLine.Presenter
{
    public static class CliPresenter
    {
        public static void present<T>(T item)
        {
            if (presentersDictionary.ContainsKey(typeof(T)))
            {
                presentersDictionary[typeof(T)](item);
            }
            else
            {
                Console.Error.WriteLine($"ERR - no presenter for {typeof(T)}");
            }
        }

        private static readonly Dictionary<Type, Action<object>> presentersDictionary =
            new Dictionary<Type, Action<object>>
            {
                {
                    typeof(List<Project>),
                    projects =>
                    {
                        ((List<Project>) projects).ForEach(project =>
                            Console.WriteLine($"{project.Id} {project.Name}"));
                    }
                },
                {
                    typeof(List<Workspace>),
                    workspaces =>
                    {
                        ((List<Workspace>) workspaces).ForEach(workspace =>
                            Console.WriteLine($"{workspace.Id} {workspace.Name}"));
                    }
                }
            };
    }
}