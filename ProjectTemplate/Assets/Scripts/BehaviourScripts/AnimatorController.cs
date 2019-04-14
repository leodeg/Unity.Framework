using System;
using UnityEngine;

namespace StateAction
{
    public class AnimatorController : MonoBehaviour
    {
        #region Editor Variables

        [Header ("Aiming properties")]
        public Transform leftHandTarget;
        public Transform rightHandTarget;
        public Transform shoulder;
        public Transform aimPivot;

        #endregion

        #region Private Variables

        // References
        private Animator animator;
        private StateManager states;

        // IK targets
        private Vector3 lookDirection;
        private float shoulderRotationSpeed = 15f;

        // Weights
        private float rightHandWeight;
        private float leftHandWeight;
        private float baseWeight;
        private float bodyWeight;

        #endregion

        public void Initialize (StateManager state)
        {
            states = state;
            animator = GetComponent<Animator> ();

            if (shoulder == null)
            {
                shoulder = animator.GetBoneTransform (HumanBodyBones.RightShoulder).transform;
            }

            aimPivot = new GameObject ().transform;
            aimPivot.name = "AimPivot";
            aimPivot.parent = states.transform;

            rightHandTarget = new GameObject ().transform;
            rightHandTarget.name = "RightHandTarget";
            rightHandTarget.parent = aimPivot;
        }

        private void OnAnimatorMove ()
        {
            lookDirection = states.movementProperties.aimPosition - aimPivot.position;
            HandleShoulder ();
        }

        private void OnAnimatorIK (int layerIndex)
        {
            HandleWeights ();

            animator.SetLookAtWeight (baseWeight, bodyWeight, 1, 1, 1);
            animator.SetLookAtPosition (states.movementProperties.aimPosition);

            if (leftHandTarget != null)
            {
                UpdateIK (AvatarIKGoal.LeftHand, leftHandTarget, leftHandWeight);
            }

            if (rightHandTarget != null)
            {
                UpdateIK (AvatarIKGoal.RightHand, rightHandTarget, rightHandWeight);
            }
        }

        private void UpdateIK (AvatarIKGoal goal, Transform target, float weight)
        {
            animator.SetIKPositionWeight (goal, weight);
            animator.SetIKRotationWeight (goal, weight);
            animator.SetIKPosition (goal, target.position);
            animator.SetIKRotation (goal, target.rotation);
        }

        public void Tick ()
        {
            
        }


        private void HandleWeights ()
        {
            if (states.currentState.isInteracting)
            {
                rightHandWeight = 0;
                leftHandWeight = 0;
                baseWeight = 0;
                return;
            }

            float base_weight = 0;
            float hand_weight = 0;

            if (states.currentState.isAiming)
            {
                hand_weight = 1;
                bodyWeight = 0.4f;
            }
            else
            {
                bodyWeight = 0.3f;
            }

            leftHandWeight = (leftHandTarget != null) ? 1 : 0;

            Vector3 aimDirection = states.movementProperties.aimPosition - states.transformInstance.position;
            float angle = Vector3.Angle (states.transformInstance.forward, aimDirection);

            base_weight = (angle < 76) ? 1 : 0;
            if (angle > 60) hand_weight = 0;

            if (!states.currentState.isAiming)
            {
                // TODO: set weight when character is not aiming 
            }

            baseWeight = Mathf.Lerp (baseWeight, base_weight, states.deltaTime * 1);
            rightHandWeight = Mathf.Lerp (rightHandWeight, hand_weight, states.deltaTime * 9);
        }

        private void HandleShoulder ()
        {
            HandleShoulderPosition ();
            HandleShoulderRotation ();
        }

        private void HandleShoulderPosition ()
        {
            aimPivot.position = shoulder.position;
        }

        private void HandleShoulderRotation ()
        {
            Vector3 targetDirection = lookDirection;

            if (targetDirection == Vector3.zero)
            {
                targetDirection = aimPivot.forward;
            }

            Quaternion lookRotation = Quaternion.LookRotation (targetDirection);
            aimPivot.rotation = Quaternion.Slerp (aimPivot.rotation, lookRotation, states.deltaTime * shoulderRotationSpeed);
        }
    }
}