﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class Payment
    {
        public Payment()
        {

        }
        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Payment date
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        //Payment sum
        [Required]
        public double Summ { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int OrderId { get; set; }

        //Make linked entity as virtual for lazy loading work
        //[Required]
        //public virtual User User { get; set; }

        [Required]
        public virtual Order Order { get; set; }

    }
}