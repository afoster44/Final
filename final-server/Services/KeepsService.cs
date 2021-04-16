using System;
using System.Collections.Generic;
using final_server.Models;
using final_server.Repositories;

namespace final_server.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;

        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Keep> GetAll()
        {
            return _repo.GetAll();
        }

        internal Keep GetById(int id)
        {
            var data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }

        internal Keep Edit(Keep updated)
        {
            var original = GetById(updated.Id);
            if (original.CreatorId != updated.CreatorId)
            {
                throw new Exception("Invalid Edit Permissions");
            }
            updated.Description = updated.Description != null ? updated.Description : original.Description;
            updated.Name = updated.Name != null ? updated.Name : original.Name;
            updated.Img = updated.Img != null ? updated.Img : original.Img;

            return _repo.Edit(updated);
        }

        internal string Delete(int id, string userId)
        {
            var original = GetById(id);
            if (original.CreatorId != userId)
            {
                throw new Exception("Invalid Delete Permissions");
            }
            _repo.Delete(id);
            return "nice delete";
        }

        internal IEnumerable<VaultKeepView> GetKeepsByVaultId(int id)
        {
            return _repo.GetKeepsByVaultId(id);
        }

        internal IEnumerable<Keep> GetKeepsByProfileId(string id)
        {
            return _repo.GetKeepsByProfileId(id);
        }
    }
}