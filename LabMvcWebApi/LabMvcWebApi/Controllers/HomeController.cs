using LabMvcWebApi.Models;
using LabMvcWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabMvcWebApi.Controllers
{
    public class HomeController : Controller
    {
        IClientKeyRep ckRep = new ClientKeyAppRep();
        string company_cd = "TUANDH_COMPANY";

        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GenerateClientKey()
        {
            // Do logic generate client key here
            //1. Generate key:

            string c_id = "";
            string c_sr = "";
            ckRep.GenerateUniqueKey(out c_id, out c_sr);
            //2. Save key to store
            ClientKey key = new ClientKey { Client_Id = c_id, Client_Secret = c_sr, Company_code = company_cd };
            ckRep.SaveClientIDandClientSecret(key);
            //3. Done
            return RedirectToAction("Index");
        }
    }
}