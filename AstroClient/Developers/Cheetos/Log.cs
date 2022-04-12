namespace AstroClient;

using AstroClient.Constants;

#region Usings

using Cheetah;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#endregion

public static class Log
{
    public static LogLevel Level { get; set; } = LogLevel.NONE;
    public static bool DebugMode { get; set; } = false;

    private static bool _initialized;
    private static bool _isRunning;
    private static bool _isDirty;

    private static readonly string _dataPath = Environment.CurrentDirectory + @"\AstroClient";
    private static readonly string _folderPath = _dataPath + @"\logs";
    private static readonly string _logPath = _dataPath + @"\latest.log";
    private static readonly string _oldLogPath = $"{_folderPath}{$@"\old_{(DateTime.Now - DateTime.MinValue).TotalMilliseconds}.log"}";

    private static readonly List<string> _fileBuffer = new();
    private static readonly List<string> _consoleBuffer = new();

    /// <summary>
    /// Opens the latest log file in Notepad
    /// </summary>
    public static void OpenLatestLogFile()
    {
        try
        {
            Process.Start(_logPath);
        }
        catch (Exception e)
        {
            Error($"Failed to open Log: {e.Message} - {_logPath}");
        }
    }

    /// <summary>
    /// Writes an <see cref="Exception"/> to the logger as <see cref="LogLevel.ERROR"/>
    /// </summary>
    /// <param name="ex"></param>
    public static void Exception(Exception ex, [CallerMemberName] string name = "", [CallerLineNumber] int line = -1)
    {
        Write($"An Exception Occured");
        Write($"{ex.GetType()}", LogLevel.ERROR);
        Write($"CallerName: {name}", LogLevel.ERROR);
        Write($"CallerLine: {line}", LogLevel.ERROR);
        if ((ex as Exception) != null)
        {
            var message = (ex as Exception).Message;
            var stackTrace = (ex as Exception).StackTrace;
            var targetSite = (ex as Exception).TargetSite;
            var source = (ex as Exception).Source;
            if (message != null)
            {
                Write($"Exception Message: {message}", LogLevel.ERROR);
            }

            if (stackTrace != null)
            {
                Write($"Exception StackTrace: {stackTrace}", LogLevel.ERROR);
            }

            if (targetSite != null)
            {
                Write($"Exception TargetSite: {targetSite}", LogLevel.ERROR);
            }

            if (source != null)
            {
                Write($"Exception Source: {source}", LogLevel.ERROR);
            }
        }
        else
        {
            Write($"Exception Was Null!", LogLevel.ERROR);
        }
    }

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.ERROR"/>
    /// </summary>
    /// <param name="line"></param>
    public static void Error(string msg, [CallerMemberName] string name = "", [CallerLineNumber] int line = -1)
    {
        Write($"An Error Occured");
        Write($"CallerName: {name}", LogLevel.ERROR);
        Write($"CallerLine: {line}", LogLevel.ERROR);
        Write($"{msg}", LogLevel.ERROR);
    }

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.FINE"/>
    /// </summary>
    /// <param name="line"></param>
    public static void Fine(string line)
    {
        if (DebugMode || Level >= LogLevel.FINE)
        {
            Write($"{line}", Color.White, LogLevel.FINE);
        }
    }

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.DEGUG"/>
    /// </summary>
    /// <param name="line"></param>
    public static void Debug(string line, [CallerMemberName] string CallerName = "", [CallerLineNumber] int CallerLine = -1)
    {
        if (DebugMode || Level >= LogLevel.DEBUG)
        {
            WriteWithCallerLine($"{line}", $"{CallerName}:{CallerLine}", Color.White, LogLevel.DEBUG);
        }
    }

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.DEGUG"/>
    /// </summary>
    /// <param name="line"></param>
    public static void Debug(string line,  System.Drawing.Color color, [CallerMemberName] string CallerName = "", [CallerLineNumber] int CallerLine = -1)
    {
        if (DebugMode || Level >= LogLevel.DEBUG)
        {

            WriteWithCallerLine($"{line}",$"{CallerName}:{CallerLine}", new Color(color.R, color.G, color.B), LogLevel.DEBUG);
        }
    }

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.DEGUG"/>
    /// </summary>
    /// <param name="line"></param>
    public static void Debug(string line, Color color, [CallerMemberName] string CallerName = "", [CallerLineNumber] int CallerLine = -1)
    {
        if (DebugMode || Level >= LogLevel.DEBUG)
        {
            Write($"{line}", color, LogLevel.DEBUG);
        }
    }

    /// <summary>
    /// Writes a line to the logger as <see cref="LogLevel.WARNING"/>
    /// </summary>
    /// <param name="line"></param>
    public static void Warn(string line)
    {
        Write($"{line}", LogLevel.WARNING);
    }

    /// <summary>
    /// Logs "----------------------" to the logger.
    /// </summary>
    public static void Bars()
    {
        Write("----------------------", Color.Crayola.Present.GrannySmithApple);
    }

    /// <summary>
    /// Writes a line to the logger.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="level"></param>
    public static void Write(string message, LogLevel level = LogLevel.INFO)
    {
        Write(message, Color.White, level);
    }
    
    /// <summary>
    /// Writes a line to the logger, with a specific <see cref="System.Drawing.Color"/>.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    /// <param name="level"></param>
    public static void Write(string message, System.Drawing.Color color, LogLevel level = LogLevel.INFO)
    {
        Write(message, new Color(color.R, color.G, color.B), level);
    }

    /// <summary>
    /// Writes a line to the logger, with a specific <see cref="Color"/>.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    /// <param name="level"></param>
    public static void Write(string message, Color color, LogLevel level = LogLevel.INFO)
    {
        var lcolor = Color.White;
        if (level == LogLevel.INFO)
        {
            lcolor = Color.HTML.Gray;
        }
        if (level == LogLevel.DEBUG)
        {
            lcolor = Color.Crayola.Original.Orange;
        }
        if (level == LogLevel.WARNING)
        {
            lcolor = Color.Crayola.Original.Yellow;
        }
        if (level == LogLevel.ERROR)
        {
            lcolor = Color.Crayola.Original.Red;
        }
        if (Level >= level)
        {
            InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Color.Crayola.Present.BananaMania);
            InternalWrite($"[AstroClient] ", Color.Crayola.Present.Bluetiful);
            InternalWrite($"[{Enum.GetName(typeof(LogLevel), level)}] ", lcolor);
            InternalWriteLine(message, color);
        }
    }
    public static void WriteWithCallerLine(string message, string CallerLine, Color color, LogLevel level = LogLevel.INFO)
    {
        var lcolor = Color.White;
        if (level == LogLevel.INFO)
        {
            lcolor = Color.HTML.Gray;
        }
        if (level == LogLevel.DEBUG)
        {
            lcolor = Color.Crayola.Original.Orange;
        }
        if (level == LogLevel.WARNING)
        {
            lcolor = Color.Crayola.Original.Yellow;
        }
        if (level == LogLevel.ERROR)
        {
            lcolor = Color.Crayola.Original.Red;
        }
        if (Level >= level)
        {
            InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Color.Crayola.Present.BananaMania);
            InternalWrite($"[AstroClient] ", Color.Crayola.Present.Bluetiful);
            InternalWrite($"[{Enum.GetName(typeof(LogLevel), level)}] ", lcolor);
            InternalWrite($"[{CallerLine}] ", Color.Crayola.Present.CottonCandy);
            InternalWriteLine(message, color);
        }
    }

    internal static void InternalWriteLine(string message, Color color)
    {
        InternalWrite(message + Environment.NewLine, color);
    }

    internal static void InternalWrite(string message, Color color)
    {
        if (!_initialized)
        {
            Initialize();
        };
        _consoleBuffer.Add($"{ConsoleUtils.ForegroundColor(color)}{message}");
        _fileBuffer.Add(message);
        _isDirty = true;
    }

    private static void Initialize()
    {
        if (Bools.IsDebugMode) { Level = LogLevel.DEBUG; }
        if (!Directory.Exists(_folderPath)) { Directory.CreateDirectory(_folderPath); }
        if (File.Exists(_logPath)) { File.Move(_logPath, _oldLogPath); }
        _initialized = true;

        Task.Run(() =>
        {
            _isRunning = true;
            while (_isRunning)
            {
                Update();
                Thread.Sleep(1);
            }
        });
    }

    private static DateTime _lastCheck = DateTime.Now;
    private static DateTime _nextCheck = DateTime.Now;

    private static void Update()
    {
        if (DateTime.Now > _nextCheck)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _consoleBuffer.Count; i++)
            {
                var message = _consoleBuffer[i];
                sb.Append(message);
            }
            _consoleBuffer.Clear();
            Console.Write(sb.ToString());
            _nextCheck = DateTime.Now.AddSeconds(1);
            _lastCheck = DateTime.Now;
            if (_isDirty)
            {
                lock (_fileBuffer)
                {
                    var sb2 = new StringBuilder();
                    for (int i = 0; i < _fileBuffer.Count; i++)
                    {
                        string line = _fileBuffer[i];
                        sb2.Append(line);
                    }
                    File.AppendAllText(_logPath, sb2.ToString());
                    _fileBuffer.Clear();
                    _isDirty = false;
                }
            }
        }
    }
}
