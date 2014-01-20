using System;
using System.Linq;
using Microsoft.Phone.Controls;
using System.Windows.Controls;

namespace JLPTFlashcards {
    public partial class Flashcards : PhoneApplicationPage {
        public Flashcards() {
            InitializeComponent();
            options[0] = option1;
            options[1] = option2;
            options[2] = option3;
            options[3] = option4;
        }

        Button[] options = new Button[4];

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            GenerateWords();
        }

        Word CurrentWord = new Word();
        int SeededWord = 0;
        void GenerateWords() {
            Random rand = new Random();
            SeededWord = rand.Next(0, MainPage.Words.Count());
            CurrentWord = MainPage.Words.ElementAt(SeededWord);
            if (MainPage.Show.Text.Equals("English"))
                MainWord.Text = CurrentWord.English.ToLower();
            else if (MainPage.Show.Text.Equals("Kanji")) {
                while (CurrentWord.Kanji.Equals("")) {
                    MainPage.Words.Remove(CurrentWord);
                    SeededWord = rand.Next(0, MainPage.Words.Count());
                    CurrentWord = MainPage.Words.ElementAt(SeededWord);
                }
                MainWord.Text = CurrentWord.Kanji;
            } else if (MainPage.Show.Text.Equals("Kana"))
                MainWord.Text = CurrentWord.Kana;
            else if (MainPage.Show.Text.Equals("Katakana"))
                MainWord.Text = CurrentWord.Katakana;
            else if (MainPage.Show.Text.Equals("Hiragana"))
                MainWord.Text = CurrentWord.Hiragana;
            else if (MainPage.Show.Text.Equals("Romaji"))
                MainWord.Text = CurrentWord.Romaji.ToLower();
            MainWord.FontSize = (MainWord.FontSize * 438) / MainWord.ActualWidth;
            if (MainWord.FontSize > 72)
                MainWord.FontSize = 72;

            if (MainPage.Ask.Text.Equals("English")) {
                for (int i = 0; i < 4; i++)
                    options[i].Content = MainPage.Words.ElementAt(rand.Next(0, MainPage.Words.Count())).English.ToLower();
            } else if (MainPage.Ask.Text.Equals("Kanji")) {
                int[] selectors = new int[4];
                for (int i = 0; i < 4; i++)
                    selectors[i] = rand.Next(0, MainPage.Words.Count);

                for (int i = 0; i < 4; i++)
                    while (MainPage.Words.ElementAt(selectors[i]).Kanji.Equals(""))
                        selectors[i] = rand.Next(0, MainPage.Words.Count);
                for (int i = 0; i < 4; i++)
                    options[i].Content = MainPage.Words.ElementAt(selectors[i]).Kanji;

            } else if (MainPage.Ask.Text.Equals("Kana")) {
                for (int i = 0; i < 4; i++)
                    options[i].Content = MainPage.Words.ElementAt(rand.Next(0, MainPage.Words.Count())).Kana;
            } else if (MainPage.Ask.Text.Equals("Katakana")) {
                for (int i = 0; i < 4; i++)
                    options[i].Content = MainPage.Words.ElementAt(rand.Next(0, MainPage.Words.Count())).Katakana;
            } else if (MainPage.Ask.Text.Equals("Hiragana")) {
                for (int i = 0; i < 4; i++)
                    options[i].Content = MainPage.Words.ElementAt(rand.Next(0, MainPage.Words.Count())).Hiragana;
            } else if (MainPage.Ask.Text.Equals("Romaji")) {
                for (int i = 0; i < 4; i++)
                    options[i].Content = MainPage.Words.ElementAt(rand.Next(0, MainPage.Words.Count())).Romaji.ToLower();
            }
            int next = rand.Next(0, 4);
            if (MainPage.Ask.Text.Equals("Kanji"))
                options[next].Content = MainPage.Words.ElementAt(SeededWord).Kanji;
            else if (MainPage.Ask.Text.Equals("English"))
                options[next].Content = MainPage.Words.ElementAt(SeededWord).English.ToLower();
            else if (MainPage.Ask.Text.Equals("Kana"))
                options[next].Content = MainPage.Words.ElementAt(SeededWord).Kana;
            else if (MainPage.Ask.Text.Equals("Hiragana"))
                options[next].Content = MainPage.Words.ElementAt(SeededWord).Hiragana;
            else if (MainPage.Ask.Text.Equals("Katakana"))
                options[next].Content = MainPage.Words.ElementAt(SeededWord).Katakana;
            else if (MainPage.Ask.Text.Equals("Romaji"))
                options[next].Content = MainPage.Words.ElementAt(SeededWord).Romaji.ToLower();
        }
        int Score = 0;
        private void Choice_Click(object sender, System.Windows.RoutedEventArgs e) {
            Button selected = new Button();
            selected = (Button)sender;
            string ComparisonData = "";

            if (MainPage.Ask.Text.Equals("Kanji"))
                ComparisonData = CurrentWord.Kanji;
            else if (MainPage.Ask.Text.Equals("English"))
                ComparisonData = CurrentWord.English.ToLower();
            else if (MainPage.Ask.Text.Equals("Kana"))
                ComparisonData = CurrentWord.Kana;
            else if (MainPage.Ask.Text.Equals("Hiragana"))
                ComparisonData = CurrentWord.Hiragana;
            else if (MainPage.Ask.Text.Equals("Katakana"))
                ComparisonData = CurrentWord.Katakana;
            else if (MainPage.Ask.Text.Equals("Romaji"))
                ComparisonData = CurrentWord.Romaji.ToLower();

            if (selected.Content.Equals(ComparisonData)) {
                MainPage.Words.RemoveAt(SeededWord);
                Score++;
                ScoreDisplay.Text = "Your Score: " + Score;
                GenerateWords();
                EnableAll();
            } else {
                selected.IsEnabled = false;
                Score--;
                ScoreDisplay.Text = "Your Score: " + Score;
            }
        }

        private void EnableAll() {
            for (int i = 0; i < 4; i++)
                options[i].IsEnabled = true;
        }
    }
}