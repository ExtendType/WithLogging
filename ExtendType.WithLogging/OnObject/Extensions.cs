using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendType.WithLogging.OnObject
{
	public static class Extensions
	{
		public static void LogEvent<T>(this T instance, TraceEventType eventType, string message, int id = 0)
		{
			Log.Write(typeof(T), eventType, message, id);
		}
		public static void LogVerbose<T>(this T instance, string message, int id = 0)
		{
			Log.Verbose(typeof(T), message, id);
		}
		public static void LogInformation<T>(this T instance, string message, int id = 0)
		{
			Log.Information(typeof(T), message, id);
		}
		public static void LogWarning<T>(this T instance, string message, int id = 0)
		{
			Log.Warning(typeof(T), message, id);
		}
		public static void LogError<T>(this T instance, string message, int id = 0)
		{
			Log.Error(typeof(T), message, id);
		}
		public static void LogEvent<T>(this T instance, TraceEventType eventType, Action<TextWriter> message, int id = 0)
		{
			Log.Write(typeof(T), eventType, message, id);
		}
		public static void LogVerbose<T>(this T instance, Action<TextWriter> message, int id = 0)
		{
			Log.Verbose(typeof(T), message, id);
		}
		public static void LogInformation<T>(this T instance, Action<TextWriter> message, int id = 0)
		{
			Log.Information(typeof(T), message, id);
		}
		public static void LogWarning<T>(this T instance, Action<TextWriter> message, int id = 0)
		{
			Log.Warning(typeof(T), message, id);
		}
		public static void LogError<T>(this T instance, Action<TextWriter> message, int id = 0)
		{
			Log.Error(typeof(T), message, id);
		}
	}
}
