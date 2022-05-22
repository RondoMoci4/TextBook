using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextBook.Data;
using TextBook.Pages;

namespace TextBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateTestPage.xaml
    /// </summary>
    public partial class CreateTestPage : Page
    {
        TimeSpan timeTest = new TimeSpan(0,0,0);
        bool Existing;
        int countQuestion = 0;

        public CreateTestPage()
        {
            InitializeComponent();
          //  ConnectionClass.connection = new DBTextBookEntities();
            ConnectionClass.connect = new TextBookEntities();
            btnDeleteQuestion.Opacity = 0.3;
            btnUpdateQuestion.Opacity = 0.3;
            btnResetQuestion.Opacity = 0.3;
            cmbUnitTime.SelectedIndex = 0;
            txbTestCreator.Text = $"{Properties.Settings.Default.NameAdmin} {Properties.Settings.Default.SurnameAdmin}";
            var existing = ConnectionClass.connect.Test.FirstOrDefault(x => x.IdTest == Properties.Settings.Default.IdExistingTest);
            if (existing == null)
            {
                txbTime.Text = timeTest.ToString();
                txbCountQuestion.Text = $"{countQuestion}";
                Existing = false;
            }
            else
            {
                Existing = true;
                LoadTest(Properties.Settings.Default.IdExistingTest);
            }
           
            
        }
        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (Existing == false)
            {
                if (!String.IsNullOrWhiteSpace(txbTitleTest.Text))
                {
                    if (txbTime.Text != "00:00:00")
                    {
                        if (!String.IsNullOrWhiteSpace(txbQuestion.Text))
                        {
                            if (!String.IsNullOrWhiteSpace(txbAnswerOne.Text) && !String.IsNullOrWhiteSpace(txbAnswerTwo.Text) && !String.IsNullOrWhiteSpace(txbAnswerThree.Text) && !String.IsNullOrWhiteSpace(txbAnswerFour.Text))
                            {
                                if (rbOneAnswer.IsChecked == true || rbTwoAnswer.IsChecked == true || rbThreeAnswer.IsChecked == true || rbFourAnswer.IsChecked == true)
                                {
                                    countQuestion++;
                                    txbCountQuestion.Text = $"{countQuestion}";
                                    Test test = new Test()
                                    {
                                        Title = txbTitleTest.Text,
                                        Time = TimeSpan.Parse(txbTime.Text),
                                        CountQuestion = Convert.ToInt32(txbCountQuestion.Text),
                                        CreatorTest = Properties.Settings.Default.AdminId
                                    };
                                    ConnectionClass.connect.Test.Add(test);
                                    ConnectionClass.connect.SaveChanges();

                                    var lastTest = ConnectionClass.connect.Test.FirstOrDefault(x => x.Title == txbTitleTest.Text);

                                    TestQuestion question = new TestQuestion()
                                    {
                                        IdTest = lastTest.IdTest,
                                        TitleQuestion = txbQuestion.Text,
                                    };
                                    ConnectionClass.connect.TestQuestion.Add(question);
                                    ConnectionClass.connect.SaveChanges();

                                    var lastQuestion = ConnectionClass.connect.TestQuestion.FirstOrDefault(x => x.TitleQuestion == txbQuestion.Text);
                                    List<string> listAnswer = new List<string>();
                                    listAnswer.Add(txbAnswerOne.Text);
                                    listAnswer.Add(txbAnswerTwo.Text);
                                    listAnswer.Add(txbAnswerThree.Text);
                                    listAnswer.Add(txbAnswerFour.Text);

                                    if (rbOneAnswer.IsChecked == true)
                                    {
                                        TestAnswer answer = new TestAnswer()
                                        {
                                            IdQuestion = lastQuestion.IdQuestion,
                                            Answer = listAnswer[0],
                                            Correct = true,
                                        };
                                        ConnectionClass.connect.TestAnswer.Add(answer);
                                        ConnectionClass.connect.SaveChanges();
                                    }
                                    else
                                    {
                                        TestAnswer answer = new TestAnswer()
                                        {
                                            IdQuestion = lastQuestion.IdQuestion,
                                            Answer = listAnswer[0],
                                            Correct = false,
                                        };
                                        ConnectionClass.connect.TestAnswer.Add(answer);
                                        ConnectionClass.connect.SaveChanges();
                                    }

                                    if (rbTwoAnswer.IsChecked == true)
                                    {
                                        TestAnswer answer = new TestAnswer()
                                        {
                                            IdQuestion = lastQuestion.IdQuestion,
                                            Answer = listAnswer[1],
                                            Correct = true,
                                        };
                                        ConnectionClass.connect.TestAnswer.Add(answer);
                                        ConnectionClass.connect.SaveChanges();
                                    }
                                    else
                                    {
                                        TestAnswer answer = new TestAnswer()
                                        {
                                            IdQuestion = lastQuestion.IdQuestion,
                                            Answer = listAnswer[1],
                                            Correct = false,
                                        };
                                        ConnectionClass.connect.TestAnswer.Add(answer);
                                        ConnectionClass.connect.SaveChanges();
                                    }

                                    if (rbThreeAnswer.IsChecked == true)
                                    {
                                        TestAnswer answer = new TestAnswer()
                                        {
                                            IdQuestion = lastQuestion.IdQuestion,
                                            Answer = listAnswer[2],
                                            Correct = true,
                                        };
                                        ConnectionClass.connect.TestAnswer.Add(answer);
                                        ConnectionClass.connect.SaveChanges();
                                    }
                                    else
                                    {
                                        TestAnswer answer = new TestAnswer()
                                        {
                                            IdQuestion = lastQuestion.IdQuestion,
                                            Answer = listAnswer[2],
                                            Correct = false,
                                        };
                                        ConnectionClass.connect.TestAnswer.Add(answer);
                                        ConnectionClass.connect.SaveChanges();
                                    }

                                    if (rbFourAnswer.IsChecked == true)
                                    {
                                        TestAnswer answer = new TestAnswer()
                                        {
                                            IdQuestion = lastQuestion.IdQuestion,
                                            Answer = listAnswer[3],
                                            Correct = true,
                                        };
                                        ConnectionClass.connect.TestAnswer.Add(answer);
                                        ConnectionClass.connect.SaveChanges();
                                    }
                                    else
                                    {
                                        TestAnswer answer = new TestAnswer()
                                        {
                                            IdQuestion = lastQuestion.IdQuestion,
                                            Answer = listAnswer[3],
                                            Correct = false,
                                        };
                                        ConnectionClass.connect.TestAnswer.Add(answer);
                                        ConnectionClass.connect.SaveChanges();
                                    }
                                    txbTitleTest.IsReadOnly = true;
                                    Existing = true;
                                    Reset();
                                }
                                else { MessageBox.Show("Выберите правильный ответ!!!"); }
                            }
                            else { MessageBox.Show("Заполните все варианты ответа!!!"); }
                        }
                        else { MessageBox.Show("Введите вопрос!!!"); }
                    }
                    else
                    {
                        MessageBox.Show("Увеличьте время прохождения!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Введите название теста");
                }
            }
            else
            {
                if (txbTime.Text != "00:00:00")
                {
                    if (!String.IsNullOrWhiteSpace(txbQuestion.Text))
                    {
                        if (!String.IsNullOrWhiteSpace(txbAnswerOne.Text) && !String.IsNullOrWhiteSpace(txbAnswerTwo.Text) && !String.IsNullOrWhiteSpace(txbAnswerThree.Text) && !String.IsNullOrWhiteSpace(txbAnswerFour.Text))
                        {
                            if (rbOneAnswer.IsChecked == true || rbTwoAnswer.IsChecked == true || rbThreeAnswer.IsChecked == true || rbFourAnswer.IsChecked == true)
                            {
                                countQuestion++;
                                txbCountQuestion.Text = $"{countQuestion}";
                                var test = ConnectionClass.connect.Test.FirstOrDefault(x => x.Title == txbTitleTest.Text);
                                test.CountQuestion = countQuestion;
                                ConnectionClass.connect.SaveChanges();
                                var lastTest = ConnectionClass.connect.Test.FirstOrDefault(x => x.Title == txbTitleTest.Text);

                                TestQuestion question = new TestQuestion()
                                {
                                    IdTest = lastTest.IdTest,
                                    TitleQuestion = txbQuestion.Text,
                                };
                                ConnectionClass.connect.TestQuestion.Add(question);
                                ConnectionClass.connect.SaveChanges();

                                var lastQuestion = ConnectionClass.connect.TestQuestion.FirstOrDefault(x => x.TitleQuestion == txbQuestion.Text);
                                List<string> listAnswer = new List<string>();
                                listAnswer.Add(txbAnswerOne.Text);
                                listAnswer.Add(txbAnswerTwo.Text);
                                listAnswer.Add(txbAnswerThree.Text);
                                listAnswer.Add(txbAnswerFour.Text);

                                if (rbOneAnswer.IsChecked == true)
                                {
                                    TestAnswer answer = new TestAnswer()
                                    {
                                        IdQuestion = lastQuestion.IdQuestion,
                                        Answer = listAnswer[0],
                                        Correct = true,
                                    };
                                    ConnectionClass.connect.TestAnswer.Add(answer);
                                    ConnectionClass.connect.SaveChanges();
                                }
                                else
                                {
                                    TestAnswer answer = new TestAnswer()
                                    {
                                        IdQuestion = lastQuestion.IdQuestion,
                                        Answer = listAnswer[0],
                                        Correct = false,
                                    };
                                    ConnectionClass.connect.TestAnswer.Add(answer);
                                    ConnectionClass.connect.SaveChanges();
                                }

                                if (rbTwoAnswer.IsChecked == true)
                                {
                                    TestAnswer answer = new TestAnswer()
                                    {
                                        IdQuestion = lastQuestion.IdQuestion,
                                        Answer = listAnswer[1],
                                        Correct = true,
                                    };
                                    ConnectionClass.connect.TestAnswer.Add(answer);
                                    ConnectionClass.connect.SaveChanges();
                                }
                                else
                                {
                                    TestAnswer answer = new TestAnswer()
                                    {
                                        IdQuestion = lastQuestion.IdQuestion,
                                        Answer = listAnswer[1],
                                        Correct = false,
                                    };
                                    ConnectionClass.connect.TestAnswer.Add(answer);
                                    ConnectionClass.connect.SaveChanges();
                                }

                                if (rbThreeAnswer.IsChecked == true)
                                {
                                    TestAnswer answer = new TestAnswer()
                                    {
                                        IdQuestion = lastQuestion.IdQuestion,
                                        Answer = listAnswer[2],
                                        Correct = true,
                                    };
                                    ConnectionClass.connect.TestAnswer.Add(answer);
                                    ConnectionClass.connect.SaveChanges();
                                }
                                else
                                {
                                    TestAnswer answer = new TestAnswer()
                                    {
                                        IdQuestion = lastQuestion.IdQuestion,
                                        Answer = listAnswer[2],
                                        Correct = false,
                                    };
                                    ConnectionClass.connect.TestAnswer.Add(answer);
                                    ConnectionClass.connect.SaveChanges();
                                }

                                if (rbFourAnswer.IsChecked == true)
                                {
                                    TestAnswer answer = new TestAnswer()
                                    {
                                        IdQuestion = lastQuestion.IdQuestion,
                                        Answer = listAnswer[3],
                                        Correct = true,
                                    };
                                    ConnectionClass.connect.TestAnswer.Add(answer);
                                    ConnectionClass.connect.SaveChanges();
                                }
                                else
                                {
                                    TestAnswer answer = new TestAnswer()
                                    {
                                        IdQuestion = lastQuestion.IdQuestion,
                                        Answer = listAnswer[3],
                                        Correct = false,
                                    };
                                    ConnectionClass.connect.TestAnswer.Add(answer);
                                    ConnectionClass.connect.SaveChanges();
                                }
                                Reset();
                            }
                            else { MessageBox.Show("Выберите правильный ответ!!!"); }
                        }
                        else { MessageBox.Show("Заполните все варианты ответа!!!"); }
                    }
                    else { MessageBox.Show("Введите вопрос!!!"); }
                }
                else
                {
                    MessageBox.Show("Увеличьте время прохождения!!!");
                }    
            }
        }
        private void btnUpdateQuestion_Click(object sender, RoutedEventArgs e)
        {
            if(txbTime.Text != "00:00:00")
            {
                if (!String.IsNullOrWhiteSpace(txbQuestion.Text))
                {
                    if (!String.IsNullOrWhiteSpace(txbAnswerOne.Text) && !String.IsNullOrWhiteSpace(txbAnswerTwo.Text) && !String.IsNullOrWhiteSpace(txbAnswerThree.Text) && !String.IsNullOrWhiteSpace(txbAnswerFour.Text))
                    {
                        if (rbOneAnswer.IsChecked == true || rbTwoAnswer.IsChecked == true || rbThreeAnswer.IsChecked == true || rbFourAnswer.IsChecked == true)
                        {
                            int id = Convert.ToInt32(txbQuestionListBox.Text);
                            var test = ConnectionClass.connect.Test.FirstOrDefault(x => x.Title == txbTitleTest.Text);
                            var question = ConnectionClass.connect.TestQuestion.FirstOrDefault(x => x.IdTest == test.IdTest && x.IdQuestion == id);
                            var answer = ConnectionClass.connect.TestAnswer.Where(x => x.IdQuestion == question.IdQuestion).ToList();
                            List<int> answerInt = new List<int>(answer.Select(x => x.IdAnswer));
                            int one = answerInt[0];
                            int two = answerInt[1];
                            int three = answerInt[2];
                            int four = answerInt[3];
                            var answerOne = ConnectionClass.connect.TestAnswer.FirstOrDefault(x => x.IdAnswer == one);
                            if (rbOneAnswer.IsChecked == true)
                            {
                                answerOne.Answer = txbAnswerOne.Text;
                                answerOne.Correct = true;
                            }
                            else
                            {
                                answerOne.Answer = txbAnswerOne.Text;
                                answerOne.Correct = false;
                            }
                            var answerTwo = ConnectionClass.connect.TestAnswer.FirstOrDefault(x => x.IdAnswer == two);
                            if (rbTwoAnswer.IsChecked == true)
                            {
                                answerTwo.Answer = txbAnswerOne.Text;
                                answerTwo.Correct = true;
                            }
                            else
                            {
                                answerTwo.Answer = txbAnswerOne.Text;
                                answerTwo.Correct = false;
                            }
                            var answerThree = ConnectionClass.connect.TestAnswer.FirstOrDefault(x => x.IdAnswer == three);
                            if (rbThreeAnswer.IsChecked == true)
                            {
                                answerThree.Answer = txbAnswerOne.Text;
                                answerThree.Correct = true;
                            }
                            else
                            {
                                answerThree.Answer = txbAnswerOne.Text;
                                answerThree.Correct = false;
                            }
                            var answerFour = ConnectionClass.connect.TestAnswer.FirstOrDefault(x => x.IdAnswer == four);
                            if (rbFourAnswer.IsChecked == true)
                            {
                                answerFour.Answer = txbAnswerOne.Text;
                                answerOne.Correct = true;
                            }
                            else
                            {
                                answerFour.Answer = txbAnswerOne.Text;
                                answerFour.Correct = false;
                            }
                            question.TitleQuestion = txbQuestion.Text;
                            test.Time = TimeSpan.Parse(txbTime.Text);
                            test.Title = txbTitleTest.Text;
                            test.CountQuestion = Convert.ToInt32(txbCountQuestion.Text);
                            ConnectionClass.connect.SaveChanges();
                        }
                        else { MessageBox.Show("Выберите правильный ответ!!!"); }
                    }
                    else { MessageBox.Show("Заполните все варианты ответа!!!"); }
                }
                else { MessageBox.Show("Введите вопрос!!!"); }
            }
            else
            {
                MessageBox.Show("Увеличьте время прохождения!!!");
            }
        }

        private void btnDeleteQuestion_Click(object sender, RoutedEventArgs e)
        {

            int id = Convert.ToInt32(txbQuestionListBox.Text);
            var test = ConnectionClass.connect.Test.FirstOrDefault(x => x.Title == txbTitleTest.Text);
            var question = ConnectionClass.connect.TestQuestion.FirstOrDefault(x => x.IdTest == test.IdTest && x.IdQuestion == id);
            var answer = ConnectionClass.connect.TestAnswer.Where(x => x.IdQuestion == id).ToList();
            ConnectionClass.connect.TestAnswer.RemoveRange(answer);
            ConnectionClass.connect.TestQuestion.Remove(question);
            ConnectionClass.connect.SaveChanges();
            Reset();
        }

        private void lbListQuestion_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = Convert.ToInt32(txbQuestionListBox.Text);
            var idQuestion = ConnectionClass.connect.TestQuestion.FirstOrDefault(x => x.IdQuestion == id);
            txbQuestion.Text = idQuestion.TitleQuestion;
            var answer = ConnectionClass.connect.TestAnswer.Where(x => x.IdQuestion == idQuestion.IdQuestion).ToList();
            List<string> Answer = new List<string>(answer.Select(x => x.Answer));
            txbAnswerOne.Text = Answer[0]; txbAnswerTwo.Text = Answer[1]; txbAnswerThree.Text = Answer[2]; txbAnswerFour.Text = Answer[3];
            List<bool> answerBool = new List<bool>(answer.Select(x => x.Correct));
            rbOneAnswer.IsChecked = answerBool[0]; rbTwoAnswer.IsChecked = answerBool[1];
            rbThreeAnswer.IsChecked = answerBool[2]; rbFourAnswer.IsChecked= answerBool[3];
            btnDeleteQuestion.IsEnabled = true; btnDeleteQuestion.Opacity = 1;
            btnUpdateQuestion.IsEnabled = true; btnUpdateQuestion.Opacity = 1;
            btnResetQuestion.IsEnabled = true; btnResetQuestion.Opacity = 1;
            btnAddQuestion.IsEnabled = false; btnAddQuestion.Opacity = 0.3;
        }

        private void btnQuestionInfo_Click(object sender, RoutedEventArgs e)
        {
            if(Properties.Settings.Default.IdExistingTest == 0)
            {
                var idTest = ConnectionClass.connect.Test.FirstOrDefault(x => x.Title == txbTitleTest.Text);
                lbListQuestion.ItemsSource = ConnectionClass.connect.TestQuestion.Where(x => x.IdTest == idTest.IdTest).ToList();
            }
            else
            {
                lbListQuestion.ItemsSource = ConnectionClass.connect.TestQuestion.Where(x => x.IdTest == Properties.Settings.Default.IdExistingTest).ToList();
            }
            if (brdInfoQuestion.Width == 250)
            {
                DoubleAnimation anim = new DoubleAnimation();
                anim.From = 250;
                anim.To = 0;
                anim.Duration = TimeSpan.FromSeconds(1);
                brdInfoQuestion.BeginAnimation(WidthProperty, anim);
            }
            else
            {
                DoubleAnimation anim = new DoubleAnimation();
                anim.From = 0;
                anim.To = 250;
                anim.Duration = TimeSpan.FromSeconds(1);
                brdInfoQuestion.BeginAnimation(WidthProperty, anim);
            }
        }

        private void btnUpTime_Click(object sender, RoutedEventArgs e) { UpTime(txbTime,cmbUnitTime); }

        private void btnDownTime_Click(object sender, RoutedEventArgs e) { DownTime(txbTime, cmbUnitTime); }

        private void UpTime(TextBox text,ComboBox comboBox)
        {
            if (comboBox.SelectedIndex == 1)
            {
                timeTest = timeTest.Add(TimeSpan.FromMinutes(1));
                text.Text = timeTest.ToString();
            }
            else if (comboBox.SelectedIndex == 2)
            {
                timeTest = timeTest.Add(TimeSpan.FromHours(1));
                text.Text = timeTest.ToString();
            }
            else
            {
                timeTest = timeTest.Add(TimeSpan.FromSeconds(1));
                text.Text = timeTest.ToString();
            }
        }

        private void DownTime(TextBox text, ComboBox comboBox)
        {
            if (timeTest == TimeSpan.Zero) { }
            else
            {
                if (comboBox.SelectedIndex == 1)
                {
                    timeTest = timeTest.Add(TimeSpan.FromMinutes(-1));
                    text.Text = timeTest.ToString();
                }
                else if (comboBox.SelectedIndex == 2)
                {
                    if (timeTest == TimeSpan.FromHours(0)) { }
                    else
                    {
                        timeTest = timeTest.Add(TimeSpan.FromHours(-1));
                        text.Text = timeTest.ToString();
                    }
                }
                else
                {
                    timeTest = timeTest.Add(TimeSpan.FromSeconds(-1));
                    text.Text = timeTest.ToString();
                }
            }
        }

        private void LoadTest(int idTest)
        {
            var test = ConnectionClass.connect.Test.FirstOrDefault(x => x.IdTest == idTest);
            txbTitleTest.Text = test.Title;
            timeTest = test.Time;
            txbTime.Text = timeTest.ToString();
            txbCountQuestion.Text = test.CountQuestion.ToString();
        }

        private void btnResetQuestion_Click(object sender, RoutedEventArgs e) { Reset(); btnAddQuestion.IsEnabled = true; btnAddQuestion.Opacity = 1; }

        private void rbAllChecked(object sender, RoutedEventArgs e) { RadioButton button = (RadioButton)sender; button.IsChecked = true; }

        private void Reset()
        {
            txbAnswerOne.Clear(); txbQuestion.Clear(); txbAnswerTwo.Clear();
            txbAnswerThree.Clear(); txbAnswerFour.Clear();
            rbOneAnswer.IsChecked = false;
            rbTwoAnswer.IsChecked = false;
            rbThreeAnswer.IsChecked = false;
            rbFourAnswer.IsChecked = false;
        }
    }
}
