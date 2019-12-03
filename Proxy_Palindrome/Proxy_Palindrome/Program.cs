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

      Console.Write("Введите кол-во вводимый строк: ");
      int n = Convert.ToInt32(Console.ReadLine());
      if(n > 0)
      {
        for (int i = 0; i < n; i++)
        {
          Console.Write("Введите проверяемую строку: ");
          Console.WriteLine("Ответ: " + PalindromeProxy.IsPalindrom(Console.ReadLine()));
        }
      }
      else
      {
        TestData(PalindromeProxy);
      }   
      Console.ReadKey();
    }

    private static void TestData(PalindromeClassLib PalindromeProxy)
    {
      string[] testString = new string[] {
        "шалаш",
        "шАлаш",
        "Арбуз",
        "Он в аду давно",
        "Коту скоро сорок суток",
        "Он в аду давно",
        "Коту скоро сорок суток",
        "шалАш",
        "Арбуз",
        "А роза упала на лапу Азора",
      };
      for (int i = 0; i < testString.Length; i++)
      {
        Console.WriteLine("Ответ: " + PalindromeProxy.IsPalindrom(testString[i]));
      }
    }
  }
#pragma warning disable IDE1006 // Стили именования
  interface PalindromeClassLib
#pragma warning restore IDE1006 // Стили именования
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
      word = word.ToLower().Replace(" ", "");
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