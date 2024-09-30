SELECT TOP (1000) [AnswerId]
      ,[NumberOfOptionOne]
      ,[IsSelectedOptionOne]
      ,[NumberOfOptionTwo]
      ,[IsSelectedOptionTwo]
  FROM [Employee_Polls].[dbo].[Answers]

--insert value for Answers table
---- should add constant for IDENTITY
INSERT INTO Answers(NumberOfOptionOne, IsSelectedOptionOne, NumberOfOptionTwo, IsSelectedOptionTwo)
	VALUES (1, 1, 0, 0)
INSERT INTO Answers(NumberOfOptionOne, IsSelectedOptionOne, NumberOfOptionTwo, IsSelectedOptionTwo)
	VALUES (0, 0, 1, 1)
INSERT INTO Answers(NumberOfOptionOne, IsSelectedOptionOne, NumberOfOptionTwo, IsSelectedOptionTwo)
	VALUES (1, 1, 0, 0)
