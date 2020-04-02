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

-- -- NOTE Tags
-- CREATE TABLE tags (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- );

-- -- NOTE blogTags
-- CREATE TABLE blogtags (
--     id INT NOT NULL AUTO_INCREMENT,
--     blogId INT NOT NULL,
--     tagId INT NOT NULL,
--     authorId VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),

--     INDEX (blogId),

--     FOREIGN KEY (blogId)
--         REFERENCES blogs(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (tagId)
--         REFERENCES tags(id)
--         ON DELETE CASCADE
-- );
