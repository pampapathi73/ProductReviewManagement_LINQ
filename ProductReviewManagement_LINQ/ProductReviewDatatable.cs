using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagement_LINQ
{
    class ProductReviewDatatable
    {
        public DataTable AddToDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductID", typeof(int));
            table.Columns.Add("UserID", typeof(int));
            table.Columns.Add("Rating", typeof(int));
            table.Columns.Add("Review", typeof(string));
            table.Columns.Add("isLike", typeof(bool));

            table.Rows.Add(1, 1, 4, "Good", true);
            table.Rows.Add(2, 1, 5, "Nice", true);
            table.Rows.Add(3, 1, 2, "Not Good", false);
            table.Rows.Add(3, 2, 1, "Bad", false);
            table.Rows.Add(2, 2, 5, "very Nice", true);
            table.Rows.Add(1, 10, 3, "Good", true);
            table.Rows.Add(2, 10, 4, "Good", true);
            table.Rows.Add(3, 10, 2, "Good", true);
            table.Rows.Add(4, 10, 6, "Good", true);
            return table;
        }

        public void DisplayDataTableRecordsWithIsLikeValueTrue(DataTable table)
        {
            var records = from products in table.AsEnumerable().Where(x => x["isLike"].Equals(true)) select products;

            Console.WriteLine("\nList Of records whose isLike value is True");
            foreach (var product in records)
            {

                Console.Write("ProductID : " + product.Field<int>("ProductID") + " " + "UserID : " + product.Field<int>("UserID") + " " + "Rating : " + product.Field<int>("Rating") + " " + "Review : " + product.Field<string>("Review") + " " + "isLike : " + product.Field<bool>("isLike") + " ");
                Console.WriteLine("\n-----------------------------------------------------------");
            }
        }
        public void FindAverageRatingOfEachProductID(DataTable table)
        {
            var records = table.Rows.Cast<DataRow>()
                          .GroupBy(x => x.Field<int>("ProductID"))
                          .Select(x => new
                          {
                              ProductID = x.Key,
                              Average = x.Average(x => x.Field<int>("Rating"))
                          }).ToList();
            Console.WriteLine("\nList of Average Rating For Given Each Product ID");
            foreach (var row in records)
            {
                Console.Write("\nProductID : " + row.ProductID + " " + "\nAverage Rating : " + row.Average);
                Console.WriteLine("\n-----------------");
            }
        }

        public void DisplayDataTableRecordsWithIsLikeValueNice(DataTable table)
        {
            var records = from products in table.AsEnumerable().Where(x => x["Review"].ToString().Contains("Nice")) select products;

            Console.WriteLine("\nList Of records whose isLike value is Nice");
            foreach (var product in records)
            {

                Console.Write("ProductID : " + product.Field<int>("ProductID") + " " + "UserID : " + product.Field<int>("UserID") + " " + "Rating : " + product.Field<int>("Rating") + " " + "Review : " + product.Field<string>("Review") + " " + "isLike : " + product.Field<bool>("isLike") + " ");
                Console.WriteLine("\n-----------------------------------------------------------");
            }
        }
        public void RetrievRecordsOfPerticularUserID(DataTable table)
        {
            var records = from products in table.AsEnumerable()
                          .OrderBy(x => x["Rating"])
                          .Where(x => x["UserID"].Equals(10))
                          select products;
            Console.WriteLine("\nList Of Products whose UserID is 10");
            foreach (var product in records)
            {
                Console.WriteLine("\n-----------------");
                Console.Write("ProductID : " + product.Field<int>("ProductID") + " " + "UserID : " + product.Field<int>("UserID") + " " + "Rating : " + product.Field<int>("Rating") + " " + "Review : " + product.Field<string>("Review") + " " + "isLike : " + product.Field<bool>("isLike") + " ");
                Console.WriteLine("\n-----------------");
            }
        }

    }
}
