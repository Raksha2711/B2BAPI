using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
        public class LoginViewModel
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string Email { get; set; }
            public string Token { get; set; }
            public string RedirectUrl { get; set; }
            public bool Error { get; set; }
            public string ErrorMessage { get; set; }

        }
    
}
