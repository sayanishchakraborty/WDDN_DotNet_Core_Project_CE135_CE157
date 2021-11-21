using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _Db;

        public StudentController(StudentContext Db)
        {
            _Db = Db;
        }
        public IActionResult StudentList()
        {
            try
            {
                

                var stdList = from a in _Db.tbl_Student
                              join b in _Db.tbl_Department
                              on a.DepID equals b.DepID
                              into Dep
                              from b in Dep.DefaultIfEmpty()

                              join c in _Db.tbl_Subject
                              on a.SubID equals c.SubID
                              into Sub
                              from c in Sub.DefaultIfEmpty()

                              select new Students
                              {
                                    StudentID = a.StudentID,
                                    RegistrationNo = a.RegistrationNo,
                                    FirstName =a.FirstName,
                                    LastName =a.LastName,
                                    Email=a.Email,
                                    Address=a.Address,
                                    Mobile=a.Mobile,
                                    Semester=a.Semester,
                                    Review=a.Review,
                                    DepID=a.DepID,
                                    SubID=a.SubID,

                                    Department=b==null?"":b.Department,
                                    Subject=c==null?"":c.Subject,
                              };

                return View(stdList);
            }
            catch(Exception ex)
            {
                return View();
            }

            
        }

        [HttpGet]
        public IActionResult Create(Students obj)
        {

            LoadDLLDep();
            LoadDLLSub();
            return View(obj);
        }

   

        [HttpPost]
        public async Task<IActionResult> AddStudent(Students obj)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    if (obj.StudentID == 0)
                    {
                      

                        _Db.tbl_Student.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }

                    LoadDLLDep();
                    LoadDLLSub();
                    return RedirectToAction("StudentList");
                   
                }
                return View();
            }
            catch(Exception ex)
            {

                return RedirectToAction("StudentList");
            }
        }

       

        public async Task<IActionResult> DeleteStd(int id)
        {
            try
            {
                var std = await _Db.tbl_Student.FindAsync(id);
                if(std!=null)
                {
                    _Db.tbl_Student.Remove(std);
                    await _Db.SaveChangesAsync();

                }
                return RedirectToAction("StudentList");

            }
            catch(Exception ex)
            {
                return RedirectToAction("StudentList");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            Students std = _Db.tbl_Student.Where(p => p.StudentID == id).FirstOrDefault();
            LoadDLLDep();
            LoadDLLSub();
            return View(std);

        }

        [HttpPost]
        public IActionResult Edit(Students std)
        {
            var student = _Db.tbl_Student.Where(p => p.StudentID == std.StudentID).FirstOrDefault();
            _Db.tbl_Student.Remove(student);
            _Db.tbl_Student.Add(student);
            return RedirectToAction("StudentList");
        }

        public void LoadDLLDep()
        {
            try
            {
                List<Departments> depList = new List<Departments>();
                depList = _Db.tbl_Department.ToList();

                depList.Insert(0, new Departments { DepID = "0", Department = "Please Select Your Department" });

                ViewBag.DepList = depList;
            }
            catch (Exception ex)
            {

            }

        }
        public void LoadDLLSub()
        {
            try
            {
                List<Subjects> subList = new List<Subjects>();
                subList = _Db.tbl_Subject.ToList();
                subList.Insert(0, new Subjects { SubID = "0", Subject = "Please Select a Subject" });


                ViewBag.SubList = subList;

            }
            catch (Exception ex)
            {

            }
        }



    }
}
