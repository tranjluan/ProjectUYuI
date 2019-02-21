using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YUI.Models
{
    public class TestCreate
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}