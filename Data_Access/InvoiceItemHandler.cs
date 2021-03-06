﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanbooks
{
    public class InvoiceItemHandler
    {

        public List<InvoiceItem> InvoiceItems()
        {
            List<InvoiceItem> invoiceItemList = null;

            using (DataTable table = DataProvider.ExecuteSelectCommand("sp_InvoiceItems_Sales",
                CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    invoiceItemList = new List<InvoiceItem>();
                    foreach (DataRow row in table.Rows)
                    {
                        InvoiceItem item = new InvoiceItem();
                        item.CartItemID = (int)row["CartItemID"];
                        item.ProductID = (int)row["ProductID"];
                        item.InvoiceID = Convert.ToInt32(row["InvoiceID"]);
                        item.InvoiceLineID = Convert.ToInt32(row["InvoiceLineNo"]);
                        item.Price = Convert.ToDouble(row["Price"]);
                        item.Quantity = Convert.ToInt32(row["Quantity"]);
                        invoiceItemList.Add(item);


                    }
                }
            }
            return invoiceItemList;
        }


        public List<InvoiceItem> InvoiceItemsGroupedByInvoiceID(DateTime dateFrom, DateTime dateTo)
        {
            List<InvoiceItem> invoiceItemList = null;

            SqlParameter[] Params = { new SqlParameter("@dateFrom", dateFrom), new SqlParameter("@dateTo", dateTo) };
            using (DataTable table = DataProvider.ExecuteParamatizedSelectCommand("sp_ViewAllInvoiceItems", CommandType.StoredProcedure, Params))
            {
                if (table.Rows.Count > 0)
                {
                    invoiceItemList = new List<InvoiceItem>();
                    foreach (DataRow row in table.Rows)
                    {
                        InvoiceItem item = new InvoiceItem();
                        item.InvoiceID = Convert.ToInt32(row["InvoiceID"]);
                        item.Price = Convert.ToDouble(row["Price"]);
                        invoiceItemList.Add(item);


                    }
                }
            }
            return invoiceItemList;
        }

        public List<InvoiceItem> GetInvoiceItemList(int InvoiceID)
        {
            List<InvoiceItem> invoiceItems = null;

            SqlParameter[] Params = { new SqlParameter("@InvoiceID", InvoiceID) };
            using (DataTable table = DataProvider.ExecuteParamatizedSelectCommand("sp_ViewInvoiceItems", CommandType.StoredProcedure, Params))
            {
                if (table.Rows.Count > 0)
                {
                    invoiceItems = new List<InvoiceItem>();
                    foreach (DataRow row in table.Rows)
                    {
                        InvoiceItem invoiceItem = new InvoiceItem();
                        invoiceItem.InvoiceLineID = Convert.ToInt32(row["InvoiceLineNo"]);
                        invoiceItem.ProductID = Convert.ToInt32(row["ProductID"]);
                        invoiceItem.InvoiceID = Convert.ToInt32(row["InvoiceID"]);
                        invoiceItem.Quantity = Convert.ToInt32(row["Quantity"]);
                        invoiceItem.CartItemID = Convert.ToInt32(row["CartItemID"]);
                        invoiceItem.Price = Convert.ToDouble(row["Price"]);
                        invoiceItems.Add(invoiceItem);
                    }
                }
            }
            return invoiceItems;
        }

        public bool InsertInvoiceItem(InvoiceItem item)
        {
            SqlParameter[] Params = new SqlParameter[]
            {
                new SqlParameter("@Quantity", item.Quantity),
                new SqlParameter("@ProductID", item.ProductID),
                new SqlParameter("@CartItemID", item.CartItemID),
                new SqlParameter("@InvoiceID", item.InvoiceID),
                new SqlParameter("@Price", item.Price)
            };
            return DataProvider.ExecuteNonQuery("sp_InsertInvoiceItems", CommandType.StoredProcedure,
                Params);
        }

        public bool DeleteInvoiceItem(int InvoiceItemID)
        {
            SqlParameter[] Params = new SqlParameter[]
            {
                new SqlParameter("@KeywordID", InvoiceItemID)
            };
            return DataProvider.ExecuteNonQuery("sp_DeleteInvoiceItems", CommandType.StoredProcedure,
                Params);
        }
    }
}
