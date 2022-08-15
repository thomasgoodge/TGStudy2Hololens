using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos.EyeTracking
{
    /// <summary>
    /// The associated GameObject will rotate when RotateTarget() is called based on a given direction and speed.
    /// </summary>
    public class RotateObject : MonoBehaviour
    {
        [Tooltip("Euler angles by which the object should be rotated by.")]
        [SerializeField]
        private Vector3 RotateByEulerAngles = Vector3.zero;

        [Tooltip("Rotation speed factor.")]
        [SerializeField]
        private float speed = 1f;

        /// <summary>
        /// Rotate game object based on specified rotation speed and Euler angles.
        /// </summary>
        public void RotateTarget()
        {
            transform.eulerAngles = transform.eulerAngles + RotateByEulerAngles * speed;
        }
    }
}