﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;
using System.Web.Mvc;
using urbanbooks.Models;

namespace urbanbooks.Controllers
{
    [Authorize(Roles="admin, supplier")]
    public class SupplierController : Controller
    {
        private ApplicationUserManager _userManager;
        BusinessLogicHandler myHandler;
        Supplier logistics;
        public ActionResult Index()
        {
            myHandler = new BusinessLogicHandler();
            List<Supplier> newList = myHandler.GetSuppliers();
            return View(newList);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(RegisterSupplier model)
        {
            ApplicationDbContext dataSocket = new ApplicationDbContext();
            UserStore<ApplicationUser> myStore = new UserStore<ApplicationUser>(dataSocket);
            ApplicationUserManager userMgr = new ApplicationUserManager(myStore);
            try
            {
                var user = new ApplicationUser() { UserName = model.Email, Email = model.Email, Address = model.Address, PhoneNumber = model.ContactPersonNumber };
                Models.Supplier supplier = new Models.Supplier { Name = model.Name, ContactPerson = model.ContactPerson, Fax = model.Fax, ContactPersonNumber = model.ContactPersonNumber, LastName = model.LastName, User_Id = user.Id };
                user.Carts = new Cart { DateLastModified = DateTime.Now };
                user.Wishlists = new Wishlist { Status = false };
                IdentityResult result = await userMgr.CreateAsync(user, model.Password);
                dataSocket.Suppliers.Add(supplier);

                dataSocket.SaveChanges();

                return View();

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                myHandler = new BusinessLogicHandler();
                logistics = new Supplier();
                TryUpdateModel(logistics);
                if (ModelState.IsValid)
                {
                    myHandler.UpdateSupplier(logistics);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
