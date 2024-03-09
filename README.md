![image](https://github.com/minhswe/academic-management-and-test-taking/assets/137794342/34cff325-1ca0-4c07-8f6b-7a42ac771ff6)# academic-management-and-test-taking
On the administrative side, it is possible to manage classes, courses, topics, questions and tests, on the student side, they can register courses, take the test (both single and multiple choice) and review the results. C# with Entity framework, SQL 

-- Introduction -- <br/>
A training center needs to develop a computer-based test program for multiple-choice subjects. The center has many subjects, subject information includes: subject code, subject name. Each subject consists of many chapters, each chapter includes many questions, a question belongs to only one chapter, a chapter belongs to only one subject. Information about the question includes: question code, question content, content of questions a, b, c, d. An exam question is only used for one exam of a subject. Information about the exam includes: exam code, exam date, questions in the subject of this exam. When a student takes an exam, the program needs to save this student's work including the choices (a, b, c, d) of the questions in this exam. Student information includes: student code, full name, address. A student belongs to only one class. Information about the class includes: class code, class name. A class must study many subjects and a student must only take exams in the subjects of his or her class.<br/><br/>

The program allows mixing questions when creating exams and allows reviewing student results from previous exams. <br/><br/>
As stated in the problem, my group divided the problem into 2 parts: management and students <br/><br/>

Regarding management: can manage classes, subjects, programs, questions and tests <br/><br/>

For students: allows students to register for courses according to the class the student previously selected. For exams, only exams for registered subjects are displayed, and each exam can only be taken once. There is a question shuffling feature, ensuring that each student will have a different order when taking the exam. together. Allows students to review test answers
<br/><br/>

-- Use case diagram -- <br/>
![image](https://github.com/minhswe/academic-management-and-test-taking/assets/137794342/1b23b8b8-178e-4851-b2a7-688d8da85957)

-- Entity relationship diagram --<br/>
![so do thuc the](https://github.com/minhswe/academic-management-and-test-taking/assets/137794342/99f33d88-2f99-4d13-b202-594bb742b3f3)
<br/><br/>
-- Relational Schema -- <br/>
![relational shema](https://github.com/minhswe/academic-management-and-test-taking/assets/137794342/4598b729-02d9-46d3-96d1-425aa206df5d)

-- Update 09/03/2024 -- <br/>
I did this project for the final exam <br/>
I believe there are still some bugs <br/>
I'll come back and finish it if I have time <br/>
