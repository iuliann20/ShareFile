using Microsoft.AspNetCore.Mvc;
using ShareFile.BL.Logic.Interfaces;
using ShareFile.Helpers.Interfaces;
using ShareFile.Models;
using ShareFile.TL.DTO;
using System;
using System.Diagnostics;

namespace ShareFile.Controllers
{
    public class ShareController : Controller
    {
        private readonly IFileLogic _fileLogic;
        private readonly IShareControllerHelper _shareControllerHelper;
        public ShareController(IFileLogic fileLogic, IShareControllerHelper shareControllerHelper)
        {
            _fileLogic = fileLogic;
            _shareControllerHelper = shareControllerHelper;
        }

        public IActionResult Index()
        {
            _fileLogic.AddFile(new SharedFileDTO { FileName = "Iulian", FileSize = "23Mb", UploadDate = DateTime.Now });

            return View();
        }
        public IActionResult Files()
        {
            System.Collections.Generic.List<SharedFileViewModel> fileViewModels = _shareControllerHelper.BuildViewModel(_fileLogic.GetAllFiles());
            return View(fileViewModels);
        }
        public IActionResult Delete(int id)
        {
            _fileLogic.RemoveFile(id);
            return RedirectToAction("Files");
        }

        [HttpPost]
        public IActionResult AddFile([FromBody] SharedFileViewModel sharedFileViewModel)
        {
            if (string.IsNullOrEmpty(sharedFileViewModel.FileName) && string.IsNullOrEmpty(sharedFileViewModel.FileSize))
            {
                return RedirectToAction("Files");
            }

            sharedFileViewModel.UploadDate = DateTime.Now;
            _fileLogic.AddFile(_shareControllerHelper.BuildDTO(sharedFileViewModel));
            return RedirectToAction("Files");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
