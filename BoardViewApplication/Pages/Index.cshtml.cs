using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BoardViewApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            var client = new HttpClient();
            var response = client.GetAsync("https://cards.floul.dev/api/v2.0/NewPlayer").Result;
            var asd1 = response.Content.ReadAsStringAsync().Result;
            var results = JsonConvert.DeserializeObject<List<Root>>(asd1);
            asd = results;
        }

        public void OnGet()
        {
        }

        public List<Root> asd;
    }
    public class Root
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string realName { get; set; }
        public double currentPosition { get; set; }
        public double potentialPosition { get; set; }
        public bool hideFromView { get; set; }
    }
}