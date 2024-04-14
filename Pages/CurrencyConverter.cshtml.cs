using System;
using System.Collections.Generic;
using CurrencyConverter_CL.Data;
using CurrencyConverter_CL.Models;
using CurrencyConverter_CL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CurrencyConverter_CL.Pages
{
    public partial class CurrencyConverterModel : PageModel
    {
        private readonly ILogger<CurrencyConverterModel> _logger;
        private readonly Converter _converter;
        private readonly IConversionRepository _conversionRepository;
        
        public CurrencyConverterModel(ILogger<CurrencyConverterModel> logger, Converter converter, IConversionRepository conversionRepository)
        {
            _logger = logger;
            _converter = converter;
            _conversionRepository = conversionRepository;
        }

        [BindProperty]
        public string FromCurrency { get; set; }

        [BindProperty]
        public string ToCurrency { get; set; }

        [BindProperty]
        public decimal Amount { get; set; }

        public Conversion ConversionResult { get; private set; }

        public void OnPost()
        {
            try
            {
                var rates = new Dictionary<string, decimal>
                {
                    { "USD", 1m },
                    { "EUR", 0.93m },
                    { "GBP", 0.76m },
                    { "JPY", 130.53m },
                    { "AUD", 1.31m }
                };

                if (string.IsNullOrWhiteSpace(FromCurrency) || string.IsNullOrWhiteSpace(ToCurrency))
                {
                    ModelState.AddModelError(string.Empty, "Currency codes cannot be empty.");
                    return;
                }

                if (!rates.ContainsKey(FromCurrency.ToUpper()) || !rates.ContainsKey(ToCurrency.ToUpper()))
                {
                    ModelState.AddModelError(string.Empty, "Unsupported currency.");
                    return;
                }

                if (Amount <= 0)
                {
                    ModelState.AddModelError(string.Empty, "Amount must be greater than zero.");
                    return;
                }

                // Use the Converter class to perform the currency conversion
                decimal convertedAmount = _converter.Convert(Amount, FromCurrency.ToUpper(), ToCurrency.ToUpper(), rates);

                ConversionResult = new Conversion
                {
                    Source = FromCurrency.ToUpper(),
                    Target = ToCurrency.ToUpper(),
                    Value = Amount,
                    Result = convertedAmount,
                    Date = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during currency conversion.");
                ModelState.AddModelError(string.Empty, "An error occurred during currency conversion.");
            }
        }
        public List<ConversionHistory> ConversionHistory { get; set; }

        public void OnGet()
        {
            // Fetch conversion history data from your database or storage
            ConversionHistory = _conversionRepository.GetAll(); // Example: Fetching all conversion history records
        }
    }
}
