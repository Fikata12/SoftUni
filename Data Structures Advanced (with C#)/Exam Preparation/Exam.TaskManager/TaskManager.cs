using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.TaskManager
{
    public class TaskManager : ITaskManager
    {
        Dictionary<string, Task> Tasks = new Dictionary<string, Task>();
        Dictionary<string, Task> ExecutableTasks = new Dictionary<string, Task>();
        Dictionary<string, Task> ExecutedTasks = new Dictionary<string, Task>();

        public void AddTask(Task task)
        {
            Tasks.Add(task.Id, task);
            ExecutableTasks.Add(task.Id, task);
        }

        public bool Contains(Task task)
        {
            return Tasks.ContainsKey(task.Id);
        }

        public int Size()
        {
            return ExecutableTasks.Count;
        }

        public Task GetTask(string taskId)
        {
            if (!Tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return Tasks[taskId];
        }

        public void DeleteTask(string taskId)
        {
            if (!Tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            Tasks.Remove(taskId);

            if (ExecutableTasks.ContainsKey(taskId))
            {
                ExecutableTasks.Remove(taskId);
            }
            else
            {
                ExecutedTasks.Remove(taskId);
            }
        }

        public Task ExecuteTask()
        {
            if (ExecutableTasks.Count < 1)
            {
                throw new ArgumentException();
            }

            var task = ExecutableTasks.First().Value;
            ExecutableTasks.Remove(task.Id);
            ExecutedTasks.Add(task.Id, task);

            return task;
        }

        public void RescheduleTask(string taskId)
        {
            if (!ExecutedTasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            var task = ExecutedTasks[taskId];
            ExecutedTasks.Remove(task.Id);
            ExecutableTasks.Add(task.Id, task);
        }

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            var tasks = ExecutableTasks.Values.Where(t => t.Domain == domain).ToList();

            if (tasks.Count < 1)
            {
                throw new ArgumentException();
            }

            return tasks;
        }

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound)
        {
            return ExecutableTasks.Values
                .Where(t => t.EstimatedExecutionTime >= lowerBound && t.EstimatedExecutionTime <= upperBound);
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
        {
            return Tasks.Values
                .OrderByDescending(t => t.EstimatedExecutionTime)
                .ThenBy(t => t.Name.Length);
        }
    }
}
