using System;

// На вход подается строка, определить наибольшую длину подстроки-палиндрома
class substringPalindrome {
    public static bool isPalindrome(string text) {
        for (int i = 0; i < text.Length; i++) {
            if (text[i] != text[text.Length - i - 1]) {
                return false;
            }
        }

        return true;
    }

    public static void Main(string[] args) {
        string text = Console.ReadLine();
        int max_length = 0;

        for (int i = 0; i < text.Length; i++) {
            for (int j = i + 1; j < text.Length; j++) {
                if (isPalindrome(text.Substring(i, j - i - 1))) {
                    if (max_length < j - i) {
                        max_length = j - i;
                    }
                }
            }
        }

        Console.WriteLine($"Длина наибольшей подстроки-палиндрома: {max_length}");
    }
}
