using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendType.WithLogging.OnType
{
	public static class Extensions
	{
		public static void LogEvent(this Type instance, TraceEventType eventType, string message, int id = 0)
		{
			Log.Write(instance, eventType, message, id);
		}
		public static void LogVerbose(this Type instance, string message, int id = 0)
		{
			Log.Verbose(instance, message, id);
		}
		public static void LogInformation(this Type instance, string message, int id = 0)
		{
			Log.Information(instance, message, id);
		}
		public static void LogWarning(this Type instance, string message, int id = 0)
		{
			Log.Warning(instance, message, id);
		}
		public static void LogError(this Type instance, string message, int id = 0)
		{
			Log.Error(instance, message, id);
		}
		public static void LogEvent(this Type instance, TraceEventType eventType, Action<TextWriter> message, int id = 0)
		{
			Log.Write(instance, eventType, message, id);
		}
		public static void LogVerbose(this Type instance, Action<TextWriter> message, int id = 0)
		{
			Log.Verbose(instance, message, id);
		}
		public static void LogInformation(this Type instance, Action<TextWriter> message, int id = 0)
		{
			Log.Information(instance, message, id);
		}
		public static void LogWarning(this Type instance, Action<TextWriter> message, int id = 0)
		{
			Log.Warning(instance, message, id);
		}
		public static void LogError(this Type instance, Action<TextWriter> message, int id = 0)
		{
			Log.Error(instance, message, id);
		}
	}
}
