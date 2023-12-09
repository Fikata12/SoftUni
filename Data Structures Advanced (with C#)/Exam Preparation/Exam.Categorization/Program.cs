using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Categorization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var categorizator = new Categorizator();

            Category category1 = new Category("1", "1", "te");
            Category category2 = new Category("2", "2", "tet");
            Category category3 = new Category("3", "3", "te");
            Category category4 = new Category("4", "4", "te");

            categorizator.AddCategory(category1);
            categorizator.AddCategory(category2);
            categorizator.AddCategory(category3);
            categorizator.AddCategory(category4);

            categorizator.AssignParent(category3.Id, category1.Id);
            categorizator.AssignParent(category1.Id, category4.Id);
            categorizator.AssignParent(category4.Id, category2.Id);

            List<Category> aaa = categorizator.GetTop3CategoriesOrderedByDepthOfChildrenThenByName().ToList();
        }
    }
}
