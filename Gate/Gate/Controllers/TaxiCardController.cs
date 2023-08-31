using FPT_UniGate.Common;
using Gate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_UniGate.Controllers
{
    public class TaxiCardController : Controller
    {
        public QLTTXDataContext context = new QLTTXDataContext();

        // GET: TaxiCard
        [SessionTimeout]
        public ActionResult Index()
        {
            List<TAXICARD> cards = context.TAXICARDs.OrderByDescending(x => x.cardID).ToList();
            return View(cards);
        }

        [SessionTimeout]
        public ActionResult Create()
        {
            return View();
        }

        [SessionTimeout]
        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            TAXICARD taxiCard = new TAXICARD();

            taxiCard.cardNum = int.Parse(fc["taxiCardNum"]);
            taxiCard.taxiCom = fc["taxiCom"];
            taxiCard.department = fc["Department"];
            if (fc["checkOwner"] == "on")
            {
                taxiCard.ownerName = fc["ownerName"];
            }
            taxiCard.isReady = true;            

            context.TAXICARDs.InsertOnSubmit(taxiCard);
            context.SubmitChanges();

            return RedirectToAction("Index");
        }

        [SessionTimeout]
        public ActionResult Detail(int id)
        {
            TAXICARD taxiCard = context.TAXICARDs.FirstOrDefault(x => x.cardID == id);
            ViewBag.taxiCard = taxiCard;
            return View();
        }

        [SessionTimeout]
        [HttpPost]
        public ActionResult Detail(FormCollection fc)
        {
            TAXICARD taxiCard = context.TAXICARDs.FirstOrDefault(x => x.cardID == int.Parse(fc["cardID"]));
            if (fc["submit"] == "Edit")
            {
                taxiCard.cardNum = int.Parse(fc["taxiCardNumDe"]);
                taxiCard.taxiCom = fc["taxiComDe"];
                taxiCard.department = fc["DepartmentDe"];
                if (fc["ownerNameDe"] != "")
                {
                    taxiCard.ownerName = fc["ownerNameDe"];
                }
                else
                {
                    taxiCard.ownerName = null;
                }
                

                context.SubmitChanges();
            }
            if (fc["submit"] == "Delete")
            {
                context.TAXICARDs.DeleteOnSubmit(taxiCard);
                context.SubmitChanges();
            }

            return RedirectToAction("Index");
        }

    }
}