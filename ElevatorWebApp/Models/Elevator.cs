using System.Collections.Generic;
using System.Linq;

namespace ElevatorWebApp.Models
{
    public enum RequestDirection { Up, Down, None }

    public class FloorRequest
    {
        public int Floor { get; set; }
        public RequestDirection Direction { get; set; }
    }

    public class Elevator
    {
        public int CurrentFloor { get; private set; } = 1;
        public List<FloorRequest> FloorRequests { get; private set; } = new List<FloorRequest>();

        public void AddFloorRequest(int floor, RequestDirection direction = RequestDirection.None)
        {
            if (!FloorRequests.Any(r => r.Floor == floor && r.Direction == direction))
            {
                FloorRequests.Add(new FloorRequest { Floor = floor, Direction = direction });
            }
        }

        // Simulate moving to the next requested floor
        // This method can be expanded to consider the direction of requests for more complex logic
        public void MoveToNextRequest()
        {
            if (FloorRequests.Count > 0)
            {
                var nextRequest = FloorRequests.First();
                CurrentFloor = nextRequest.Floor;
                FloorRequests.RemoveAt(0);
            }
        }
    }
}
