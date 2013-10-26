using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AutoMorgue.Services.Models
{
    [DataContract]
    public class UserRegisterModel : UserLoginModel
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }
    }
}