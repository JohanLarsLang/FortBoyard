// Lab 1, Göteborg 171010

// By Johan lång and Anders Eriksson

using System;
using System.IO;

namespace TheFortBoyard
{
    class Program
    {
        // Method: Print out Welcome
        static void Welcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to The FORT BOYARD GAME! \n---------------------- \n");
        }

        // Method: Print out Welcome back
        static void Quit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to play again! \n Thank you! \n");
        }

        // Method: Random a numer from randomMin to randomMax - 1
        static int randomNr(int randomMin, int randomMax)
        {

            Random rnd = new Random((int)DateTime.Now.Ticks);
            int randomNr = rnd.Next(randomMin, randomMax); //1,7 gives a randomNr = 1 - 6
            return randomNr;
        }

        //An enmun for each room in the game
        enum Rooms { Pot, WatchTower, Treasure };

        //Method Main, start of the program
        static void Main(string[] args)
        {
            MainMenu:
            //Variables for the game
            string roomCommand = "";
            string message = "";
            int numberOfKeys = 0;
            int numberOfMaps = 0;
            int numberOfCompasses = 0;
            int numberOfScorpions = 0;
            int points = 0;

            const int Scorpion = 0;
            const int Compass = 1000;
            const int Map = 2000;
            const int Key = 3000;

            int[] roomItemsPoints = new int[] { Scorpion, Compass, Map, Key };
            string[] roomItems = new string[] { "Scorpion", "Compass", "Map", "Key" };

            bool compassTrue = false;
            bool mapTrue = false;
            bool keyTrue = false;
            bool openTreasure = false;
            bool answearTreasure = false;

            String riddle = "";
            String clue1 = "";
            String clue2 = "";
            bool riddle1True = false;
            bool riddle2True = false;
            bool riddle3True = false;
            bool clue1True = false;
            bool clue2True = false;
            bool answearRiddle1 = false;
            bool answearRiddle2 = false;
            bool answearRiddle3 = false;


            string[] riddle1 = new string[] { "This metal is so poisonous some people tried to ban it. \nThe namesake of a Roman God, it also is a planet.", "Famous Ford brand", "Used in thermometer", "mercury", "kvicksilver" };
            string[] riddle2 = new string[] { "Many students are incapable of writing a good essay in this. \nThe Queen often uses hers for official business. \nAll the challenges on Fort Boyard are governed by it.", "Famous news magazine", "This is changed during summer in most European countries.", "time", "tid" };
            string[] riddle3 = new string[] { "It's kept in the cellar, but you don't have it with every meal. \nThe most common one is white, and it should be dry. \nRoman soldiers were paid in it.", "The Dead Sea has 33% of it.", "A mineral composed primarily of sodium chloride", "salt", "salt" };
            string[] treasure1 = new string[] { "Rhymes on something sweet", "Wall Street is where you can make a lot of it", "Scrooge McDuck has plenty", "Same as the title of a song written by Roger Waters" };
            string[] clue = new string[4];

            // Game start


            Welcome();
            string menyMainSelection = "";

            do
            {
                Console.WriteLine("[I]nstruction");
                Console.WriteLine("[P]lay the game Fort Boyard");
                Console.WriteLine("[Q]UIT \n");

                Console.Write("Select one above: ");
                menyMainSelection = Console.ReadLine();
                menyMainSelection = menyMainSelection.ToLower();

                switch (menyMainSelection)
                {
                    case "i":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Game Instructions: \n ---------------------  \n");
                        Console.WriteLine("Instructions for Fort Boyard");
                        Console.WriteLine("Your mission is to collect as many keys as possible \nto open the treasure! You will digg in pots and \nanswer riddles in the Watch tower and at least \ntry to figure out the password to open the treasure. \nEnjoy the game and Good Luck!"); 
                        
                        
                        Console.WriteLine();
                        break;

                    case "p":
                        Rooms currentRoom = Rooms.Pot;

                        string menyPotRoomCommand = "";
                        if (currentRoom == Rooms.Pot)
                        {
                            do
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"You are now in the {Rooms.Pot} Room \n");
                                Console.WriteLine($"Your mission is to digg in pots to find the key...");
                                Console.WriteLine($"Thera are other things to find as well but the pot can also be empty.");
                                Console.WriteLine($"Be aware... ...you will maybe find a scorpion!\n");

                                Console.WriteLine("[D]igg in a pot");
                                Console.WriteLine("[N]ext room");
                                Console.WriteLine("[Q]UIT \n");

                                Console.WriteLine($"\nCurrent Inventory: ");
                                Console.WriteLine($"\nKeys: {numberOfKeys}, Maps: {numberOfMaps}, Compasses: {numberOfCompasses}, Scopions: {numberOfScorpions}");
                                Console.WriteLine($"\nCurrent Points: {points} \n");

                                Console.WriteLine($"\nMessage: {message}");

                                Console.Write("Select one above: ");
                                menyPotRoomCommand = Console.ReadLine();
                                menyPotRoomCommand = menyPotRoomCommand.ToLower();

                                switch (menyPotRoomCommand)
                                {
                                    case "d":
                                        int rndNr = randomNr(0, 4);

                                        //System.Threading.Thread.Sleep(1000);
                                        //Console.Beep();

                                        if (rndNr == 0)
                                        {
                                            message = "You found a Scorpion!";
                                            numberOfScorpions++;
                                            points = 0;
                                        }

                                        else if (rndNr == 1)
                                        {
                                            message = "You found a Compass!";
                                            points += roomItemsPoints[rndNr];
                                            numberOfCompasses++;
                                            compassTrue = true;
                                        }

                                        else if (rndNr == 2)
                                        {
                                            message = "You found a Map!";
                                            points += roomItemsPoints[rndNr];
                                            numberOfMaps++;
                                            mapTrue = true;
                                        }

                                        else if (rndNr == 3)
                                        {
                                            if (numberOfKeys == 1)
                                            {
                                                message = "You found nothing!";
                                            }

                                            else
                                            {
                                                message = "You found: " + roomItems[rndNr];
                                                points += roomItemsPoints[rndNr];
                                                keyTrue = true;
                                                numberOfKeys++;
                                            }
                                        }

                                        break;

                                    case "n":
                                        currentRoom = Rooms.WatchTower;

                                        if (compassTrue == true && mapTrue == true && keyTrue == true)
                                        {

                                            string menyWatchRoomSelection = "";

                                            message = "";

                                            if (currentRoom == Rooms.WatchTower)
                                                do
                                                {
                                                    Console.Clear();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    String room2 = "The " + Rooms.WatchTower;
                                                    string wholeNameRoom2 = room2.Insert(9, " ");

                                                    Console.WriteLine($"You are now in the {wholeNameRoom2} \n");
                                                    Console.WriteLine($"Your mission is to answer 3 riddles and each correct answer will give you a key!\n");

                                                    Console.WriteLine("[R]iddle");
                                                    Console.WriteLine("[C]lue");
                                                    Console.WriteLine("[N]ext room");
                                                    Console.WriteLine("[Q]UIT \n");

                                                    Console.WriteLine($"Riddle: {riddle}\n");
                                                    Console.WriteLine($"Clue 1: {clue1}");
                                                    Console.WriteLine($"Clue 2: {clue2}");

                                                    Console.WriteLine($"\nCurrent Inventory: ");
                                                    Console.WriteLine($"\nKeys: {numberOfKeys}, Maps: {numberOfMaps}, Compasses: {numberOfCompasses}, Scopions: {numberOfScorpions}");
                                                    Console.WriteLine($"\nCurrent Points: {points} \n");

                                                    Console.WriteLine($"\nMessage: {message}");

                                                    Console.Write("Type command from above/ enter answear: ");
                                                    menyWatchRoomSelection = Console.ReadLine();
                                                    menyWatchRoomSelection = menyWatchRoomSelection.ToLower();

                                                    switch (menyWatchRoomSelection)
                                                    {
                                                        case "r":
                                                            message = "";

                                                            if (riddle1True == false && riddle2True == false && riddle3True == false && answearRiddle1 == false && answearRiddle2 == false && answearRiddle3 == false)
                                                            {
                                                                riddle = riddle1[0];
                                                                riddle1True = true;
                                                            }

                                                            else if (riddle1True == true && riddle2True == false && riddle3True == false && answearRiddle1 == true && answearRiddle2 == false && answearRiddle3 == false)
                                                            {
                                                                riddle = riddle2[0];
                                                                riddle2True = true;
                                                                clue1 = "";
                                                                clue2 = "";
                                                            }

                                                            else if (riddle1True == true && riddle2True == true && riddle3True == false && answearRiddle1 == true && answearRiddle2 == true && answearRiddle3 == false)
                                                            {
                                                                riddle = riddle3[0];
                                                                riddle3True = true;
                                                                clue1 = "";
                                                                clue2 = "";
                                                            }
                                                            break;

                                                        case "kvicksilver":
                                                        case "mercury":
                                                            if (riddle1True == true && answearRiddle1 == false)
                                                            {
                                                                message = "Correct! Type comman R for next riddle!";
                                                                numberOfKeys++;
                                                                answearRiddle1 = true;

                                                                if (clue1True == false && clue2True == false)
                                                                    points += 3000;

                                                                else if (clue1True == true && clue2True == false)
                                                                    points += 2000;

                                                                else if (clue1True == true && clue2True == true)
                                                                    points += 1000;

                                                                clue1True = false;
                                                                clue2True = false;
                                                            }

                                                            break;

                                                        case "time":
                                                        case "tid":
                                                            if (riddle2True == true && answearRiddle2 == false)
                                                            {
                                                                message = "Correct! Type comman R for next riddle!";
                                                                numberOfKeys++;
                                                                answearRiddle2 = true;

                                                                if (clue1True == false && clue2True == false)
                                                                    points += 3000;

                                                                else if (clue1True == true && clue2True == false)
                                                                    points += 2000;

                                                                else if (clue1True == true && clue2True == true)
                                                                    points += 1000;

                                                                clue1True = false;
                                                                clue2True = false;
                                                            }

                                                            break;

                                                        case "salt":
                                                            if (riddle3True == true && answearRiddle3 == false)
                                                            {
                                                                message = "Correct! Type command N for next room!";
                                                                numberOfKeys++;
                                                                answearRiddle3 = true;

                                                                if (clue1True == false && clue2True == false)
                                                                    points += 3000;

                                                                else if (clue1True == true && clue2True == false)
                                                                    points += 2000;

                                                                else if (clue1True == true && clue2True == true)
                                                                    points += 1000;

                                                                clue1True = false;
                                                                clue2True = false;
                                                            }

                                                            break;

                                                        case "n":
                                                            currentRoom = Rooms.Treasure;
                                                            if (answearRiddle3 == true)
                                                            {
                                                                string menyTreasureRoomSelection = "";

                                                                message = "";
                                                                clue1 = "";
                                                                clue2 = "";

                                                                if (currentRoom == Rooms.Treasure)
                                                                    do
                                                                    {
                                                                        Console.Clear();
                                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                                        Console.WriteLine($"You are now in the {Rooms.Treasure} room! \n");
                                                                        Console.WriteLine($"Your mission is to figure out the password to open the treasure!");
                                                                        Console.WriteLine($"You got one clue for the password for each key.");
                                                                        Console.WriteLine($"You have only one (1) chance to enter the correct password!\n");
                                                                        Console.WriteLine("[O]pen treasure..");
                                                                        Console.WriteLine("[P]lay again..");
                                                                        Console.WriteLine("[Q]UIT \n");

                                                                        Console.WriteLine($"Clue 1: {clue[0]}");
                                                                        Console.WriteLine($"Clue 2: {clue[1]}");
                                                                        Console.WriteLine($"Clue 3: {clue[2]}");
                                                                        Console.WriteLine($"Clue 4: {clue[3]}");

                                                                        Console.WriteLine($"\nCurrent Inventory: ");
                                                                        Console.WriteLine($"\nKeys: {numberOfKeys}, Maps: {numberOfMaps}, Compasses: {numberOfCompasses}, Scopions: {numberOfScorpions}");
                                                                        Console.WriteLine($"\nCurrent Points: {points} \n");

                                                                        Console.WriteLine($"\nMessage: {message}");

                                                                        Console.Write("Type the tresaure password and then enter command from above: ");
                                                                        menyTreasureRoomSelection = Console.ReadLine();
                                                                        menyTreasureRoomSelection = menyTreasureRoomSelection.ToLower();

                                                                        switch (menyTreasureRoomSelection)
                                                                        {
                                                                            case "o":
                                                                                message = "Enter password to open the treasure";
                                                                                openTreasure = true;

                                                                                for (int i = 0; i < numberOfKeys; i++)
                                                                                {
                                                                                    clue[i] = treasure1[i];
                                                                                }

                                                                                break;
                                                                            case "money":
                                                                            case "pengar":
                                                                                answearTreasure = true;
                                                                                if (openTreasure == true)
                                                                                {
                                                                                    message = $"Correct! Congratulations, you won the treasure of $ {points}! ";
                                                                                }

                                                                                else
                                                                                    message = "Open the treasure by select command: O";
                                                                                break;

                                                                            case "p":
                                                                                if (openTreasure == true && answearTreasure == true)
                                                                                {
                                                                                    numberOfKeys = 0;
                                                                                    numberOfMaps = 0;
                                                                                    numberOfCompasses = 0;
                                                                                    numberOfScorpions = 0;
                                                                                    points = 0;
                                                                                    answearTreasure = false;
                                                                                    openTreasure = false;

                                                                                    goto MainMenu;
                                                                                }

                                                                                else if (openTreasure == true && answearTreasure == false)
                                                                                    message = "Enter password to open the treasure!";

                                                                                else
                                                                                    message = "Open the treasure by select command: O";
                                                                                break;

                                                                            case "q":
                                                                                Quit();
                                                                                Console.WriteLine();
                                                                                Console.WriteLine("Are you sure you want to quit the game?");
                                                                                Console.Write("Select Y or y to quit the game or any key to continue: ");
                                                                                string quitSelection3 = Console.ReadLine();

                                                                                if (quitSelection3 == "Y" || quitSelection3 == "y")
                                                                                    return;

                                                                                else
                                                                                {
                                                                                    Console.Clear();
                                                                                }
                                                                                break;

                                                                            default:
                                                                                if (openTreasure == true)
                                                                                {
                                                                                    message = "Not Correct! Select P to Play again or Q for quit";
                                                                                }

                                                                                else
                                                                                    message = "Open the treasure by selecting command: O";
                                                                                answearTreasure = true;
                                                                                break;
                                                                        }
                                                                    } while (menyTreasureRoomSelection != "q");
                                                            }

                                                            else
                                                                message = "You must answear the 3 riddles to go to the next room";

                                                            break;

                                                        case "q":
                                                            Quit();
                                                            Console.WriteLine();
                                                            Console.WriteLine("Are you sure you want to quit the game?");
                                                            Console.Write("Select Y or y to quit the game or any key to continue: ");
                                                            string quitSelection2 = Console.ReadLine();

                                                            if (quitSelection2 == "Y" || quitSelection2 == "y")
                                                                return;

                                                            else
                                                            {
                                                                Console.Clear();
                                                            }
                                                            break;

                                                        default:
                                                            if (riddle1True == true && riddle2True == false && riddle3True == false)
                                                            {
                                                                if (clue1True == false && clue2True == false)
                                                                {
                                                                    clue1 = riddle1[1];
                                                                    clue1True = true;
                                                                }

                                                                else if (clue1True == true && clue2True == false)
                                                                {
                                                                    clue2 = riddle1[2];
                                                                    clue2True = true;
                                                                }

                                                                else if (clue1True == true && clue2True == true)
                                                                {
                                                                    answearRiddle1 = true;
                                                                    riddle = "";
                                                                    clue1 = "";
                                                                    clue2 = "";
                                                                    clue1True = false;
                                                                    clue2True = false;
                                                                    message = "Type comand R for next Riddle";
                                                                }
                                                            }

                                                            else if (riddle1True == true && riddle2True == true && riddle3True == false)
                                                            {
                                                                if (clue1True == false && clue2True == false)
                                                                {
                                                                    clue1 = riddle2[1];
                                                                    clue1True = true;
                                                                }

                                                                else if (clue1True == true && clue2True == false)
                                                                {
                                                                    clue2 = riddle2[2];
                                                                    clue2True = true;
                                                                }

                                                                else if (clue1True == true && clue2True == true)
                                                                {
                                                                    answearRiddle2 = true;
                                                                    riddle = "";
                                                                    clue1 = "";
                                                                    clue2 = "";
                                                                    clue1True = false;
                                                                    clue2True = false;
                                                                    message = "Type comand R for next Riddle";
                                                                }
                                                            }

                                                            else if (riddle1True == true && riddle2True == true && riddle3True == true)
                                                            {
                                                                if (clue1True == false && clue2True == false)
                                                                {
                                                                    clue1 = riddle3[1];
                                                                    clue1True = true;
                                                                }

                                                                else if (clue1True == true && clue2True == false)
                                                                {
                                                                    clue2 = riddle3[2];
                                                                    clue2True = true;
                                                                }

                                                                else if (clue1True == true && clue2True == true)
                                                                {
                                                                    answearRiddle3 = true;
                                                                    riddle = "";
                                                                    clue1 = "";
                                                                    clue2 = "";
                                                                    clue1True = false;
                                                                    clue2True = false;
                                                                    message = "Type comand N for next Room";
                                                                }
                                                            }

                                                            break;
                                                    }
                                                } while (menyWatchRoomSelection != "q");
                                        }

                                        else
                                        {
                                            message = "You need at least one of each: Key, Map, Compass, to go to next room";
                                        }

                                        break;

                                    case "q":
                                        Quit();
                                        Console.WriteLine();
                                        Console.WriteLine("Are you sure you want to quit the game?");
                                        Console.Write("Select Y or y to quit the game or any key to continue: ");

                                        string quitSelection1 = Console.ReadLine();

                                        if (quitSelection1 == "Y" || quitSelection1 == "y")
                                            return;

                                        else
                                        {
                                            Console.Clear();
                                        }
                                        break;

                                    default:
                                        break;
                                }
                            } while (roomCommand != "q");
                        } // CurrentRoom == Rooms.Pot

                        break;

                    case "q":
                        Quit();
                        Console.WriteLine();
                        Console.WriteLine("Are you sure you want to quit the game?");
                        Console.Write("Select Y or y to quit the game or any key to continue: ");

                        string quitSelection = Console.ReadLine();

                        if (quitSelection == "Y" || quitSelection == "y")
                            return;

                        else
                        {
                            Console.Clear();
                        }
                        break;

                    default:
                        Console.Clear();
                        Welcome();
                        break;
                }
            } while (menyMainSelection != "q");
        }
    }
}