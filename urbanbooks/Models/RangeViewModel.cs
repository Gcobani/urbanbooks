﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace urbanbooks.Models
{
    public class RangeViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public RangeValidate myRange { get; set; }
        public List<Monthly> MonthlySales { get; set; }
        public string radioButtons { get; set; }
        public LooseRanger Range { get; set; }
        public Monthly Month { get; set; }
        public TotalClass Total { get; set; }
        public List<DetailedCustom> Detailed { get; set; }
        public Company company { get; set; }
    }
    public class RangeValidate
    {
        [Key]
        public int TheKey { get; set; }
        [Required]
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
    public class Monthly 
    {
        [Key]
        public int key { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Month { get; set; }
        [DataType(DataType.Currency)]
        public double TotalSales { get; set; }
    }
    public class DetailedCustom
    {
        [Key]
        public int Id_key { get; set; }
        public int InvoiceID { get; set; }
        public string DateIssued { get; set; }
        [DataType(DataType.Currency)]
        public double InvoiceTotal { get; set; }
    }
    public class TotalClass 
    {
        [Key]
        [DataType(DataType.Currency)]
        public double Total { get; set; }
    }
    public class LooseRanger 
    {
        [Key]
        public int keen_Id { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
    }

}