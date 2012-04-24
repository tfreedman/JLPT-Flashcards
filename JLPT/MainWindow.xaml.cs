using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections;
using LumenWorks.Framework.IO.Csv;
using Kelebron.Utils.Japanese;

namespace JLPT {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        ArrayList[] array;
        String[,] dataSet;
        public MainWindow() {
            InitializeComponent();

            ReadCsv();
            dataSet = new String[array[0].Count, array.Length];

            for (int j = 0; j < array[0].Count; j++) {
                for (int i = 0; i < array.Length; i++) {
                    dataSet[j, i] = Convert.ToString(array[i][j]);
                }
            }
            array = null;
        }

        void PrintData() {
            for (int i = 0; i < dataSet.GetLength(0); i++) {
                for (int j = 0; j < dataSet.GetLength(1); j++) {
                    content.Text += dataSet[i, j];
                    content.Text += "\t";
                }
                content.Text += "\n";
            }
        }

        void ReadCsv() {
            using (CsvReader csv =
                   new CsvReader(new StreamReader("JLPT5.csv"), true)) {
                int fieldCount = csv.FieldCount;
                array = new ArrayList[fieldCount];
                for (int i = 0; i < fieldCount; i++)
                    array[i] = new ArrayList();
                string[] headers = csv.GetFieldHeaders();
                for (int i = 0; i < headers.Length; i++)
                    array[i].Add(headers[i]);
                while (csv.ReadNextRecord()) {
                    for (int i = 0; i < fieldCount; i++) {
                        array[i].Add(csv[i]);
                    }
                }
            }
        }

        private void GetWord_Click(object sender, RoutedEventArgs e) {
            Random random = new Random();
            int rand = random.Next(1, dataSet.GetLength(0));
            content.Text = "";
            for (int i = 0; i < dataSet.GetLength(1); i++) {
                content.Text += dataSet[0, i] + ": ";
                content.Text += dataSet[rand, i] + "\n";
            }
            
            content.Text += "Romaji: " + JapaneseRomajiConverter.KanaToRomaji(dataSet[rand, 1]);
            content.Text += "\n";
            content.Text += "Katakana: " + ConvertToKatakana(dataSet[rand, 1]);
            content.Text += "\n";
            content.Text += "Hiragana: " + ConvertToHiragana(dataSet[rand, 1]);
            content.Text += "\n";
            content.Text += "\n";

            //kana = converter.KatakanaToHiragana(kana);
        }

        private string ConvertToHiragana(String toHiragana) {
            JapaneseKanaConverter converter = new JapaneseKanaConverter();
            String converted = "";
            for (int i = 0; i < toHiragana.Length; i++) {
                if (JapaneseKanaClassifier.IsHiragana(toHiragana[i]))
                    converted += toHiragana[i];
                else if (JapaneseKanaClassifier.IsKatakana(Convert.ToString(toHiragana[i])))
                    converted += converter.KatakanaToHiragana(Convert.ToString(toHiragana[i]));
                else {
                    Console.WriteLine(toHiragana + " " + toHiragana[i] + " " + i);
                    if (JapaneseKanaClassifier.IsKanji(Convert.ToString(toHiragana[i])))
                        throw new FormatException("Kanji Error");
                    else
                        converted += toHiragana[i]; //Latin Characters
                }
            }
            return converted;
        }

        private string ConvertToKatakana(String toKatakana) {
            JapaneseKanaConverter converter = new JapaneseKanaConverter();
            String converted = "";
            for (int i = 0; i < toKatakana.Length; i++) {
                if (JapaneseKanaClassifier.IsKatakana(Convert.ToString(toKatakana[i])))
                    converted += toKatakana[i];
                else if (JapaneseKanaClassifier.IsHiragana(Convert.ToString(toKatakana[i])))
                    converted += converter.HiraganaToKatakana(Convert.ToString(toKatakana[i]));
                else {
                    Console.WriteLine(toKatakana + " " + toKatakana[i] + " " + i);
                    if (JapaneseKanaClassifier.IsKanji(Convert.ToString(toKatakana[i])))
                        throw new FormatException("Kanji Error");
                    else
                        converted += toKatakana[i]; //Latin Characters
                }
            }
            return converted;
        }


    }
}