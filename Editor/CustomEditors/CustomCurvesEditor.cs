using UnityEngine;
using UnityEngine.Timeline;

namespace UnityEditor.Timeline
{
	public class CustomCurvesEditor
	{
		internal WindowState state;
		
		public TrackAsset Track { get; internal set; }
		public Vector2 ActiveRange { get; internal set; }

		public virtual void OnDrawHeader(Rect rect)
		{
		}

		public virtual void OnDrawTrack(Rect rect)
		{
			
		}
	}
}