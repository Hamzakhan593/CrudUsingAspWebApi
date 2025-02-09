using CrudUsingAspWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CrudUsingAspWebApi.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7038/api/StudentAPI";
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult Create (Student student)
        {
            return View(student);
        }
    }
}
