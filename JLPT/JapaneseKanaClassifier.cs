//  Author: Paweł Szczepański (kelebron@gmail.com)
//  January 2010
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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kelebron.Utils.Japanese {
  /// <summary>
  /// The tool classifies the letters within strings to be wither romaji (latin), kanji or kana.
  /// These do not verify if the word is a valid romaji or kana composite (ie. does syllabes together
  /// make sense), but only checks the word letter by letter.
  /// For example a word 'ball' will be classified as romaji.
  /// If you require more information, then you may catch FormatExceptions by JapaneseKanaConverter.
  /// </summary>
  public class JapaneseKanaClassifier {
    /// <summary>
    /// Check whether the character is hiragana or not.
    /// </summary>
    public static bool IsHiragana(char c) {
      return ('\u3041' <= c) && (c <= '\u309e');
    }

    /// <summary>
    /// Determines if this character is a romaji character.
    /// </summary>
    public static bool IsRomaji(char c) {
      return (('\u0061' <= c) && (c <= '\u007a')) ||
             (('\u0041' <= c) && (c <= '\u005a')) ||
             "āīūēō".Contains(c);
    }

    /// <summary>
    /// Determines if this character is a half-width katakana.
    /// </summary>
    public static bool IsHalfwidthKatakana(char c) {
      return (('\uff66' <= c) && (c <= '\uff9d'));
    }

    /// <summary>
    /// Determines if this character is a full-width katakana.
    /// </summary>
    public static bool IsFullwidthKatakana(char c) {
      return (('\u30a1' <= c) && (c <= '\u30fe'));
    }

    /// <summary>
    /// Determines if a given character is a kanji character.
    /// </summary>
    public static bool IsKanji(char c) {
      return (('\u4e00' <= c) && (c <= '\u9fa5')) ||
             (('\u3005' <= c) && (c <= '\u3007'));
    }

    /// <summary>
    /// Determine if the character is one of the japanese characters.
    /// </summary>
    public static bool IsJapaneseScript(char c) {
      return IsKanji(c) || !IsHiragana(c) || !IsFullwidthKatakana(c);
    }

    /// <summary>
    /// Check whether the string is hiragana or not.
    /// </summary>
    public static bool IsHiragana(string str) {
      for (int i = 0; i < str.Length; i++) {
        if (!IsHiragana(str[i])) {
          return false;
        }
      }
      return true;
    }

    /// <summary>
    /// Determine if all of the characters are one of the japanese characters.
    /// </summary>
    public static bool IsJapaneseScript(string str) {
      for (int i = 0; i < str.Length; i++) {
        if (!IsJapaneseScript(str[i])) {
          return false;
        }
      }
      return true;
    }

    /// <summary>
    /// Determines if all characters are either fill-width or half-width katakana.
    /// </summary>
    public static bool IsKatakana(string str) {
      return (IsHalfwidthKatakana(str) || IsFullwidthKatakana(str));
    }

    /// <summary>
    /// Determines if all characters are half-width katakana.
    /// </summary>
    public static bool IsHalfwidthKatakana(string str) {
      for (int i = 0; i < str.Length; i++) {
        if (!IsHalfwidthKatakana(str[i])) {
          return false;
        }
      }
      return true;
    }

    /// <summary>
    /// Determines if all characters are full-width katakana.
    /// </summary>
    public static bool IsFullwidthKatakana(string str) {
      for (int i = 0; i < str.Length; i++) {
        if (!IsFullwidthKatakana(str[i])) {
          return false;
        }
      }
      return true;
    }

    /// <summary>
    /// Determines if all characters are kanji characters.
    /// </summary>
    public static bool IsKanji(string str) {
      for (int i = 0; i < str.Length; i++) {
        if (!IsKanji(str[i])) {
          return false;
        }
      }
      return true;
    }

    /// <summary>
    /// Determines if each character is either hiragana or kanji character.
    /// </summary>
    public static bool IsKanjiAndHiragana(string str) {
      for (int i = 0; i < str.Length; i++) {
        if (!IsKanji(str[i]) &&
            !IsHiragana(str[i])) {
          return false;
        }
      }
      return true;
    }

    /// <summary>
    /// Determines if any character is a kanji character.
    /// </summary>
    public static bool ContainsKanji(string str) {
      for (int i = 0; i < str.Length; i++) {
        if (IsKanji(str[i])) {
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Determines if all characters are romaji characters.
    /// </summary>
    public static bool IsRomaji(string str) {
      for (int i = 0; i < str.Length; i++) {
        if (!IsRomaji(str[i]) && str[i] != ' ') {
          return false;
        }
      }
      return true;
    }
  }
}
