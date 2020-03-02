﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSimpleGame.Models;
using WpfSimpleGame.Data;

namespace WpfSimpleGame.Business
{
    class GameBusiness
    {

        public enum GameStatus
        {
            QUIT,
            QUIT_SAVE
        }



        List<Player> _allPlayers;

        Player _playerOne;
        Player _playerTwo;

        IDataService _dataService;

        public GameBusiness()
        {
            InitializeDataService();
            InitializeGame();
        }

        private void InitializeDataService()
        {
            //
            // instantiate the data service
            //
            _dataService = new DataServiceSeed();
            //_dataService = new DataServiceXml();
            //_dataService = new DataServiceJson();
        }

        private void InitializeGame()
        {

            _allPlayers = _dataService.ReadAll();

            //
            // choose players for games and add to the tuple
            //
            _playerOne = _allPlayers.FirstOrDefault(p => p.Name == "Darth");
            _playerTwo = _allPlayers.FirstOrDefault(p => p.Name == "Leia");
        }

        public List<Player> GetAllPlayers()
        {
            return _dataService.ReadAll();
        }

        public void SaveAllPlayers()
        {
            _dataService.WriteAll(_allPlayers);
        }

        public (Player playerOne, Player playerTwo) GetCurrentPlayers()
        {
            //
            // choose players for games and add to the tuple
            //
            _playerOne = _allPlayers.FirstOrDefault(p => p.Name == "Darth");
            _playerTwo = _allPlayers.FirstOrDefault(p => p.Name == "Leia");
            (Player playerOne, Player playerTwo) currentPlayers = (_playerOne, _playerTwo);

            return currentPlayers;
        }


    }
}
