﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using QLKS.Common;
using PagedList;
using System.Data;
using System.Data.Entity;
using System.Net;


namespace QLKS.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        //[HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index(string searchString,int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();

            var model = dao.ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        //[HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {

            return View();
        }

        //[HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        //[HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create(ADMIN user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptedMD5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMD5Pas;

                int id = dao.Insert(user);

                if (id > 0)
                {
                    SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công.");
                }
            }
            return View("Index");
        }


        [HttpPost]
        //[HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(ADMIN user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                }


                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        //    [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
