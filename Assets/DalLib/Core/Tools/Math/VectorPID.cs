using UnityEngine;

namespace DaleranGames
{
    [System.Serializable]
    public class VectorPID
    {
        public float Kp, Ki, Kd;

        private float integralF;
        private float lastErrorF;

        private Vector2 integralV2;
        private Vector2 lastErrorV2;

        private Vector3 integralV3;
        private Vector3 lastErrorV3;

        public VectorPID(float kp, float ki, float kd)
        {
            this.Kp = kp;
            this.Ki = ki;
            this.Kd = kd;
        }

        public float Update(float currentError, float timeFrame)
        {
            integralF += currentError * timeFrame;
            var deriv = (currentError - lastErrorF) / timeFrame;
            lastErrorF = currentError;
            return currentError * Kp + integralF * Ki + deriv * Kd;
        }

        public Vector2 Update(Vector2 currentError, float timeFrame)
        {
            integralV2 += currentError * timeFrame;
            var deriv = (currentError - lastErrorV2) / timeFrame;
            lastErrorV2 = currentError;
            return currentError * Kp + integralV2 * Ki + deriv * Kd;
        }

        public Vector3 Update(Vector3 currentError, float timeFrame)
        {
            integralV3 += currentError * timeFrame;
            var deriv = (currentError - lastErrorV3) / timeFrame;
            lastErrorV3 = currentError;
            return currentError * Kp + integralV3 * Ki + deriv * Kd;
        }
    }
}
