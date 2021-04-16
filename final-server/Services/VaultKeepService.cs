using System;
using System.Collections.Generic;
using final_server.Models;
using final_server.Repositories;

namespace final_server.Services
{
    public class VaultKeepService
    {
        private readonly VaultKeepRepository _repo;

        public VaultKeepService(VaultKeepRepository repo)
        {
            _repo = repo;
        }

        internal VaultKeep GetById(int id)
        {
            var data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal VaultKeep Create(VaultKeep newVK)
        {
            return _repo.Create(newVK);

        }

        internal string Delete(int id, string userId)
        {
            VaultKeep original = GetById(id);
            if (original.CreatorId != userId)
            {
                throw new Exception("You are not the creator, you can not delete this!");
            }
            _repo.Delete(id);
            return "Deleted";
        }
    }
}