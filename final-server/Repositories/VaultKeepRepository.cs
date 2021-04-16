using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using final_server.Models;

namespace final_server.Repositories
{
    public class VaultKeepRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep GetById(int id)
        {
            string sql = @"SELECT * FROM vaultkeeps WHERE id = @id;";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
        }

        internal VaultKeep Create(VaultKeep newVK)
        {
            string sql = @"
            INSERT INTO vaultkeeps 
            (vaultId, keepId, creatorId) 
            VALUES 
            (@VaultId, @KeepId, @CreatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newVK);
            newVK.Id = id;
            return newVK;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });

        }
    }
}