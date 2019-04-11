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
        public Player player;
        public Player AIplayer;
        public Player currentPlayer;
        public bool HasWinner { get; set; }
        public Player Winner { get; set; }

        public float currentAnimationTime = 0;
        private bool isAttacking = false;
        private bool justAttacked = false;
        private AttackObject attackObject;

        // Use this for initialization
        void Start()
        {
            player = playerGameObject.GetComponent<Player>();
           
            currentPlayer = player;
            AIplayer = AIplayerGameObject.GetComponent<Player>();
            textInfo.GetComponent<Text>().text = "Your Turn";
            
            HasWinner = false;

            playerAnimations = playerGameObject.GetComponent<PlayerAnimations>();
            AIAnimations = AIplayerGameObject.GetComponent<PlayerAnimations>();
        }

        // Update is called once per frame
        void Update()
        {
            if (currentAnimationTime > 0f)
            {
                currentAnimationTime += -1f * Time.deltaTime;
            }
            if (isAttacking && !justAttacked)
            {
                Attack(attackObject.weapon, attackObject.weaponType, attackObject.player, attackObject.endturn);
            } else
            {
                justAttacked = false;
            }
            
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
            if (isAttacking == false)
            {
                attackObject = new AttackObject(weapon, weaponType, player, endturn);
                isAttacking = true;
                currentAnimationTime = 7f;

                if (currentPlayer = player)
                {
                    playerAnimations.AttackRight();
                    playerAnimations.Reset();
                }
                else
                {

                    playerAnimations.AttackLeft();
                    playerAnimations.Reset();
                }
            } else
            {
          
                if (currentAnimationTime < .5f)
                {
                    isAttacking = false;
                    if (CurrentPlayerIsOverheated())
                    {
                        currentPlayer.Heat -= 20;
                        EndTurn();
                    }

                    if (weaponType == 1)
                    {
                        player.SelectedWeapon = player.Weapons[0];
                        player.QuickAttack(GetOpponent());
                    }
                    else if (weaponType == 2)
                    {
                        player.SelectedWeapon = player.Weapons[1];
                        player.NormalAttack(GetOpponent());
                    }
                    else if (weaponType == 3)
                    {
                        player.SelectedWeapon = player.Weapons[2];
                        player.HeavyAttack(GetOpponent());
                    }

                    
                    CheckForWinner();
                    EndTurn();
                }
            }
           
        }

        private void EndTurn()
        {
            if (currentAnimationTime < 1f)
            {
                currentPlayer = GetOpponent();
                if (currentPlayer == player)
                {
                    textInfo.GetComponent<Text>().text = "Your Turn";
                }
                else
                {
                    textInfo.GetComponent<Text>().text = "Opponents Turn";
                }
                
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
               
                if (Winner == player)
                {
                    playerAnimations.Die();
                    this.GetComponent<EndscreenUI>().Display(true);
                } else
                {
                    AIAnimations.Die();
                    this.GetComponent<EndscreenUI>().Display(false);
                }
                
                Debug.Log("Game has a winner");
            }
        }

        private class AttackObject
        {
            public IWeapon weapon;
            public int weaponType;
            public Player player;
            public bool endturn = true;

            public AttackObject(IWeapon weapon, int weaponType, Player player, bool endturn = true)
            {
                this.weapon = weapon;
                this.weaponType = weaponType;
                this.player = player;
                this.endturn = endturn;
            }
        }
    }

   
}
