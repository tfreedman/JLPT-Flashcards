JLPT Flashcards
===============

Note: this repository contains two distinct programs. While the first one allowed me to develop the second, they can be used independently.

The first program, Kana Converter, is a utility for converting kana to romaji, written in C#. This utility is intended as an extension to Paweł Szczepański's library, found here: 
http://kanjimap.wordpress.com/2010/01/31/kana-converter-in-c/

For people trying to learn hiragana or katakana, it may be desirable to read Japanese words using English characters. This utility will convert a list of Japanese words into a a roughly equivalent string of Latin characters. However, it is important to note that the conversion isn't lossless. This means that converting from Japanese to English and back will NOT produce the same input string, for a number of reasons. It is exceedingly difficult to convert Japanese to English losslessly, given the number of different variations of Japanese romanization that exist. This tool should not be used as any kind of definitive resource on Japanese text conversion. Rather, it should be used to produce text that can be easily read by someone not well versed in kana.

For a detailed breakdown of why this is so, see here: [Variations on Japanese romanization](http://nayuki.eigenstate.org/page/variations-on-japanese-romanization).

 Paweł Szczepański's library is used extensively in this program. While it is an excellent library, it does not provide support for kana to romaji, only romaji to kana. I've written a library, JapaneseRomajiConverter.cs, which performs the reverse operation of Paweł Szczepański's code. Since it relies on his code to run, and his code is LGPL3, my library is also published under LGPLv3.

The code also relies on Sébastien Lorion's CSV reader, which is bundled with the code. This library is published under the MIT license.

--------------

The second program, JLPT Flashcards, is an app for Windows Phone 7/7.5/8 designed to teach the Japanese-Language Proficiency Test's vocabulary lists, in order to study / memorize them. While the JLPT does not publish official study lists for vocabulary, the lists provided are a decent estimate of what words are expected to be known.

The program allows you to either study or get quizzed. While studying, you can pick which word list you'd like to study. However, while the JLPT exams themselves are cumulative, the word lists aren't. Selecting N1 allows you to study only the content new on N1, while selecting levels N5 - N1 would contain most words on the exam. 

Quiz mode is an endlessly long multiple choice quiz, in which you must select the correct word out of 4 that matches the one at the top of the screen. You can choose to be shown one of either [kanji/kana/english/romaji/hiragana/katakana], and select the matching [kanji/kana/english/romaji/hiragana/katakana]. Points are given for the correct answer, and deducted for an incorrect answer.

It is important to note that selecting hiragana or katakana will not only select words that are actually written in hiragana or katakana. Rather, it will convert the word into the selected kana, regardless of whether or not this actually makes sense in Japanese. For example, サンドイッチ would never be written さんどいっち, but selecting the hiragana mode would show you さんどいっち, as the purpose of the app is to test reading comprehension and your ability to remember definitions. If you want to be shown a word in its unaltered form, selecting kana will only show the actual Japanese writing used for each word. 

Also note that selecting kanji will not return every single word in the word list. This is because not all words are written with kanji, and there is no way to map a word that isn't written in kanji back to kanji, if the goal is to make any sense whatsoever.

Screenshots:

![Loading screen](/JLPT Flashcards/SplashScreenImage.jpg)
The loading screen...

![Menu](/JLPT Flashcards/screenshot1.png)
The initial menu, with teaching mode selected.

![Teaching mode](/JLPT Flashcards/screenshot2.png)
Learning the word keisatsu

![Expanded menu](/JLPT Flashcards/screenshot6.png)
The expanded quiz menu, showing available options.

![Quiz mode](/JLPT Flashcards/screenshot7.png)
An example quiz in which katakana is shown - the user is asked to select the relevant hiragana.


This app is published under the BSD license below.

Copyright (c) 2012, Tyler Freedman
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * The name of the author may not be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.  