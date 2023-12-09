using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Categorization
{
    public class Categorizator : ICategorizator
    {
        Dictionary<string, Category> Categories = new Dictionary<string, Category>();

        public void AddCategory(Category category)
        {
            if (Categories.ContainsKey(category.Id))
            {
                throw new ArgumentException();
            }

            Categories.Add(category.Id, category);
        }

        public void AssignParent(string childCategoryId, string parentCategoryId)
        {
            if (!Categories.ContainsKey(childCategoryId) || !Categories.ContainsKey(parentCategoryId))
            {
                throw new ArgumentException();
            }

            var child = Categories[childCategoryId];

            var parent = Categories[parentCategoryId];

            if (parent.Children.Contains(child))
            {
                throw new ArgumentException();
            }

            parent.Children.Add(child);
            child.Parent = parent;
        }

        public bool Contains(Category category)
        {
            return Categories.ContainsValue(category);
        }

        public void RemoveCategory(string categoryId)
        {
            if (!Categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            RemoveCategory(Categories[categoryId]);

            Categories.Remove(categoryId);
        }

        public void RemoveCategory(Category category)
        {
            foreach (var categoryChild in category.Children)
            {
                RemoveCategory(categoryChild);
                Categories.Remove(categoryChild.Id);
            }
        }

        public int Size()
        {
            return Categories.Count;
        }

        public IEnumerable<Category> GetChildren(string categoryId)
        {
            if (!Categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            HashSet<Category> children = new HashSet<Category>();

            GetChildren(Categories[categoryId], children);

            return children;
        }

        public void GetChildren(Category category, HashSet<Category> children)
        {
            foreach (var categoryChild in category.Children)
            {
                children.Add(categoryChild);

                if (categoryChild.Children.Count > 0)
                {
                    GetChildren(categoryChild, children);
                }
            }
        }

        public IEnumerable<Category> GetHierarchy(string categoryId)
        {
            if (!Categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            Stack<Category> parents = new Stack<Category>();

            GetHierarchy(Categories[categoryId], parents);

            return parents;
        }

        public void GetHierarchy(Category category, Stack<Category> parents)
        {
            if (category == null)
            {
                return;
            }

            parents.Push(category);

            GetHierarchy(category.Parent, parents);
        }

        public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
        {
            return Categories.Values
                .OrderByDescending(c => GetDeepestChildDepth(c));
        }

        private int GetDeepestChildDepth(Category category)
        {
            var children = GetChildren(category.Id);
            var depth = 1;

            foreach (var child in children)
            {
                var level = GetHierarchy(child.Id).Count();

                if (level > depth)
                {
                    depth = level;
                }
            }

            return depth;
        }
    }
}
