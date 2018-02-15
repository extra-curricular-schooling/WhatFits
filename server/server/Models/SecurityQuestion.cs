﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class SecurityQuestions
    {
        public SecurityQuestions()
        {

        }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public string[] Questions { get; set; }
    }
}