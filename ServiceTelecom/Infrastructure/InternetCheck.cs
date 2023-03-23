using System;
using System.Net;
using System.Windows;

namespace ServiceTelecom.Infrastructure
{
    internal class InternetCheck
    {
        /// <summary>
        /// Проверка Интернета
        /// </summary>
        /// <returns></returns>
        public static bool CheckSkyNET()
        {
            try
            {
                Dns.GetHostEntry("yandex.com");
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Отсутствует подключение к Интернету. Проверьте настройки сети и повторите попытку",
                        "Сеть недоступна");
                return false;
            }
        }
    }
}
