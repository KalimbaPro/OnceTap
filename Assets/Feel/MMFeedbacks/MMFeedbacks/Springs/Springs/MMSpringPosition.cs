using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	public class MMSpringPosition : MMSpringVector3Component<Transform>
	{
		public enum Spaces { Local, World }

		[MMInspectorGroup("Target", true, 17)] 
		public Spaces Space = Spaces.World;
		
		public override Vector3 TargetVector3
		{
			get => (Space == Spaces.Local) ? Target.localPosition : Target.position;
			set
			{
				if (Space == Spaces.Local)
				{
					Target.localPosition = value;
				}
				else
				{
					Target.position = value;
				}
			}
		}
	}
}
