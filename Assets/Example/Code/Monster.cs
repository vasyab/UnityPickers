using UnityEngine;
using UnityPickers;

namespace Example.Code
{
	[CreateAssetMenu(menuName = "Resources/Monster")]
	public class Monster : ScriptableObject
	{
		public MonsterType Type;

		public Faction Faction;

		[AssetPicker("Example/Monsters/Prefabs")]
		public MonsterView Prefab;
	}
}