using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class Channel
    {
        public Channel()
        {
        }
        //primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public char name { get; set; }
        [Required]
        public float price { get; set; }
     

        // if ageLimit - OK - true
        [Required]
        [DefaultValue(false)]
        public bool ageLimit { get; set; }
    }
}