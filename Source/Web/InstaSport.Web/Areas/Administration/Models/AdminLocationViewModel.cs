﻿namespace InstaSport.Web.Areas.Administration.Models
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using InstaSport.Web.Infrastructure.Mapping;

    public class AdminLocationViewModel : IMapFrom<Location>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}