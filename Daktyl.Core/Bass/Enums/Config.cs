﻿namespace Daktyl.Core.Bass.Enums
{
	internal enum Config : uint
	{
		Buffer = 0,
		Updateperiod = 1,
		GvolSample = 4,
		GvolStream = 5,
		GvolMusic = 6,
		CurveVol = 7,
		CurvePan = 8,
		Floatdsp = 9,
		Algorithm3D = 10,
		NetTimeout = 11,
		NetBuffer = 12,
		PauseNoplay = 13,
		NetPrebuf = 15,
		NetPassive = 18,
		RecBuffer = 19,
		NetPlaylist = 21,
		MusicVirtual = 22,
		Verify = 23,
		Updatethreads = 24,
		DevBuffer = 27,
		RecLoopback = 28,
		VistaTruepos = 30,
		IosSession = 34,
		IosMixaudio = 34,
		DevDefault = 36,
		NetReadtimeout = 37,
		VistaSpeakers = 38,
		IosSpeaker = 39,
		MfDisable = 40,
		Handles = 41,
		Unicode = 42,
		Src = 43,
		SrcSample = 44,
		AsyncfileBuffer = 45,
		OggPrescan = 47,
		MfVideo = 48,
		Airplay = 49,
		DevNonstop = 50,
		IosNocategory = 51,
		VerifyNet = 52,
		DevPeriod = 53,
		Float = 54,
		NetSeek = 56,
		AmDisable = 58,
		NetPlaylistDepth = 59,
		NetPrebufWait = 60,
		AndroidSessionid = 62,
		WasapiPersist = 65,
		RecWasapi = 66,
		AndroidAaudio = 67,

		// BASS_SetConfigPtr options
		NetAgent = 16,
		NetProxy = 17,
		IosNotify = 46,
		Libssl = 64,

		// BASS_CONFIG_IOS_SESSION flags
		IosSessionMix = 1,
		IosSessionDuck = 2,
		IosSessionAmbient = 4,
		IosSessionSpeaker = 8,
		IosSessionDisable = 16
	}
}