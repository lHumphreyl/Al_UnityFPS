using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.LowLevel;

namespace FPS
{
    public class Main : MonoBehaviour
    {
        public static Main Instance { get; private set; }

		public PlayerModel Player { get; private set; }

        public InputController InputController { get; private set; }
        public FlashlightController FlashlightController { get; private set; }
		public WeaponController WeaponController { get; private set; }
		public TeammatesController TeammatesController { get; private set; }


        private void Awake()
        {
			if (Instance) DestroyImmediate(gameObject);
			else Instance = this;
        }

        private void Start()
        {
			Player = FindObjectOfType<PlayerModel> ();

            InputController = gameObject.AddComponent<InputController>();
            FlashlightController = gameObject.AddComponent<FlashlightController>();
			WeaponController = gameObject.AddComponent<WeaponController>();
			TeammatesController = gameObject.AddComponent<TeammatesController>();
        }
    }
}