//  Author: Tyler Freedman
//  April 24th, 2012
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using Kelebron.Utils.Japanese;
using System.Collections.Generic;

namespace JLPT {

    public class JapaneseRomajiConverter {

        static string[] romajiHiraganaPairs = new string[]{ 
          "あ", "a", "い", "i",  "う", "u",  "え", "e",  "お", "o",  "か", "ka", "き", "ki",  "く", "ku", "け", "ke", "こ", "ko", "さ", "sa",
          "し", "shi", "す", "su", "せ", "se", "そ", "so", "た", "ta", "ち", "chi",  "つ", "tsu", "て", "te", "と", "to", "な", "na",
          "に", "ni",  "ぬ", "nu", "ね", "ne", "の", "no", "は", "ha", "ひ", "hi", "ふ", "fu",  "へ", "he", "ほ", "ho", "ま", "ma", 
          "み", "mi",  "む", "mu", "め", "me", "も", "mo", "や", "ya", "ゆ", "yu", "よ", "yo",  "ら", "ra", "り", "ri", "る", "ru",
          "れ", "re",  "ろ", "ro", "わ", "wa", "ゐ", "i/wi", "ゑ", "e/we", "を", "o/wo", "ん", "n",
          "が", "ga",  "ぎ", "gi", "ぐ", "gu", "げ", "ge", "ご", "go", "ざ", "za", "じ", "ji", "ず", "zu", "ぜ", "ze", "ぞ", "zo",
          "だ", "da",  "ぢ", "ji", "づ", "zu", "で", "de", "ど", "do", "ば", "ba", "び", "bi", "ぶ", "bu", "べ", "be", "ぼ", "bo",
          "ぱ", "pa",  "ぴ", "pi", "ぷ", "pu", "ぺ", "pe", "ぽ", "po", "ゔ", "vu"
         };

        static string[] romajiHiraganaDigraphs = new string[] {
          "きゃ", "kya", "きゅ", "kyu", "きょ", "kyo", "しゃ", "sha", "しゅ", "shu", "しょ", "sho", "ちゃ", "cha", "ちゅ", "chu", "ちょ", "cho",
          "にゃ", "nya", "にゅ", "nyu", "にょ", "nyo", "ひゃ", "hya", "ひゅ", "hyu", "ひょ", "hyo", "みゃ", "mya", "みゅ", "myu", "みょ", "myo",
          "りゃ", "rya", "りゅ", "ryu", "りょ", "ryo", "ぎゃ", "gya", "ぎゅ", "gyu", "ぎょ", "gyo", "じゃ", "ja",  "じゅ", "ju",  "じょ", "jo",
          "ぢゃ", "ja",  "ぢゅ", "ju",  "ぢょ", "jo",  "びゃ", "bya", "びゅ", "byu", "びょ", "byo", "ぴゃ", "pya", "ぴゅ", "pyu", "ぴょ", "pyo"
        };

        static string[] romajiKatakanaPairs = new string[] { 
         "ア","a",  "イ","i", "ウ","u", "エ","e", "オ","o",  "カ","ka", "キ","ki", "ク","ku", "ケ","ke", "コ","ko",  "サ","sa", "シ","shi",
         "ス","su",  "セ","se", "ソ","so", "タ","ta", "チ","chi", "ツ","tsu", "テ","te", "ト","to", "ナ","na", "ニ","ni", "ヌ","nu", "ネ","ne", 
         "ノ","no", "ハ","ha", "ヒ","hi", "フ","fu", "ヘ","he", "ホ","ho", "マ","ma", "ミ","mi", "ム","mu", "メ","me", "モ","mo", "ヤ","ya",
         "ユ","yu", "ヨ","yo", "ラ","ra", "リ","ri", "ル","ru", "レ","re", "ロ","ro", "ワ","wa", "ヲ","wo", "ン","n", "ガ","ga",  "ギ","gi",
         "グ","gu",  "ゲ","ge",  "ゴ","go", "ザ","za",  "ジ","ji",  "ズ","zu",  "ゼ","ze",  "ゾ","zo",  "ダ","da", "デ","de",  "ド","do", 
         "バ","ba",  "ビ","bi",  "ブ","bu",  "ベ","be",  "ボ","bo",  "パ","pa",  "ピ","pi",  "プ","pu", "ペ","pe",  "ポ","po", "ヴ","vu"
        };

        static string[] romajiKatakanaDigraphs = new string[] {
          "ギャ","gya", "ギュ","gyu", "ギョ","gyo",  "ミャ","mya",  "ミュ","myu",  "ミョ","myo",  "リャ","rya", "リュ","ryu",
          "リョ","ryo",  "ピャ","pya",  "ピュ","pyu",  "ピョ","pyo",  "イィ","yi",  "イェ","ye",  "ウェ", "we",  "チャ","cha",
          "チュ","chu",  "チョ","cho",  "ニャ","nya",  "ニュ","nyu",  "ニョ","nyo",  "ヒャ","hya",  "ヒュ","hyu",  "ヒョ","hyo",
          "ビャ","bya",  "ビュ","byu",  "ビョ","byo",  "ジャ","jya",  "ジュ","jyu",  "ジョ","jyo",  "キャ","kya",  "キュ","kyu", 
          "キョ", "kyo",  "ウャ","wya",  "ウュ","wyu",  "ウョ","wyo",  "クァ","kwa",  "クィ","kwi",  "クゥ","kwu",  "クェ","kwe",  
          "クォ","kwo",  "グァ","gwa",  "グィ","gwi",  "グゥ","gwu", "グェ","gwe",   "グォ","gwo",  "ムァ", "mwa", "ムィ","mwi", 
          "ムゥ","mwu",   "ムェ","mwe", "ムォ","mwo",  "フャ","fya", "フュ","fyu",   "フョ","fyo", "リィ","ryi", "リェ","rye", 
          "シャ","sha",   "シュ","shu", "ショ","sho", "ヴァ","va", "ヴィ","vi",   "ヴェ","ve", "ヴォ","vo", "ヴャ","vya", 
          "ヴュ","vyu",   "ヴョ","vyo", "シェ","she", "ジェ","je", "チェ","che",   "スァ","swa", "スィ","si", "スゥ","swu", 
          "スェ","swe",   "スォ","swo", "スャ","sya", "スュ","syu", "スョ","syo",   "ズァ","zwa", "ズィ","zi", "ズゥ","zwu", 
          "ズェ","zwe",   "ズォ","zwo", "ズャ","zya", "ズュ","zyu", "ズョ","zyo",   "ツァ","tsa", "ツィ","tsi", "ツェ","tse",  
          "ツォ","tso",   "テァ","tha", "ティ","ti", "テゥ","thu", "テェ","tye",   "テォ","tho", "テャ","tya", "テュ","tyu",
          "テョ","tyo",   "デァ","dha", "ディ","di", "デゥ","dhu", "デェ","dye",  "デォ","dho", "デャ","dya", "デュ","dyu", 
          "デョ","dyo",  "トァ","twa",  "トィ","twi",  "トゥ","tu",  "トェ","twe",  "トォ","two",  "ドァ","dwa",  "ドィ","dwi",  
          "ドゥ","du",   "ドェ","dwe",  "ドォ","dwo",  "ファ","fa",  "フィ","fi",   "ホゥ","hu",  "フェ","fe",  "フォ","fo",  
          "ウィ","wi",  "ウゥ","wu"  
 };


        public static string KanaToRomaji(String kana) {
            if (JapaneseKanaClassifier.ContainsKanji(kana))
                throw new FormatException("String contains kanji");
            JapaneseKanaConverter converter = new JapaneseKanaConverter();
            if (JapaneseKanaClassifier.IsHiragana(kana)) {
                kana = converter.HiraganaToKatakana(kana);
            }
            String converted = "";
            for (int i = 0; i < kana.Length; i++) {
                if (JapaneseKanaClassifier.IsHiragana(kana[i])) {
                    converted += converter.HiraganaToKatakana(Convert.ToString(kana[i]));
                }
                else { converted += kana[i]; }

            }
            kana = converted;

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            Dictionary<string, string> digraph = new Dictionary<string, string>();

            for (int i = 0; i < romajiKatakanaPairs.Length; i += 2)
                dictionary.Add(romajiKatakanaPairs[i], romajiKatakanaPairs[i + 1]);

            for (int i = 0; i < romajiKatakanaDigraphs.Length; i += 2)
                digraph.Add(romajiKatakanaDigraphs[i], romajiKatakanaDigraphs[i + 1]);


            String temp = "";
            String modified = "";
            for (int i = 0; i < kana.Length; i++) {
                temp = "";
                if (((i + 1) < kana.Length) && dictionary.ContainsKey(Convert.ToString(kana[i]))) {
                    temp = kana[i] + "" + kana[i + 1];
                    if (digraph.ContainsKey(temp)) {
                        modified += digraph[temp];
                        i++;
                    }
                    else if (dictionary.ContainsKey(Convert.ToString(kana[i]))) {
                        modified += dictionary[Convert.ToString(kana[i])];
                    }
                }
                else if (dictionary.ContainsKey(Convert.ToString(kana[i]))) {
                    modified += dictionary[Convert.ToString(kana[i])];
                }
                else if (kana[i] == 'っ' || kana[i] == 'ッ') {
                    string buffer = "";
                    if (((i + 1) < kana.Length) && dictionary.ContainsKey(Convert.ToString(kana[i + 1])) && JapaneseKanaClassifier.IsJapaneseScript(Convert.ToString(kana[i + 1]))) {
                        buffer += dictionary[Convert.ToString(kana[i + 1])];
                        modified += buffer[0];
                    }
                    else if ((i + 1) == kana.Length || (((i + 1) < kana.Length) && dictionary.ContainsKey(Convert.ToString(kana[i + 1])) && !JapaneseKanaClassifier.IsJapaneseScript(Convert.ToString(kana[i + 1]))))
                        modified += "-";
                }
                else if (kana[i] == 'ー') {
                    modified += modified[i];
                }
                else {
                    modified += kana[i];
                }
            }
            return modified;
        }

    }
}