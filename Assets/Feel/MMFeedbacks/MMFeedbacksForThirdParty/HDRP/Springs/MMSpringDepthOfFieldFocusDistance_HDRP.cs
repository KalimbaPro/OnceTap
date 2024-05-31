#if MM_HDRP
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace MoreMountains.Feedbacks
{
	public class MMSpringDepthOfFieldFocusDistance_HDRP : MMSpringFloatComponent<Volume>
	{
		protected DepthOfField _depthOfField;
		
		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = this.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet(out _depthOfField);
			base.Initialization();
		}
		
		public override float TargetFloat
		{
			get => _depthOfField.focusDistance.value;
			set => _depthOfField.focusDistance.Override(value);
		}
	}
}
#endif