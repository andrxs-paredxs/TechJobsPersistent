--Part 1
TABLE employers(
	Id INTEGER PRIMARY KEY AUTO_INCREMENT,
	Location LONGTEXT,
	Name LONGTEXT
),

TABLE jobs(
	EmployerId INTEGER,
	Id INTEGER PRIMARY KEY AUTO_INCREMENT,
	Name LONGTEXT
)

TABLE jobskills(
	JobId INTEGER,
	SkillId INTEGER
)

TABLE Skills(
	Id INTEGER PRIMARY KEY AUTO_INCREMENT,
	Description LONGTEXT,
	Name LONGTEXT
)


--Part 2
SELECT name FROM dbtechjobs.employers where Location="St. Louis City";

--Part 3
SELECT jobskills.SkillId, skills.Name, skills.Description
FROM skills
INNER JOIN jobskills 
ON jobskills.SkillId = skills.Id
ORDER BY skills.Name ASC
