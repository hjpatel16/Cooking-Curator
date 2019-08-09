using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CookingCurator.Controllers
{
    public class RecipeBase
    {
        [Key]
        public int recipe_ID { get; set; }

        public string title { get; set; }

        public string instructions { get; set; }

        public string author { get; set; }
    }
}