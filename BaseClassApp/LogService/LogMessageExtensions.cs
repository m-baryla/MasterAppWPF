using System;
using System.Collections.ObjectModel;

namespace BaseClassApp.LogService
{
    public static class LogMessageExtensions
    {
        /// <summary>
        ///  Adds message to collection.
        /// </summary>
        /// <param name="collection">Collection to which add LogMessage.</param>
        /// <param name="message">Message to add.</param>
        /// <param name="type">Type of message.</param>
        public static void AddLogMessage(this ObservableCollection<LogMessage> collection, string message, LogMessageType type)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;
            collection.Add(new LogMessage(message, type, DateTime.Now));
        }

        /// <summary>
        /// Adds message to collection.
        /// </summary>
        /// <param name="collection">Collection to which add LogMessage.</param>
        /// <param name="message">Message to add.</param>
        /// <param name="value">Value to decide which LogMessageType should be used. Less than 0 - Error, more than 0 - Warning, else Normal.</param>
        public static void AddLogMessage(this ObservableCollection<LogMessage> collection, string message, int value)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            LogMessageType type;
            if (value < 0) type = LogMessageType.Error;
            else if (value > 0) type = LogMessageType.Warning;
            else type = LogMessageType.Normal;

            collection.AddLogMessage(message, type);
        }

        /// <summary>
        /// Performs action in "try/catch".
        /// </summary>
        /// <param name="collection">Collection to which add LogMessage if exception occured.</param>
        /// <param name="action">Action to perform.</param>
        /// <param name="log">Action performed if exception occured. Should not throw exception.</param>
        /// <returns>False if exception occured, otherwise true.</returns>
        public static bool Wrap(this ObservableCollection<LogMessage> collection, Action action,
            Action<Exception> log = null)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception e)
            {
                collection.AddLogMessage(e.Message, LogMessageType.Error);
                if (log != null) log(e);
                return false;
            }
        }

        /// <summary>
        /// Performs action in "try/catch".
        /// </summary>
        /// <typeparam name="TResultType">Type of result.</typeparam>
        /// <param name="collection">Collection to which add LogMessage if exception occured.</param>
        /// <param name="func">Function to perform.</param>
        /// <param name="log">Action performed if exception occured. Should not throw exception.</param>
        /// <param name="result">Result of function. If exception occured set to default(TResultType).</param>
        /// <returns>False if exception occured, otherwise true.</returns>
        public static bool Wrap<TResultType>(this ObservableCollection<LogMessage> collection, Func<TResultType> func,
            out TResultType result, Action<Exception> log = null)
        {
            result = default(TResultType);
            try
            {
                result = func();
                return true;
            }
            catch (Exception e)
            {
                collection.AddLogMessage(e.Message, LogMessageType.Error);
                if (log != null) log(e);
                return false;
            }

        }
    }
}
