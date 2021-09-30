//namespace AstroClient.Cheetos.MediaController
//{
//	using System;
//	using System.Collections.Generic;
//	using Windows.Foundation;
//	using Windows.Media.Control;

//	internal class MediaController
//	{
//		internal delegate void MediaSessionDelegate(MediaSession session);

//		/// <summary>
//		/// Triggered when a new media source gets added to the MediaSessions
//		/// </summary>
//		internal static event MediaSessionDelegate OnNewSource;

//		/// <summary>
//		/// Triggered when a media source gets removed from the MediaSessions
//		/// </summary>
//		internal static event MediaSessionDelegate OnRemovedSource;

//		/// <summary>
//		/// Triggered when a playback state changes of a MediaSession
//		/// </summary>
//		internal static event TypedEventHandler<MediaSession, GlobalSystemMediaTransportControlsSessionPlaybackInfo> OnPlaybackStateChanged;

//		/// <summary>
//		/// Triggered when a song changes of a MediaSession
//		/// </summary>
//		internal static event TypedEventHandler<MediaSession, GlobalSystemMediaTransportControlsSessionMediaProperties> OnSongChanged;

//		/// <summary>
//		/// A dictionary of the current MediaSessions
//		/// </summary>
//		internal static Dictionary<string, MediaSession> CurrentMediaSessions = new Dictionary<string, MediaSession>();

//		private static bool IsStarted;

//		internal static void Start()
//		{
//			if (!IsStarted)
//			{
//				var sessionManager = GlobalSystemMediaTransportControlsSessionManager.RequestAsync().GetAwaiter().GetResult();
//				SessionsChanged(sessionManager);
//				sessionManager.SessionsChanged += SessionsChanged;
//				IsStarted = true;
//			}
//		}

//		private static void SessionsChanged(GlobalSystemMediaTransportControlsSessionManager sender, SessionsChangedEventArgs args = null)
//		{
//			var sessionList = sender.GetSessions();

//			foreach (var session in sessionList)
//			{
//				if (!CurrentMediaSessions.ContainsKey(session.SourceAppUserModelId))
//				{
//					MediaSession mediaSession = new MediaSession(session);
//					CurrentMediaSessions[session.SourceAppUserModelId] = mediaSession;
//					OnNewSource.SafetyRaise(mediaSession);
//					mediaSession.OnSongChange(session);
//				}
//			}
//		}

//		private static void RemoveSession(MediaSession mediaSession)
//		{
//			CurrentMediaSessions.Remove(mediaSession.ControlSession.SourceAppUserModelId);
//			OnRemovedSource.SafetyRaise(mediaSession);
//		}

//		internal class MediaSession
//		{
//			internal GlobalSystemMediaTransportControlsSession ControlSession;
//			internal string LastSong;

//			internal MediaSession(GlobalSystemMediaTransportControlsSession ctrlSession)
//			{
//				ControlSession = ctrlSession;
//				ControlSession.MediaPropertiesChanged += OnSongChange;
//				ControlSession.PlaybackInfoChanged += OnPlaybackInfoChanged;
//			}

//			private void OnPlaybackInfoChanged(GlobalSystemMediaTransportControlsSession session, PlaybackInfoChangedEventArgs args = null)
//			{
//				var props = session.GetPlaybackInfo();
//				if (props.PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Closed)
//				{
//					session.PlaybackInfoChanged -= OnPlaybackInfoChanged;
//					session.MediaPropertiesChanged -= OnSongChange;
//					RemoveSession(this);
//				}
//				else
//				{
//					OnPlaybackStateChanged.SafetyRaise(this, props);
//				}
//			}

//			internal async void OnSongChange(GlobalSystemMediaTransportControlsSession session, MediaPropertiesChangedEventArgs args = null)
//			{
//				var props = await session.TryGetMediaPropertiesAsync();
//				string song = $"{props.Title} | {props.Artist}";

//				//This is needed because for some reason this method is invoked twice every song change
//				if (LastSong != song && !(String.IsNullOrWhiteSpace(props.Title) && String.IsNullOrWhiteSpace(props.Artist)))
//				{
//					LastSong = song;
//					OnSongChanged.SafetyRaise(this, props);
//				}
//			}
//		}
//	}
//}