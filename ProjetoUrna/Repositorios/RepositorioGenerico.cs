using Microsoft.EntityFrameworkCore;
using ProjetoUrna.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoUrna.Repositorios
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {
        private readonly Context _context;

        public RepositorioGenerico(Context context)
        {
            _context = context;
        }

        public async Task Alterar(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(int id)
        {
            try
            {
                var entity = await RecuperarPorId(id);
                await Excluir(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Inserir(TEntity entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> ListarTodos()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> RecuperarPorId(int id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
