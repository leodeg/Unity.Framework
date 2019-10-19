using UnityEngine;

namespace LeoDeg.Framework
{
	interface IHittable
	{
		void TakeHit (float damage);
		void TakeHit (float damage, Vector3 hitPoint);
		void TakeHit (float damage, Vector3 hitPoint, Vector3 hitDirection);
	}
}
