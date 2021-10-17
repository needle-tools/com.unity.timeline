#nullable enable

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

namespace UnityEditor.Timeline
{
	public class CustomCurvesEditor
	{
		private WindowState state = null!;
		
		protected TrackAsset Track { get; private set; } = null!;
		protected TimelineClip? SelectedClip { get; private set; }
		protected Vector2? SelectedRange { get; private set; }

		internal void Init(WindowState _state, TrackAsset track, TimelineClipGUI? selectedClip, IReadOnlyList<TimelineClipGUI> clips)
		{
			this.state = _state;
			this.Track = track;
			if (selectedClip != null)
			{
				this.SelectedClip = selectedClip.clip;
				SelectedRange = new Vector2(state.TimeToPixel(selectedClip.clip.start), state.TimeToPixel(selectedClip.clip.end));
			}
			else SelectedClip = null;
			OnInit();
		}

		protected virtual void OnInit(){}

		protected float TimeToPixel(double time) => state.TimeToPixel(time);
		protected float PixelToTime(float pixel) => state.PixelToTime(pixel);
		protected float PixelDeltaToDeltaTime(float d) => state.PixelDeltaToDeltaTime(d);
		protected void Repaint() => state.editorWindow.Repaint(); 

		protected void UpdatePreview()
		{
			if (state?.previewedDirectors == null) return;
			foreach(var d in state.previewedDirectors) d?.Evaluate();
		}

		protected Rect GetRangeRect(float y, float height)
		{
			if(SelectedRange == null) return Rect.zero;
			var range = SelectedRange.Value;
			var rangeRect = new Rect
			{
				xMin = range.x,
				xMax = range.y,
				height = height,
				y = y
			};
			return rangeRect;
		}

		protected internal virtual void OnDrawHeader(Rect rect)
		{
		}

		protected internal virtual void OnDrawTrack(Rect rect)
		{
		}

		protected IEnumerable<TimelineClip> EnumerateClips()
		{
			foreach (var clip in Track.clips) yield return clip;
		}
	}
}