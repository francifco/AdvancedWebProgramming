create database  pickurl;


use pickurl;

create table users (
    id int not null AUTO_INCREMENT,
    lastName varchar(255) not null,
    firstName varchar(255)not null,
    username varchar(255)not null,
    password varchar(255) not null,
	nationality varchar(255)not null,
    primary key(id)
);

create table url (
    id int not null AUTO_INCREMENT,
    shortenedURL varchar(255),
    url varchar(500) not null,
    userId int,
    clicks int,
    lastClick datetime,
    created datetime,
    primary key(id),
	foreign key (userId) references Users(id)
);

create table locations (
    id int not null AUTO_INCREMENT,
    urlId int,
    locations varchar(255),
    primary key(id),
    foreign key (urlId) references Url(id)
);

create table agents (
    id int not null AUTO_INCREMENT,
    urlId int,
    agents varchar(255),
    primary key(id),
    foreign key (urlId) references Url(id)
);


create table reference (
    id int not null AUTO_INCREMENT,
    urlId int,
    reference varchar(255),
    primary key(id),
    foreign key (urlId) references Url(id)
);

create table Plaform (
    id int not null AUTO_INCREMENT,
    urlId int,
    plaform varchar(255),
    primary key(id),
    foreign key (urlId) references Url(id)
);









