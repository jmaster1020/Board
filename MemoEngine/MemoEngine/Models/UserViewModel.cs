using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoEngine.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Intro { get; set; }

    }
}