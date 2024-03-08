using System.Collections;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Base {
	public struct DestroyByTime : IComponentData {
		public float Value;
	}
}