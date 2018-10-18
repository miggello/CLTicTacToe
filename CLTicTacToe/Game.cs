using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTicTacToe
{
    internal class Game
    {
        private string _name;
        private result _gameResult;
        private int _playerNumber;
        private difficulty _difficulty;

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
            _name = "Game_" + dt.ToString();
            _gameResult = result.Incomplete;
            _playerNumber = assignPlayer();
            _difficulty = difficulty.Easy;
        }

        public Game(string name, difficulty dif)
        {
            _name = name;
            _gameResult = result.Incomplete;
            _playerNumber = assignPlayer();
            _difficulty = dif;
        }

        private int assignPlayer()
        {
            Random rand = new Random();
            if (rand.NextDouble() > 0.5)
            {
                return 2;
            }
            else
            {
                return 2;
            }
        }

        public enum difficulty
        {
            Easy = 1,
            Normal,
            Hard
        }

        private enum playerType
        {
            Human = 1,
            Computer
        }

        private enum result
        {
            Incomplete = 1,
            Draw,
            Win,
            Loss
        }

        public difficulty Difficulty
        {
            get
            {
                return _difficulty;
            }
        }

        protected List<int> moves = new List<int>();

        //TODO Add error handling for invalid names.
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        //TODO create make move method
        public void makeMove(int move)
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
        private static void writeInstructions()
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
        private bool evaluateGame()
        {
            List<int> evmoves;
                
            evmoves = getMoves(playerType.Human);

            if (hasWin(evmoves))
            {
                _gameResult = result.Win;
                return false;
            }

            evmoves = getMoves(playerType.Computer);

            if (hasWin(evmoves))
            {
                _gameResult = result.Loss;
                return false;
            }

            if(moves.Count >= 9)
            {
                _gameResult = result.Draw;
                return false;
            }

            _gameResult = result.Incomplete;
            return true;
        }

        private bool hasWin(List<int> evmoves)
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

        private List<int> getMoves(playerType ptype)
        {
            List<int> movesList = new List<int> { };
                int i = 0;
                if (_playerNumber == 2 && ptype == playerType.Human)
                {
                    i = 1;
                }
                if(_playerNumber == 1 && ptype == playerType.Computer)
                {
                    i = 1;
                }

                while (i < moves.Count - 1)
                {
                    movesList.Add(moves[i]);
                    i += 2;
                }
                return movesList;
        }

        //TODO create draw board method
        public void drawBoard()
        {
            Console.Write("   Board: \n\n");
            Console.Write(" {0} | {1} | {2} \n",getToken(1), getToken(2), getToken(3));
            Console.Write("___|___|___\n");
            Console.Write("   |   |   \n");
            Console.Write(" {0} | {1} | {2} \n",getToken(4),getToken(5),getToken(6));
            Console.Write("___|___|___\n");
            Console.Write("   |   |   \n");
            Console.Write(" {0} | {1} | {2} \n\n",getToken(7),getToken(8),getToken(9));
        }

        private char getToken(int moveindex)
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

        public void play()
        {
            if (_gameResult != result.Incomplete)
            {
                throw new Exception("Completed games cannot be re-played!");
            }

            writeInstructions();

            if (_playerNumber == 1)
            {
                while(evaluateGame())
                {
                    drawBoard();
                    playerMove();
                    if(evaluateGame())
                    {
                        computerMove();
                    }
                }
            }
            else
            {
                while (evaluateGame())
                {
                    computerMove();
                    drawBoard();
                    if(evaluateGame())
                    {
                        playerMove();
                    }
                }
            }

            drawBoard();
            Console.WriteLine("This game's result was a " + _gameResult + "!");
            Console.WriteLine(string.Join(",", moves));

        }

        private void playerMove()
        {
            while (true)
            { 
                Console.Write("Enter Your Move! ");
                validMoves();
                string strmove = Console.ReadLine();
                if (int.TryParse(strmove, out int intMove) && intMove > -1 && intMove < 10)
                {
                    if (moves.Contains(intMove))
                    {
                        Console.WriteLine("That move has already been made!");
                        validMoves();
                    }
                    else
                    {
                        makeMove(intMove);
                        break;
                    }
                }
                else
                {
                    Console.Write("Invalid Move.");
                    validMoves();
                }
            }
        }

        private void computerMove()
        {
            for (int i = 1; i < 10; i++)
            {
                if (moves.Contains(i) == false)
                {
                    makeMove(i);
                    break;
                }
            }
        }

        private void validMoves()
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
