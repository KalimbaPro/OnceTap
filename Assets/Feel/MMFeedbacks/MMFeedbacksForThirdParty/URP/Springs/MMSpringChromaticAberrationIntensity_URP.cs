#if MM_URP
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	public class MMSpringChromaticAberrationIntensity_URP : MMSpringFloatComponent<Volume>
	{
		protected ChromaticAberration _chromaticAberration;
		
		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = this.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet(out _chromaticAberration);
			base.Initialization();
		}
		
		public override float TargetFloat
		{
			get => _chromaticAberration.intensity.value;
			set => _chromaticAberration.intensity.Override(value);
		}
	}
}
#endif