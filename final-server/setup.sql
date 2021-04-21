USE finalkeepraf;

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE vaults
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   description VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   creatorid VARCHAR(255) NOT NULL,
--   isprivate TINYINT NOT NULL,
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorid) 
--   REFERENCES profiles (id)
--   ON DELETE CASCADE
-- );


-- CREATE TABLE keeps
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   description VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   creatorid VARCHAR(255) NOT NULL,
--   img VARCHAR(255) NOT NULL,
--   views INT DEFAULT 0,
--   shares INT DEFAULT 0,
--   keeps INT DEFAULT 0,
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorid) 
--   REFERENCES profiles (id)
--   ON DELETE CASCADE
-- );

-- CREATE TABLE vaultkeeps
-- (
--     id INT NOT NULL AUTO_INCREMENT,
--     creatorId VARCHAR(255) NOT NULL,
--     vaultId INT NOT NULL,
--     keepId INT NOT NULL,
    
--     PRIMARY KEY (id),

--     FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE,

--     FOREIGN KEY (vaultId)
--     REFERENCES vaults (id)
--     ON DELETE CASCADE,

--     FOREIGN KEY (keepId)
--     REFERENCES keeps (id)
--     ON DELETE CASCADE
-- )



-- if we are trying to drop the data from a table with foreign keys 
-- we must set the foreign key check to 0 so it won't worry about it

-- SET FOREIGN_KEY_CHECKS=0;
-- TRUNCATE TABLE vaults;
-- TRUNCATE TABLE keeps;
-- TRUNCATE TABLE vaultkeeps;


