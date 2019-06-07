using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace acidfox_api.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
        public bool Called { get; set; }
        public int Called_Count { get; set; }
        public DateTime? Last_Called { get; set; }
        public string Notes { get; set; }

    }
}