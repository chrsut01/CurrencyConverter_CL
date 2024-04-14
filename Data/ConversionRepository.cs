using System;
using System.Collections.Generic;
using CurrencyConverter_CL.Models;

namespace CurrencyConverter_CL.Data
{
    public class ConversionRepository : IConversionRepository
    {
        private List<ConversionHistory> _conversionHistory;

        public ConversionRepository()
        {
            _conversionHistory = new List<ConversionHistory>();
            // Initialize with some dummy data for testing purposes
            InitializeDummyData();
        }

        public List<ConversionHistory> GetAll()
        {
            return _conversionHistory;
        }

        public void Add(ConversionHistory conversion)
        {
            _conversionHistory.Add(conversion);
        }

        // Method to initialize some dummy data (for testing purposes)
        private void InitializeDummyData()
        {
            _conversionHistory.Add(new ConversionHistory
            {
                Source = "USD",
                Target = "EUR",
                Value = 100,
                Result = 93,
                Date = DateTime.Now
            });

            // Add more dummy data as needed
        }
    }
}