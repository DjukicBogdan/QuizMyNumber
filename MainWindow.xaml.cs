using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace QuizMyNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string EnterText { get; set; }
        DateTime dateTime = new DateTime();
        public static int TargetNumber;
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private readonly string path = @"..\..\Data\TextFileRecord.txt";
        public static string NewName = "";
        public List<Record> listRecord = new List<Record>();
        public class Record
        {
            public int Number { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Normal;
            TimerSet();
            ReadRecord();
            StartGame();
        }

        private void TimerSet()
        {
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void StartGame()
        {
            dateTime = dateTime.AddHours(-dateTime.Hour).AddMinutes(-dateTime.Minute).AddSeconds(-dateTime.Second).AddMilliseconds(-dateTime.Millisecond);
            TextBoxInput.Text = " ";
            EnterText = " ";
            TextBlockResult.Text = "";
            TextBoxInput.IsReadOnly = true;
            LabelCover.Visibility = Visibility.Hidden;
            TextBlockRandomNumber1.IsEnabled = true;
            TextBlockRandomNumber2.IsEnabled = true;
            TextBlockRandomNumber3.IsEnabled = true;
            TextBlockRandomNumber4.IsEnabled = true;
            TextBlockRandomNumber10.IsEnabled = true;
            TextBlockRandomNumber100.IsEnabled = true;
            TextBlockRandomNumber1.Background = Brushes.Blue;
            TextBlockRandomNumber2.Background = Brushes.Blue;
            TextBlockRandomNumber3.Background = Brushes.Blue;
            TextBlockRandomNumber4.Background = Brushes.Blue;
            TextBlockRandomNumber10.Background = Brushes.Blue;
            TextBlockRandomNumber100.Background = Brushes.Blue;
            dispatcherTimer.Start();
            GetRandomNumber();
        }

        private void GetRandomNumber()
        {
            Random rnd = new Random();
            int num1 = rnd.Next(1, 10);
            int num2 = rnd.Next(1, 10);
            int num3 = rnd.Next(1, 10);
            TargetNumber = num1 * 100 + num2 * 10 + num3;
            TextBlockTargetNumber1.Text = num1.ToString();
            TextBlockTargetNumber2.Text = num2.ToString();
            TextBlockTargetNumber3.Text = num3.ToString();
            int NumRnd1 = rnd.Next(1, 10);
            int NumRnd2 = rnd.Next(1, 10);
            int NumRnd3 = rnd.Next(1, 10);
            int NumRnd4 = rnd.Next(1, 10);
            int NumRnd10 = rnd.Next(2, 5) * 5;
            int NumRnd100 = rnd.Next(1, 5) * 25;
            TextBlockRandomNumber1.Text = NumRnd1.ToString();
            TextBlockRandomNumber2.Text = NumRnd2.ToString();
            TextBlockRandomNumber3.Text = NumRnd3.ToString();
            TextBlockRandomNumber4.Text = NumRnd4.ToString();
            TextBlockRandomNumber10.Text = NumRnd10.ToString();
            TextBlockRandomNumber100.Text = NumRnd100.ToString();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            dateTime = dateTime.AddSeconds(1);
            TextBlockTime.Text = dateTime.ToString("mm:ss");
        }

        private void ButtonNewGame_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (EnterText.Length > 1)
            {
                EnterText = "";
                TextBoxInput.Text = "";
                TextBlockResult.Text = "";
                LabelCover.Visibility = Visibility.Hidden;
                TextBlockRandomNumber1.IsEnabled = true;
                TextBlockRandomNumber2.IsEnabled = true;
                TextBlockRandomNumber3.IsEnabled = true;
                TextBlockRandomNumber4.IsEnabled = true;
                TextBlockRandomNumber10.IsEnabled = true;
                TextBlockRandomNumber100.IsEnabled = true;
                TextBlockRandomNumber1.Background = Brushes.Blue;
                TextBlockRandomNumber2.Background = Brushes.Blue;
                TextBlockRandomNumber3.Background = Brushes.Blue;
                TextBlockRandomNumber4.Background = Brushes.Blue;
                TextBlockRandomNumber10.Background = Brushes.Blue;
                TextBlockRandomNumber100.Background = Brushes.Blue;
            }
        }

        private void TryToDoMath()
        {
            try
            {
                string number = TextBoxInput.Text;
                int DoMath = Convert.ToInt32(new DataTable().Compute(number, null));
                TextBlockResult.Text = DoMath.ToString();
            }
            catch (Exception)
            {

                TextBlockResult.Text = "";
            }
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxInput.Text) || string.IsNullOrEmpty(TextBoxInput.Text))
            {
                return;
            }
            try
            {
                string number = TextBoxInput.Text;
                int DoMath = Convert.ToInt32(new DataTable().Compute(number, null));
                TextBlockResult.Text = DoMath.ToString();
                dispatcherTimer.Stop();
                if (DoMath == TargetNumber)
                {
                    MessageBox.Show("WIN !!!");
                    WindowNewName windowNewName = new WindowNewName();
                    windowNewName.ShowDialog();
                    EditTextFile(dateTime.ToString("mm:ss"));
                    GridRecord.Visibility = Visibility.Visible;
                    ButtonClose.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("You didn't found a target number " + TargetNumber + "\ndifference: " + (TargetNumber - DoMath) + "\ntime: " + dateTime.ToString("mm:ss"));
                    StartGame();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error! ");
                StartGame();
            }
        }

        private void EditTextFile(string time)
        {
            string data = "";
            if (!File.Exists(path))
            {
                MessageBox.Show("File TextFileRecord.txt not found");
                try
                {
                    using (FileStream fs = File.Create(path))
                    {

                    }
                    MessageBox.Show("File TextFileRecord.txt is created");
                }
                catch (Exception exc)
                {

                    MessageBox.Show("File TextFileRecord.txt is not created, error: " + exc);
                }
            }
            data = ((NewName + "      " + time.ToString()) + Environment.NewLine);
            File.AppendAllText(path, data);
            string[] line = File.ReadAllLines(path);
            listRecord.Clear();

            foreach (var item in line)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                Record record = new Record();
                record.Name = item.Substring(0, item.Length - 5);
                record.Time = (item.Substring(item.Length - 5, 5));
                listRecord.Add(record);

            }
            var NewlistRecord = listRecord.OrderBy(x => x.Time);
            int i = 1;
            foreach (var item in NewlistRecord)
            {
                item.Number = i; i++;
            }

            foreach (var item1 in NewlistRecord)
            {
                if (item1.Number > 10)
                {
                    listRecord.Remove(item1);
                }
            }
            NewlistRecord = listRecord.OrderBy(x => x.Number);
            File.WriteAllText(path, "");
            foreach (var item in NewlistRecord)
            {
                string Time = item.Time;
                data = (item.Name + " " + Time + Environment.NewLine);
                File.AppendAllText(path, data);
            }

            DataGridRecord.ItemsSource = null;
            DataGridRecord.Items.Clear();
            DataGridRecord.ItemsSource = NewlistRecord.ToList();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            ButtonClose.Visibility = Visibility.Hidden;
            GridRecord.Visibility = Visibility.Hidden;
            LabelCover.Visibility = Visibility.Hidden;
            StartGame();
        }

        private void TextBlockRandomNumber1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnterText += TextBlockRandomNumber1.Text;
            TextBoxInput.Text = EnterText;
            TextBlockRandomNumber1.Background = Brushes.LightGray;
            TextBlockRandomNumber1.IsEnabled = false;
            LabelCover.Visibility = Visibility.Visible;
            TryToDoMath();
        }

        private void TextBlockRandomNumber2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnterText += TextBlockRandomNumber2.Text;
            TextBoxInput.Text = EnterText;
            TextBlockRandomNumber2.Background = Brushes.LightGray;
            TextBlockRandomNumber2.IsEnabled = false;
            LabelCover.Visibility = Visibility.Visible;
            TryToDoMath();
        }

        private void TextBlockRandomNumber3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnterText += TextBlockRandomNumber3.Text;
            TextBoxInput.Text = EnterText;
            TextBlockRandomNumber3.Background = Brushes.LightGray;
            TextBlockRandomNumber3.IsEnabled = false;
            LabelCover.Visibility = Visibility.Visible;
            TryToDoMath();
        }

        private void TextBlockRandomNumber4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnterText += TextBlockRandomNumber4.Text;
            TextBoxInput.Text = EnterText;
            TextBlockRandomNumber4.Background = Brushes.LightGray;
            TextBlockRandomNumber4.IsEnabled = false;
            LabelCover.Visibility = Visibility.Visible;
            TryToDoMath();
        }

        private void TextBlockRandomNumber10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnterText += TextBlockRandomNumber10.Text;
            TextBoxInput.Text = EnterText;
            TextBlockRandomNumber10.Background = Brushes.LightGray;
            TextBlockRandomNumber10.IsEnabled = false;
            LabelCover.Visibility = Visibility.Visible;
            TryToDoMath();
        }

        private void TextBlockRandomNumber100_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EnterText += TextBlockRandomNumber100.Text;
            TextBoxInput.Text = EnterText;
            TextBlockRandomNumber100.Background = Brushes.LightGray;
            TextBlockRandomNumber100.IsEnabled = false;
            LabelCover.Visibility = Visibility.Visible;
            TryToDoMath();
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            EnterText += "+ "; TextBoxInput.Text = EnterText;
            LabelCover.Visibility = Visibility.Hidden;
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            EnterText += "- "; TextBoxInput.Text = EnterText;
            LabelCover.Visibility = Visibility.Hidden;
        }

        private void ButtonMultiple_Click(object sender, RoutedEventArgs e)
        {
            EnterText += "* "; TextBoxInput.Text = EnterText;
            LabelCover.Visibility = Visibility.Hidden;
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            EnterText += "/ "; TextBoxInput.Text = EnterText;
            LabelCover.Visibility = Visibility.Hidden;
        }

        private void ButtonOpenBracket_Click(object sender, RoutedEventArgs e)
        {
            EnterText += "( "; TextBoxInput.Text = EnterText;
            LabelCover.Visibility = Visibility.Hidden;
        }

        private void ButtonClosedBracket_Click(object sender, RoutedEventArgs e)
        {
            EnterText += ") "; TextBoxInput.Text = EnterText;
            LabelCover.Visibility = Visibility.Hidden;
            TryToDoMath();
        }

        private void ReadRecord()
        {
            string[] line = File.ReadAllLines(path);
            listRecord.Clear();

            foreach (var item in line)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                Record record = new Record();
                record.Name = item.Substring(0, item.Length - 5);
                record.Time = (item.Substring(item.Length - 5, 5));
                listRecord.Add(record);

            }
            var NewlistRecord = listRecord.OrderBy(x => x.Time);
            int i = 1;
            foreach (var item in NewlistRecord)
            {
                item.Number = i; i++;
            }

            foreach (var item1 in NewlistRecord)
            {
                if (item1.Number > 10)
                {
                    listRecord.Remove(item1);
                }
            }
            NewlistRecord = listRecord.OrderBy(x => x.Number);
            File.WriteAllText(path, "");
            foreach (var item in NewlistRecord)
            {
                string Time = item.Time;
                var data = (item.Name + " " + Time + Environment.NewLine);
                File.AppendAllText(path, data);
            }

            DataGridRecord.ItemsSource = null;
            DataGridRecord.Items.Clear();
            DataGridRecord.ItemsSource = NewlistRecord.ToList();
        }

        private void TextBlockTime_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TextBoxInput.IsReadOnly == false)
            {
                TextBoxInput.IsReadOnly = true;
            }
            else
            {
                TextBoxInput.IsReadOnly = false;
            }

        }
    }
}
