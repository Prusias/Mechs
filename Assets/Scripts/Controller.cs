using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MechAndSandals
{
    public class Controller : MonoBehaviour

    {
        public GameObject playerGameObject;
        public GameObject textInfo;
        Player player;

        // Use this for initialization
        void Start()
        {
            player = playerGameObject.GetComponent<Player>();
            textInfo.GetComponent<Text>().text = "Your Turn";
        }

        // Update is called once per frame
        void Update()
        {
            player.Health--;
        }

        public void Cast(IAbility ability, Player target, bool endturn = true)
        {

        }
    }

}
