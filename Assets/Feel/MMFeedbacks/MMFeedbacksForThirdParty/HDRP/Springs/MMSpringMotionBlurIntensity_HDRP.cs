#if MM_HDRP
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace MoreMountains.Feedbacks
{
	public class MMSpringMotionBlurIntensity_HDRP : MMSpringFloatComponent<Volume>
	{
		protected MotionBlur _motionBlur;
		
		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = this.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet(out _motionBlur);
			base.Initialization();
		}
		
		public override float TargetFloat
		{
			get => _motionBlur.intensity.value;
			set => _motionBlur.intensity.Override(value);
		}
	}
}
#endif