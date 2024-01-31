using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoredProcedure.Models;

namespace StoredProcedure.Pages.User
{
    public class UpdateModel : PageModel
    {
        public Users user=new Users();
        private readonly IConfiguration configuration;

        public UpdateModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnGet()
        {
            long id=Convert.ToUInt16(Request.Query["Id"]);
            DataAccessLayer accessLayer = new DataAccessLayer();
            user=accessLayer.GetUser(id, configuration);
        }

        public void OnPost(long id)
        {
            user.Name = Request.Form["Name"];
            user.Email = Request.Form["Email"];

            DataAccessLayer dataAccessLayer = new DataAccessLayer();
            dataAccessLayer.UpdateUser(id,configuration,user);
        }
    }
}
