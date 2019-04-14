using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateAction
{
    public class StateManager : MonoBehaviour
    {
        [Header ("Layer Masks")]
        public bool setupDefaultLayerAtStart = true;
        public LayerMask groundLayers;
        public LayerMask weaponRaycastLayers;

        [Header ("State Properties")]
        public State currentBehaviorState;
        public StateActions initializationUpdater;

        [Header ("Animation")]
        public AnimationsName animationName;
        public AnimatorParameters animatorParameters;
        public AnimationHashes animationHashes;
        public AnimatorController animatorController;

        [Header ("State")]
        public StateProperties currentState;


        [HideInInspector] public MovementProperties movementProperties;
        [HideInInspector] public float deltaTime;

        // References
        [HideInInspector] public Animator animatorInstance;
        [HideInInspector] public Rigidbody rigidbodyInstance;
        [HideInInspector] public Transform transformInstance;

        private void Start ()
        {
            if (setupDefaultLayerAtStart)
            {
                groundLayers = ~(1 << 9 | 1 << 3);
            }

            transformInstance = this.transform;
            animatorInstance = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();

            rigidbodyInstance = GetComponent<Rigidbody> ();
            rigidbodyInstance.drag = 4;
            rigidbodyInstance.angularDrag = 999;
            rigidbodyInstance.constraints = RigidbodyConstraints.FreezeRotation;

            initializationUpdater.Execute (this);

            animationHashes = new AnimationHashes ();
        }

        private void FixedUpdate ()
        {
            deltaTime = Time.deltaTime;
            if (currentBehaviorState != null)
            {
                currentBehaviorState.FixedTick (this);
            }
        }

        private void Update ()
        {
            deltaTime = Time.deltaTime;
            if (currentBehaviorState != null)
            {
                currentBehaviorState.Tick (this);
            }
        }

        public void PlayAnimation (string animationName)
        {
            animatorInstance.CrossFade (animationName, 0.2f);
        }
    }
}
