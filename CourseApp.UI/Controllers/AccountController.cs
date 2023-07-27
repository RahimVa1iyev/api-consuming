using CourseApp.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CourseApp.UI.Controllers
{
    public class AccountController : Controller
    {
        HttpClient _client;
        public AccountController()
        {
            _client = new HttpClient();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM vm, string? returnURL)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            StringContent content = new StringContent(JsonConvert.SerializeObject(vm), System.Text.Encoding.UTF8, "application/json");
            using (var response = await _client.PostAsync("https://localhost:7223/api/Account/login", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var resp = JsonConvert.DeserializeObject<LoginResponseVM>(responseContent);
                    Response.Cookies.Append("admin_token", "Bearer " + resp.Token);

                    return returnURL == null ? RedirectToAction("index", "home") : Redirect(returnURL);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ModelState.AddModelError("", "Username or password is not correct!");
                    return View();
                }
            }
            return View("error");
        }
        public IActionResult Logout()
        {
            Response.Cookies.Append("admin_token", "");
            return RedirectToAction("login");
        }
    }
}
