using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LSD_CORP
{
    class DataBase
    {
        private LsdCorpContext _context = new();
        private static DataBase instance;

        public static DataBase Instance { get => instance ??= new(); }
        public LsdCorpContext GetContext { get => _context; }

        public async Task<bool> AddMat(Material mat)
        {
            if (mat == null || _context.Materials.Contains(mat))
                return false;

            await _context.Materials.AddAsync(mat);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddFur(Furniture fur)
        {
            if (fur == null || _context.Furnitures.Contains(fur))
                return false;

            await _context.Furnitures.AddAsync(fur);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DelMat(Material mat)
        {
            if (mat == null || !_context.Materials.Contains(mat))
                return false;

            _context.Materials.Remove(mat);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DelFur(Furniture fur)
        {
            if (fur == null || !_context.Furnitures.Contains(fur))
                return false;

            _context.Furnitures.Remove(fur);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdMat(Material mat)
        {
            if (mat == null)
                return false;

            _context.Materials.Update(mat);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdFur(Furniture fur)
        {
            if (fur == null)
                return false;

            _context.Furnitures.Update(fur);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Material> SearchMatById(int id)
            => _context.Materials.FirstOrDefault(s => s.Id == id) ?? new();
        public async Task<Furniture> SearchFurById(int id)
            => _context.Furnitures.FirstOrDefault(s => s.Id == id) ?? new();

        public List<Material> GetAllMaterials()
            => [.. _context.Materials];
        internal List<Furniture> GetAllFurnitures()
            => [.. _context.Furnitures];

        public async Task<bool> Authorization(User user)
            => await _context.Users.FirstOrDefaultAsync(s => s.Login == user.Login && s.Password == user.Login) != null;
        public async Task<bool> Registraition(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Login) ||
                string.IsNullOrWhiteSpace(user.Password) ||
                string.IsNullOrEmpty(user.Login) ||
                string.IsNullOrEmpty(user.Password))
                return false;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}