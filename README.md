JLPT
====

A program designed to teach the JLPT's vocabulary lists, in order to study / memorize them. While the JLPT does not publish official study lists for vocabulary, the lists provided are a decent estimate of what words are expected to be known.

The program also contains a library for converting kana to romaji, written in C#. This library is intended as an extension to Paweł Szczepański's library, found here: 
http://kanjimap.wordpress.com/2010/01/31/kana-converter-in-c/

While it is an excellent library, it does not provide support for kana to romaji, only romaji to kana. I've written a library, JapaneseRomajiConverter.cs, which performs the reverse operation of Paweł Szczepański's code. Since it relies on his code to run, and his code is LGPL3, my library is also published under LGPLv3.

The code also relies on Sébastien Lorion's CSV reader, which is bundled with the code. This library is published under the MIT license.