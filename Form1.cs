using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_Objects
{
    public partial class Form1 : Form
    {
        //Store all of the RadioButton in a list,
        //to make it easier to figufre out which one was checked, or to uncheck all
        private List<RadioButton> QuizRadioButtons;
        //All of the quiz questions
        private List<Question> QuizQuestions;
        //Keeps track of what question the app is currently asking, will be used to index QuizQuestions
        private int CurrentQuestionNumber;
        private int score = 0;
        public Form1()
        {
            InitializeComponent();
            //Add the four radio buttons to the list
            QuizRadioButtons = new List<RadioButton> { radioButton1, radioButton2, radioButton3, radioButton4 };
            //Example questions - feel free to make up your own
            //Create new Question with variables
            string questionText = "What is the fastest animal?";
            string questionAnswer = "Cheetah";
            List<string> wrongAnswers = new List<string> { "Slot", "Snail", "Tortoise" };
            Question q1 = new Question(questionText, questionAnswer, wrongAnswers);
            //Or create with literals
            Question q2 = new Question("What color is an elephant?", "Gray", new List<string> { "Pink", "Green", "Purple" });
            Question q3 = new Question("What does a cat say?", "Meow", new List<string> { "Quack", "Woof", "Beep" });
            //Add quiz questions to a list
            QuizQuestions = new List<Question> { q1, q2, q3 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayQuestion(0);
            btnNext.Enabled = false;
            btnCheckAnswer.Focus();
        }
        private void DisplayQuestion(int questionIndex)
        {
            //Lookup up the question, using questionIndex
            Question question = QuizQuestions[questionIndex];
            //Read the Answers property to get all list of the answer choices
            List<string> answers = question.AllAnswers;
            //Deselect all the radio buttons
            foreach (RadioButton rb in QuizRadioButtons)
            {
                rb.Checked = false;
            }
            //Set or reset the label result so it does not show result from previoius question
            lblResult.Text = "??";
            //Use the answeers to set the text for each RadioButton
            for (int a = 0; a < answers.Count; a++)
            {
                QuizRadioButtons[a].Text = answers[a];
            }
            //And display the question text
            lblQuestion.Text = question.QuestionText;
        }

        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            Question currentQuestion = QuizQuestions[CurrentQuestionNumber];
            //Which RadioButton was selected? The text of that raidio button is the user's answer
            string userAnswer = null;
            foreach (RadioButton rb in QuizRadioButtons)
            {
                if (rb.Checked == true)
                {
                    userAnswer = rb.Text;
                }
            }
            if (userAnswer == null)
            {
                MessageBox.Show("Pick an answer", "Error");
                return;
            }
            if (currentQuestion.IsCorrect(userAnswer)) //Determine if the user's answer is the correct one
            {
                lblResult.Text = "Correct!";
                score++; //Increase score
            }
            else
            {
                lblResult.Text = $"Wrong. The correct answer is {currentQuestion.CorrectAnswer}";
            }
            //Disable btnCheckAnswer, enable btnNext, focus on btnNext
            btnCheckAnswer.Enabled = false;
            btnNext.Enabled = true;
            btnNext.Focus();
            //Method.  Can be called for a Question object
            }   
            public bool IsCorrect(String answer)
            {
                return answer == CorrectAnswer;
            }
        }
        
    }   