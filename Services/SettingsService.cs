using System;
using Windows.Storage;

namespace Serenity.Services
{
    /// <summary>
    // App local storage
    /// </summary>
    public sealed class SettingsService : ISettingsService
    {
        /// <summary>
        /// Use Windows local storage
        /// </summary>
        private readonly ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        /// <summary>
        /// Retrieve a value from storage using a category (container) namespace
        /// </summary>
        /// <typeparam name="T">Nullable object type</typeparam>
        /// <param name="category">Storage category name</param>
        /// <param name="key">Storage key</param>
        /// <returns></returns>
        public T? GetValue<T>(string category, string key)
        {
            ApplicationDataContainer container = localSettings.CreateContainer(category, ApplicationDataCreateDisposition.Always);
            if (container.Values.TryGetValue(key, out object? value)) {
                return (T)value;
            }
            return default;
        }

        /// <summary>
        /// Set a value in storage using a category (container) namespace
        /// </summary>
        /// <typeparam name="T">Storage type</typeparam>
        /// <param name="category">Storage category name</param>
        /// <param name="key">Storage key</param>
        /// <param name="value">Value to store</param>
        public void SetValue<T>(string category, string key, T value)
        {
            ApplicationDataContainer container = localSettings.CreateContainer(category, ApplicationDataCreateDisposition.Always);
            if (container.Values.ContainsKey(key)) {
                container.Values[key] = value;
            } else
            {
                container.Values.Add(key, value);
            }
        }
    }
}
