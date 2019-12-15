using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemDemo
{
  class Program
  {
    static void Main()
    {
      Operand op1 = new Operand(3);
      Operand op2 = new Operand(4);
      Operand op3 = new Operand(5);
      Console.WriteLine("Operand-1 - {0}, Operand-2 - {1}, Operand-3 - {2}", op1.Result(), op2.Result(), op3.Result());
      Operation oper1 = new Operation('+');
      Operation oper2 = new Operation('*');
      
      oper1.Add(op1);
      oper1.Add(op2);
      oper1.Add(op3);
      oper2.Add(op1);
      oper2.Add(op2);
      oper1.Add(oper2);
      Console.WriteLine("Result Operation 1 = {0}", oper1.Result());
      Console.WriteLine("Result Operation 2 = {0}", oper2.Result());
      oper1.Remove(op1);
      Console.WriteLine("Operand 1 was deleted!");
      Console.WriteLine("Result Operation 1 = {0}", oper1.Result());
      Console.ReadKey();
    }
  }
  abstract class Arithmetic
  {
    public abstract int Result();
  }
  class Operand:Arithmetic
  {
    int result;
    public Operand(int s) { result = s; }
    public override int Result() {
        return result;
    }

  }
  class Operation:Arithmetic
  {
    private List<Arithmetic> elements;
    private char operation;
    public Operation(char operation)
    {
        elements = new List<Arithmetic>();
        this.operation = operation;
    }
    public void Add(Arithmetic fse)
    {
        elements.Add(fse);
    }
    public void Remove(Arithmetic fse)
    {
      elements.Remove(fse);
    }
    public override int Result()
    {
      int s = 1;
      if (operation == '+' || operation == '-')
        s = 0;
      switch (operation)
      {
        case '+':
          foreach (Arithmetic fse in elements)
            s += fse.Result();
          break;
        case '-':
          foreach (Arithmetic fse in elements)
            s -= fse.Result();
          break;
        case '*':
          foreach (Arithmetic fse in elements)
            s *= fse.Result();
          break;
        case '/':
          foreach (Arithmetic fse in elements)
            s /= fse.Result();
          break;
          
      }
      return s;
    }
  }
}
