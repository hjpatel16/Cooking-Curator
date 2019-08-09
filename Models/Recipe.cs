using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CookingCurator.Models
{
    [Table("RECIPES")]
    public partial class Recipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipe()
        {
            //Recipe = new HashSet<Track>();
        }
        [Key]
        public int recipe_ID { get; set; }

        public string title { get; set; }

        public string instructions { get; set; }

        public string author { get; set; }

        //[Required]
        //[StringLength(160)]
        //public string Title { get; set; }

        //public int ArtistId { get; set; }

        //public virtual Artist Artist { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Track> Tracks { get; set; }
    }
}