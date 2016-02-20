﻿namespace InstaSport.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using InstaSport.Data.Common.Models;

    public class Rating : BaseModel<int>
    {
        [Range(0, 10)]
        public int Value { get; set; }
    }
}
