using System;
using System.Linq;
using Microsoft.Phone.Controls;
using System.Xml.Linq;
using System.Windows.Resources;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace JLPTFlashcards {
    public partial class MainPage : PhoneApplicationPage {
        XDocument loadedData;
        StreamResourceInfo xml;

        public MainPage() {
            InitializeComponent();
        }
        public static List<Word> Words = new List<Word>();

        void ShowMe_Click(object sender, System.Windows.RoutedEventArgs e) {
            TextBlock Clicked = (TextBlock)sender;
            ShowKanji.Foreground = PageTitle.Foreground;
            ShowKana.Foreground = PageTitle.Foreground;
            ShowEnglish.Foreground = PageTitle.Foreground;
            ShowRomaji.Foreground = PageTitle.Foreground;
            ShowHiragana.Foreground = PageTitle.Foreground;
            ShowKatakana.Foreground = PageTitle.Foreground;
            Clicked.Foreground = new SolidColorBrush(Color.FromArgb(255, 58, 158, 38));
            Show = Clicked;
            isStartable(sender, e);
        }

        void AskMe_Click(object sender, System.Windows.RoutedEventArgs e) {
            TextBlock Clicked = (TextBlock)sender;
            AskKanji.Foreground = PageTitle.Foreground;
            AskKana.Foreground = PageTitle.Foreground;
            AskEnglish.Foreground = PageTitle.Foreground;
            AskRomaji.Foreground = PageTitle.Foreground;
            AskHiragana.Foreground = PageTitle.Foreground;
            AskKatakana.Foreground = PageTitle.Foreground;
            Clicked.Foreground = new SolidColorBrush(Color.FromArgb(255, 58, 158, 38));
            Ask = Clicked;
            isStartable(sender, e);
        }

        public static TextBlock Ask = new TextBlock();
        public static TextBlock Show = new TextBlock();
        public static TextBlock Mode = new TextBlock();

        void Mode_Click(object sender, System.Windows.RoutedEventArgs e) {
            TextBlock Clicked = (TextBlock)sender;
            TeachingMode.Foreground = PageTitle.Foreground;
            QuizMode.Foreground = PageTitle.Foreground;
            Clicked.Foreground = new SolidColorBrush(Color.FromArgb(255, 58, 158, 38));
            Mode = Clicked;
            isStartable(sender, e);
            if (Clicked.Text.Equals("Teach")) {
                QuizGroup.Height = 0.0;
            } else
                QuizGroup.Height = Double.NaN;
        }

        void isStartable(object sender, System.Windows.RoutedEventArgs e) {
            if ((Level5.IsChecked == true || Level4.IsChecked == true || Level3.IsChecked == true || Level2.IsChecked == true || Level1.IsChecked == true) && !Mode.Text.Equals("")) {
                if (Mode.Text.Equals("Teach"))
                    StartButton.IsEnabled = true;
                else if (!Ask.Text.Equals("") && !Show.Text.Equals(""))
                    StartButton.IsEnabled = true;
                else
                    StartButton.IsEnabled = false;
            } else
                StartButton.IsEnabled = false;
        }

        String[] dicts = new String[] { "JLPT1.xml", "JLPT2.xml", "JLPT3.xml", "JLPT4.xml", "JLPT5.xml" };

        private void StartButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            CheckBox[] Levels = new CheckBox[5];
            Levels[0] = Level1;
            Levels[1] = Level2;
            Levels[2] = Level3;
            Levels[3] = Level4;
            Levels[4] = Level5;

            int[] selectedDicts = new int[5];
            for (int i = 0; i < 5; i++) {
                if (Levels[i].IsChecked == true)
                    selectedDicts[i] = i + 1;
                else
                    selectedDicts[i] = 0;
            }

            for (int i = 0; i < 5; i++) {
                if (selectedDicts[i] != 0) {
                    xml = App.GetResourceStream(new Uri(dicts[i], UriKind.Relative));
                    loadedData = XDocument.Load(xml.Stream);
                    var dict = from query in loadedData.Descendants("Word")
                               select new Word {
                                   Kanji = (string)query.Attribute("Kanji"),
                                   Kana = (string)query.Attribute("Kana"),
                                   English = (string)query.Attribute("English"),
                                   Romaji = (string)query.Attribute("Romaji"),
                                   Katakana = (string)query.Attribute("Katakana"),
                                   Hiragana = (string)query.Attribute("Hiragana")
                               };
                    Words.AddRange(dict.ToList());
                    System.Diagnostics.Debug.WriteLine("Loaded" + dicts[i]);
                }
            }

            if (Mode.Text.Equals("Quiz"))
                NavigationService.Navigate(new Uri("/Flashcards.xaml", UriKind.Relative));
            else if (Mode.Text.Equals("Teach"))
                NavigationService.Navigate(new Uri("/Teach.xaml", UriKind.Relative));

        }
    }
}