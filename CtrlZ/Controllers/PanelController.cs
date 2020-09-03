﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CtrlZ.Controllers
{
    public class PanelController : Controller
    {
        public IPanel _admin;
        public PanelController(IPanel admin)
        {
            _admin = admin;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult ShowArticles()
        {
            var articles = _admin.GetAllArticles();
            return View(articles);
        }

        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateArticle(ArticleViewModel viewmodel)
        {

            if (ModelState.IsValid)
            {
                Article article = new Article()
                {
                    Text = viewmodel.Text,
                    Describtion = viewmodel.Describtion,
                    visit = 0,
                    CreateDate = DateClass.GetDate(),
                    ArticlePicture = viewmodel.ArticlePicture,
                    CategoryId = 1,
                    UserId = _admin.GetUserId(User.Identity.Name),
                    Title = viewmodel.Title,
                    ShowSlide = viewmodel.ShowSlide

                };
                _admin.InsertArticle(article);
                return RedirectToAction("ShowArticles");
            }
            else
            {

            }

            return View(viewmodel);
        }

        public IActionResult DeleteArticle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var article = _admin.GetArticle(id.Value);

            if (article == null)
            {
                return NotFound();
            }

            return PartialView(article);
        }

        public IActionResult ConfirmDeleteAticle(int id)
        {

            _admin.DeleteArticle(id);

            return RedirectToAction("ShowArticles");
        }
        
        public IActionResult EditArticle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var article = _admin.GetArticle(id.Value);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }
        [HttpPost]
        public IActionResult EditArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                _admin.UpdateArticle(article.ArticleId, article);
            }
            return View();
        }
        public IActionResult ShowCategory()
        {
            List<Category> Categories = _admin.GetCategories();

            return View(Categories);
        }
        public IActionResult ShowSubCategory(int id)
        {
            List<Category> Categories = _admin.GetSubCategory();
            ViewBag.parentId = id;
            return View(Categories);
        }
        public IActionResult CreateCategory()
        {
            return PartialView();
        }  
        [HttpPost]
        public IActionResult CreateCategory(int? id ,CategoriViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category()
                {
                    Name = viewmodel.Name,
                    ParentId = id
                };
                _admin.InsertCategory(category);
                return RedirectToAction("ShowCategory");
            }
            return View(viewmodel);
        }
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category cate = _admin.GetCategoriById(id.Value);
            if (cate == null)
            {
                return NotFound();
            }

            return PartialView(cate);
        }
        public IActionResult ConfirmDeleteCategory(int id)
        {
            try
            {
                _admin.DeleteCategory(id);
            }
            catch
            {
                return NotFound();
            }

            return RedirectToAction("ShowCategory");
        }
        public IActionResult UpdateCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category cate = _admin.GetCategoriById(id.Value);
            if (cate == null)
            {
                return NotFound();
            }

            return View(cate);
        }
        [HttpPost]
        public IActionResult UpdateCategory(int id,Category viewmodel)
        {
            _admin.UpdateSubCategory(id, viewmodel.ParentId, viewmodel.Name);
            if (viewmodel.ParentId == null)
            {
                return RedirectToAction("ShowCategory");
            }
            else
            {
                return Redirect("/panel/showsubcategory/" + viewmodel.ParentId);
            }
            

        }
    }


}