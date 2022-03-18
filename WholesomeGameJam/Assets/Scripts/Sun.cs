using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Sun : MonoBehaviour
    {
        public static Sun Inst;
        public float Population = 1;
        public float PopulationScaleFactor = 10000;
        public float Offset;
        public List<Planet> AllPlanets = new List<Planet>();

        private void Awake()
        {
            Inst = this;
        }

        public void Update()
        {
            var tmp = 0f;
            for(int i= 0; i<AllPlanets.Count; i++)
            {
                tmp += AllPlanets[i].Offset;
            }
            Offset = tmp / AllPlanets.Count;
        }
    }
}
