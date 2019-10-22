using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestCase1_Shop.Pages
{
    public class StoreProduct : PageModel
    {
        public Guid Id { get; set; }
        public void OnGet(Guid id)
        {
            Id = id;
        }
    }
}
