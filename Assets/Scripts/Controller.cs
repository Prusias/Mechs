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
        public GameObject endScreenGameObject;
        Player player;
        Player AIplayer;
        public Player currentPlayer; 

        // Use this for initialization
        void Start()
        {
            player = playerGameObject.GetComponent<Player>();
            player = new Player(

            );
            AIplayer = AIplayerGameObject.GetComponent<Player>();
            AIplayer = new Player(

            );
            textInfo.GetComponent<Text>().text = "Your Turn";
            currentPlayer = player;
        }

        // Update is called once per frame
        void Update()
        {
            


        }

        public void Cast(IAbility ability, Player player, bool endturn = true)
        {
            ability.Cast(player);
            EndTurn();
        }

        public void Attack(IWeapon weapon, int weaponType, Player player, bool endturn = true)
        {
            if (weaponType == 1)
            {
                player.QuickAttack(GetOpponent());
            } else if (weaponType == 2)
            {
                player.NormalAttack(GetOpponent());
            } else if (weaponType == 3)
            {
                player.HeavyAttack(GetOpponent());
            }
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
    }

}
