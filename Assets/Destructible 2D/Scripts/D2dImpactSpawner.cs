﻿using UnityEngine;
using UnityEngine.Events;

namespace Destructible2D
{
    /// <summary>This component spawns a prefab at the impact point when an object hits the current object.</summary>
    [RequireComponent(typeof(D2dCollisionHandler))]
    [HelpURL(D2dHelper.HelpUrlPrefix + "D2dImpactSpawner")]
    [AddComponentMenu(D2dHelper.ComponentMenuPrefix + "Impact Spawner")]
    public class D2dImpactSpawner : MonoBehaviour
    {
        public enum RotationType
        {
            RandomDirection,
            ImpactDirection,
            SurfaceNormal
        }

        /// <summary>The collision layers you want to listen to.</summary>
        public LayerMask Mask { set { mask = value; } get { return mask; } }
        [SerializeField] private LayerMask mask = -1;

        /// <summary>The impact force required.</summary>
        public float Threshold { set { threshold = value; } get { return threshold; } }
        [SerializeField] private float threshold = 1.0f;

        /// <summary>This allows you to control the minimum amount of time between fissure creation in seconds.</summary>
        public float Delay { set { delay = value; } get { return delay; } }
        [SerializeField] private float delay = 5.0f;

        /// <summary>If you want a prefab to spawn at the impact point, set it here.</summary>
        public GameObject Prefab { set { prefab = value; } get { return prefab; } }
        [SerializeField] private GameObject prefab;

        /// <summary>This allows you to move the start point of the fissure back a bit.</summary>
        public float Offset { set { offset = value; } get { return offset; } }
        [SerializeField] private float offset = 0.1f;

        /// <summary>How should the spawned prefab be rotated?</summary>
        public RotationType RotateTo { set { rotateTo = value; } get { return rotateTo; } }
        [SerializeField] private RotationType rotateTo;

        /// <summary>This gets called when the prefab was spawned.</summary>
        public UnityEvent OnImpact { get { if (onImpact == null) onImpact = new UnityEvent(); return onImpact; } }
        [SerializeField] private UnityEvent onImpact;

        [System.NonSerialized]
        private D2dCollisionHandler cachedCollisionHandler;

        [SerializeField]
        private float cooldown;

        protected virtual void OnEnable()
        {
            if (cachedCollisionHandler == null) cachedCollisionHandler = GetComponent<D2dCollisionHandler>();

              //       += Collision;
        }

        protected virtual void Update()
        {
            cooldown -= Time.deltaTime;
        }

        protected virtual void OnDisable()
        {
            //cachedCollisionHandler.OnCollision -= Collision;
        }

        private void Collision(Vector3 pos)
        {
            if (cooldown <= 0.0f && prefab != null)
            {


                Instantiate(prefab, pos, Quaternion.identity);

                if (onImpact != null)
                {
                    onImpact.Invoke();
                }


            }
        }
    }
}



#if UNITY_EDITOR
namespace Destructible2D.Inspector
{
    using UnityEditor;

    [CanEditMultipleObjects]
    [CustomEditor(typeof(D2dImpactSpawner))]
    public class D2dImpactSpawner_Editor : D2dEditor<D2dImpactSpawner>
    {
        protected override void OnInspector()
        {
            BeginError(Any(t => t.Mask == 0));
            Draw("mask", "The collision layers you want to listen to.");
            EndError();
            Draw("threshold", "The impact force required.");
            Draw("delay", "This allows you to control the minimum amount of time between fissure creation in seconds.");

            Separator();

            BeginError(Any(t => t.Prefab == null));
            Draw("prefab", "If you want a prefab to spawn at the impact point, set it here.");
            EndError();
            Draw("offset", "This allows you to move the start point of the fissure back a bit.");
            Draw("rotateTo", "How should the spawned prefab be rotated?");

            Separator();

            Draw("onImpact");
        }
    }
}
#endif