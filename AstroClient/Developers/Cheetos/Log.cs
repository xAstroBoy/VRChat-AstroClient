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

    private static readonly List<string> _buffer = new();

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
        Write($"{ex.Message}", LogLevel.ERROR);
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
    /// Writes a line to the logger as <see cref="LogLevel.DEGUG"/>
    /// </summary>
    /// <param name="line"></param>
    public static void Debug(string line)
    {
        if (DebugMode)
        {
            Write($"{line}", LogLevel.DEGUG);
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
        if (level == LogLevel.DEGUG)
        {
            lcolor = Color.HTML.Yellow;
        }
        if (Level >= level)
        {
            InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Color.Crayola.Present.BananaMania);
            InternalWrite($"[AstroClient] ", Color.Crayola.Present.Bluetiful);
            InternalWrite($"[{Enum.GetName(typeof(LogLevel), level)}] ", lcolor);
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
        }

        ConsoleUtils.SetColor(ConsoleUtils.ColorType.FOREGROUND, color);
        _buffer.Add(message);
        Console.Write(message);
        _isDirty = true;
        ConsoleUtils.SetColor(ConsoleUtils.ColorType.FOREGROUND, Color.White);
    }

    private static void Initialize()
    {
        if (Bools.IsDebugMode) { Level = LogLevel.DEGUG; }
        if (!Directory.Exists(_folderPath)) { Directory.CreateDirectory(_folderPath); }
        if (File.Exists(_logPath)) { File.Move(_logPath, _oldLogPath); }
        _initialized = true;

        Task.Run(() =>
        {
            _isRunning = true;
            while (_isRunning)
            {
                Update();
                Thread.Sleep(100);
            }
        });
    }

    private static void Update()
    {
        if (_isDirty)
        {
            lock (_buffer)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < _buffer.Count; i++)
                {
                    string line = _buffer[i];
                    sb.Append(line);
                }
                File.AppendAllText(_logPath, sb.ToString());
                _buffer.Clear();
                _isDirty = false;
            }
        }
    }
}
