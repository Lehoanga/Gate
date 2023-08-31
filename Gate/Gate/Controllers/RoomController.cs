using Gate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gate.Controllers
{
    public class RoomController : Controller
    {
        private QLTTXDataContext context = new QLTTXDataContext();
        // GET: Room
        public ActionResult Index()
        {
            List<ROOM> room = context.ROOMs.OrderByDescending(x => x.ID).ToList();
            return View(room);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            ROOM room = new ROOM();
            room.roomID = fc["roomID"].Trim();
            room.inforRom = fc["inforRoom"].Trim();
            room.isReady = true;

            context.ROOMs.InsertOnSubmit(room);
            context.SubmitChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            ROOM room = context.ROOMs.FirstOrDefault(x => x.ID == id);
            ViewBag.room = room;
            return View();
        }

        [HttpPost]
        public ActionResult Detail(FormCollection fc)
        {
            ROOM room = context.ROOMs.FirstOrDefault(x => x.ID == int.Parse(fc["ID"]));
            if (fc["submit"] == "Edit")
            {
                room.roomID = fc["roomIDDE"].Trim();
                room.inforRom= fc["inforRoomDE"].Trim();
                
                context.SubmitChanges();
            }
            if (fc["submit"] == "Delete")
            {
                context.ROOMs.DeleteOnSubmit(room);
                context.SubmitChanges();
            }

            return RedirectToAction("Index");
        }
    }
}