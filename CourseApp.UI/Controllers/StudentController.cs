using CourseApp.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace CourseApp.UI.Controllers
{
    public class StudentController : Controller
    {
        private HttpClient _client;
        public StudentController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7223/api/");
        }

        public async Task<IActionResult> Index()
        {

            var token = Request.Cookies["admin_token"];

            if (token != null)

                _client.DefaultRequestHeaders.Add(Microsoft.Net.Http.Headers.HeaderNames.Authorization, token);
            else
                return RedirectToAction("login", "account");

            using (var response = await _client.GetAsync("students/all"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    StudentVM vm = new StudentVM
                    {
                        Students = JsonConvert.DeserializeObject<List<StudentGetVM>>(content)
                    };
                    return View(vm);

                }
           
            }

            return View("error");
        }
        public async Task<IActionResult> Create()
        {
            var token = Request.Cookies["admin_token"];

            if (token != null)

                _client.DefaultRequestHeaders.Add(Microsoft.Net.Http.Headers.HeaderNames.Authorization, token);
            else
                return RedirectToAction("login", "account");

            ViewBag.Groups = await _getGroups();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateVM vm)
        {
            var token = Request.Cookies["admin_token"];

            if (token != null)

                _client.DefaultRequestHeaders.Add(Microsoft.Net.Http.Headers.HeaderNames.Authorization, token);
            else
                return RedirectToAction("login", "account");

            if (!ModelState.IsValid)
            {
                ViewBag.Groups = await _getGroups();
                return View();
            }

            if (vm.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
                ViewBag.Groups = await _getGroups();
                return View();
            }



            MultipartFormDataContent requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(vm.Fullname), "Fullname");
            requestContent.Add(new StringContent(vm.GroupId.ToString()), "GroupId");
            requestContent.Add(new StringContent(vm.Point.ToString()), "Point");
            var fileContent = new StreamContent(vm.ImageFile.OpenReadStream());
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(vm.ImageFile.ContentType);
            requestContent.Add(fileContent, "ImageFile", vm.ImageFile.FileName);


         

            using (var response = await _client.PostAsync("students", requestContent))
            {
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("index");
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.Groups = await _getGroups();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var errorVM = JsonConvert.DeserializeObject<ErrorVM>(responseContent);
                    foreach (var item in errorVM.Errors)
                        ModelState.AddModelError(item.Key, item.ErrorMessage);

                    return View();
                }
               
            }

            return View("error");
        }


        public async Task<IActionResult> Edit(int id)
        {
            var token = Request.Cookies["admin_token"];

            if (token != null)

                _client.DefaultRequestHeaders.Add(Microsoft.Net.Http.Headers.HeaderNames.Authorization, token);
            else
                return RedirectToAction("login", "account");

            ViewBag.Groups = await _getGroups();


            using (var response = await _client.GetAsync($"students/{id}"))
            {

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var vm = JsonConvert.DeserializeObject<StudentEditVM>(responseContent);
                    return View(vm);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("login", "account");
                }

            }
            return View("error");

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudentEditVM vm)
        {


            var token =   Request.Cookies["admin_token"];

            if (token != null)

                _client.DefaultRequestHeaders.Add(Microsoft.Net.Http.Headers.HeaderNames.Authorization, token);
            else
                return RedirectToAction("login", "account");

            if (!ModelState.IsValid)
            {
                ViewBag.Groups = await _getGroups();

                return View(vm);

            }
            MultipartFormDataContent requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(vm.Fullname), "Fullname");
            requestContent.Add(new StringContent(vm.GroupId.ToString()), "GroupId");
            requestContent.Add(new StringContent(vm.Point.ToString()), "Point");

            if (vm.ImageFile != null)
            {
                var fileContent = new StreamContent(vm.ImageFile.OpenReadStream());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(vm.ImageFile.ContentType);
                requestContent.Add(fileContent, "ImageFile", vm.ImageFile.FileName);
            }


           

            using (var response = await _client.PutAsync($"students/{id}", requestContent))
            {
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("index");
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.Groups = await _getGroups();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var errorVM = JsonConvert.DeserializeObject<ErrorVM>(responseContent);
                    foreach (var item in errorVM.Errors)
                        ModelState.AddModelError(item.Key, item.ErrorMessage);

                    return View();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return RedirectToAction("login", "account");
                }
            }

            return View("error");
        }
        public async Task<IActionResult> Delete(int id)
        {

            var token = Request.Cookies["admin_token"];
            if (token != null)

                _client.DefaultRequestHeaders.Add(Microsoft.Net.Http.Headers.HeaderNames.Authorization, token);
            else
                return RedirectToAction("login", "account");

            using (var response = await _client.DeleteAsync($"students/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return RedirectToAction("index");
                }
              

            }

            return View("error");
        }

        private async Task<List<GroupViewModelItem>> _getGroups()
        {
            List<GroupViewModelItem> groups = new List<GroupViewModelItem>();

            using (var response = await _client.GetAsync("groups/all"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    groups = JsonConvert.DeserializeObject<List<GroupViewModelItem>>(content);
                }
            }
            return groups;
        }
    }
}
