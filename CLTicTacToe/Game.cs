using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTicTacToe
{
    internal class Game
    {
        private Result _gameResult;
        private readonly int _playerNumber;
        private readonly Difficulty _difficulty;

        public int PlayerNumber
        {
            get
            {
                return _playerNumber;
            }
        }

        public Game()
        {
            DateTime dt = DateTime.Now;
            Name = "Game_" + dt.ToString();
            _gameResult = Result.Incomplete;
            _playerNumber = AssignPlayer();
            _difficulty = Difficulty.Easy;
        }

        public Game(string name, Difficulty dif)
        {
            Name = name;
            _gameResult = Result.Incomplete;
            _playerNumber = AssignPlayer();
            _difficulty = dif;
        }

        private int AssignPlayer()
        {
            Random rand = new Random();
            if (rand.NextDouble() > 0.5)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public enum Difficulty
        {
            Easy = 1,
            Normal,
            Hard
        }

        private enum PlayerType
        {
            Human = 1,
            Computer
        }

        private enum Result
        {
            Incomplete = 1,
            Draw,
            Win,
            Loss
        }

        public Difficulty Dif
        {
            get
            {
                return _difficulty;
            }
        }

        protected List<int> moves = new List<int>();

        //TODO Add error handling for invalid names.
        public string Name { get; set; }

        //TODO create make move method
        public void MakeMove(int move)
        {
            if (moves.Count() == 9)
            {
                throw new Exception("Game board is full, something went wrong!");
            }
            else
            {
                moves.Add(move);
            }
        }

        //draw game instructions.
        private static void WriteInstructions()
        {
            Console.WriteLine("When prompted enter the number shown in the cell you would like to place your token (X) in as seen below:\n");
            Console.WriteLine(" 1 | 2 | 3 ");
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" 4 | 5 | 6 ");
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" 7 | 8 | 9 \n");
        }

        //Evaluate Game for Winner
        private bool EvaluateGame()
        {
            List<int> evmoves;
                
            evmoves = GetMoves(PlayerType.Human);

            if (HasWin(evmoves))
            {
                _gameResult = Result.Win;
                return false;
            }

            evmoves = GetMoves(PlayerType.Computer);

            if (HasWin(evmoves))
            {
                _gameResult = Result.Loss;
                return false;
            }

            if(moves.Count >= 9)
            {
                _gameResult = Result.Draw;
                return false;
            }

            _gameResult = Result.Incomplete;
            return true;
        }

        private bool HasWin(List<int> evmoves)
        {
            int[][] wins = new int[8][]
            {
                new int[3] {1, 2, 3 },
                new int[3] {4, 5, 6 },
                new int[3] {7, 8, 9 },
                new int[3] {1, 4, 7 },
                new int[3] {2, 5, 8 },
                new int[3] {3, 6, 9 },
                new int[3] {1, 5, 9 },
                new int[3] {3, 5, 7 }
            };

            foreach (int[] item in wins)
            {
                if (evmoves.Contains(item[0]) && evmoves.Contains(item[1]) && evmoves.Contains(item[2]))
                {
                    Console.WriteLine(item[0].ToString() + ", " + item[1].ToString() + ", " + item[2].ToString());
                    return true;
                }
            }
            return false;
        }

        private List<int> GetMoves(PlayerType ptype)
        {
            List<int> movesList = new List<int> { };
                int i = 0;
                if (_playerNumber == 2 && ptype == PlayerType.Human)
                {
                    i = 1;
                }
                if(_playerNumber == 1 && ptype == PlayerType.Computer)
                {
                    i = 1;
                }

                while (i < moves.Count)
                {
                    movesList.Add(moves[i]);
                    i += 2;
                }
                return movesList;
        }

        public void DrawBoard()
        {
            Console.Write("   Board: \n\n");
            Console.Write(" {0} | {1} | {2} \n",GetToken(1), GetToken(2), GetToken(3));
            Console.Write("___|___|___\n");
            Console.Write("   |   |   \n");
            Console.Write(" {0} | {1} | {2} \n",GetToken(4),GetToken(5),GetToken(6));
            Console.Write("___|___|___\n");
            Console.Write("   |   |   \n");
            Console.Write(" {0} | {1} | {2} \n\n",GetToken(7),GetToken(8),GetToken(9));
        }

        private char GetToken(int moveindex)
        {
            if (moves.Contains(moveindex))
            {
                if (moves.IndexOf(moveindex) == 0 || moves.IndexOf(moveindex) % 2 == 0){
                    if(_playerNumber == 1)
                    {
                        return 'X';
                    }
                    else
                    {
                        return 'O';
                    }
                }
                else
                {
                    if(_playerNumber == 2)
                    {
                        return 'X';
                    }
                    else
                    {
                        return 'O';
                    }
                }
            }
            else
            {
                return ' ';
            }
        }

        public void Play()
        {
            if (_gameResult != Result.Incomplete)
            {
                throw new Exception("Completed games cannot be re-played!");
            }

            WriteInstructions();

            if (_playerNumber == 1)
            {
                while(EvaluateGame())
                {
                    DrawBoard();
                    PlayerMove();
                    if(EvaluateGame())
                    {
                        ComputerMove();
                    }
                }
            }
            else
            {
                while (EvaluateGame())
                {
                    ComputerMove();
                    DrawBoard();
                    if (EvaluateGame())
                    {
                        PlayerMove();

                    }
                }
            }

            DrawBoard();
            Console.WriteLine("This game's result was a " + _gameResult + "!");

        }

        private void PlayerMove()
        {
            while (true)
            { 
                Console.Write("Enter Your Move! ");
                ValidMoves();
                string strmove = Console.ReadLine();
                if (int.TryParse(strmove, out int intMove) && intMove > -1 && intMove < 10)
                {
                    if (moves.Contains(intMove))
                    {
                        Console.WriteLine("That move has already been made!");
                        ValidMoves();
                    }
                    else
                    {
                        MakeMove(intMove);
                        break;
                    }
                }
                else
                {
                    Console.Write("Invalid Move.");
                    ValidMoves();
                }
            }
        }

        private void ComputerMove()
        {
            switch (_difficulty)
            {
                case Difficulty.Normal:
                    while (true)
                    {
                        Random rand = new Random();
                        double seed = rand.NextDouble();
                        int i = (int)(seed * 10);
                        if (moves.Contains(i) == false)
                        {
                            MakeMove(i);
                            break;
                        }
                    }
                    break;
                case Difficulty.Hard:
                default:
                    for (int i = 1; i < 10; i++)
                    {
                        if (moves.Contains(i) == false)
                        {
                            MakeMove(i);
                            break;
                        }
                    }
                    break;
            }
        }

        private void ValidMoves()
        {
            Console.WriteLine("The following are valid moves:");
            Console.Write("(");
            for (int i = 1; i < 10; i++)
            {
                if (moves.Contains(i) == false)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine(")");
        }
    }
}
