using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp_app.Models
{
    public class ImageData
    {
        public string ImageURL { get; set; }


        public ImageData(string url)
        {
            ImageURL = url;

        }
    }
}
