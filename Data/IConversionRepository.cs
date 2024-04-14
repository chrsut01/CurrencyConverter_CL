using System.Collections.Generic;
using CurrencyConverter_CL.Models;

namespace CurrencyConverter_CL.Data
{
    public interface IConversionRepository
    {
        List<ConversionHistory> GetAll(); // Method to fetch all conversion history records
        void Add(ConversionHistory conversion); // Method to add a new conversion history record
        // Other methods if needed...
    }
}