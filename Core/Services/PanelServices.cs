using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class PanelServices : IPanel
    {
        Context _context;
        public PanelServices(Context context)
        {
            _context = context;
        }
        public void DeleteArticle(int Id)
        {
            var article = _context.Articles.Find(Id);
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            List<Category> subcategory = _context.Categories.Where(c => c.ParentId == id).ToList();
            _context.Categories.RemoveRange(subcategory);

            Category newcategory = _context.Categories.Find(id);
            _context.Categories.Remove(newcategory);

            _context.SaveChanges();
        }

        public List<Article> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public Article GetArticle(int id)
        {
            return _context.Articles.Find(id);
        }

        public Category GetCategoriById(int id)
        {
            return _context.Categories.Find(id);
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.Where(c => c.ParentId == null).ToList();
        }

        public List<Category> GetSubCategory()
        {
            return _context.Categories.ToList();
        }

        public int GetUserId(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            return user.Id;
        }

        public void InsertArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public void InsertCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateArticle(int id ,Article article)
        {
            var oldarticle = _context.Articles.Find(id);
            oldarticle.ArticlePicture = article.ArticlePicture;
            oldarticle.Describtion = article.Describtion;
            oldarticle.ShowSlide = article.ShowSlide;
            oldarticle.Text = article.Text;
            oldarticle.Title = article.Title;

            _context.SaveChanges();
        }

        public void UpdateCategory(int id, string name)
        {
            Category cate = _context.Categories.Find(id);
            cate.Name = name;
            _context.SaveChanges();
        }

        public void UpdateSubCategory(int id, int? parentid ,string name)
        {
            Category cate = _context.Categories.Find(id);
            cate.Name = name;
            cate.ParentId = parentid;
            _context.SaveChanges();
        }
    }
}
