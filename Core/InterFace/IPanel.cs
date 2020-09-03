using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IPanel
    {
        #region for Articcle
        public void InsertArticle(Article article);
        public void UpdateArticle(int id ,Article article);
        public void DeleteArticle(int Id);
        public Article GetArticle(int id);
        public List<Article> GetAllArticles();
        public int GetUserId(string email);
        #endregion

        #region For Category
        public void InsertCategory(Category category);
        public void UpdateCategory(int id , string name);
        public void DeleteCategory(int id);
        public List<Category> GetSubCategory();
        public List<Category> GetCategories();
        public Category GetCategoriById(int id);
        public void UpdateSubCategory(int id,int? parentid, string name );
        #endregion
    }
}
