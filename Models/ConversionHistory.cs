﻿using System;

namespace CurrencyConverter_CL.Models
{
    public class ConversionHistory
    {
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public decimal Value { get; set; }
        public decimal Result { get; set; }
    }
}