using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace StickWizards.Models
{
    public class StickTextureViewModel
    {
        public List<Stick> Sticks { get; set; }
        public SelectList Texture { get; set; }
        public string StickTexture { get; set; }
        public string SearchString { get; set; }
    }
}
