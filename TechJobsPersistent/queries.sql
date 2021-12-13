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

TABLE jobskills(
	Id INTEGER PRIMARY KEY AUTO_INCREMENT,
	Description LONGTEXT,
	Name LONGTEXT
)


--Part 2
SELECT name FROM dbtechjobs.employers where Location="St. Louis City";

--Part 3
SELECT name, description 
FROM skills
WHERE id == jobskill.skillId
ASC
