USE Employee_Polls

--CREATE TABLE SETTINGS
CREATE TABLE Settings (
	ID int IDENTITY(100, 1),
	PARAMETER_NAME nvarchar(max),
	PARAMETER_VALUE varchar(50)
);

SELECT * FROM [Employee_Polls].[dbo].[Users]
SELECT * FROM [Employee_Polls].[dbo].[Answers]
SELECT * FROM [Employee_Polls].[dbo].[Questions]
SELECT * FROM QuestionAnswers
--insert value for Users table
INSERT INTO Users VALUES ('sarahedo', 'password123', 'Sarah Edo', 
						  'https://gravatar.com/avatar/3488054da5eddcea12a54a829afdeaf5?s=200&d=robohash&r=x')
INSERT INTO Users VALUES ('tylermcginnis', 'abc321', 'Tyler McGinnis', 
						  'https://gravatar.com/avatar/f41195b2d86b8e2de6eccc1ad5f36ac2?s=200&d=robohash&r=x')
INSERT INTO Users VALUES ('mtsamis', 'xyz123', 'Mike Tsamis', 
						  'https://gravatar.com/avatar/b37485331b482a3574f05b5ce83be659?s=200&d=robohash&r=x')
INSERT INTO Users VALUES ('zoshikanlu', 'pass246', 'Zenobia Oshikanlu', 
						  'https://robohash.org/e74b74e78898a61f19f13e121f68b883?set=set4&bgset=&size=30x30')

--insert value for Answers table
--QuestionID: 8xf0y6ziyjabvozdd253nd
INSERT INTO Answers VALUES ('sarahedo', 'Build our new application with Javascript', '', 'Build our new application with Typescript')
--QuestionsID: 6ni6ok3ym7mf1p33lnez
INSERT INTO Answers VALUES ('', 'hire more frontend developers', 'mtsamis', 'hire more backend developers')
INSERT INTO Answers VALUES ('', 'hire more frontend developers', 'sarahedo', 'hire more backend developers')

--QuestionID: am8ehyc8byjqgar0jgpub9
INSERT INTO Answers VALUES ('', 'conduct a release retrospective 1 week after a release', 'sarahedo', 'conduct release retrospectives quarterly')

--QuestionID: loxhs1bqm25b708cmbf3g
INSERT INTO Answers VALUES ('', 'have code reviews conducted by peers', 'sarahedo', 'have code reviews conducted by managers')

--QuestionID: vthrdm985a262al8qx3do
INSERT INTO Answers VALUES ('tylermcginnis', 'take a course on ReactJS', 'mtsamis', 'take a course on unit testing with Jest')

--QuestionID: xj352vofupe1dqz9emx13r
INSERT INTO Answers VALUES ('mtsamis', 'deploy to production once every two weeks', '', 'deploy to production once every month')
INSERT INTO Answers VALUES ('zoshikanlu', 'deploy to production once every two weeks', '', 'deploy to production once every month')
INSERT INTO Answers VALUES ('', 'deploy to production once every two weeks', 'tylermcginnis', 'deploy to production once every month')

--insert value for Questions table
SELECT * FROM [Employee_Polls].[dbo].[Questions]
INSERT INTO Questions VALUES ('8xf0y6ziyjabvozdd253nd', 'sarahedo', 'sarahedo', '2016-06-29 09:21:12.634') --1
INSERT INTO Questions VALUES ('6ni6ok3ym7mf1p33lnez', 'mtsamis', 'mtsamis', '2016-07-14 14:02:47.190')--2, 3
INSERT INTO Questions VALUES ('am8ehyc8byjqgar0jgpub9', 'sarahedo', 'sarahedo', '2017-03-04 05:22:47.190') --4

INSERT INTO Questions VALUES ('loxhs1bqm25b708cmbf3g', 'tylermcginnis', 'tylermcginnis', '2016-12-24 18:42:47.190') --5
INSERT INTO Questions VALUES ('vthrdm985a262al8qx3do', 'tylermcginnis', 'tylermcginnis', '2017-03-15 19:09:27.190') --6
INSERT INTO Questions VALUES ('xj352vofupe1dqz9emx13r', 'mtsamis', 'mtsamis', '2017-05-01 02:16:07.190') --7, 8, 9

--insert value for general table: Question and Answer
INSERT INTO QuestionAnswers VALUES ('8xf0y6ziyjabvozdd253nd', 1)
INSERT INTO QuestionAnswers VALUES ('6ni6ok3ym7mf1p33lnez', 2)
INSERT INTO QuestionAnswers VALUES ('6ni6ok3ym7mf1p33lnez', 3)
INSERT INTO QuestionAnswers VALUES ('am8ehyc8byjqgar0jgpub9', 4)
INSERT INTO QuestionAnswers VALUES ('loxhs1bqm25b708cmbf3g', 5)
INSERT INTO QuestionAnswers VALUES ('vthrdm985a262al8qx3do', 6)
INSERT INTO QuestionAnswers VALUES ('xj352vofupe1dqz9emx13r', 7)
INSERT INTO QuestionAnswers VALUES ('xj352vofupe1dqz9emx13r', 8)
INSERT INTO QuestionAnswers VALUES ('xj352vofupe1dqz9emx13r', 9)

SELECT * FROM Settings
--insert value for Settings table
INSERT INTO Settings VALUES ('ORDER_BY_AUTHOR_ALPHABET', 'DESC')
INSERT INTO Settings VALUES ('ORDER_BY_ANSWERED_QUESTIONS', 'DESC')
INSERT INTO Settings VALUES ('ORDER_BY_CREATED_QUESTIONS', 'DESC')


USE Employee_Polls
SELECT * FROM [Employee_Polls].[dbo].[Users]
SELECT * FROM [Employee_Polls].[dbo].[Answers]
SELECT * FROM [Employee_Polls].[dbo].[Questions]
SELECT * FROM QuestionAnswers


SELECT UserId,
       AnsweredQuestions,
       CreatedQuestions,
       AvatarURL
FROM
  (SELECT VotedOption, SUM(VoteCount) AS AnsweredQuestions
   FROM
     (SELECT VotedOptionOne AS VotedOption, COUNT(*) AS VoteCount
      FROM Answers
      GROUP BY VotedOptionOne
      UNION ALL 
	  SELECT VotedOptionTwo AS VotedOption, COUNT(*) AS VoteCount
      FROM Answers
      GROUP BY VotedOptionTwo) AS CombinedVotes
   GROUP BY VotedOption) AS T1
INNER JOIN
  (SELECT Users.UserId AS Author,
          COALESCE(COUNT(Questions.QuestionId), 0) AS CreatedQuestions,
          Users.AvatarURL
   FROM Users
   LEFT JOIN Questions ON Questions.Author = Users.UserId
   GROUP BY Users.UserId,
            Users.AvatarURL) AS T2 ON T1.VotedOption = T2.UserId
ORDER BY AnsweredQuestions DESC
SELECT * FROM SETTINGS WHERE [PARAMETER_NAME] = 'ORDER_BY_ANSWERED_QUESTIONS'
