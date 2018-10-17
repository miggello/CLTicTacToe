﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTicTacToe
{
    public class Game
    {
        private string _name;
        private result _gameResult;
        private int _playerNumber;

        public Game()
        {
            DateTime dt = DateTime.Now;
            _name = "Game_" + dt.ToString();
            _gameResult = result.Incomplete;
            _playerNumber = assignPlayer();
        }

        private int assignPlayer()
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

        private enum result
        {
            Incomplete = 1,
            Draw,
            Win,
            Loss
        }

        protected List<int> Moves { get; set; }

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
        public void makeMove()
        {
            if (Moves.Count() == 9)
            {
                _gameResult = evaluateGame();
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
        private result evaluateGame()
        {
            throw new NotImplementedException();
        }

        //TODO create draw board method
        public void drawBoard()
        {

        }

        public void play()
        {
            
        }

    }
}
