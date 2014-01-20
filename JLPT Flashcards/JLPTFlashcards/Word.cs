namespace JLPTFlashcards {
    public class Word {
        string Word_Kanji = "";
        string Word_Kana = "";
        string Word_English = "";
        string Word_Romaji = "";
        string Word_Katakana = "";
        string Word_Hiragana = "";

        public string Kanji {
            get { return Word_Kanji; }
            set { Word_Kanji = value; }
        }
        public string Kana {
            get { return Word_Kana; }
            set { Word_Kana = value; }
        }
        public string English {
            get { return Word_English; }
            set { Word_English = value; }
        }
        public string Romaji {
            get { return Word_Romaji; }
            set { Word_Romaji = value; }
        }
        public string Katakana {
            get { return Word_Katakana; }
            set { Word_Katakana = value; }
        }
        public string Hiragana {
            get { return Word_Hiragana; }
            set { Word_Hiragana = value; }
        }
    }
}