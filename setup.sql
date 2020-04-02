USE bloggr;

-- -- NOTE BLOGS
-- CREATE TABLE blogs (
--     id INT NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     body VARCHAR(255),
--     authorId VARCHAR(255) NOT NULL,
--     isPrivate TINYINT NOT NULL,
--     PRIMARY KEY (id)
-- )

-- NOTE Comments

-- CREATE TABLE comments (
--     id INT NOT NULL AUTO_INCREMENT,
--     body VARCHAR(255) NOT NULL,
--     authorId VARCHAR(255) NOT NULL,
--     blogId INT NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (blogId)
--         REFERENCES blogs(id)
--         ON DELETE CASCADE
-- )


