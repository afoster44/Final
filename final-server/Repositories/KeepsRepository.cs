using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using final_server.Models;

namespace final_server.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> GetAll()
        {
            string sql = @"
      SELECT 
      keep.*,
      prof.*
      FROM keeps keep
      JOIN profiles prof ON keep.creatorId = prof.id;";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, splitOn: "id");
        }

        internal Keep GetById(int id)
        {
            string sql = @" UPDATE keeps SET views = views + 1 WHERE id = @id;
      SELECT 
      keep.*,
      prof.*
      FROM keeps keep
      JOIN profiles prof ON keep.creatorId = prof.id
      WHERE keep.id = @id;";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, new { id }, splitOn: "id").FirstOrDefault();
        }

        internal Keep Create(Keep newKeep)
        {
            string sql = @"
            INSERT INTO keeps 
            (description, name, creatorId, img, views, shares, keeps) 
            VALUES 
            (@Description, @Name, @CreatorId, @Img, 0, 0, 0);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newKeep);
            newKeep.Id = id;
            return newKeep;
        }

        internal Keep Edit(Keep updated)
        {
            string sql = @"
            UPDATE keeps
            SET
            description = @Description,
            name = @Name,
            img = @Img, 
            views = @Views,
            shares = @Shares,
            keeps = @Keeps
            WHERE id = @Id;";
            _db.Execute(sql, updated);
            return updated;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<VaultKeepView> GetKeepsByVaultId(int id)
        {
            string sql = @"SELECT
            k.*,
            vk.id AS VaultKeepId,
            p.*
            FROM vaultkeeps vk
            JOIN keeps k ON k.id = vk.keepId
            JOIN profiles p ON k.creatorId = p.id
            WHERE vk.vaultId = @id;";
            return _db.Query<VaultKeepView, Profile, VaultKeepView>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, new { id }, splitOn: "id");
        }

        internal IEnumerable<Keep> GetKeepsByProfileId(string id)
        {
            string sql = @"SELECT
            k.*,
            p.*
            FROM keeps k
            JOIN profiles p ON k.creatorId = p.id
            WHERE k.creatorId = @id;";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, new { id }, splitOn: "id");
        }
    }
}