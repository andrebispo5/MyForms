using System;
using MyForms.Models;

namespace MyForms.Services
{
    public interface IAppDataService
    {
        UserProfile UserProfile { get; }
    }
}
