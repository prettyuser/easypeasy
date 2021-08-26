using GoodsForecast.Useful.Reflection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace GoodsForecast.Scheduling.Model.Db
{
    /// <summary>
    /// Фабрика создания POCO динамических типов данных.
    /// Используется для кеширования динамически созданных типов данных, чтобы каждый раз не создавать типы данных заново.
    /// Тип данных определяется числовым идентификатором.
    /// </summary>
    public class CachedPocoTypeFactor<T> where T : IEquatable<T>
    {
        /// <summary>
        /// Кэш типов данных строк по идентификатору таблицы.
        /// </summary>
        private ConcurrentDictionary<T, Type> _cachedTypes = new ConcurrentDictionary<T, Type>();        

        /// <summary>
        /// Получить динамически созданный тип данных.
        /// </summary>
        /// <param name="typeId">Числовой идентификатор типа данных.</param>
        /// <param name="typeName">Наименование создаваемого типа данных.</param>
        /// <param name="baseType">Базовый тип, от которого наследуется создаваемый тип данных.</param>
        /// <param name="fieldsGetterFunc">Список свойств, который нужно добавить в динамический тип.</param>
        /// <returns>Возвращает созданный тип данных.</returns>
        public Type GetType(T typeId, string typeName, Type baseType, Func<IEnumerable<(string FieldName, Type FieldType)>> fieldsGetterFunc)
        {
            var rowType = _cachedTypes.GetOrAdd(typeId, tn =>
            {
                var fields = fieldsGetterFunc();

                var pocoTypeBuilder = new PocoTypeBuilder();

                return pocoTypeBuilder.CreateType(typeName, baseType, fields);
            });

            return rowType;
        }
    }
}
