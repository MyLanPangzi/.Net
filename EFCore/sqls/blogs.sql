drop table if exists Blogs;
create table Blogs(
    BlogId INTEGER not null PRIMARY KEY,
    Url text null,
    Rating INTEGER null

);


drop table if exists Post;
create table Post(
    PostId INTEGER not null PRIMARY KEY,
    BlogId INTEGER null,
    Title text null,
    Content text null
);