#if MM_POSTPROCESSING
using UnityEngine.Rendering.PostProcessing;
#endif

namespace MoreMountains.Feedbacks
{
	public class MMSpringBloomIntensity : MMSpringFloatComponent<PostProcessVolume>
	{
		#if MM_POSTPROCESSING
		protected Bloom _bloom;
		
		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = this.gameObject.GetComponent<PostProcessVolume>();
			}
			Target.profile.TryGetSettings(out _bloom);
			base.Initialization();
		}
		
		public override float TargetFloat
		{
			get => _bloom.intensity;
			set => _bloom.intensity.Override(value);
		}
		#endif
	}
}