using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    public class Manager : IManager
    {
        Dictionary<string, Task> tasks = new Dictionary<string, Task>();

        public void AddDependency(string taskId, string dependentTaskId)
        {
            if (!tasks.ContainsKey(taskId) || !tasks.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException();
            }

            if (tasks[dependentTaskId].Dependencies.FirstOrDefault(t => t.Id == taskId) != null)
            {
                throw new ArgumentException();
            }

            tasks[taskId].Dependencies.Add(tasks[dependentTaskId]);
            tasks[dependentTaskId].Dependents.Add(tasks[taskId]);
        }

        public void AddTask(Task task)
        {
            if (tasks.ContainsKey(task.Id))
            {
                throw new ArgumentException();
            }

            tasks.Add(task.Id, task);
        }

        public bool Contains(string taskId)
        {
            return tasks.ContainsKey(taskId);
        }

        public Task Get(string taskId)
        {
            if (!tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return tasks[taskId];
        }

        public IEnumerable<Task> GetDependencies(string taskId)
        {
            HashSet<Task> dependencies = new HashSet<Task>();

            if (!tasks.ContainsKey(taskId))
            {
                return dependencies;
            }

            GetDependencies(taskId, dependencies);

            return dependencies;
        }

        private void GetDependencies(string taskId, HashSet<Task> dependencies)
        {
            foreach (Task task in tasks[taskId].Dependencies)
            {
                dependencies.Add(task);
                GetDependencies(task.Id, dependencies);
            }
        }

        public IEnumerable<Task> GetDependents(string taskId)
        {
            HashSet<Task> dependents = new HashSet<Task>();

            if (!tasks.ContainsKey(taskId))
            {
                return dependents;
            }

            GetDependents(taskId, dependents);

            return dependents;
        }

        private void GetDependents(string taskId, HashSet<Task> dependents)
        {
            foreach (Task task in tasks[taskId].Dependents)
            {
                dependents.Add(task);
                GetDependents(task.Id, dependents);
            }
        }

        public void RemoveDependency(string taskId, string dependentTaskId)
        {
            if (!tasks.ContainsKey(taskId) || !tasks.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException();
            }

            if (tasks[taskId].Dependencies.FirstOrDefault(t => t.Id == dependentTaskId) == null)
            {
                throw new ArgumentException();
            }

            tasks[taskId].Dependencies.Remove(tasks[dependentTaskId]);
            tasks[dependentTaskId].Dependents.Remove(tasks[taskId]);
        }

        public void RemoveTask(string taskId)
        {
            if (!tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < tasks[taskId].Dependents.Count; i++)
            {
                for (int j = 0; j < tasks[taskId].Dependents[i].Dependencies.Count; j++)
                {
                    if (tasks[taskId].Dependents[i].Dependencies[j].Id == taskId)
                    {
                        tasks[taskId].Dependents[i].Dependencies.Remove(tasks[taskId].Dependents[i].Dependencies[j]);
                    }
                }
            }

            for (int i = 0; i < tasks[taskId].Dependencies.Count; i++)
            {
                for (int j = 0; j < tasks[taskId].Dependencies[i].Dependents.Count; j++)
                {
                    if (tasks[taskId].Dependencies[i].Dependents[j].Id == taskId)
                    {
                        tasks[taskId].Dependencies[i].Dependents.Remove(tasks[taskId].Dependencies[i].Dependents[j]);
                    }
                }
            }

            tasks.Remove(taskId);
        }

        public int Size()
        {
            return tasks.Count();
        }
    }
}