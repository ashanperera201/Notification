#region References
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Notification.Service;
using Notification.Coordinates;
#endregion

#region Namespace
namespace Notification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private IHubContext<LocationHub, ILocationHubService> _hubContext;
        public LocationController(IHubContext<LocationHub, ILocationHubService> hubContext)
        {
            _hubContext = hubContext;
        }


        [HttpPost]
        public string Post([FromBody]CoordinatesDTO coordinates)
        {
            string retMessage = string.Empty;

            try
            {
                //_hubContext.Clients.All.GetLocation(coordinates);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }
    }
}
#endregion