using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using static Utilities.Utils;
using static Utilities.EnumExtensions;
using System.Threading.Tasks;

namespace TurtleChallenge
{
    class Program
    {
        static IFullPosition _initialPosition { get; set; }
        static IPosition _finalPostion;
        static int _boardHeigth;
        static int _boardWidth;
        static ICollection<Position> _minesList;
        static ICollection<Moves> _movesList;
        static IFullPosition _turtlePosition;

        static string gameSettingsPath = @"C:\Turtle\Turtle_Success\TurtleConfigSettings.txt";
        static string movesPath = @"C:\Turtle\Turtle_Success\Turtle_Moves.txt";

        //const PathGameSettings = 
        //static void Main(string[] args)
        //{
        //    AsyncContext.Run(() => MainAsync(args));
        //}

        static void Main(string[] args)
        {
            try
            {
                var input = string.Empty;
                var inProgress = true;

                do
                {
                    StartGame();
                    Console.WriteLine("Press R to reset the game or any key to exit");
                    input = Console.ReadLine();

                    if (input.ToUpper() != "R") inProgress = false;
                }
                while (inProgress);

               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.InnerException);
                Console.WriteLine();
            }
           
        }

        private static void StartGame()
        {
            Console.WriteLine("Welcome to the turle Game. Please specify the full path for boths files needed to play the game.");
            Console.WriteLine("Please enter the full path ( inlcuding the file name and extension) for the game settings and press enter");
            Console.Write("> ");
            gameSettingsPath = Console.ReadLine();

            Console.WriteLine("Please enter the full path (inlcuding the file name and extension) for the moves and press enter");
            Console.Write("> ");
            movesPath = Console.ReadLine();

            ReadFileGameSettings(gameSettingsPath);
        
            ReadFileMoves(movesPath);

            Console.WriteLine("Let's start the turtle Game!");
            Console.WriteLine(">>>...");
            Console.WriteLine(">>>...");

            //Iturtle
            //Check if the firt position is the exit position
            var turtleGame = new TurtleGame(_initialPosition, _finalPostion, _boardHeigth, _boardWidth, _minesList, _movesList);
            //Attaching event Handlers
            //We do it this way to show the usage of an inline function with lambda expression
            turtleGame.moveEvent += (s, e) => displayMove(e.move);

            //turtleGame.taskEvent += (s, e) => { Console.WriteLine(e); };

            var result = turtleGame.PlayGame();

            Console.WriteLine(result.GetDescription());
        }

        //This would be another way to handle the event
        //static void Turtle_MoveEvent(object s, MoveEventArgs e)
        //{
        //    Console.WriteLine(">> Move performed with action: " + e.move.GetDescription());
        //}
        private static void displayMove(Moves m)
        {
            Console.WriteLine(">> Move performed with action: " + m.GetDescription());
        }

        private static void ReadFileGameSettings(string path)
        {
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    //int counter = 0;
                    //Reading the board size
                    string ln;
                    ln = file.ReadLine();
                    var boardSize = ln.Split(',');
                    _boardHeigth = int.Parse(boardSize[0]);
                    _boardWidth = int.Parse(boardSize[1]);
                    Console.WriteLine("Dimension of the board is: ");
                    Console.WriteLine(">> Height: " + boardSize[0]);
                    Console.WriteLine(">> Width: " + boardSize[1]);
                    //Reading the Start position
                    ln = file.ReadLine();
                    var pos = ln.Split(',');
                    var coorX = int.Parse(pos[0]);
                    var CoorY = int.Parse(pos[1]);
                    //var direction = pos[2];
                    Enum.TryParse(pos[2], true, out Direction direction);
                    _initialPosition = new StartPosition(coorX, CoorY, direction);

                    Console.WriteLine("Initial position is: ");
                    Console.WriteLine(">> " + coorX + "," + CoorY);
                    //Reading the end position
                    ln = file.ReadLine();
                    pos = ln.Split(',');
                    coorX = int.Parse(pos[0]);
                    CoorY = int.Parse(pos[1]);
                    _finalPostion = new Position(coorX, CoorY);

                    Console.WriteLine("Final position is: ");
                    Console.WriteLine(">> " + coorX + "," + CoorY);
                    //Reading the list of mines
                    Console.WriteLine("The mine list is: ");
                    _minesList = new List<Position>();
                    while ((ln = file.ReadLine()) != null)
                    {
                        pos = ln.Split(',');
                        coorX = int.Parse(pos[0]);
                        CoorY = int.Parse(pos[1]);
                        _minesList.Add(new Position(coorX, CoorY));
                        Console.WriteLine(">> " + coorX + "," + CoorY);
                        //counter++;
                    }
                    file.Close();

                }
            }
            catch(Exception ex)
            {
                throw new Exception("Exeception reading the game settings file with Exception ", ex);
            }
            
        }

        private static void ReadFileMoves(string path)
        {
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    string ln;
                    _movesList = new List<Moves>();
                    while ((ln = file.ReadLine()) != null)
                    {

                        Enum.TryParse(ln, true, out Moves move);
                        _movesList.Add(move);
                    }
                    file.Close();
                }
                
                Console.WriteLine("The files with moves has been read.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error while reading the moves file with Exception ", ex);
            }
        }
    }
}
