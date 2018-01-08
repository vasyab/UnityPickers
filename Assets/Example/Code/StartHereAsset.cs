using UnityEngine;
using UnityPickers;

namespace Example.Code
{
	[CreateAssetMenu(menuName = "Resources/StartHere")]
	public class StartHereAsset : ScriptableObject
	{
		public MonsterType MonsterType;

		public Monster Monster;

		public Faction Faction;

		[AssetPicker]
		public GameObject AnyPrefab;

		[AssetPicker("Example/Monsters/Prefabs")]
		public MonsterView MonsterPrefab;

		[AssetPicker]
		public Texture Icon;
	}
}