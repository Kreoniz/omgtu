using System;

// Подается текст
// Определить кол-во четных цифр в строке
// Определить является ли строка палиндромом
class Text {
    public static void Main(string[] args) {
        int count = 0;
        bool isPalindrome = true;

        string text = Console.ReadLine().Trim('\n').ToLower().Replace(" ", "");
        for (int i = 0; i < text.Length; i++) {
            if (Char.IsDigit(text[i])) {
                if (Convert.ToInt32(text[i]) % 2 == 0) count++;
            }
        }
        Console.WriteLine();

        for (int i = 0; i < text.Length; i++) {
            if (text[i] != text[text.Length - i - 1]) {
                isPalindrome = false;
                break;
            }
        }

        Console.WriteLine($"Кол-во четных цифр в строке: {count}");

        if (isPalindrome) {
            Console.WriteLine("Это палиндром");
        } else {
            Console.WriteLine("Это НЕ палиндром");
        }
    }
}
