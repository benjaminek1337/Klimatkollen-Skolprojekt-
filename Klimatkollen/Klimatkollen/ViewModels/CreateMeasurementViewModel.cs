﻿using Klimatkollen.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.ViewModels
{
    public class CreateMeasurementViewModel
    {

        public String Value { get; set; }
        public int observationId { get; set; }
        [ForeignKey("observationId")]
        [Required]
        public virtual Observation Observation { get; set; }
        public int? thirdCategoryId { get; set; }
        [ForeignKey("thirdCategoryId")]
        public ThirdCategory ThirdCategory { get; set; }
        public int categoryId { get; set; }
        public Category Category { get; set; }
        public IFormFile Photo { get; set; }
    }
}
