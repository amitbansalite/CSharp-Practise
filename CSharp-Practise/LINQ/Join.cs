using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.LINQ
{
    
    public class Join
    {
        #region Data

        class Product
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int CategoryID { get; set; }
        }

        class Category
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
        }

        // Specify the first data source.
        List<Category> categories = new List<Category>()
    { 
        new Category(){Name="Beverages", ID=001},
        new Category(){ Name="Condiments", ID=002},
        new Category(){ Name="Vegetables", ID=003},
        new Category() {  Name="Grains", ID=004},
        new Category() {  Name="Fruit", ID=005}            
    };

        // Specify the second data source.
        List<Product> products = new List<Product>()
   {
      new Product{Name="Cola",  CategoryID=001},
      new Product{Name="Tea",  CategoryID=001},
      new Product{Name="Mustard", CategoryID=002},
      new Product{Name="Pickles", CategoryID=002},
      new Product{Name="Carrots", CategoryID=003},
      new Product{Name="Bok Choy", CategoryID=003},
      new Product{Name="Peaches", CategoryID=005},
      new Product{Name="Melons", CategoryID=005},
    };
        #endregion

        public void join()
        {
            var result = from category in categories
                         join prod in products on category.ID equals prod.CategoryID
                         select new {CategoryName = category.Name, ProductName = prod.Name};    // flat sequence

        }

        public void group_join()
        {
            // If you just select the results of a group join, you can access the items, but you cannot identify the key that they match on. 
            // Therefore, it is generally more useful to select the results of the group join into a new type that also has the key name

            var result = from category in categories
                         join prod in products on category.ID equals prod.CategoryID into newGroup
                         select new {CategoryName = category.Name, Products = newGroup};
            foreach (var entry in result)
            {
                Console.WriteLine("\n\n New Category Name : {0}",entry.CategoryName);
                foreach (var prod in entry.Products)
                {
                    Console.WriteLine(prod.Name);
                }
            }
        }

        public void leftOuterJoin()
        {
            var leftOuterJoinQuery =
                                from category in categories
                                join prod in products on category.ID equals prod.CategoryID into prodGroup
                                from item in prodGroup.DefaultIfEmpty(new Product { Name = String.Empty, CategoryID = 0 })
                                select new { CatName = category.Name, ProdName = item.Name };

        }

        // while using composite keys, all the key should have the same type
        public void compositeJoinKey()
        {
            var query = from c in categories    
                        join p in products on new {c.Name, c.LastName} equals new { p.Name, p.LastName} into newGroup
                        select new {c.Name, newGroup};

            // below is compile error and NOT allowed
            /*var query = from c in categories
                        join p in products on new { c.Name, c.ID} equals new { p.Name, p.CategoryID} into newGroup
                        select new { c.Name, newGroup };*/
        }
        
    }
}
