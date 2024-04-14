using System;
using System.Collections.Generic;
using CurrencyConverter_CL.Models;
using CurrencyConverter_CL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
/*
namespace CurrencyConverter_CL.Pages
{
    public partial class CurrencyConverterModel : PageModel
    {
        private readonly ILogger<CurrencyConverterModel> _logger;
        private readonly Converter _converter;

        public CurrencyConverterModel(ILogger<CurrencyConverterModel> logger, Converter converter)
        {
            _logger = logger;
            _converter = converter;
        }

        [BindProperty]
        public string FromCurrency { get; set; }

        [BindProperty]
        public string ToCurrency { get; set; }

        [BindProperty]
        public decimal Amount { get; set; }

        public Conversion ConversionResult { get; private set; }
        public List<ConversionHistory> ConversionHistory { get; set; }

        public void OnGet()
        {
            // Fetch conversion history data from your database or storage
            // Populate the ConversionHistory property
        }

        public void OnPost()
        {
            var rates = new Dictionary<string, decimal>
            {
                { "USD", 1m },
                { "EUR", 0.93m },
                { "GBP", 0.76m },
                { "JPY", 130.53m },
                { "AUD", 1.31m }
            };

            if (rates.ContainsKey(FromCurrency.ToUpper()) && rates.ContainsKey(ToCurrency.ToUpper()))
            {
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
            else
            {
                ModelState.AddModelError(string.Empty, "Unsupported currency.");
            }
        }
    }
}*/
