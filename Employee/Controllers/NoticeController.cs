using Employee.Data;
using Employee.Data.Static;
using Employee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class NoticeController : Controller
    {
        private readonly StaffContext _context;
        public NoticeController(StaffContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult NoticeList()
        {
            var data = _context.Notices.ToList();
            return View(data);

        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Notice model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                _context.Notices.Add(model);
                await _context.SaveChangesAsync();
                ModelState.AddModelError("msg", "Post Notice Successfully");

            }
            catch (Exception)
            {
                ModelState.AddModelError("msg", "Error");
            }

            return View();
        }

        public IActionResult Update(int Id)
        {
            var notices = _context.Notices.Find(Id);
            return View(notices);
        }
        [HttpPost]

        public async Task<IActionResult> Update(Notice model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("NoticeList");
            }
            catch (Exception)
            {

                ModelState.AddModelError("msg", "Notice Edited Successfully!!!");
                return View();

            }

        }
        public IActionResult Remove(int Id)
        {
            try
            {
                var notices = _context.Notices.Find(Id);
                if (notices != null)
                {
                    _context.Notices.Remove(notices);
                    _context.SaveChanges();
                }

            }
            catch(Exception)
            {

            }
            return RedirectToAction("NoticeList");
        }

    }
}
