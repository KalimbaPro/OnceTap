﻿using System.Collections;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.FeedbacksForThirdParty
{
	/// <summary>
	/// This feedback will let you change the transform origin an element on a target UI Document
	/// </summary>
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the transform origin an element on a target UI Document")]
	[FeedbackPath("UI Toolkit/UITK Transform Origin")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.UIToolkit")]
	public class MMF_UIToolkitTransformOrigin : MMF_UIToolkitVector2Base
	{
		[Header("Units")]
		/// how to interpret the x value
		[Tooltip("how to interpret the x value")]
		public LengthUnit LengthUnitX = LengthUnit.Pixel;
		/// how to interpret the y value
		[Tooltip("how to interpret the y value")]
		public LengthUnit LengthUnitY = LengthUnit.Pixel;

		protected override void SetValue(Vector2 newValue)
		{
			foreach (VisualElement element in _visualElements)
			{
				element.style.transformOrigin = new StyleTransformOrigin(new TransformOrigin(new Length(newValue.x, LengthUnitX), new Length(newValue.y, LengthUnitY)));
				HandleMarkDirty(element);
			}
		}

		protected override Vector2 GetInitialValue()
		{
			return _visualElements[0].resolvedStyle.transformOrigin;
		}
	}
}