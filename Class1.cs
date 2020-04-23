using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Objects
{
    class Question
    {
        //Constructor
        public Question(string questionText, string correctAnswer, List<String> wrongAnswers)
        {
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
        }
        //Auto Properties
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> WrongAnswers { get; set; }
        public List<string> AllAnswers
        {
            get
            {
                //Create a list of the correct answer and the wrong answers
                List<string> allAnswers = new List<string>();
                allAnswers.Add(CorrectAnswer);
                allAnswers.AddRange(WrongAnswers);
                //Create a random number generator
                Random random = new Random();
                //Create a new list for the shuffled answers
                List<String> shuffledAnswers = new List<String>();
                //Loop until all answers have been added to the shuffled list
                while (allAnswers.Count > 0)
                {
                    //Pick a random answer from all answers
                    int index = random.Next(allAnswers.Count);
                    //Fetch that answer, and remove from the list of all answers
                    string answer = allAnswers[index];
                    allAnswers.RemoveAt(index);
                    //Pick a random location to insert this answer into shuffled answers
                    int insertIndex = random.Next(shuffledAnswers.Count);
                    //And insert the answer
                    shuffledAnswers.Insert(insertIndex, answer);
                }
                return shuffledAnswers;
            }
        }
    }
}
