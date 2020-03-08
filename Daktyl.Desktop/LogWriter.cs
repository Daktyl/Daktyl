using Serilog;
using Serilog.Events;
using System;
using System.IO;
using System.Text;

namespace Daktyl.Desktop
{
	public class LogWriter : TextWriter
	{
		public override Encoding Encoding => throw new NotImplementedException();

		public LogEventLevel LogLevel { get; }

		public LogWriter(LogEventLevel logLevel)
		{
			LogLevel = logLevel;
		}

		public override void WriteLine(bool value)
		{
			Log.Write(LogLevel, value.ToString());
		}

		public override void WriteLine(char value)
		{
			Log.Write(LogLevel, value.ToString());
		}

		public override void WriteLine(char[] buffer)
		{
			Log.Write(LogLevel, new string(buffer));
		}

		public override void WriteLine(object value)
		{
			Log.Write(LogLevel, value.ToString());
		}

		public override void WriteLine(string value)
		{
			Log.Write(LogLevel, value);
		}

		public override void WriteLine(StringBuilder value)
		{
			Log.Write(LogLevel, value.ToString());
		}
	}
}