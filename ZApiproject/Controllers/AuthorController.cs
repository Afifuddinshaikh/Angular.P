using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZApiproject.Models;

namespace ZApiproject.Controllers
{ 
    
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
     

        [HttpGet]
        public IEnumerable<Author> Get()
        {
           using (var Context=new EmployeeContext())
            {
                //To get all list
                //return Context.Authors.ToList();
                //return Context.Authors.Where(auth=>auth.AuthorId== 1).ToList();
                //add new data table
                //Author auther=new Author();
                //auther.FirstName = "afif";
                //  auther.LastName = "uddin";
                //  Context.Authors.Add(auther);
                //  Context.SaveChanges();
                //return Context.Authors.Where(auth => auth.FirstName == "afif").ToList();
                //Author auther=Context.Authors.Where(auth=>auth.FirstName== "afif").FirstOrDefault();
                //auther.Phone = "9975646100";
                //Context.SaveChanges();
                return Context.Authors.Where(auth=>auth.Phone=="9975646100").ToList();
            }
        }
    }
}