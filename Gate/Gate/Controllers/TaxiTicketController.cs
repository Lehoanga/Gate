using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using FPT_UniGate.Common;
using Gate.Models;
using OfficeOpenXml;
using PagedList;

namespace FPT_UniGate.Controllers
{
    public class TaxiTicketController : Controller
    {
        // GET: TaxiTicket
        public QLTTXDataContext context = new QLTTXDataContext();

        [SessionTimeout]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string SearchDateStart, string SearchDateEnd, int? page)
        {
            List<TAXITICKET> ticketList = context.TAXITICKETs.OrderByDescending(x => x.ID).ToList();

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
                                       || s.cardNum.ToString().Contains(searchString)
                                       || s.userName.ToLower().Contains(searchString.ToLower())
                                       ).ToList();
            }
            if (!String.IsNullOrEmpty(SearchDateStart))
            {
                ticketList = ticketList.Where(s => s.startDate >= DateTime.Parse(SearchDateStart)).ToList();
            }
            if (!String.IsNullOrEmpty(SearchDateEnd))
            {
                ticketList = ticketList.Where(s => s.startDate <= DateTime.Parse(SearchDateEnd)).ToList();
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
            List<TAXITICKET> ticketList = context.TAXITICKETs.OrderByDescending(x => x.ID).ToList();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CLTSortParm = String.IsNullOrEmpty(sortOrder) ? "CLT_desc" : "CLT_desc";
            ViewBag.DMTSortParm = String.IsNullOrEmpty(sortOrder) ? "DMT_desc" : "DMT_desc";
            ViewBag.DTTSortParm = String.IsNullOrEmpty(sortOrder) ? "DTT_desc" : "DTT_desc";
            ViewBag.AllSortParm = String.IsNullOrEmpty(sortOrder) ? "All_desc" : "All_desc";

            if (!String.IsNullOrEmpty(searchString))
            {
                ticketList = ticketList.Where(s => s.ticketID.ToString().Contains(searchString)
                                       || s.cardNum.ToString().Contains(searchString)
                                       || s.userName.ToLower().Contains(searchString.ToLower())
                                       ).ToList();
            }            
            if (!String.IsNullOrEmpty(SearchDateStart))
            {
                ticketList = ticketList.Where(s => s.startDate >= DateTime.Parse(SearchDateStart)).ToList();
            }
            if (!String.IsNullOrEmpty(SearchDateEnd))
            {
                ticketList = ticketList.Where(s => s.startDate <= DateTime.Parse(SearchDateEnd)).ToList();
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

                    string formattedDateStart = item.startDate.Value.ToString("dd/MM/yyyy");
                    string formattedDateEnd = item.endDate.Value.ToString("dd/MM/yyyy");

                    string formattedtakecardDate = "";
                    string formattedreturncardDate = "";
                    if (item.takecardDate != null)
                    {
                        formattedtakecardDate = item.takecardDate.Value.ToString();
                    }
                    if (item.returncardDate != null)
                    {
                        formattedreturncardDate = item.returncardDate.Value.ToString();
                    }                

                    worksheet.Cells[row, col++].Value = item.ticketID;
                    worksheet.Cells[row, col++].Value = item.cardNum;
                    worksheet.Cells[row, col++].Value = item.userName;
                    worksheet.Cells[row, col++].Value = formattedDateStart;
                    worksheet.Cells[row, col++].Value = formattedDateEnd;
                    worksheet.Cells[row, col++].Value = item.loggerName;
                    worksheet.Cells[row, col++].Value = item.borrowerName;
                    worksheet.Cells[row, col++].Value = formattedtakecardDate;
                    worksheet.Cells[row, col++].Value = formattedreturncardDate;
                    if(item.borrowStatus == false && item.returnStatus == false)
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
                    return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BaocaomuontheTaxi.xlsx");
                }
            }
        }

        [SessionTimeout]
        public ActionResult Detail(int ID)
        {
            TAXITICKET ticket = context.TAXITICKETs.FirstOrDefault(x => x.ID == ID);
            ViewBag.ticketDetail = ticket;

            List<TAXICARD> taxiCard = context.TAXICARDs.Where(x => x.isReady == true).OrderByDescending(x => x.cardID).ToList();
            ViewBag.taxiCard = taxiCard;

            TAXICARD TicketCardNum = context.TAXICARDs.FirstOrDefault(x => x.cardNum == ticket.cardNum);
            ViewBag.TicketCardNum = TicketCardNum;

            return View();
        }

        [SessionTimeout]
        [HttpPost]
        public ActionResult Detail(FormCollection fc)
        {
            if (fc["submit"] == "edit")
            {
                TAXITICKET tic = context.TAXITICKETs.FirstOrDefault(x => x.ID == int.Parse(fc["ID"]));
                TAXICARD card = context.TAXICARDs.FirstOrDefault(x => x.cardNum == int.Parse(fc["taxicardNum"]));

                tic.ticketID = int.Parse(fc["ticketID"]);;
                tic.startDate = DateTime.Parse(fc["startDate"]);
                tic.endDate = DateTime.Parse(fc["endDate"]);
                tic.userName = fc["userName"];
                tic.loggerName = fc["loggerName"];
                tic.borrowerName = fc["borrowerName"];
                
                if(card.cardNum != tic.cardNum)
                {
                    TAXICARD card2 = context.TAXICARDs.FirstOrDefault(x => x.cardNum == tic.cardNum);
                    tic.cardNum = int.Parse(fc["taxicardNum"]);                

                    card.isReady = false;
                    card2.isReady = true;
                    context.SubmitChanges();
                }

                context.SubmitChanges();
            }
            if (fc["submit"] == "checkin")
            {
                TAXITICKET tic = context.TAXITICKETs.FirstOrDefault(x => x.ID == int.Parse(fc["ID"]));
                tic.takecardDate = DateTime.Now;
                tic.borrowStatus = true;
                context.SubmitChanges();
            }
            if (fc["submit"] == "checkout")
            {
                TAXITICKET tic = context.TAXITICKETs.FirstOrDefault(x => x.ID == int.Parse(fc["ID"]));
                TAXICARD card2 = context.TAXICARDs.FirstOrDefault(x => x.cardNum == tic.cardNum);
                TAXICARD card = context.TAXICARDs.FirstOrDefault(x => x.cardNum == int.Parse(fc["taxicardNum"]));

                card.isReady = false;
                card2.isReady = true;
                context.SubmitChanges();

                tic.returncardDate = DateTime.Now;
                tic.returnStatus = true;
                tic.Price = fc["Price"];

                context.SubmitChanges();
            }
            return RedirectToAction("Detail",new {ID = int.Parse(fc["ID"]) });
        }

        [SessionTimeout]
        public ActionResult Create()
        {
            List<TAXICARD> taxiCard = context.TAXICARDs.Where(x => x.isReady == true).OrderByDescending(x => x.cardID).ToList();
            ViewBag.taxiCard = taxiCard;
            return View();
        }

        [SessionTimeout]
        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            TAXITICKET tic = new TAXITICKET();
            TAXICARD card = context.TAXICARDs.FirstOrDefault(x => x.cardNum == int.Parse(fc["taxicardNum"]));

            tic.ticketID = int.Parse(fc["ticketID"]);
            tic.cardNum = int.Parse(fc["taxicardNum"]);
            tic.startDate = DateTime.Parse(fc["startDate"]);
            tic.endDate = DateTime.Parse(fc["endDate"]);
            tic.userName = fc["userName"];
            tic.loggerName = fc["loggerName"];
            //default
            tic.borrowerName = fc["loggerName"];
            tic.borrowStatus = false;
            tic.returnStatus = false;

            card.isReady = false;

            context.TAXITICKETs.InsertOnSubmit(tic);
            context.SubmitChanges();

            return RedirectToAction("Index");
        }
    }
}