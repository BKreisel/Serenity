using Windows.Foundation.Collections;

namespace Serenity.Services
{
    public interface ISettingsService
    {

        /// <summary>
        /// Sets a settings value based on a key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="category">Namespace for the key</param>
        /// <param name="key">Setting name key</param>
        /// <param name="value">Setting value</param>
        void SetValue<T>(string category, string key, T value);

        /// <summary>
        /// Retrieves a Setting based on a key.
        /// </summary>
        /// <typeparam name="IPropertySet"></typeparam>
        /// <param name="category">Namespace for the key</param>
        /// <param name="key">Setting name key</param>
        /// <returns>The setting</returns>
        T? GetValue<T>(string category, string key);
    }
}
