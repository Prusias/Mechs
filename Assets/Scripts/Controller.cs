using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MechAndSandals
{
    public class Controller : MonoBehaviour

    {
        public GameObject playerGameObject;
        public GameObject AIplayerGameObject;
        public GameObject textInfo;
        PlayerAnimations playerAnimations;
        PlayerAnimations AIAnimations;
        Player player;
        AIPlayer AIplayer;
        public Player currentPlayer;
        public bool HasWinner { get; set; }
        public string Winner { get; set; }

        // Use this for initialization
        void Start()
        {
            player = playerGameObject.GetComponent<Player>();
            player = new Player(

            );
            AIplayer = AIplayerGameObject.GetComponent<AIPlayer>();
            AIplayer = new AIPlayer(

            );
            textInfo.GetComponent<Text>().text = "Your Turn";
            currentPlayer = player;
            HasWinner = false;

            playerAnimations = playerGameObject.GetComponent<PlayerAnimations>();
            AIAnimations = AIplayerGameObject.GetComponent<PlayerAnimations>();
        }

        // Update is called once per frame
        void Update()
        {
            


        }

        public void Cast(IAbility ability, Player player, bool endturn = true)
        {

            if (CurrentPlayerIsOverheated())
            {
                currentPlayer.Heat -= 20;
                EndTurn();
            }

            ability.Cast(player);
            currentPlayer.Heat += 25;
            CheckForWinner();
            EndTurn();
        }

        public void Attack(IWeapon weapon, int weaponType, Player player, bool endturn = true)
        {

            if (CurrentPlayerIsOverheated())
            {
                currentPlayer.Heat -= 20;
                EndTurn();
            }

            if (weaponType == 1)
            {
                player.QuickAttack(GetOpponent());
            } else if (weaponType == 2)
            {
                player.NormalAttack(GetOpponent());
                FindObjectOfType<AudioManager>().Play("MelePunch");
            } else if (weaponType == 3)
            {
                player.HeavyAttack(GetOpponent());
            }

            CheckForWinner();
            EndTurn(); 
        }

        private void EndTurn()
        {
            currentPlayer = GetOpponent();
            if (currentPlayer == player)
            {
                textInfo.GetComponent<Text>().text = "Your Turn";
            } else
            {
                textInfo.GetComponent<Text>().text = "Opponents Turn";
            }
        }

        public Player GetOpponent()
        {
            if (currentPlayer == player)
            {
                return AIplayer;
            } else
            {
                return player;
            }
        }

        public bool CurrentPlayerIsOverheated()
        {
            if (player.IsOverheated)
            {
                return true;
            }

            return false;
        }

        public void CheckForOverheatingOpponent()
        {
            if (GetOpponent().Heat >= 100)
            {
                GetOpponent().IsOverheated = true;
            }
        }

        public void CheckForWinner()
        {
            if(GetOpponent().Health <= 0)
            {
                HasWinner = true;
                Winner = currentPlayer;
                Debug.Log("Game has a winner");
            }
        }
    }

}
