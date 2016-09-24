using UnityEngine;

namespace UnitySteer.Behaviors
{
    [AddComponentMenu("UnitySteer/Steer/... for PathSimplifiedCircular")]
    public class SteerForPathSimplifiedCircular : SteerForPathSimplified
    {
        public override float DistanceAlongPath{
            get
            {
                float value = (Mathf.Max(0f, base.DistanceAlongPath) + 6) % this.Path.TotalPathLength;
                return value;
            } 
        }
        
    }
}