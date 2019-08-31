using Notification.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Service
{
    public interface ILocationHubService
    {
        //Task GetLocation<T>(T dto);
        Task GetUserNotification<T>(T userDto);
    }
}
