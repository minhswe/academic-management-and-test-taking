using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSystem
{
    internal class methodTest
    {
        ExaminationSystemEntities eSystem = new ExaminationSystemEntities();
       public void calculateScore(string questionID)
        {
            var correctChoices = eSystem.QuestionCorrectAnswers.Where(x => x.QuestionID == questionID).Select(y => y.CorrectChoice);

            List<string> a = new List<string>();
            foreach (var item in correctChoices)
            {
                a.Add(item);
            }

            // Join the elements in list 'a' without commas
            string concatenatedA = string.Join("", a);

            MessageBox.Show("Result a:" + concatenatedA);



            var studentChoice = eSystem.StudentRespones.Where(x => x.QuestionID == questionID).Select(y => y.ResponeChoice);
            List<string> b = new List<string>();

            foreach (var item in studentChoice)
            {
                string[] splitChoices = item.Split(','); // Splitting by comma
                for (int i = 0; i < splitChoices.Length; i++)
                {
                    splitChoices[i] = splitChoices[i].Trim();
                }

                // Join the splitChoices array without commas
                string concatenatedChoices = string.Join("", splitChoices);

                b.Add(concatenatedChoices); // Add concatenated string to the list
            }

            // Display or use the elements in the list
            foreach (var choice in b)
            {
                MessageBox.Show("Result b: " + choice);
            }

            a.Sort();
            b.Sort();
            var differences = a.Except(b).Union(b.Except(a));

            // Displaying the differences
            foreach (var item in differences)
            {
                MessageBox.Show("Difference: " + item);
            }

            bool listsAreEqual = a.SequenceEqual(b);

            if (listsAreEqual)
            {
                MessageBox.Show("Lists are equal");
            }
            else
            {
                MessageBox.Show("Lists are not equal");
            }
        }

        public void calculateScore1(string questionID)
        {
            var correctChoices = eSystem.QuestionCorrectAnswers.Where(x => x.QuestionID == questionID).Select(y => y.CorrectChoice);

            List<string> a = new List<string>();
            foreach (var item in correctChoices)
            {
                a.Add(item.ToUpper().Replace(" ", "")); // Convert to uppercase and remove spaces
            }

            a.Sort(); // Sort list 'a'

            var studentChoice = eSystem.StudentRespones.Where(x => x.QuestionID == questionID).Select(y => y.ResponeChoice);
            List<string> b = new List<string>();

            foreach (var item in studentChoice)
            {
                string[] splitChoices = item.Split(','); // Splitting by comma
                foreach (var choice in splitChoices)
                {
                    b.Add(choice.Trim().ToUpper().Replace(" ", "")); // Trim, convert to uppercase, and remove spaces
                }
            }

            b.Sort(); // Sort list 'b'

            // Remove spaces and trim whitespace from elements for comparison
            List<string> trimmedA = a.Select(choice => choice.Trim()).ToList();
            List<string> trimmedB = b.Select(choice => choice.Trim()).ToList();

            var differences = trimmedA.Except(trimmedB).Union(trimmedB.Except(trimmedA));

            foreach (var item in differences)
            {
                MessageBox.Show("Difference: " + item);
            }

            bool listsAreEqual = trimmedA.SequenceEqual(trimmedB);

            if (listsAreEqual)
            {
                MessageBox.Show("Lists are equal");
            }
            else
            {
                MessageBox.Show("Lists are not equal");
            }

        }
    }
}
