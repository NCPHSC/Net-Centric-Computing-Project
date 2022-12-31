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
    public class StaffController : Controller
    {

        private readonly StaffContext _context;
        public StaffController(StaffContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            Staff staff = new Staff();
            return View(staff);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Staff model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                _context.Staffs.Add(model);
                await _context.SaveChangesAsync();
                ModelState.AddModelError("msg", "Staff Save Successfully");

            }
            catch(Exception)
            {
                ModelState.AddModelError("msg", "Data Could not Saved");
            }

            return View();
        }

        [AllowAnonymous]
        public IActionResult StaffList(string SearchText="")
        {
            List<Staff> staffs;
            if(SearchText!=""&& SearchText!=null)
            {
                staffs = _context.Staffs.Where(p => p.FullName.Contains(SearchText)).ToList();
            }
            else
                staffs= _context.Staffs.ToList();
            return View(staffs);

        }
        
        public IActionResult Update(int Id)
        {
            var staffs = _context.Staffs.Find(Id);
            return View(staffs);
        }
        [HttpPost]

        public async Task<IActionResult> Update(Staff model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("StaffList");
            }
            catch(Exception)
            {

                ModelState.AddModelError("msg", "Data update Successfully!!!");
                return View();

            }
            
        }


        public IActionResult Remove(int Id)
        {
            try
            {
                var staffs = _context.Staffs.Find(Id);
                if (staffs != null)
                {
                    _context.Staffs.Remove(staffs);
                    _context.SaveChanges();
                }

            }
            catch (Exception)
            {

            }
            return RedirectToAction("StaffList");
        }
    }
}
