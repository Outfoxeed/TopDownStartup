using Game.Runtime.Enemies;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "Game.Runtime.Enemies.EntityDamagedGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "EntityDamaged",
	    order = 120)]
	public sealed class EntityDamagedGameEvent : GameEventBase<EntityDamaged>
	{
	}
}