using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetIdentity.Shared
{
    public class UserManagerResponse
    {
        //After register
        public string Message { get; set; }
        public bool IsSucces { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
