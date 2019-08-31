using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Notification.Dto;
using Notification.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The hub context
        /// </summary>
        private IHubContext<LocationHub, ILocationHubService> _hubContext;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="hubContext">The hub context.</param>
        public UserController(IHubContext<LocationHub, ILocationHubService> hubContext)
        {
            _hubContext = hubContext;
        }

        /// <summary>
        /// Posts the user notification.
        /// </summary>
        /// <param name="userDto">The user dto.</param>
        /// <returns></returns>
        [HttpPost("notify")]
        public string PostUserNotification([FromBody] UserDto userDto)
        {
            try
            {
                _hubContext.Clients.All.GetUserNotification<UserDto>(userDto);
                return "Done";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
