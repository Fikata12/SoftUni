using System.Collections.Generic;

namespace TaskManager
{
    public class Task
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Assignee { get; set; }

        public int Priority { get; set; }

        public List<Task> Dependencies { get; set; } = new List<Task>();

        public List<Task> Dependents { get; set; } = new List<Task>();

        public override string ToString()
        {
            return this.Title;
        }
    }
}