﻿using AnimaTechAPI.Models;
using System.Data;

namespace AnimaTechAPI.Services
{
    public class Service
    {
        private DataBase _context;

        public Service()
        {
            _context = new DataBase();
        }

        public Usuario GetByEmail(string email)
        {
            var user = new Usuario();
            string query = string.Format($"SELECT Nome, Email, Senha FROM Usuario Where Email = '{email}'");
            DataTable data = _context.ConsultaQuery(query);
            if(data == null)
                return null;                
            else
            {
                foreach (DataRow item in data.Rows)
                {
                    user.Nome = item[0].ToString();
                    user.Email = item[1].ToString();
                    user.Senha = item[2].ToString();
                }
                return user;
            }
        }

        public Usuario PostUser(Usuario user)
        {
            string query = string.Format($"SELECT Nome, Email, Senha FROM Usuario Where Email = '{user.Email}'");
            DataTable data = _context.ConsultaQuery(query);
            if (data.Rows.Count <= 0)
            {
                query = string.Format($"INSERT INTO Usuario(Email, Nome, Senha) Values('{user.Email}', '{user.Nome}', '{user.Senha}');");
                if(_context.ExecutarQuery(query))
                {
                    return user;
                }
            }
            return null;
        }

        public List<Publicacao> GetAll()
        {
            var Posts = new List<Publicacao>();
            string query = string.Format($"SELECT Titulo, ImgPublicacao, Duracao FROM Publicacao");
            DataTable data = _context.ConsultaQuery(query);
            if (data == null)
                return null;
            else
            {
                foreach (DataRow item in data.Rows)
                {
                    var Post = new Publicacao();
                    Post.Titulo = item[0].ToString();
                    Post.Imagem = item[1].ToString();
                    Post.Duracao= item[2].ToString();
                    Posts.Add(Post);
                }
            }

            return Posts;
        }
        public Publicacao Post(Publicacao post)
        {
            string query = string.Format($"SELECT Nome, Email, Senha FROM Publicacao Where Titulo = '{post.Titulo}'");
            DataTable data = _context.ConsultaQuery(query);
            if (data.Rows.Count <= 0)
            {
                query = string.Format($"INSERT INTO Usuario(Titulo, ImgPublicacao, Duracao) Values('{post.Titulo}', '{post.Imagem}', '{post.Duracao}');");
                if (_context.ExecutarQuery(query))
                {
                    return post;
                }
            }
            return null;
        }
    }
}
