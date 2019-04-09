using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MechAndSandals
{
    public class Controller : MonoBehaviour
    {
        public GameObject playerGameObject;
        Player player;

        // Use this for initialization
        void Start()
        {
            player = playerGameObject.GetComponent<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            player.Health--;
        }

    }

}
