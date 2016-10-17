﻿using System;
using System.Collections.Generic;

namespace Yakari
{
    public interface ICacheProvider : IDisposable
    {
        bool HasSlidingSupport { get; }

        /// <summary>
        ///     Get cache item from cache store
        /// </summary>
        /// <param name="key"></param>
        /// <param name="getTimeout"></param>
        /// <param name="isManagerCall">Whether or not is manager calling</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Get<T>(string key, TimeSpan getTimeout, bool isManagerCall = false) where T : class;

        /// <summary>
        ///     Get cache item from cache store
        /// </summary>
        /// <param name="key"></param>
        /// <param name="getTimeout"></param>
        /// <param name="acquireFunction">Action to get data from store</param>
        /// <param name="expiresIn"></param>
        /// <param name="isManagerCall">Whether or not is manager calling</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Get<T>(string key, TimeSpan getTimeout, Func<T> acquireFunction, TimeSpan expiresIn, bool isManagerCall = false) where T : class;

        /// <summary>
        ///     Set generic cache item with expiration
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn"></param>
        /// <param name="isManagerCall">Whether or not is manager calling</param>
        void Set(string key, object value, TimeSpan expiresIn, bool isManagerCall = false);

        /// <summary>
        ///     Delete cache item
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isManagerCall">Whether or not is manager calling</param>
        void Delete(string key, bool isManagerCall = false);

        /// <summary>
        ///     Check key exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(string key);

        /// <summary>
        ///     Return all cache keys
        /// </summary>
        List<string> AllKeys();
    }
}