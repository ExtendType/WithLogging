using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendType.WithLogging
{
	public static class Log
	{
		#region Fields

		private static readonly ConcurrentDictionary<string, TraceSource> Sources;

		#endregion

		#region Lifecycle

		static Log()
		{
			Sources = new ConcurrentDictionary<string, TraceSource>();
		}

		#endregion

		#region Methods

		private static IEnumerable<string> Path(Type sourceType)
		{
			string[] segments = sourceType.FullName.Split('.');
			for (int index = 1; index < segments.Length; index++)
			{
				yield return String.Join(".", segments.Take(index));
			}
		}

		public static IEnumerable<TraceSource> Resolve(Type sourceType)
		{
			foreach (string key in Path(sourceType))
			{
				yield return Sources.GetOrAdd(key, vf => new TraceSource(key));
			}
		}

		public static void Write(Type sourceType, TraceEventType eventType, string message, int id = 0)
		{
			foreach (TraceSource source in Resolve(sourceType).Where(p => p.Listeners.Count > 0)) source.TraceEvent(eventType, id, message);
		}
		public static void Verbose(Type sourceType, string message, int id = 0)
		{
			Write(sourceType, TraceEventType.Verbose, message, id);
		}
		public static void Information(Type sourceType, string message, int id = 0)
		{
			Write(sourceType, TraceEventType.Information, message, id);
		}
		public static void Warning(Type sourceType, string message, int id = 0)
		{
			Write(sourceType, TraceEventType.Warning, message, id);
		}
		public static void Error(Type sourceType, string message, int id = 0)
		{
			Write(sourceType, TraceEventType.Error, message, id);
		}
		public static void Write(Type sourceType, TraceEventType eventType, Action<TextWriter> message, int id = 0)
		{
			Lazy<string> lazy = new Lazy<string>(() =>
			{
				StringBuilder result = new StringBuilder();
				message(new StringWriter(result));
				return result.ToString();
			});
			foreach (TraceSource source in Resolve(sourceType).Where(p => p.Listeners.Count > 0)) source.TraceEvent(eventType, id, lazy.Value);
		}
		public static void Verbose(Type sourceType, Action<TextWriter> message, int id = 0)
		{
			Write(sourceType, TraceEventType.Verbose, message, id);
		}
		public static void Information(Type sourceType, Action<TextWriter> message, int id = 0)
		{
			Write(sourceType, TraceEventType.Information, message, id);
		}
		public static void Warning(Type sourceType, Action<TextWriter> message, int id = 0)
		{
			Write(sourceType, TraceEventType.Warning, message, id);
		}
		public static void Error(Type sourceType, Action<TextWriter> message, int id = 0)
		{
			Write(sourceType, TraceEventType.Error, message, id);
		}
		#endregion
	}
}
