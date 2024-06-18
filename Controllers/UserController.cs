using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here
            return View(userlist);

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Implement the Create method (POST) here
            if (ModelState.IsValid)
            {
                // Assuming User has an Id property that uniquely identifies each user
                // and it's manually set. If your IDs are auto-generated (e.g., database auto-increment),
                // you might not need this step.
                user.Id = userlist.Any() ? userlist.Max(u => u.Id) + 1 : 1;

                userlist.Add(user);
                return RedirectToAction("Index");
            }

            // If model state is not valid, return to the Create view to show validation errors
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            var user = userlist.FirstOrDefault(u => u.Id == id);
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
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Find the user in the list
                var userToUpdate = userlist.FirstOrDefault(u => u.Id == id);

                // If no user is found with the provided ID, return HttpNotFoundResult
                if (userToUpdate == null)
                {
                    return HttpNotFound();
                }

                // Update the user's details
                userToUpdate.Name = user.Name;
                userToUpdate.Email = user.Email;
                //userToUpdate.Phone = user.Phone;
                // Add any other fields that need to be updated

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }

            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            return View(user);

        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            // Find the user in the list
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user to the Delete view
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here
            // Find the user in the list
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Remove the user from the list
            userlist.Remove(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
    }
}
