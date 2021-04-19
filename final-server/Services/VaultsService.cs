using System;
using System.Collections.Generic;
using System.Linq;
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
            else if (data.IsPrivate == true)
            {
                throw new Exception("This is a private vault");
            }
            return data;
        }

        // internal Vault GetById(int id, string userId)
        // {
        //     var data = _repo.GetById(id);
        //     if (data == null)
        //     {
        //         throw new Exception("Invalid Id");
        //     }
        //     // else if (data.IsPrivate == true && data.CreatorId != userId)
        //     // {
        //     //     throw new Exception("you are not the creator of this vault");
        //     // }
        //     return data;
        // }

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
            IEnumerable<Vault> vaults = _repo.GetVaultsByProfileId(id);
            return vaults.ToList().FindAll(r => r.IsPrivate == false);
        }
    }
}