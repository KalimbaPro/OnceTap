#if MM_POSTPROCESSING
using UnityEngine.Rendering.PostProcessing;
#endif

namespace MoreMountains.Feedbacks
{
	public class MMSpringColorGradingTint : MMSpringFloatComponent<PostProcessVolume>
	{
		#if MM_POSTPROCESSING
		protected ColorGrading _colorGrading;
		
		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = this.gameObject.GetComponent<PostProcessVolume>();
			}
			Target.profile.TryGetSettings(out _colorGrading);
			base.Initialization();
		}
		
		public override float TargetFloat
		{
			get => _colorGrading.tint;
			set => _colorGrading.tint.Override(value);
		}
		#endif
	}
}