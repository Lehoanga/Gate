using Gate.Models;
using OfficeOpenXml;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gate.Controllers
{
    public class RoomTicketController : Controller
    {
        private QLTTXDataContext context = new QLTTXDataContext();
        // GET: RoomTicket
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string SearchDateStart, string SearchDateEnd, int? page)
        {
            List<ROOMTICKET> ticketList = context.ROOMTICKETs.OrderByDescending(x => x.ID).ToList();
            
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CLTSortParm = String.IsNullOrEmpty(sortOrder) ? "CLT_desc" : "CLT_desc";
            ViewBag.DMTSortParm = String.IsNullOrEmpty(sortOrder) ? "DMT_desc" : "DMT_desc";
            ViewBag.DTTSortParm = String.IsNullOrEmpty(sortOrder) ? "DTT_desc" : "DTT_desc";
            ViewBag.AllSortParm = String.IsNullOrEmpty(sortOrder) ? "All_desc" : "All_desc";

            if (searchString != null && SearchDateStart != null && SearchDateEnd != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentDateStart = SearchDateStart;
            ViewBag.SearchDateEnd = SearchDateEnd;

            if (!String.IsNullOrEmpty(searchString))
            {
                ticketList = ticketList.Where(s => s.ticketID.ToString().Contains(searchString)
                                       || s.roomID.ToString().Contains(searchString)
                                       || s.bookingName.ToLower().Contains(searchString.ToLower())
                                       ).ToList();
            }
            if (!String.IsNullOrEmpty(SearchDateStart))
            {
                ticketList = ticketList.Where(s => s.datetimeStart >= DateTime.Parse(SearchDateStart)).ToList();
            }
            if (!String.IsNullOrEmpty(SearchDateEnd))
            {
                ticketList = ticketList.Where(s => s.datetimeStart <= DateTime.Parse(SearchDateEnd)).ToList();
            }

            switch (sortOrder)
            {
                //case "name_desc":
                //    bor = bor.OrderByDescending(s => s.Borrower).ToList();
                //    break;                

                case "CLT_desc":
                    ticketList = ticketList.Where(x => x.borrowStatus == false && x.returnStatus == false).ToList();
                    break;
                case "DMT_desc":
                    ticketList = ticketList.Where(x => x.borrowStatus == true && x.returnStatus == false).ToList();
                    break;
                case "DTT_desc":
                    ticketList = ticketList.Where(x => x.borrowStatus == true && x.returnStatus == true).ToList();
                    break;
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(ticketList.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ExportToExcel(string sortOrder, string searchString, string SearchDateStart, string SearchDateEnd)
        {
            List<ROOMTICKET> ticketList = context.ROOMTICKETs.OrderByDescending(x => x.ID).ToList();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CLTSortParm = String.IsNullOrEmpty(sortOrder) ? "CLT_desc" : "CLT_desc";
            ViewBag.DMTSortParm = String.IsNullOrEmpty(sortOrder) ? "DMT_desc" : "DMT_desc";
            ViewBag.DTTSortParm = String.IsNullOrEmpty(sortOrder) ? "DTT_desc" : "DTT_desc";
            ViewBag.AllSortParm = String.IsNullOrEmpty(sortOrder) ? "All_desc" : "All_desc";

            if (!String.IsNullOrEmpty(searchString))
            {
                ticketList = ticketList.Where(s => s.ticketID.ToString().Contains(searchString)
                                       || s.roomID.ToString().Contains(searchString)
                                       || s.bookingName.ToLower().Contains(searchString.ToLower())
                                       ).ToList();
            }
            if (!String.IsNullOrEmpty(SearchDateStart))
            {
                ticketList = ticketList.Where(s => s.datetimeStart >= DateTime.Parse(SearchDateStart)).ToList();
            }
            if (!String.IsNullOrEmpty(SearchDateEnd))
            {
                ticketList = ticketList.Where(s => s.datetimeStart <= DateTime.Parse(SearchDateEnd)).ToList();
            }

            switch (sortOrder)
            {
                //case "name_desc":
                //    bor = bor.OrderByDescending(s => s.Borrower).ToList();
                //    break;                

                case "CLT_desc":
                    ticketList = ticketList.Where(x => x.borrowStatus == false && x.returnStatus == false).ToList();
                    break;
                case "DMT_desc":
                    ticketList = ticketList.Where(x => x.borrowStatus == true && x.returnStatus == false).ToList();
                    break;
                case "DTT_desc":
                    ticketList = ticketList.Where(x => x.borrowStatus == true && x.returnStatus == true).ToList();
                    break;
            }


            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                int row = 2;

                worksheet.Cells["A1"].Value = "Số Ticket";
                worksheet.Cells["B1"].Value = "Số thẻ Taxi";
                worksheet.Cells["C1"].Value = "Người đi";
                worksheet.Cells["D1"].Value = "Ngày đi";
                worksheet.Cells["E1"].Value = "Ngày về";
                worksheet.Cells["F1"].Value = "Người tạo yêu cầu";
                worksheet.Cells["G1"].Value = "Người mượn thẻ";
                worksheet.Cells["H1"].Value = "Thời gian lấy thẻ";
                worksheet.Cells["I1"].Value = "Thời gian trả thẻ";
                worksheet.Cells["J1"].Value = "Trạng thái";

                foreach (var item in ticketList)
                {
                    int col = 1;

                    string formattedDateStart = item.datetimeStart.Value.ToString();
                    string formattedDateEnd = item.datetimeEnd.Value.ToString();

                    string formattedtakecardDate = "";
                    string formattedreturncardDate = "";
                    if (item.datetimeCheckin != null)
                    {
                        formattedtakecardDate = item.datetimeCheckin.Value.ToString();
                    }
                    if (item.datetimeCheckout != null)
                    {
                        formattedreturncardDate = item.datetimeCheckout.Value.ToString();
                    }

                    worksheet.Cells[row, col++].Value = item.ticketID;
                    worksheet.Cells[row, col++].Value = item.roomID;
                    worksheet.Cells[row, col++].Value = item.bookingName;
                    worksheet.Cells[row, col++].Value = item.borrowerName;
                    worksheet.Cells[row, col++].Value = formattedDateStart;
                    worksheet.Cells[row, col++].Value = formattedDateEnd;
                    worksheet.Cells[row, col++].Value = formattedtakecardDate;
                    worksheet.Cells[row, col++].Value = formattedreturncardDate;
                    if (item.borrowStatus == false && item.returnStatus == false)
                    {
                        worksheet.Cells[row, col++].Value = "Chưa lấy thẻ";
                    }
                    if (item.borrowStatus == true && item.returnStatus == false)
                    {
                        worksheet.Cells[row, col++].Value = "Đang mượn";
                    }
                    if (item.borrowStatus == true && item.returnStatus == true)
                    {
                        worksheet.Cells[row, col++].Value = "Đã trả thẻ";
                    }
                    row++;
                }

                // Lưu dữ liệu vào MemoryStream
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);

                    // Trả về file Excel như một FileResult
                    return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Baocaomuonthephonghop.xlsx");
                }
            }
        }

        public ActionResult Create()
        {
            List<ROOM> room = context.ROOMs.OrderByDescending(x => x.ID).ToList();
            ViewBag.room = room;
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            ROOMTICKET ticket = new ROOMTICKET();
            ROOM room = context.ROOMs.FirstOrDefault(x => x.roomID.Equals(fc["roomID"]));
            List<ROOMTICKET> ticExist = context.ROOMTICKETs.Where(x => x.roomID == room.roomID && x.returnStatus == false).ToList();
            //List<ROOMTICKET> ticExistOverlap = new List<ROOMTICKET>();

            //foreach (var t in ticExist)
            //{
            //    if (CheckdatetimeOverlap(t.datetimeStart, t.datetimeEnd, DateTime.Parse(fc["startDate"]), DateTime.Parse(fc["endDate"])))
            //    {
            //        ticExistOverlap.Add(t);
            //    }
            //}

            //if (ticExistOverlap.Count > 0)
            //{
            //    ViewBag.ErrOverlap = ticExistOverlap;                
            //    return RedirectToAction("Create");
            //}

            ticket.ticketID = int.Parse(fc["ticketID"]);
            ticket.roomID = fc["roomID"];
            ticket.bookingName = fc["orderName"];
            ticket.datetimeStart = DateTime.Parse(fc["startDate"]);
            ticket.datetimeEnd = DateTime.Parse(fc["endDate"]);

            ticket.borrowStatus = false;
            ticket.returnStatus = false;
            ticket.borrowerName = fc["orderName"];
            context.ROOMTICKETs.InsertOnSubmit(ticket);
            context.SubmitChanges();

            room.isReady = false;
            context.SubmitChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int ID)
        {
            ROOMTICKET ticket = context.ROOMTICKETs.FirstOrDefault(x => x.ID == ID);
            ViewBag.ticketDetail = ticket;

            List<ROOM> room = context.ROOMs.Where(x => x.isReady == true).OrderByDescending(x => x.ID).ToList();
            ViewBag.room = room;

            ROOM TicketRoomID = context.ROOMs.FirstOrDefault(x => x.roomID == ticket.roomID);
            ViewBag.TicketRoomID = TicketRoomID;

            return View();
        }

        [HttpPost]
        public ActionResult Detail(FormCollection fc)
        {          
            if (fc["submit"] == "edit")
            {
                ROOMTICKET ticket = context.ROOMTICKETs.FirstOrDefault(x => x.ID == int.Parse(fc["ID"]));
                ROOM room = context.ROOMs.FirstOrDefault(x => x.roomID.Equals(fc["roomID"]));

                ticket.ticketID = int.Parse(fc["ticketID"]);
                ticket.datetimeStart = DateTime.Parse(fc["startDate"]);
                ticket.datetimeEnd = DateTime.Parse(fc["endDate"]);
                ticket.bookingName = fc["orderName"];
                ticket.borrowerName = fc["borrowerName"];

                if (room.roomID != ticket.roomID)
                {
                    ROOM room2 = context.ROOMs.FirstOrDefault(x => x.roomID == ticket.roomID);
                    ticket.roomID = fc["roomID"];

                    room2.isReady = true;
                    room.isReady = false;
                    context.SubmitChanges();
                }
                context.SubmitChanges();
            }

            if (fc["submit"] == "checkin")
            {
                ROOMTICKET ticket = context.ROOMTICKETs.FirstOrDefault(x => x.ID == int.Parse(fc["ID"]));
                ROOM room = context.ROOMs.FirstOrDefault(x => x.roomID == ticket.roomID);
                ticket.datetimeCheckin = DateTime.Now;
                ticket.borrowStatus = true;
                room.isReady = false;
                context.SubmitChanges();
            }

            if (fc["submit"] == "checkout")
            {
                ROOMTICKET ticket = context.ROOMTICKETs.FirstOrDefault(x => x.ID == int.Parse(fc["ID"]));
                ROOM room = context.ROOMs.FirstOrDefault(x => x.roomID == ticket.roomID);
                
                ticket.datetimeCheckout = DateTime.Now;
                ticket.returnStatus = true;
                room.isReady = true;
                context.SubmitChanges();
            }

            return RedirectToAction("Detail", new { ID = int.Parse(fc["ID"]) });
        }

        public static bool CheckdatetimeOverlap(DateTime? tStartA, DateTime? tEndA, DateTime tStartB, DateTime tEndB)
        {
            bool overlap = tStartA < tEndB && tStartB < tEndA;
            return overlap;
        }
    }
}