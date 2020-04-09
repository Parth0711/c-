using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotorCycle.Models
{
    public class MotorBike
    {

        //this class will be get all data from user for motorbike page

        //variable 
        public int Id { get; set; }
        //variable 
        [Required]
        [StringLength(50)]
        public string MotorName { get; set; }
        //variable 
        public int MakeYear { get; set; }

        //variable 
        [Required]
        [StringLength(50)]
        public string Company { get; set; }
    }
}