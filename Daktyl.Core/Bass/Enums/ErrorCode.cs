﻿namespace Daktyl.Core.Bass.Enums
{
	internal enum ErrorCode
	{
		Unknown = -1,
		Ok = 0,
		Mem = 1,
		FileOpen = 2,
		Driver = 3,
		BufLost = 4,
		Handle = 5,
		Format = 6,
		Position = 7,
		Init = 8,
		Start = 9,
		Ssl = 10,
		Already = 14,
		NotAudio = 17,
		Nochan = 18,
		Illtype = 19,
		Illparam = 20,
		No3D = 21,
		Noeax = 22,
		Device = 23,
		Noplay = 24,
		Freq = 25,
		NotFile = 27,
		Nohw = 29,
		Empty = 31,
		Nonet = 32,
		Create = 33,
		Nofx = 34,
		Notavail = 37,
		Decode = 38,
		Dx = 39,
		Timeout = 40,
		Fileform = 41,
		Speaker = 42,
		Version = 43,
		Codec = 44,
		Ended = 45,
		Busy = 46,
		Unstreamable = 47
	}
}