﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Tweet
    {
        public int TweetId { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }

    }
}
