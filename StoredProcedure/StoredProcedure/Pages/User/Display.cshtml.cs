using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoredProcedure.Models;

namespace StoredProcedure.Pages.User
{
    public class DisplayModel : PageModel
    {
        public List<Users> users = new List<Users>();
        private readonly IConfiguration configuration;

        public DisplayModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnGet()
        {
            DataAccessLayer dataAccessLayer = new DataAccessLayer();
           users= dataAccessLayer.GetUsers(configuration);
        }
    }
}
