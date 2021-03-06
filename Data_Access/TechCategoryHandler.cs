﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanbooks
{
    public class TechCategoryHandler
    {
        public List<TechCategory> CheckDuplicateTechCategory(string category)
        {
            List<TechCategory> categoryList = null;
            SqlParameter[] Params = { new SqlParameter("@category", category) };
            using (DataTable table = DataProvider.ExecuteParamatizedSelectCommand("sp_CheckDuplicateTechCategory", CommandType.StoredProcedure, Params))
            {
                if (table.Rows.Count > 0)
                {
                    categoryList = new List<TechCategory>();
                    foreach (DataRow row in table.Rows)
                    {
                        TechCategory techCategory = new TechCategory();
                        techCategory.TechCategoryID = Convert.ToInt32(row["TechCategoryID"]);
                        techCategory.CategoryName = row["CategoryName"].ToString();
                        techCategory.CategoryDescription = row["CategoryDescription"].ToString();
                        categoryList.Add(techCategory);
                    }
                }
            }
            return categoryList;
        }
        public List<TechCategory> GetTechCategoryList()
        {
            List<TechCategory> TechCategoryList = null;

            using (DataTable table = DataProvider.ExecuteSelectCommand("sp_ViewAllTechCategories",
                CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    TechCategoryList = new List<TechCategory>();
                    foreach (DataRow row in table.Rows)
                    {
                        TechCategory category = new TechCategory();
                        category.TechCategoryID = Convert.ToInt32(row["TechCategoryID"]);
                        category.CategoryName = row["CategoryName"].ToString();
                        category.CategoryDescription = row["CategoryDescription"].ToString();
                        TechCategoryList.Add(category);
                    }
                }
            }
            return TechCategoryList;
        }


        public List<TechCategory> TechnologyCategoryGloablSearch(string query)
        {
            List<TechCategory> TechCategoryList = null;

            SqlParameter[] Params = { new SqlParameter("@Search", query) };
            using (DataTable table = DataProvider.ExecuteParamatizedSelectCommand("sp_TechnologyCategoryGloablSearch",
                CommandType.StoredProcedure, Params))
            {
                if (table.Rows.Count > 0)
                {
                    TechCategoryList = new List<TechCategory>();
                    foreach (DataRow row in table.Rows)
                    {
                        TechCategory category = new TechCategory();
                        category.TechCategoryID = Convert.ToInt32(row["TechCategoryID"]);
                        category.CategoryName = row["CategoryName"].ToString();
                        category.CategoryDescription = row["CategoryDescription"].ToString();
                        TechCategoryList.Add(category);
                    }
                }
            }
            return TechCategoryList;
        }

        public TechCategory GetTechCategoryDetails(int TechCategoryID)
        {
            TechCategory category = null;

            SqlParameter[] Params = { new SqlParameter("@TechCategoryID", TechCategoryID) };
            using (DataTable table = DataProvider.ExecuteParamatizedSelectCommand("sp_ViewSpecificTechType",
                CommandType.StoredProcedure, Params))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    category = new TechCategory();
                    category.TechCategoryID = Convert.ToInt32(row["TechCategoryID"]);
                    category.CategoryName = row["CategoryName"].ToString();
                    category.CategoryDescription = row["CategoryDescription"].ToString();
                }
            }
            return category;
        }

        public TechCategory SearchTechCategory(string Query)
        {
            TechCategory category = null;
            SqlParameter[] Params = new SqlParameter[]
            {
                new SqlParameter("@Name", Query) ///SEARCH
            };
            using (DataTable table = DataProvider.ExecuteParamatizedSelectCommand("sp_...",
                CommandType.StoredProcedure, Params))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    category = new TechCategory();
                    category.TechCategoryID = Convert.ToInt32(row["TechCategoryID"]);
                    category.CategoryName = row["CategoryName"].ToString();
                    category.CategoryDescription = row["CategoryDescription"].ToString();
                   
                }
            }
            return category;
        }

        public bool DeleteTechCategory(int TechCategoryID)
        {
            SqlParameter[] Params = new SqlParameter[]
            {
                new SqlParameter("@TechCategoryID", TechCategoryID)
            };
            return DataProvider.ExecuteNonQuery("sp_DeleteTechCategory", CommandType.StoredProcedure,
                Params);
        }

        public bool InsertTechCategory(TechCategory categor)
        {
            SqlParameter[] Params = new SqlParameter[]
            {
                new SqlParameter("@CategoryName", categor.CategoryName ),
                new SqlParameter("@CategoryDescription", categor.CategoryDescription)
            };
            return DataProvider.ExecuteNonQuery("sp_InsertTechCategory", CommandType.StoredProcedure,
                Params);
        }

        public bool UpdateTechCategory(TechCategory category)
        {
            SqlParameter[] Params = new SqlParameter[]
            {
                new SqlParameter("@TechCategoryID", category.TechCategoryID),
                new SqlParameter("@CategoryName", category.CategoryName ),
                new SqlParameter("@CategoryDescription",category.CategoryDescription)
            };
            return DataProvider.ExecuteNonQuery("sp_UpdateTechCategory", CommandType.StoredProcedure,
                Params);
        }
    }
}