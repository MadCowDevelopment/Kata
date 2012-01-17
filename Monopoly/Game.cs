using System;
using System.Collections.Generic;

using Monopoly.Locations;

namespace Monopoly
{
    public class Game
    {
        public List<Player> Players { get; private set; }

        public List<ILocation> Locations { get; private set; }  

        private int _rollCount;

        public Player CurrentPlayer
        {
            get
            {
                return Players[_currentPlayerIndex];
            }
        }

        public int _currentPlayerIndex;

        public Game()
        {
            Players = new List<Player>();

            InitializeLocations();
        }

        private void InitializeLocations()
        {
            Locations = new List<ILocation>();

            for (int i = 0; i < 40; i++)
            {
                Locations.Add(new GenericLocation());
            }

            Locations[4] = new IncomeTax();
            Locations[30] = new GoToJail();
            Locations[38] = new LuxuryTax();
        }

        public void Roll(int roll)
        {
            VerifyGameIsRunning();

            PerformRoll(roll);

            SetNextPlayer();

            if (LastRollOfTheGame())
            {
                SetGameOver();
            }
        }

        private void SetGameOver()
        {
            GameState = GameState.GameOver;
        }

        private void PerformRoll(int roll)
        {
            _rollCount++;
            CurrentPlayer.Roll(roll);
        }

        private void VerifyGameIsRunning()
        {
            if (GameState != GameState.Running)
            {
                throw new InvalidOperationException();
            }
        }

        private void SetNextPlayer()
        {
            _currentPlayerIndex++;
            _currentPlayerIndex %= Players.Count;
        }

        private bool LastRollOfTheGame()
        {
            return _rollCount == Players.Count * 20;
        }

        public GameState GameState { get; private set; }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void Start()
        {
            VerifyPlayerCount();
            RandomizePlayers();
            GameState = GameState.Running;
        }

        private void VerifyPlayerCount()
        {
            if (Players.Count < 2 || Players.Count > 8)
            {
                throw new InvalidOperationException();
            }
        }

        private void RandomizePlayers()
        {
            Players.Shuffle();
        }
    }
}