using UnityEngine;
using UnityEngine.UI;
#if (MM_TEXTMESHPRO || MM_UGUI2)
using TMPro;

namespace MoreMountains.Feedbacks
{
	public class MMSpringTMPSoftness : MMSpringFloatComponent<TMP_Text>
	{
		protected override void ApplyValue(float newValue)
		{
			base.ApplyValue(newValue);
			Target.fontSharedMaterial.SetFloat(ShaderUtilities.ID_OutlineSoftness, newValue);
		}
		
		protected override void GrabCurrentValue()
		{
			FloatSpring.CurrentValue = Target.fontMaterial.GetFloat(ShaderUtilities.ID_OutlineSoftness);
		}
	}
}
#endif
