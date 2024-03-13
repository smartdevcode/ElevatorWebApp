using Microsoft.AspNetCore.Mvc;
using ElevatorWebApp.Models;

namespace ElevatorWebApp.Controllers
{
    public class ElevatorController : Controller
    {
        private static Elevator elevator = new Elevator();

        public IActionResult Index()
        {
            return View(elevator);
        }

        [HttpPost]
        public IActionResult RequestElevator(int floor, RequestDirection direction = RequestDirection.None)
        {
            elevator.AddFloorRequest(floor, direction);
            return RedirectToAction("Index");
        }

        public IActionResult MoveElevator()
        {
            elevator.MoveToNextRequest();
            return RedirectToAction("Index");
        }
    }
}
