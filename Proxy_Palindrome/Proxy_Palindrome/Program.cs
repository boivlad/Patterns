using System;
using System.Collections.Generic;
using System.Linq;

namespace Proxy_Palindrome
{
  class Program
  {
    static void Main()
    {
      PalindromeClassLib PalindromeClass = new RealPalindromeClass();
      PalindromeClassLib PalindromeProxy = new CachedPalindromeClass(PalindromeClass);
      Console.WriteLine("Ответ: " + PalindromeProxy.IsPalindrom("ШалАш"));
      Console.WriteLine("Ответ: " + PalindromeProxy.IsPalindrom("шалАш"));
      Console.WriteLine("Ответ: " + PalindromeProxy.IsPalindrom("Арбуз"));
      Console.WriteLine("Ответ: " + PalindromeProxy.IsPalindrom("шалАш"));
      Console.WriteLine("Ответ: " + PalindromeProxy.IsPalindrom("Арбуз"));
      Console.ReadKey();
    }
  }
  interface PalindromeClassLib
  {
    bool IsPalindrom(string word);
  }
  struct WordReverse
  {
    private readonly string word;
    private readonly bool palindrom;
    public WordReverse(string word, bool palindrom)
    {
      this.word = word;
      this.palindrom = palindrom;
    }
    public string GetWord()
    {
      return this.word;
    }
    public bool IsPalindrom()
    {
      return palindrom;
    }
  }
  class RealPalindromeClass : PalindromeClassLib
  {
    public bool IsPalindrom(string word)
    {
      Console.WriteLine("Выполняется проверка слова '{0}'", word);
      return (new string(word.ToCharArray().Reverse().ToArray()) == word);
    }
  }
  class CachedPalindromeClass : PalindromeClassLib
  {
    private readonly List<WordReverse> Palindrome;
    private readonly PalindromeClassLib realClass;

    public CachedPalindromeClass(PalindromeClassLib realClass)
    {
      this.realClass = realClass;
      Palindrome = new List<WordReverse>();
    }
    public bool IsPalindrom(string word)
    {
      word = word.ToLower();
      foreach (WordReverse wordReverse in Palindrome)
      {
        if (wordReverse.GetWord() == word)
        {
          Console.WriteLine("Совпадение cлова '{0}' найдено в Кэше ", word);
          return wordReverse.IsPalindrom();
        }
      }
      bool ispalindrom = realClass.IsPalindrom(word);
      Palindrome.Add(new WordReverse(word, ispalindrom));
      return ispalindrom;

    }
  }
}