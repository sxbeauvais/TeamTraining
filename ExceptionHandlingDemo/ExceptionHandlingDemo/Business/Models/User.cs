using ExceptionHandlingDemo.Business.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandlingDemo.Business.Models
{
    public class User: IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
