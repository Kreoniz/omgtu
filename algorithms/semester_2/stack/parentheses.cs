using System;
using System.Collections;
using System.Collections.Generic;

class Parentheses {
  public static void Main(string[] args) {
    Console.WriteLine("Введите строку со скобками:");
    string str = Console.ReadLine();
    char[] parens = new char[] {'(', ')', '[', ']', '{', '}'};

    Stack<char> stack = new Stack<char>();

    foreach (char c in str) {
      int index = Array.IndexOf(parens, c);
      if (c == '(' || c == '[' || c == '{') {
        stack.Push(c);
      } else if (index != -1) {
        if (stack.Count > 0 && stack.Peek() == parens[index - 1]) {
          stack.Pop();
        } else {
          stack.Push(c);
        }
      }
    }

    Console.WriteLine();

    if (stack.Count > 0) {
      Console.WriteLine("Скобки расставленны НЕВЕРНО!");
    } else {
      Console.WriteLine("Все верно!");
    }
  }
}
