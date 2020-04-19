using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Menu();

            Console.ReadKey();
        }
    }

    public class Game
    {
        public static void Menu()
        {
            Console.Clear();

            txd("Welcome to Casino!\n");
            printc(ConsoleColor.White, "1. Single game");
            printc(ConsoleColor.White, "\n2. Multiplayer");
            printc(ConsoleColor.White, "\n3. About");

            string ans = Console.ReadLine();
            if (ans == "1" || ans.ToLower() == "single")
            {
                Console.Clear();
                Single();
            }
            else if (ans == "2" || ans.ToLower() == "mp" || ans.ToLower() == "multiplayer")
            {
                Console.Clear();
                Multiplayer();
            }
            else if (ans == "3" || ans.ToLower() == "about")
            {
                Console.Clear();
                About();
            }
            else
            {
                Console.Clear();
                Menu();
            }
        }

        public static void Single()
        {
            txdc("\nPlease, input your Name: ");
            string username = Console.ReadLine();
            if (username.ToLower() == "polina" || username.ToLower() == "polena")
            {
                PolinaMod();
            }
            txdc($"\nOkay, "); txdc($"{username}", ConsoleColor.Yellow); txdc(". Let's play in my casino!\n");

            Console.ReadKey();
            Console.Clear();

        asd: txd("Input your balance: ");
            string bal_s = Console.ReadLine();
            int balance; bool bal = int.TryParse(bal_s, out balance);
            if (balance <= 0 && bal == true)
            {
                Console.Clear();
                txd("You should input positive balance to play!");
                goto asd;
            }
            else if (bal != true)
            {
                Console.Clear();
                txd("Please, input true value!");
                goto asd;
            }

            txdc($"Your balance: "); txdc($"{balance}$", ConsoleColor.Green); txdc("!\n");

            Console.ReadKey();
            Console.Clear();

            Gameplay(balance);
            txd("\n");
        }

        public static void Multiplayer()
        {
            Console.Clear();
       asd: txd("How many players in yout party?");
            string players_str = Console.ReadLine();
            int players; bool pl_bl = int.TryParse(players_str, out players);
            
            if(pl_bl !=true)
            {
                txd("Incorrert count");
                goto asd;
            }

            
            
        }

        public static void About()
        {
            printc(ConsoleColor.Red, "\n\nCasino Game  v.2.0\n");
            printc(ConsoleColor.Green, "Author: FAFAFA\n");
            printc(ConsoleColor.Yellow, "SoloLearn: \"Hannah Montana\"\n");
            printc(ConsoleColor.Cyan, "vk.com/dangost\n\n\n");
            txd("Press any key to come back in Menu...");
            Console.ReadKey();
            Menu();

            /*
             rules!!!
           */
        }

        public static void Gameplay(int balance)
        {
            while (balance > 0)
            {
            asd: txdc($"\nYour balance: "); txdc($"{balance}$", ConsoleColor.Green); txdc("!");
                txd("Please make a bet: \n");

                txd($"Input a color: \n\n");
                printc(ConsoleColor.Red, "1. Red");
                printc(ConsoleColor.Green, "2. Green");
                printc(ConsoleColor.White, "3. Black");

                string str_color = Console.ReadLine();

                int bet_color_id, win_color_id;
                string bet_color_name;
                ConsoleColor cnsl_color;

                if (str_color == "1" || str_color.ToLower() == "red")
                {
                    bet_color_id = 1;
                    bet_color_name = "red";
                    cnsl_color = ConsoleColor.Red;
                }
                else if (str_color == "2" || str_color == "green")
                {
                    bet_color_id = 0;
                    bet_color_name = "green";
                    cnsl_color = ConsoleColor.Green;
                }
                else if (str_color == "3" || str_color.ToLower() == "black")
                {
                    bet_color_id = 2;
                    bet_color_name = "black";
                    cnsl_color = ConsoleColor.White;
                }
                else
                {
                    Console.Clear();
                    txd("Please, input color! (1, 2, 3 or 'red', 'green', 'black')");
                    goto asd;
                }

            qwe: txdc("\nInput your bet ("); txdc("$", ConsoleColor.Green); txdc("): ");

                string bet_str = Console.ReadLine();
                int bet; bool bet_bl = int.TryParse(bet_str, out bet);

                if (bet_bl != true)
                {
                    txd("Input correct value!");
                    goto qwe;
                }
                else if (bet > balance || bet <= 0)
                {
                    txd("Your bet should be positive and less than 0");
                    goto qwe;
                }


                balance -= bet;
                txdc($"\nAccepted! "); txdc($"Your balance: "); txdc($"{balance}$", ConsoleColor.Green); txdc("!\n");
                txdc($"\nYour bet: "); txdc($"{bet}$", ConsoleColor.Green); txdc(" on "); txdc($"{bet_color_name}\n", cnsl_color);
                txd("Let's roll!");

                int roll = Roll();
                win_color_id = win_c_id(roll);
                string win_color_str = win_color(win_color_id);

                txdc($"\nNumber: "); txdc($"{roll}.", cnsl_win_color(-1, roll)); txdc("       Color: "); txdc($"{win_color_str}\n", cnsl_win_color(win_color_id));
                Console.ReadKey();


                if (bet_color_id == win_color_id && win_color_id == 0)
                {
                    txdc($"\nOh my god! It's "); txdc("green", ConsoleColor.Green); txdc($"! It's "); txdc($"{14 * bet}$", ConsoleColor.Green); txdc(" for you!\n");
                    balance += 14 * bet;
                }
                else if (bet_color_id == win_color_id && win_color_id != 0)
                {
                    txdc($"\nCongratulations! You win "); txdc($"{2 * bet}$", ConsoleColor.Green); txdc("!\n");
                    balance += 2 * bet;
                }
                else if (bet_color_id != win_color_id)
                {
                    txd("You lose. Try again.");
                }
                Console.ReadKey();
                Console.Clear();

            }

            Console.Clear();
            txdc($"\nYour balance: "); txdc($"{balance}$", ConsoleColor.Green); txdc("!\n");
            txd("You lose your all money!");
            Console.ReadKey();
            Console.Clear();
            GameOver();

            txd("\n\nPress any key to come back in Menu...");
            Console.ReadKey();
            Menu();
        }





        static int Roll()
        {
            Random random = new Random();

            int rnd = random.Next(0, 14);
            return rnd;
        }

        static int win_c_id(int roll)
        {
            int win_color_id;
            if (roll == 0)
                win_color_id = 0;       // green

            else if (roll % 2 == 0)
                win_color_id = 1;       // red

            else
                win_color_id = 2;       // black

            return win_color_id;
        }

        static string win_color(int win_color_id)
        {
            string color = "";

            switch (win_color_id)
            {
                case 0:
                    color = "green";
                    break;

                case 1:
                    color = "red";
                    break;
                case 2:
                    color = "black";
                    break;

            }

            return color;
        }

        static ConsoleColor cnsl_win_color(int win_color_id = 1, int roll = -1)
        {
            ConsoleColor color = ConsoleColor.White;

            switch (win_color_id)
            {
                case 0:
                    color = ConsoleColor.Green;
                    break;

                case 1:
                    color = ConsoleColor.Red;
                    break;
                case 2:
                    color = color = ConsoleColor.White;
                    break;

            }

            if (roll != -1 && roll == 0)
            {
                color = ConsoleColor.Green;
            }

            else if (roll != -1 && roll % 2 == 0)
            {
                color = ConsoleColor.Red;
            }

            else if (roll != -1)
            {
                color = ConsoleColor.White;
            }

            return color;
        }



        static void PolinaMod() // - govnokod
        {
            Random random = new Random();

            ConsoleColor[] colors = {       ConsoleColor.Blue,
                                            ConsoleColor.Cyan,
                                            ConsoleColor.White,
                                            ConsoleColor.Yellow,
                                            ConsoleColor.Red,
                                            ConsoleColor.Magenta,
                                            ConsoleColor.Green};


            while (true)
            {




                for (int k = 0; k <= 7; k++)
                {
                    printc(colors[random.Next(0, colors.Length)], "\nYou are always a winner!");
                }
                System.Threading.Thread.Sleep(50);
                Console.Clear();



            }

        }

        static void printc(ConsoleColor color, string messege)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(messege);
            Console.ResetColor();
        }

        static void txd(string message)
        {
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (char ch in message)
            {
                Console.Write(ch);
                System.Threading.Thread.Sleep(50);
            }
            Console.Write("\n");
            Console.ResetColor();
        }

        static void txdc(string message, ConsoleColor color = ConsoleColor.White)
        {

            Console.ForegroundColor = color;
            foreach (char ch in message)
            {
                Console.Write(ch);
                System.Threading.Thread.Sleep(50);
            }

            Console.ResetColor();
        }

        static void GameOver(int time = 200, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;

            Console.WriteLine("\n\n ####    ####   ##   ##  #####");
            System.Threading.Thread.Sleep(time);
            Console.WriteLine("##      ##  ##  ### ###  ##   ");
            System.Threading.Thread.Sleep(time);
            Console.WriteLine("##  ##  ######  ## # ##  #### ");
            System.Threading.Thread.Sleep(time);
            Console.WriteLine("##  ##  ##  ##  ##   ##  ##   ");
            System.Threading.Thread.Sleep(time);
            Console.WriteLine(" ####   ##  ##  ##   ##  #####");
            System.Threading.Thread.Sleep(time);
            Console.WriteLine("                              ");
            System.Threading.Thread.Sleep(time);
            Console.WriteLine(" ####   ##  ##  #####  #####  ");
            System.Threading.Thread.Sleep(time);
            Console.WriteLine("##  ##  ##  ##  ##     ##  ## ");
            System.Threading.Thread.Sleep(time);
            Console.WriteLine("##  ##  ##  ##  ####   #####  ");
            System.Threading.Thread.Sleep(time);
            Console.WriteLine("##  ##   ####   ##     ##  ## ");
            System.Threading.Thread.Sleep(time);
            Console.WriteLine(" ####     ##    #####  ##  ## ");

            Console.ResetColor();
        }

    }
}
