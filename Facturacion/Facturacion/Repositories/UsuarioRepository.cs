﻿using Facturacion.Data;
using Facturacion.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Facturacion.Repositories
{
    public class UsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioRepository(MongoDBContext context)
        {
            _usuarios = context.Database.GetCollection<Usuario>("Usuarios");
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _usuarios.Find(usuario => true).ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(string id)
        {
            return await _usuarios.Find<Usuario>(usuario => usuario.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetByNombreUsuarioAsync(string nombreUsuario)
        {
            return await _usuarios.Find<Usuario>(usuario => usuario.NombreUsuario == nombreUsuario).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _usuarios.InsertOneAsync(usuario);
        }

        public async Task UpdateAsync(string id, Usuario usuarioIn)
        {
            await _usuarios.ReplaceOneAsync(usuario => usuario.Id == id, usuarioIn);
        }

        public async Task DeleteAsync(string id)
        {
            await _usuarios.DeleteOneAsync(usuario => usuario.Id == id);
        }
    }
}
