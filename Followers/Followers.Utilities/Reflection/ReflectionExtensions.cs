using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.Reflection
{
    /// <summary>
    /// Методы расширения для работы с рефлексией.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Получить интерфейсы - реализации открытого обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемые данным типом.
        /// </summary>
        /// <param name="type">Тип, имплементирующий обобщённый интерфейс типа <paramref name="openGeneric"/>.</param>
        /// <param name="openGeneric">Открытый обобщённый интерфейс, имплементируемый данным типом.</param>
        /// <returns>Множество интерфейсов - реализаций открытого обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемых данным типом.</returns>
        public static IEnumerable<Type> GetGenericInterfaces(this Type type, Type openGeneric)
            => type.GetInterfaces().Where(q => q.IsGenericType && q.GetGenericTypeDefinition() == openGeneric);

        /// <summary>
        /// Получить атрибуты шаблона из реализаций открытого обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемых данным типом.
        /// </summary>
        /// <param name="type">Тип, имплементирующий обобщённый интерфейс типа <paramref name="openGeneric"/>.</param>
        /// <param name="openGeneric">Открытый обобщённый интерфейс, имплементируемый данным типом.</param>
        /// <param name="position">0-based позиция атрибута шаблона обобщённого интерфейса типа <paramref name="openGeneric"/>.</param>
        /// <returns>Список атрибутов шаблона из реализаций открытого обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемых данным типом.</returns>
        public static IEnumerable<Type> GetClosedGenericInterfaceAttributes(this Type type, Type openGeneric, byte position)
            => type.GetGenericInterfaces(openGeneric).Select(q => q.GetGenericArguments()[position]);
    }
}