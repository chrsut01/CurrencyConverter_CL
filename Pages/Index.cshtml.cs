using CurrencyConverter_CL.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CurrencyConverter_CL.Pages;

public class IndexModel : PageModel
{
  //  public List<ConversionHistory> ConversionHistory { get; set; }

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

  /*  public void OnGet()
    {
    }*/
}