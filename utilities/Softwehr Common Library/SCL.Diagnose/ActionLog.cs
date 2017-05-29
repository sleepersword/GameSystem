using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCL.Diagnose
{
    public class ActionLog : IDisposable
    {
        public string LogPath { get; private set; }
        public StreamWriter Writer { get; private set; }

        public delegate void LogEventHandler(Event toLog);

        private readonly FileStream _fs;
        private readonly List<IActionLogClient> _clients = new List<IActionLogClient>(10);

        public ActionLog(string logPath, bool addDate,bool continueIfExist = true)
        {
            if (File.Exists(logPath) && !continueIfExist) return;

            if (addDate)
            {
                var now = DateTime.Now;
                logPath = logPath.Insert(logPath.LastIndexOf('.') , string.Format("{0}-{1}-{2}_{3}-{4}", now.Day, now.Month, now.Year, now.Hour, now.Minute));
            }
            _fs = File.OpenWrite(logPath);
            Writer = new StreamWriter(_fs) {AutoFlush = true};
            LogPath = logPath;

            ActiveLogs.Add(this);
        }

        public void SetClient(IActionLogClient client)
        {
            if (_clients.Contains(client)) return;
            client.LogEvent += LogEvent;
            _clients.Add(client);
        }

        public void RemoveClient(IActionLogClient client)
        {
            if (!_clients.Contains(client)) return;
            client.LogEvent -= LogEvent;
            _clients.Remove(client);
        }

        public void LogEvent(Event toLog)
        {
            Writer.WriteLineAsync(toLog.ToString(false)).Wait();
        }

        public void Dispose()
        {
            foreach (var c in _clients)
            {
                c.LogEvent -= LogEvent;
            }
            _clients.Clear();
            if (Writer != null)
            {
                Writer.Flush();
                Writer.Dispose();
            }
            ActiveLogs.Remove(this);
        }

        public static List<ActionLog> ActiveLogs { get; private set; }
        public static ActionLog CreateNew(string logPath)
        {
            return new ActionLog(logPath, true, true);
        }

        static ActionLog()
        {
            ActiveLogs = new List<ActionLog>(3);
        }
    }
        
    public enum EventState
        {
            Normal,
            Warning,
            Error,
            Info, 
            Commentary
        }

    public struct Event
    {

        public string Source;
        public string Message;
        public EventState State;
        public DateTime Time;

        public Event(string sender, string msg, EventState state)
        {
            Source = sender;
            Message = msg;
            State = state;
            Time = DateTime.Now;
        }

        public string ToString(bool includeSource)
        {
            if (includeSource)
            {
                return string.Format("[{0}]{1}: \"{2}\" fired by {3}", Time.ToLongTimeString(), State.ToString(),
                                     Message, Source);
            }
            else
            {
                return string.Format("[{0}]{1}: \"{2}\"", Time.ToLongTimeString(), State.ToString(),
                                     Message);
            }
        }
    }

    public interface IActionLogClient
    {
        event ActionLog.LogEventHandler LogEvent;
    }
}
