using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoredProcedure.Models;

namespace StoredProcedure.Pages.User
{
    public class AddModel : PageModel
    {
        private readonly IConfiguration configuration;
       
        public Users user =new Users();

        public AddModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            user.Name = Request.Form["Name"];
            user.Email = Request.Form["Email"];

            DataAccessLayer accessLayer = new DataAccessLayer();
            accessLayer.Save(user, configuration);
        }
    }
}
