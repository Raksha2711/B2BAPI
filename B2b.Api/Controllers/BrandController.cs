using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Db;
using Microsoft.AspNetCore.Http;
using Data.Entity;
using System.IO;
using OfficeOpenXml;
using Microsoft.Extensions.Configuration;

namespace B2b.Api.Controllers
{
    public class BrandController : Controller
    {
        
        public B2bDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public BrandController(B2bDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
            {
                var list = _dbContext.BrandMaster.Where(w => w.Status.Equals("1")).ToList();
                return View(list);
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View("~/Views/Item/Update.cshtml");
            }
            public IActionResult Edit(int id)
            {
                var result = _dbContext.BrandMaster.Where(w => w.Id.Equals(id)).FirstOrDefault();
                return View("~/Views/Item/Update.cshtml", result);
            }
            [HttpPost]
            public IActionResult Update(BrandMaster model)
            {
                if (model != null)
                {
                    model.Status = "1";
                    if (model.Id == 0)
                    {
                        model.CreatedDate = DateTime.Now;
                        _dbContext.BrandMaster.Add(model);
                    }
                    else
                    {
                        _dbContext.BrandMaster.Update(model);
                    }
                    _dbContext.SaveChanges();
                }
                //redirect to edit
                return RedirectToAction("Edit", new { id = model.Id });
            }

            public IActionResult Delete(int id)
            {
                var result = _dbContext.BrandMaster.Where(w => w.Id.Equals(id)).FirstOrDefault();
                result.Status = "0";
                _dbContext.BrandMaster.Update(result);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            public async Task<List<BrandMaster>> Import()
            {
                IFormFile formFile = Request.Form.Files[0];
                var list = new List<BrandMaster>();
                using (var stream = new MemoryStream())
                {
                    await formFile.CopyToAsync(stream);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(stream))
                    {
                        try
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                            var rowCount = worksheet.Dimension.Rows;

                            for (int row = 2; row <= rowCount; row++)
                            {
                                list.Add(new BrandMaster
                                {
                                    Name = (worksheet.Cells[row, 1].Value).ToString(),
                                    CreatedDate = DateTime.Now,
                                    Status = "1"
                                });

                            }
                            if (list.Count > 0)
                            {
                                var newUserIDs = list.Select(u => u.Name).Distinct().ToArray();
                                var usersInDb = _dbContext.BrandMaster.Where(u => newUserIDs.Contains(u.Name))
                                                               .Select(u => u.Name).ToArray();
                                var usersNotInDb = list.Where(u => !usersInDb.Contains(u.Name));
                                foreach (BrandMaster user in usersNotInDb)
                                {
                                    _dbContext.Add(user);
                                    _dbContext.SaveChanges();
                                }
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                return list;
            }
            public async Task<IActionResult> ExportToExcel()

            {
                //Let use below test data for writing it to excel
                var item = _dbContext.BrandMaster.Where(w => w.Status.Equals("1")).ToList();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // let's convert our object data to Datatable for a simplified logic.
                // Datatable is the easiest way to deal with complex datatypes for easy reading and formatting. 
                //DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(item), (typeof(DataTable)));
                //string path = HttpContext.Current.Server.MapPath(HttpRequest.ApplicationPath);
                //string path = "F:/";// System.Environment.GetFolderPath(Environment.SpecialFolder);
                //FileInfo filePath = new FileInfo(path);
                var stream = new MemoryStream();

                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("test");
                    workSheet.Cells.LoadFromCollection(item, true);

                }
                //using (var excelPack = new ExcelPackage(filePath))
                //{
                //    var ws = excelPack.Workbook.Worksheets.Add("WriteTest");
                //    ws.Cells.LoadFromDataTable(table, true, OfficeOpenXml.Table.TableStyles.Light8);
                //    excelPack.Save();
                //}
                stream.Position = 0;
                string excelName = $"FlashSale-{DateTime.Now.ToString("ddMMyyyy")}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);

                // return ;
            }

        }
    
}
