using CRUD_application_2.Models;
using System.Web.Mvc;

public class UserController : Controller
{
    private readonly IUserRepository userRepository;

    public UserController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    // GET: User
    public ActionResult Index()
    {
        var users = userRepository.GetUsers();
        return View(users);
    }

    // GET: User/Details/5
    public ActionResult Details(int id)
    {
        var user = userRepository.GetUser(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }

    // GET: User/Create
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            userRepository.AddUser(user);
            return RedirectToAction("Index");
        }
        return View(user);
    }

    // GET: User/Edit/5
    public ActionResult Edit(int id)
    {
        var user = userRepository.GetUser(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }

    // POST: User/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, User user)
    {
        if (ModelState.IsValid)
        {
            var existingUser = userRepository.GetUser(id);
            if (existingUser == null)
            {
                return HttpNotFound();
            }
            userRepository.UpdateUser(user);
            return RedirectToAction("Index");
        }
        return View(user);
    }


    // GET: User/Delete/5
    public ActionResult Delete(int id)
    {
        var user = userRepository.GetUser(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }

    // POST: User/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
        var user = userRepository.GetUser(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        userRepository.DeleteUser(id);
        return RedirectToAction("Index");
    }
}
