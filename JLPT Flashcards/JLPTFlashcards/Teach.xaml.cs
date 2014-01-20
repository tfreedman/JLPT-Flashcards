using System;
using System.Linq;
using Microsoft.Phone.Controls;

namespace JLPTFlashcards {
    public partial class Teach : PhoneApplicationPage {
        public Teach() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            GenerateWords();
        }

        Word CurrentWord = new Word();
        void GenerateWords() {
            CurrentWord = MainPage.Words.ElementAt(position);
            if (position == 0)
                PreviousButton.IsEnabled = false;
            else if (position == MainPage.Words.Count() - 1)
                NextButton.IsEnabled = false;

            MainWord.Text = CurrentWord.Kanji;
            T_Kana.Text = CurrentWord.Kana;
            T_Romaji.Text = CurrentWord.Romaji.ToLower();
            T_Meaning.Text = CurrentWord.English.ToLower();

            MainWord.FontSize = (MainWord.FontSize * 438) / MainWord.ActualWidth;
            if (MainWord.FontSize > 72)
                MainWord.FontSize = 72;
        }

        int position = 0;
        private void RandomButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            Random rand = new Random();
            position = rand.Next(0, MainPage.Words.Count());
            GenerateWords();
            if (position < MainPage.Words.Count() - 1)
                NextButton.IsEnabled = true;
            else
                NextButton.IsEnabled = false;
            if (position > 0)
                PreviousButton.IsEnabled = true;
            else
                PreviousButton.IsEnabled = false;
        }

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (position < MainPage.Words.Count() - 1) {
                position++;
                GenerateWords();
                PreviousButton.IsEnabled = true;
            } else
                NextButton.IsEnabled = false;
        }

        private void PreviousButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            if (position > 0) {
                position--;
                GenerateWords();
                NextButton.IsEnabled = true;
            } else
                PreviousButton.IsEnabled = false;
        }
    }
}