using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolWeb.ViewModel
{
    public class SelectListViewModel
    {
        public SelectList Classes { get; set; }
        public SelectList MinZus { get; set; }
    }
}