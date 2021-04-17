using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using final_server.Models;

namespace final_server.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Vault> GetAll()
        {
            string sql = @"
      SELECT 
      vaul.*,
      prof.*
      FROM vaults vaul
      JOIN profiles prof ON vaul.creatorId = prof.id;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, splitOn: "id");
        }

        internal Vault GetById(int id)
        {
            string sql = @" 
      SELECT 
      vaul.*,
      prof.*
      FROM vaults vaul
      JOIN profiles prof ON vaul.creatorId = prof.id
      WHERE vaul.id = @id;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { id }, splitOn: "id").FirstOrDefault();
        }

        internal Vault Create(Vault newVault)
        {
            string sql = @"
      INSERT INTO vaults 
      (description, name, creatorId, isPrivate) 
      VALUES 
      (@Description, @Name, @CreatorId, @IsPrivate);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newVault);
            newVault.Id = id;
            return newVault;
        }

        internal Vault Edit(Vault updated)
        {
            string sql = @"
        UPDATE vaults
        SET
         description = @Description,
         name = @Name
        WHERE id = @Id;";
            _db.Execute(sql, updated);
            return updated;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<Vault> GetVaultsByProfileId(string id)
        {
            string sql = @"SELECT
            v.*,
            p.*
            FROM vaults v
            JOIN profiles p ON v.creatorId = p.id
            WHERE v.creatorId = @id;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { id }, splitOn: "id");
        }
    }
}