using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodsForecast.Useful.Reflection
{
    /// <summary>
    /// Методы расширения для работы с рефлексией.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Наследует/имплементит ли данный тип реализацию открытого обобщённого интерфейса типа <paramref name="openGeneric"/>.
        /// </summary>
        /// <param name="type">Проверяемый тип.</param>
        /// <param name="openGeneric">Открытый обобщённый интерфейс для проверки.</param>
        /// <returns><see langword="true" />, если открытый обобщённый интерфейс типа <paramref name="openGeneric"/> имплементится или наследуется проверяемым типом.</returns>
        public static bool IsClosedInterfaceOf(this Type type, Type openGeneric)
            => type.GetInterfaces().Any(q => q.IsGenericType && q.GetGenericTypeDefinition() == openGeneric);

        /// <summary>
        /// Получить интерфейсы - реализации открытого обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемые данным типом.
        /// </summary>
        /// <param name="type">Тип, имплементирующий обобщённый интерфейс типа <paramref name="openGeneric"/>.</param>
        /// <param name="openGeneric">Открытый обобщённый интерфейс, имплементируемый данным типом.</param>
        /// <returns>Множество интерфейсов - реализаций открытого обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемых данным типом.</returns>
        public static IEnumerable<Type> GetGenericInterfaces(this Type type, Type openGeneric)
            => type.GetInterfaces().Where(q => q.IsGenericType && q.GetGenericTypeDefinition() == openGeneric);

        /// <summary>
        /// Получить интерфейс - реализацию открытого обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемого данным типом.
        /// </summary>
        /// <param name="type">Тип, имплементирующий обобщённый интерфейс типа <paramref name="openGeneric"/>.</param>
        /// <param name="openGeneric">Открытый обобщённый интерфейс, имплементируемый данным типом.</param>
        /// <returns>Интерфейс - реализация обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемого данным типом.</returns>
        public static Type GetGenericInterface(this Type type, Type openGeneric)
            => type.GetInterfaces().SingleOrDefault(q => q.IsGenericType && q.GetGenericTypeDefinition() == openGeneric);

        /// <summary>
        /// Получить атрибуты шаблона из реализаций открытого обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемых данным типом.
        /// </summary>
        /// <param name="type">Тип, имплементирующий обобщённый интерфейс типа <paramref name="openGeneric"/>.</param>
        /// <param name="openGeneric">Открытый обобщённый интерфейс, имплементируемый данным типом.</param>
        /// <param name="position">0-based позиция атрибута шаблона обобщённого интерфейса типа <paramref name="openGeneric"/>.</param>
        /// <returns>Список атрибутов шаблона из реализаций открытого обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемых данным типом.</returns>
        public static IEnumerable<Type> GetClosedGenericInterfaceAttributes(this Type type, Type openGeneric, byte position)
            => type.GetGenericInterfaces(openGeneric).Select(q => q.GetGenericArguments()[position]);

        /// <summary>
        /// Получить атрибут шаблона из реализации открытого обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемой данным типом.
        /// </summary>
        /// <param name="type">Тип, имплементирующий обобщённый интерфейс типа <paramref name="openGeneric"/>.</param>
        /// <param name="openGeneric">Открытый обобщённый интерфейс, имплементируемый данным типом.</param>
        /// <param name="position">0-based позиция атрибута шаблона обобщённого интерфейса типа <paramref name="openGeneric"/>.</param>
        /// <returns>Атрибут шаблона из реализации открытого обобщённого интерфейса типа <paramref name="openGeneric"/>, имплементируемой данным типом.</returns>
        public static Type GetClosedGenericInterfaceAttribute(this Type type, Type openGeneric, byte position)
            => type.GetGenericInterface(openGeneric)?.GetGenericArguments()[position];
    }
}