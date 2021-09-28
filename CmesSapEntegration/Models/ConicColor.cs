using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CmesSapEntegration.Models
{
    public class ConicColor
    {
        public ConicColor()
        {
        }

        public ConicColor(string ColorName)
        {
            this.ColorName = ColorName;
        }

        public string ColorName { get; set; }

    }
}
