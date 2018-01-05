using UnityEngine;

namespace Example.Code
{
	[CreateAssetMenu(menuName = "Resources/Root")]
	public class Root : ScriptableObject
	{
		public Monster[] Monsters;
	}
}