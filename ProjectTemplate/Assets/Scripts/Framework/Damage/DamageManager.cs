using UnityEngine;
using System.Collections;

namespace LeoDeg.Framework
{
	public class DamageManager : MonoBehaviour, IHittable
	{
		public float startHealth;
		private float health;

		void Start ()
		{
			health = startHealth;
		}

		void Update ()
		{

		}

		public void TakeHit (float damage)
		{
			TakeDamage (damage);
		}

		public void TakeHit (float damage, Vector3 hitPoint)
		{
			TakeDamage (damage);
		}

		public void TakeHit (float damage, Vector3 hitPoint, Vector3 hitDirection)
		{
			TakeDamage (damage);
		}

		private void TakeDamage (float damage)
		{
			health -= damage;
			if (health < 0.0f)
				health = 0.0f;
		}
	}
}
