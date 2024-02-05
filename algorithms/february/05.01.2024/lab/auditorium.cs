using System;
using System.Collections.Generic;

// Программа для формирования аудиторной базы университета
// И вывода информации об аудиториях

class Auditorium {
  public int SeatCount;
  public bool Projector;
  public bool Computers;
  public int Floor;
  public int Room;

  public Auditorium(int seatCount, bool projector, bool computers, int floor, int room) {
    this.SeatCount = seatCount;
    this.Projector = projector;
    this.Computers = computers;
    this.Floor = floor;
    this.Room = room;
  }

  public void PrintInfo() {
    Console.WriteLine($"Количество мест:\t{this.SeatCount}");
    Console.WriteLine($"Наличие прожекторов:\t{this.Projector ? "Да" : "Нет"}");
    Console.WriteLine($"Наличие компьютеров:\t{this.Computers ? "Да" : "Нет"}");
    Console.WriteLine($"Этаж:\t{this.Floor}");
    Console.WriteLine($"Номер аудитории:\t{this.Room}");
  }
}

class Menu {
  public static void AddAuditorium(List<Auditorium> auditoria) {
    int pointer = 0;
    bool broken = false;

    object[] info = new object[5];

    string[] prompts = {
      "Введите количество мест:",
      "Есть ли прожектор? (да/нет):",
      "Есть ли компьютеры? (да/нет):",
      "Введите номер этажа:",
      "Введите номер аудитории:"
    };

    string[] errors = {
      "Количество мест должно быть числом",
      "Наличие прожектора введено неправильно",
      "Наличие компьютеров введено неправильно",
      "Номер этажа должен быть числом",
      "Номер аудитории должен быть числом"
    };

    while (pointer < prompts.Length) {
      try {
        Console.WriteLine(prompts[pointer]);
        string data = Console.ReadLine();

        if (data == "!") {
          broken = true;
          break;
        }

        if (pointer == 1 || pointer == 2) {
          if (data != "да" && data != "нет") {
            throw new Exception();
          }
        } else {
          if (Convert.ToInt32(data) <= 0) {
            throw new Exception();
          }
        }

        info[pointer] = data;
        pointer++;
      } catch (Exception) {
        Console.WriteLine(errors[pointer]);
      }
    }

    if (broken) {
      Console.WriteLine("Команда завершена");
    } else {
      Auditorium auditorium = new Auditorium(
          Convert.ToInt32(info[0]),
          (Convert.ToString(info[1]) == "да") ? true : false,
          (Convert.ToString(info[2]) == "да") ? true : false,
          Convert.ToInt32(info[3]),
          Convert.ToInt32(info[4])
          );

      Console.WriteLine();
      Console.WriteLine("Добавленная аудитория:");
      auditorium.PrintInfo();

      auditoria.Add(auditorium);
    }
  }

  public static void EditAuditorium(List<Auditorium> auditoria, int floor, int room) {
    Auditorium auditorium = new Auditorium(0, false, false, 0, 0);

    for (int i = 0; i < auditoria.Count; i++) {
      if (auditoria[i].Floor == floor && auditoria[i].Room == room) {
        auditorium = auditoria[i];
        break;
      }
    }

    Console.WriteLine();
    if (auditorium.Floor != 0) {
      Console.WriteLine("Найденная аудитория:");
      auditorium.PrintInfo();

      object[] info = new object[3];

      string[] prompts = {
        "Введите новое количество мест:",
        "Есть ли прожектор? (да/нет):",
        "Есть ли компьютеры? (да/нет):",
      };

      string[] errors = {
        "Количество мест должно быть числом",
        "Наличие прожектора введено неправильно",
        "Наличие компьютеров введено неправильно",
      };

      Console.WriteLine();

      int pointer = 0;
      bool broken = false;
      while (pointer < prompts.Length) {
        try {
          Console.WriteLine(prompts[pointer]);
          string data = Console.ReadLine();

          if (data == "!") {
            broken = true;
            break;
          }

          if (pointer == 1 || pointer == 2) {
            if (data != "да" && data != "нет") {
              throw new Exception();
            }
          } else {
            if (Convert.ToInt32(data) <= 0) {
              throw new Exception();
            }
          }

          info[pointer] = data;
          pointer++;
        } catch (Exception) {
          Console.WriteLine(errors[pointer]);
        }
      }

      if (broken) {
        Console.WriteLine("Команда завершена");
      } else {
        auditorium.SeatCount = Convert.ToInt32(info[0]);
        auditorium.Projector = (Convert.ToString(info[1]) == "да") ? true : false;
        auditorium.Computers = (Convert.ToString(info[2]) == "да") ? true : false;

        Console.WriteLine();
        Console.WriteLine("Измененная аудитория:");
        auditorium.PrintInfo();
      }
    } else {
      Console.WriteLine("Аудитория не найдена");
    }
  }
}

class Program {
  public static List<Auditorium> SelectBySeats(List<Auditorium> auditoria, int seatCount) {
    List<Auditorium> Selected = new List<Auditorium>();

    for (int i = 0; i < auditoria.Count; i++) {
      if (auditoria[i].SeatCount >= seatCount) {
        Selected.Add(auditoria[i]);
      }
    }

    return Selected;
  }

  public static List<Auditorium> SelectyBySeatsWithProjector(List<Auditorium> auditoria, int seatCount) {
    List<Auditorium> Selected = new List<Auditorium>();

    for (int i = 0; i < auditoria.Count; i++) {
      if (auditoria[i].Projector && auditoria[i].SeatCount >= seatCount) {
        Selected.Add(auditoria[i]);
      }
    }

    return Selected;
  }

  public static List<Auditorium> SelectyBySeatsWithComputers(List<Auditorium> auditoria, int seatCount) {
    List<Auditorium> Selected = new List<Auditorium>();

    for (int i = 0; i < auditoria.Count; i++) {
      if (auditoria[i].Computers && auditoria[i].SeatCount >= seatCount) {
        Selected.Add(auditoria[i]);
      }
    }

    return Selected;
  }

  public static List<Auditorium> SelectByFloor(List<Auditorium> auditoria, int floor) {
    List<Auditorium> Selected = new List<Auditorium>();

    for (int i = 0; i < auditoria.Count; i++) {
      if (auditoria[i].Floor == floor) {
        Selected.Add(auditoria[i]);
      }
    }

    return Selected;
  }

  public static void PrintAuditoria(List<Auditorium> auditoria) {
    for (int i = 0; i < auditoria.Count; i++) {
      Console.WriteLine();
      Console.WriteLine($"Аудитория #{i + 1}:");
      auditoria[i].PrintInfo();
    }
  }

  public static void DisplayHelp() {
    Console.WriteLine("Помощь:");
    Console.WriteLine("'?' - для вывода помощи");
    Console.WriteLine("'!' - для выхода из программы / завершения текущей команды");
    Console.WriteLine("'все' - для отображения всех аудиторий");
    Console.WriteLine("'места' - для поиска аудиторий с достаточным кол-вом мест");
    Console.WriteLine("'проектор' - для поиска аудиторий с проектором и достаточным кол-вом мест");
    Console.WriteLine("'компьютер' - для поиска аудиторий с компьютерами и достаточным кол-вом мест");
    Console.WriteLine("'этаж' - для поиска аудиторий на заданном этаже");
    Console.WriteLine("'добавить' - для добавления аудитории");
    Console.WriteLine("'изменить' - для изменения данных аудитории");
  }

  public static void Main(string[] args) {
    List<Auditorium> AuditoriumDatabase = new List<Auditorium>() {
      new Auditorium(100, true, true, 8, 832),
      new Auditorium(50, false, true, 4, 417),
      new Auditorium(20, false, false, 2, 226),
    };

    bool running = true;
    while (running) {
      Console.WriteLine();
      Console.WriteLine("Напишите команду ('?' - для помощи):");
      string command = Console.ReadLine();
      Console.Clear();

      bool passed = false;
      List<Auditorium> auditoria;
      int seats = -1;
      int floor = -1;
      bool broken = false;
      switch(command) {
        case "?":
          DisplayHelp();
          break;
        case "!":
          running = false;
          break;
        case "все":
          Console.WriteLine("Все аудитории:");
          PrintAuditoria(AuditoriumDatabase);
          break;
        case "места":
          Console.WriteLine("Аудитории с достаточным кол-вом мест:");
          while (!passed) {
            try {
              string data = Console.ReadLine();

              if (data == "!") {
                broken = true;
                break;
              }

              seats = Convert.ToInt32(data);
              if (seats <= 0) {
                Console.WriteLine("Количество мест должно быть больше нуля");
              } else {
                passed = true;
              }
            } catch (Exception) {
              Console.WriteLine("Количество мест должно быть числом");
            }
          }

          if (broken) {
            Console.WriteLine("Команда отменена");
          } else {
            auditoria = SelectBySeats(AuditoriumDatabase, seats);
            PrintAuditoria(auditoria);
          }
          break;
        case "проектор":
          Console.WriteLine("Аудитории с проектором и достаточным кол-вом мест:");
          while (!passed) {
            try {
              string data = Console.ReadLine();

              if (data == "!") {
                broken = true;
                break;
              }

              seats = Convert.ToInt32(data);
              if (seats <= 0) {
                Console.WriteLine("Количество мест должно быть больше нуля");
              } else {
                passed = true;
              }
            } catch (Exception) {
              Console.WriteLine("Количество мест должно быть числом");
            }
          }

          if (broken) {
            Console.WriteLine("Команда отменена");
          } else {
            auditoria = SelectyBySeatsWithProjector(AuditoriumDatabase, seats);
            PrintAuditoria(auditoria);
          }
          break;
        case "компьютер":
          Console.WriteLine("Аудитории с компьютерами и достаточным кол-вом мест:");
          while (!passed) {
            try {
              string data = Console.ReadLine();

              if (data == "!") {
                broken = true;
                break;
              }

              seats = Convert.ToInt32(data);
              if (seats <= 0) {
                Console.WriteLine("Количество мест должно быть больше нуля");
              } else {
                passed = true;
              }
            } catch (Exception) {
              Console.WriteLine("Количество мест должно быть числом");
            }
          }

          if (broken) {
            Console.WriteLine("Команда отменена");
          } else {
            auditoria = SelectyBySeatsWithComputers(AuditoriumDatabase, seats);
            PrintAuditoria(auditoria);
          }
          break;
        case "этаж":
          Console.WriteLine("Аудитории на данном этаже:");
          while (!passed) {
            try {
              string data = Console.ReadLine();

              if (data == "!") {
                broken = true;
                break;
              }

              floor = Convert.ToInt32(data);
              if (floor <= 0) {
                Console.WriteLine("Этаж должен быть больше нуля");
              } else {
                passed = true;
              }
            } catch (Exception) {
              Console.WriteLine("Номер этажа должен быть числом");
            }
          }

          if (broken) {
            Console.WriteLine("Команда отменена");
          } else {
            auditoria = SelectByFloor(AuditoriumDatabase, floor);
            PrintAuditoria(auditoria);
          }
          break;
        case "добавить":
          Console.WriteLine("Добавление аудитории:");
          Menu.AddAuditorium(AuditoriumDatabase);
          break;
        case "изменить":
          Console.WriteLine("Изменение данных аудитории:");

          while (!passed) {
            try {
              Console.WriteLine("Введите номер этажа:");
              string data = Console.ReadLine();

              if (data == "!") {
                broken = true;
                break;
              }

              floor = Convert.ToInt32(data);
              if (floor <= 0) {
                Console.WriteLine("Номер этажа должен быть больше нуля");
              } else {
                passed = true;
              }
            } catch (Exception) {
              Console.WriteLine("Номер должен быть числом");
            }
          }

          if (!broken) {
            int room = -1;
            passed = false;
            while (!passed) {
              try {
                Console.WriteLine("Введите номер аудитории:");
                string data = Console.ReadLine();

                if (data == "!") {
                  broken = true;
                  break;
                }

                room = Convert.ToInt32(data);
                if (floor <= 0) {
                  Console.WriteLine("Номер аудитории должен быть больше нуля");
                } else {
                  passed = true;
                }
              } catch (Exception) {
                Console.WriteLine("Номер должен быть числом");
              }
            }

            if (broken) {
              Console.WriteLine("Команда отменена");
            } else {
              Menu.EditAuditorium(AuditoriumDatabase, floor, room);
            }
          }

          if (broken) {
            Console.WriteLine("Команда отменена");
          }

          break;
        default:
          Console.WriteLine("Неверная команда, введите '?' для списка команд:");
          break;
      }
    }
  }
}
