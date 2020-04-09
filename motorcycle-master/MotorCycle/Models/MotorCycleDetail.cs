using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotorCycle.Models
{
    public class MotorCycleDetail
    {

        //this class will be get all data from user for motorcycledetails
        public int Id { get; set; }

        

        [Required]
        [StringLength(20)]
        public string MotorBrand { get; set; }

        [Required]
        [StringLength(20)]
        public string MotorModel { get; set; }

        [Required]
        [StringLength(20)]
        public string Country { get; set; }

        public int MotorCycleId { get; set; }

        public MotorBike MotorCycle { get; set; }
    }
}