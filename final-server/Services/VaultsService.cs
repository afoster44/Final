using System;
using System.Collections.Generic;
using final_server.Models;
using final_server.Repositories;

namespace final_server.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Vault> GetAll()
        {
            return _repo.GetAll();
        }

        internal Vault GetById(int id)
        {
            var data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal Vault Create(Vault newVault)
        {
            return _repo.Create(newVault);
        }

        internal Vault Edit(Vault updated)
        {
            var original = GetById(updated.Id);
            if (original.CreatorId != updated.CreatorId)
            {
                throw new Exception("Invalid Edit Permissions");
            }
            updated.Description = updated.Description != null ? updated.Description : original.Description;
            updated.Name = updated.Name != null ? updated.Name : original.Name;


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


        internal IEnumerable<Vault> GetVaultsByProfileId(string id)
        {
            return _repo.GetVaultsByProfileId(id);
        }
    }
}