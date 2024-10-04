SELECT * FROM [Employee_Polls].[dbo].[Answers]
SELECT * FROM [Employee_Polls].[dbo].[Questions]

SELECT * FROM [Employee_Polls].[dbo].[Users]



--insert value for Answers table
---- should add constant for IDENTITY
INSERT INTO Answers VALUES ('sarahedo', 'Build our new application with Javascript', 0, 'Build our new application with Typescript')
INSERT INTO Answers VALUES (0, 2)

--insert value for Questions table
INSERT INTO Questions VALUES ('8xf0y6ziyjabvozdd253nd', 'sarahedo', GETDATE(),  1)
INSERT INTO Users VALUES ('sarahedo', 'password123', 'sarahedo', 'https://gravatar.com/avatar/3488054da5eddcea12a54a829afdeaf5?s=200&d=robohash&r=x', '8xf0y6ziyjabvozdd253nd')
