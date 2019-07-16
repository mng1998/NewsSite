USE [master]
GO
/****** Object:  Database [News]    Script Date: 11/26/2018 10:45:17 AM ******/
CREATE DATABASE [News]
 CONTAINMENT = NONE
 GO

ALTER DATABASE [News] SET COMPATIBILITY_LEVEL = 100
ALTER DATABASE [News] COLLATE Vietnamese_CI_AS
GO

USE [News]
GO

CREATE TABLE CATEGORIES(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(255) NOT NULL)
	
CREATE TABLE USERS(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	UserName NVARCHAR(50) NOT NULL UNIQUE,
	Password NVARCHAR(50) NOT NULL,
	FirstName [nvarchar](50) NOT NULL,
	LastName [nvarchar](200) NOT NULL,
	DOB DATE NULL,
	HomeAddress nvarchar(255) NULL,
	Tel varchar(12) NULL,
	Email nvarchar(255) NULL UNIQUE,
	UserStatus VARCHAR(10) NOT NULL CHECK (UserStatus IN('Created','Active','Suspended','Deleted')))
	

CREATE TABLE ROLES(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(255) NULL)

CREATE TABLE USERROLES(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	UserId BIGINT NOT NULL,
	RoleId BIGINT NOT NULL,
	CreatedDate DATETIME NOT NULL,
	ModifiedDate DATETIME NULL,
	CONSTRAINT FK_UserRole_User FOREIGN KEY (UserId) REFERENCES USERS(Id),
	CONSTRAINT FK_UserRole_Role FOREIGN KEY (RoleId) REFERENCES ROLES(Id))

CREATE TABLE ARTICLES(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	UserId BIGINT NOT NULL,
	CategoryId BIGINT NOT NULL,
	Title NVARCHAR(255) NOT NULL,
	Content NVARCHAR(max) NULL,
	Picture NVARCHAR(255) NULL,
	CreatedDate DATETIME NOT NULL,
	ModifiedDate DATETIME NULL,
	Link VARCHAR(255) NULL,
	Summary NVARCHAR(255) NULL,
	Highlight BIT DEFAULT 0,
	Active bit DEFAULT 0,
	CONSTRAINT FK_User_Article FOREIGN KEY (UserId) REFERENCES USERS(Id),
	CONSTRAINT FK_Category_Article FOREIGN KEY (CategoryId) REFERENCES CATEGORIES(Id))
	
	CREATE TABLE LABELS(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(25) NOT NULL,
	Description NVARCHAR(255) NULL)
	
	CREATE TABLE ARTICLELABLES(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	ArticleId BIGINT NOT NULL,
	LabelId BIGINT NOT NULL
	CONSTRAINT FK_LabelArticle_Article FOREIGN KEY (ArticleId) REFERENCES ARTICLES(Id),
	CONSTRAINT FK_LableArticle_Label FOREIGN KEY (LabelId) REFERENCES LABELS(Id))
	
	CREATE TABLE COMMENTS(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	ArticleId BIGINT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Content NVARCHAR(255) NOT NULL
	CONSTRAINT FK_Comment_New FOREIGN KEY (ArticleId) REFERENCES ARTICLES(Id))

insert into CATEGORIES (Name, Description) values ('Health', 'Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy.');
insert into CATEGORIES (Name, Description) values ('Computers', 'Quisque id justo sit amet sapien dignissim vestibulum.');
insert into CATEGORIES (Name, Description) values ('Kids', 'Vestibulum quam sapien, varius ut, blandit non, interdum in, ante.');
insert into CATEGORIES (Name, Description) values ('Music', 'Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit.');
insert into CATEGORIES (Name, Description) values ('Social', 'Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.');
insert into CATEGORIES (Name, Description) values ('Games', 'Proin leo odio, porttitor id, consequat in, consequat ut, nulla. ');
insert into CATEGORIES (Name, Description) values ('Music', 'Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros.');

insert into USERS (UserName, Password, FirstName, LastName, DOB, HomeAddress, Tel, Email, UserStatus) values ('pebrookf', '1234','Pebrook', 'Foulkes', '1955-1-1', '955 Eggendart Point', '406-448-8152', 'pfoulkes0@friendfeed.com', 'Active');
insert into USERS (UserName, Password, FirstName, LastName, DOB, HomeAddress, Tel, Email, UserStatus) values ('elRuvel', '123456789', 'Elbertine', 'Ruvel', '1950-4-5', '401 Farragut Lane', '969-710-9223', 'eruvel1@angelfire.com', 'Active');
insert into USERS (UserName, Password, FirstName, LastName, DOB, HomeAddress, Tel, Email, UserStatus) values ('garSwind', '!23456', 'Garrett', 'Swindlehurst', '1980-8-7','41 Little Fleur Avenue', '322-447-9736', 'gswindlehurst2@boston.com', 'Active');
insert into USERS (UserName, Password, FirstName, LastName, DOB, HomeAddress, Tel, Email, UserStatus) values ('northcas', '1234', 'Northrup', 'Castro', '1979-1-1','89 Caliangt Center', '424-618-5762', 'ncastro3@freewebs.com', 'Active');
insert into USERS (UserName, Password, FirstName, LastName, DOB, HomeAddress, Tel, Email, UserStatus) values ('wylie', '1234567', 'Wylie', 'Kencott', '1970-7-6','02741 Bashford Court', '788-483-9261', 'wkencott4@google.com.au', 'Active');
insert into USERS (UserName, Password, FirstName, LastName, DOB, HomeAddress, Tel, Email, UserStatus) values ('chiqua', '67890', 'Chiquia', 'Gedling', '1986-12-12','58426 Harper Place', '660-292-1465', 'cgedling5@amazon.co.jp', 'Active');
insert into USERS (UserName, Password, FirstName, LastName, DOB, HomeAddress, Tel, Email, UserStatus) values ('tanhya', '234277', 'Tanhya', 'O''Lunny', '1978-6-3', '3454 Badeau Parkway', '861-452-6698', 'tolunny6@typepad.com', 'Active');
insert into USERS (UserName, Password, FirstName, LastName, DOB, HomeAddress, Tel, Email, UserStatus) values ('sim', 'ti345', 'Sim', 'Summerson', '1988-4-7', '59350 Elmside Alley', '161-239-2451', 'ssummerson7@goodreads.com', 'Active');
insert into USERS (UserName, Password, FirstName, LastName, DOB, HomeAddress, Tel, Email, UserStatus) values ('clair', '1246789', 'Clair', 'Klaff', '1973-6-7', '136 Waxwing Crossing', '606-909-3931', 'cklaff8@umich.edu', 'Active');
insert into USERS (UserName, Password, FirstName, LastName, DOB, HomeAddress, Tel, Email, UserStatus) values ('cristi', '111111', 'Cristi', 'Bruntjen', '1989-2-2', '94 7th Way', '527-715-7238', 'cbruntjen9@miibeian.gov', 'Active');

insert into ROLES (Name, Description) values ('admin', 'admin');
insert into ROLES (Name, Description) values ('reviewer','reviewer');
insert into ROLES (Name, Description) values ('writer','writer');

INSERT INTO ARTICLES(UserId, CategoryId, Title, Content, Picture, CreatedDate, ModifiedDate, Link, Summary, Highlight, Active)
VALUES (2, 1, 'How to Be Healthy', 'Many people think that being healthy is a difficult task that involves lots of dieting and time at the gym, but that is not actually true! By making some simple tweaks to your routine and setting small goals for yourself, you can be on the path toward living a healthier, happier life. Start a daily habit of making healthier choices when it comes to eating, relaxing, being active, and sleeping. Soon, you will start to see your healthy life taking shape!', null, 2019-4-9, null, null, 'Many people think that being healthy is a difficult task that involves lots of dieting and time at the gym, but that is not actually true! By making some simple tweaks to your routine and setting small goals for yourself, you can be on the path toward living a healthier, happier life. Start a daily habit of making healthier choices when it comes to eating, relaxing, being active, and sleeping. Soon, you will start to see your healthy life taking shape!', 1, 1);
INSERT INTO ARTICLES(UserId, CategoryId, Title, Content, Picture, CreatedDate, ModifiedDate, Link, Summary, Highlight, Active)
VALUES (3, 7, 'Tallinn Music Week 2019', 'Thursday evening is ushered in by Puuluup, an Estonian duo that self-identify as "neo-zombie-post-folk." They wring the most bewildering array of sounds from their talharpas, a form of Northern European lyre, whether by drumming, bowing, plucking, or brushing them. From such seemingly rudimental equipment, the rhythms that they loop and the melodies that they harmonize are immediate crowd-pleasers; by the time they demonstrate the two-step dance-along for one of their closers, the growing audience need no convincing. It is folk, it is contemporary, it is funny, and it is danceable. It is a perfect launching pad for the weekend', null, 2019-4-12, null, null, 'For three days each spring, a corner of the old town in the Estonian capital transforms from a preserved, post-industrial throwback to a bustling, anything-is-possible playground for hundreds of invited artists and speakers to splash around in.', 1, 1);
INSERT INTO ARTICLES(UserId, CategoryId, Title, Content, Picture, CreatedDate, ModifiedDate, Link, Summary, Highlight, Active)
VALUES (4, 7, 'Lil Rap Column: Lil Uzi Vert is Trapped, Just as He’s Finding His Voice', 'In recent months, Uzi has been trapped in an ongoing war with his label Generation Now over the album release, threatening to quit music altogether and releasing a comeback single, "Free Uzi," which seemed to take shots at them. Amid that conflict, two new singles arrived last week, "Sanguine Paradise" and "Tha is a Rack," both of which were conspicuously not promoted on Uzi is Twitter or Instagram. But, if you can ignore the incessant gossip around his label drama, you might be able to notice that Uzi new music is actually good.', null, 2019-4-11, null, null, 'My enduring belief that Lil Uzi Vert will come good is based on one thing: No artist who makes a song as era-defining as "XO TOUR Llif3" does it by mistake.', 1, 1);
INSERT INTO ARTICLES(UserId, CategoryId, Title, Content, Picture, CreatedDate, ModifiedDate, Link, Summary, Highlight, Active)
VALUES (5, 2, 'Microsoft surrenders control over Windows 10 upgrades: What you need to know', 'It is not easy keeping track of all the upgrade timing changes Microsoft keeps rolling out. And now, there is a new one: Download and install now. Here is what that means.', null, 2019-4-13, null, null, 'Every few months, the Redmond, Wash. company switches up scheduling or support or something about Window 10, just to make sure everyone is paying attention.', 1, 1);
INSERT INTO ARTICLES(UserId, CategoryId, Title, Content, Picture, CreatedDate, ModifiedDate, Link, Summary, Highlight, Active)
VALUES (6, 5, 'Where Do The Rich ', 'Have you checked the newest "Forbes 400: The Full List of The Richest People in America" yet?
Surprise, Bill Gates, with a net worth of $81 billion, is ranked No. 1 for the 23rd year running. Meanwhile, his friend Warren Buffett fell to third place for the first time in 15 years with a net worth of $65.5 billion. Thanks to soaring stock prices of hot tech firms, CEOs at the helm of those companies seem to have been accumulating wealth at a much faster pace than others. Amazon.com CEO Jeff Bezos gained $20 billion to boost his net worth to $67 billion, making him the second-richest person in the U.S.', null, 2019-4-12, null, null, 'Sizing up the homes of Bill Gates and other top members of the new Forbes 400 list', 1, 1);
INSERT INTO ARTICLES(UserId, CategoryId, Title, Content, Picture, CreatedDate, ModifiedDate, Link, Summary, Highlight, Active)
VALUES (7, 5, 'How Often Will a U.S Resident Have to Pay Taxes on a Luxury Home?', 'Every week, Mansion Global poses a tax question to real estate tax attorneys. Here is this week’s question.
Q: I am moving from London to the U.S. and am hoping to buy a property. How often throughout the year will I have to pay property tax?
A: Property taxes in the U.S. are levied by each state, as well as the local municipality in which the property is located. Therefore, the charges and when they are due vary.
But unlike council taxes in London, which are often spread out into 10 installments, property tax in the U.S. is generally paid in one or two payments.', null, 2019-4-9, null, null, 'Frequency can vary depending on location, but payments generally are made once or twice a year', 1, 1);

insert into COMMENTS (ArticleId, Name, Content) values (6, 'Niccolo Turford', 'Great');
insert into COMMENTS (ArticleId, Name, Content) values (6, 'Natale O''Sharkey', 'Nice');
insert into COMMENTS (ArticleId, Name, Content) values (2, 'Gwen Matonin', 'Good idea!');
insert into COMMENTS (ArticleId, Name, Content) values (2, 'Meredeth Darwin', 'Unbelievable');
insert into COMMENTS (ArticleId, Name, Content) values (2, 'Abby Karolyi', 'Good saying');
insert into COMMENTS (ArticleId, Name, Content) values (7, 'Batholomew MacQuarrie', 'Thank you');
insert into COMMENTS (ArticleId, Name, Content) values (7, 'Jerad Grimsdike', 'Nice');
insert into COMMENTS (ArticleId, Name, Content) values (7, 'Alisun Leonardi', 'Unbelievable');
insert into COMMENTS (ArticleId, Name, Content) values (6, 'Christos Gavin', 'Good');
insert into COMMENTS (ArticleId, Name, Content) values (4, 'Merridie Brydon', 'Nice');