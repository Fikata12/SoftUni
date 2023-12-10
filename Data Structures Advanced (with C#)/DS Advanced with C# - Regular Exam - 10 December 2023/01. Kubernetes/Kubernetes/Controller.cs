using System;
using System.Collections.Generic;
using System.Linq;

namespace Kubernetes
{
    public class Controller : IController
    {
        Dictionary<string, Pod> pods = new Dictionary<string, Pod>();

        public bool Contains(string podId)
        {
            return pods.ContainsKey(podId);
        }

        public void Deploy(Pod pod)
        {
            pods.Add(pod.Id, pod);
        }

        public Pod GetPod(string podId)
        {
            if (!pods.ContainsKey(podId))
            {
                throw new ArgumentException();
            }

            return pods[podId];
        }

        public IEnumerable<Pod> GetPodsBetweenPort(int lowerBound, int upperBound)
        {
            return pods.Values
                .Where(p => p.Port >= lowerBound && p.Port <= upperBound);
        }

        public IEnumerable<Pod> GetPodsInNamespace(string @namespace)
        {
            return pods.Values
                .Where(p => p.Namespace == @namespace);
        }

        public IEnumerable<Pod> GetPodsOrderedByPortThenByName()
        {
            return pods.Values
                .OrderByDescending(p => p.Port)
                .ThenBy(p => p.Namespace);
        }

        public int Size()
        {
            return pods.Count();
        }

        public void Uninstall(string podId)
        {
            if (!pods.ContainsKey(podId))
            {
                throw new ArgumentException();
            }

            pods.Remove(podId);
        }

        public void Upgrade(Pod pod)
        {
            pods[pod.Id] = pod;
        }
    }
}