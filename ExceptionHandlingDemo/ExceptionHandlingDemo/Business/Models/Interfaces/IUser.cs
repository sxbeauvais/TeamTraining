using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandlingDemo.Business.Models.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
