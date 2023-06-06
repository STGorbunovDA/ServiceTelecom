namespace ServiceTelecom.Infrastructure.Interfaces
{
    internal interface IGetSetRegistryServiceTelecomSetting
    {
        /// <summary> Запись в реестр Login </summary>
        void SetRegistryUser(string user);

        /// <summary> Получение из реестра Login </summary>
        string GetRegistryUser();

        /// <summary> Запись в реестр City </summary>
        void SetRegistryCity(string city);

        // <summary> Запись из реестра City </summary>
        string GetRegistryCity();
    }
}
