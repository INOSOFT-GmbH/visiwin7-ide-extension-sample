namespace CustomNamespace.ExtensionSample.CustomCommands
{
    internal class IndexHelper
    {
        private static int alarmGroupIndex;

        public static int GetAlarmGroupIndex()
        {
            int result = alarmGroupIndex;

            alarmGroupIndex++;

            return result;
        }
    }
}
