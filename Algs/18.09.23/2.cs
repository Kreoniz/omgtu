using System;

// Переводит секунды в часы, минуты и секунды
// ! Нельзя использовать деление с остатком
class SecondsConversion {
    public static void Main(string[] args) {
        int number;
        string seconds, minutes, hours;
        
        int MINUTE = 60;
        int HOUR = 60 * MINUTE;
        
        number = Convert.ToInt32(Console.ReadLine());

        hours = (number / HOUR).ToString("D2");
        number = number - Convert.ToInt32(hours) * HOUR;
        minutes = (number / MINUTE).ToString("D2");
        number = number - Convert.ToInt32(minutes) * MINUTE;
        seconds = number.ToString("D2");

        Console.WriteLine(string.Format("{0}:{1}:{2}", hours, minutes, seconds));
    }
}
