﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace urbanbooks.Controllers
{
    public class HelpController : Controller
    {
        public ActionResult FAQs()
        {
            return View();
        }
    }
}