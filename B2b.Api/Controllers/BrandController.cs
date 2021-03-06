﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Db;
using Microsoft.AspNetCore.Http;
using Data.Entity;
using System.IO;
using OfficeOpenXml;
using B2b.BusinessService;

namespace B2b.Admin.Controllers
{
    [Route("brand/[action]")]
    public class BrandController : Controller
    {

         IBrandService _service;
        public BrandController(IBrandService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            _service.GetList();
            return View("~/Views/Brand/Index.cshtml");
        }
        //public IActionResult Index()
        //{
        //    var list = _service.Find(w => w.Status.Equals("1")).ToList();
        //    return View();
        //}
        [HttpGet]
        [Route("{id}")]
        public IActionResult Update(int id)
        {
            ViewBag.Id = id;
            return View("~/Views/Airport/Update.cshtml");
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View("~/Views/Item/Update.cshtml");
        //}
        //public IActionResult Edit(int id)
        //{
        //    var result = _service.Get(id);
        //    return View("~/Views/Item/Update.cshtml", result);
        //}
        //[HttpPost]
        //public IActionResult Update(BrandMaster model)
        //{
        //    if (model != null)
        //    {
        //        model.Status = "1";
        //        if (model.Id == 0)
        //        {
        //            model.CreatedDate = DateTime.Now;
        //            _service.Create(model);
        //        }
        //        else
        //        {
        //            _service.Update(model.Id, model);
        //        }
        //    }
        //    //redirect to edit
        //    return RedirectToAction("Edit", new { id = model.Id });
        //}

        //public IActionResult Delete(int id)
        //{
        //    var result = _service.Delete(id);

        //    return RedirectToAction("Index");
        //}
        //public async Task<List<BrandMaster>> Import()
        //{
        //    IFormFile formFile = Request.Form.Files[0];
        //    var list = new List<BrandMaster>();
        //    using (var stream = new MemoryStream())
        //    {
        //        await formFile.CopyToAsync(stream);
        //        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //        using (var package = new ExcelPackage(stream))
        //        {
        //            try
        //            {
        //                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //                var rowCount = worksheet.Dimension.Rows;

        //                for (int row = 2; row <= rowCount; row++)
        //                {
        //                    list.Add(new BrandMaster
        //                    {
        //                        Name = (worksheet.Cells[row, 1].Value).ToString(),
        //                        CreatedDate = DateTime.Now,
        //                        Status = "1"
        //                    });

        //                }
        //                if (list.Count > 0)
        //                {
        //                    var newUserIDs = list.Select(u => u.Name).Distinct().ToArray();
        //                    var usersInDb = _service.Find(u => newUserIDs.Contains(u.Name))
        //                                                   .Select(u => u.Name).ToArray();
        //                    var usersNotInDb = list.Where(u => !usersInDb.Contains(u.Name));
        //                    foreach (BrandMaster user in usersNotInDb)
        //                    {
        //                        _service.Create(user);
        //                    }
        //                }
        //            }
        //            catch (Exception e)
        //            {

        //            }
        //        }
        //    }
        //    return list;
        //}
        //public async Task<IActionResult> ExportToExcel()

        //{
        //    //Let use below test data for writing it to excel
        //    var item = _service.Find(w => w.Status.Equals("1")).ToList();
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //    // let's convert our object data to Datatable for a simplified logic.
        //    // Datatable is the easiest way to deal with complex datatypes for easy reading and formatting. 
        //    //DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(item), (typeof(DataTable)));
        //    //string path = HttpContext.Current.Server.MapPath(HttpRequest.ApplicationPath);
        //    //string path = "F:/";// System.Environment.GetFolderPath(Environment.SpecialFolder);
        //    //FileInfo filePath = new FileInfo(path);
        //    var stream = new MemoryStream();

        //    using (var package = new ExcelPackage(stream))
        //    {
        //        var workSheet = package.Workbook.Worksheets.Add("test");
        //        workSheet.Cells.LoadFromCollection(item, true);

        //    }
        //    stream.Position = 0;
        //    string excelName = $"FlashSale-{DateTime.Now.ToString("ddMMyyyy")}.xlsx";
        //    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);

        //    // return ;
        //}

    }

}
