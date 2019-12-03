using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Palindrome_Arrays
{
  class Program
  {
    static void Main()
    {
      ReverseString reverseClass = new RealReverseClass();
      ReverseString reverseProxy = new ProxyReverseClass(reverseClass);
      Console.WriteLine(reverseProxy.isReverse("томмот"));
      Console.WriteLine(reverseProxy.isReverse("абракадбра"));
      Console.WriteLine(reverseProxy.isReverse("томмот"));
      Console.WriteLine(reverseProxy.isReverse("абракадбра"));
      Console.WriteLine(reverseProxy.isReverse("томмот"));
      Console.ReadKey();
    }
  }
  interface ReverseString
  {
    bool isReverse(string normalString);
  }
  class RealReverseClass : ReverseString
  {
    public bool isReverse(string normalString)
    {
      Console.Write("Проверка слова '" + normalString + "': Результат - ");
      return (new string(normalString.ToCharArray().Reverse().ToArray()) == normalString);
    }
  }
  class ProxyReverseClass : ReverseString
  {
    private string[] ReverseString;
    private bool[] IsReverse;
    private int counter;
    private ReverseString realClass;

    public ProxyReverseClass(ReverseString realClass)
    {
      this.realClass = realClass;
      ReverseString = new string[100];
      IsReverse = new bool[100];
      counter = 0;
    }
    public bool isReverse(string normalString)
    {
      for (int i = 0; i <= counter; i++)
      {
        if (ReverseString[i] == normalString)
        {
          Console.Write("Результат слова '" + normalString + "' с прокси - ");
          return IsReverse[i];
        }
      }
      counter++;
      ReverseString[counter] = normalString;
      return (IsReverse[counter] = realClass.isReverse(normalString));
      
    }
  }
}
