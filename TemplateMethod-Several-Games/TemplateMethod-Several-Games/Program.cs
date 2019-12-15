using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod_Several_Games
{
  class Program
  {
    static void Main(string[] args)
    {
      GameObject game = new Monopoly();

      game.PlayOneGame(2);
      Console.ReadKey();
    }
  }
  public abstract class GameObject
  {
    protected int PlayersCount;

    abstract protected bool EndOfGame();

    abstract protected void InitializeGame();

    abstract protected int MakePlay(int player, int score);

    abstract protected void PrintWinner(int id);

    /* Шаблонный метод */
    public void PlayOneGame(int playersCount)
    {
      Random rand = new Random();
      int[] score = new int[50];
      PlayersCount = playersCount;
      InitializeGame();
      int j = 0;
      bool status = true;
      int winner = 1;
      while (status)
      {
        score[j] = MakePlay(j, score[j]);
        Console.WriteLine("Игрок под номером {0} заработал {1} очей", j, score[j]);
        if (score[j] >= 10)
        {
          winner = j;
          status = EndOfGame();
        }
        j = (j + 1) % playersCount;
        
      }

      PrintWinner(winner);
    }
  }
  public class Monopoly : GameObject
  {

    protected override void InitializeGame()
    {
      Console.WriteLine("Инициализация игры с игроками");
    }

    protected override int MakePlay(int player, int score)
    {
      Random rand = new Random();
      Console.WriteLine("Выполнение одного хода игроком {0}", player);
      score += rand.Next(5);
      return score;
    }

    protected override bool EndOfGame()
    {
      Console.WriteLine("Окончание игры!");
      return false;
    }

    protected override void PrintWinner(int id)
    {
      Console.WriteLine("Победил в монополию игрок № {0}", id);
    }

  }
  public class Chess : GameObject
  {

    protected override void InitializeGame()
    {
      Console.WriteLine("Инициализация игры с игроками");
    }

    protected override int MakePlay(int player, int score)
    {
      Random rand = new Random();
      Console.WriteLine("Выполнение одного хода игроком {0}", player);
      score += rand.Next(2);
      return score;
    }

    protected override bool EndOfGame()
    {
      return false;
    }

    protected override void PrintWinner(int id)
    {
      Console.WriteLine("Победил в шахматы игрок № {0}", id);
    }

  }

}
