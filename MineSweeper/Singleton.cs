/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

	Copyright (c) 2006, Dan McKinley
	All rights reserved.

	Redistribution and use in source and binary forms, with or without modification, 
	are permitted provided that the following conditions are met:

	-	Redistributions of source code must retain the above copyright notice, 
		this list of conditions and the following disclaimer. 
		
	-	Redistributions in binary form must reproduce the above copyright notice, 
		this list of conditions and the following disclaimer in the documentation 
		and/or other materials provided with the distribution. 
	
	-	The name of Dan McKinley may not be used to endorse or promote products 
		derived from this software without specific prior written permission. 
		
	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
	AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
	IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
	ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
	LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
	CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
	SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
	INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
	CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
	ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
	POSSIBILITY OF SUCH DAMAGE.

 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MineSweeper
{
    /// <summary>
    /// A default <see cref="IClassFactory"/> implementation,
    /// which uses a parameterless constructor to create the
    /// instance.
    /// </summary>
    public class DefaultClassFactory<T> : IClassFactory<T>
        where T : class, new()
    {
        public T CreateInstance()
        {
            return new T();
        }
    }

    /// <summary>
    /// Interface for objects that create instances of
    /// another type.
    /// </summary>
    public interface IClassFactory<T> where T : class
    {
        T CreateInstance();
    }

    /// <summary>
    /// A basic singleton type that can be used with objects
    /// that are created with a parameterless constructor.
    /// </summary>
    public class Singleton<T> : Singleton<T, DefaultClassFactory<T>>
            where T : class, new()
    {
    }

    /// <summary>
    /// A base (or helper) singleton class. Defines the 
    /// singleton instance.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the singleton object.
    /// </typeparam>
    /// <typeparam name="class_factory">
    /// The type of the class factory to use to create an
    /// instance of type <typeparamref name="T"/>.
    /// </typeparam>
    public class Singleton<T, class_factory>
        where T : class
        where class_factory : IClassFactory<T>, new()
    {
        private static object _sync = new object();
        private static T _default;

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static T Default
        {
            get
            {
                EnsureDefault();
                return _default;
            }
        }

        /// <summary>
        /// Ensures that the singleton has been created.
        /// </summary>
        private static void EnsureDefault()
        {
            if (_default == null)
            {
                lock (_sync)
                {
                    if (_default == null)
                    {
                        CreateDefault();
                    }
                }
            }
        }

        /// <summary>
        /// Uses the class factory to create the instance.
        /// </summary>
        private static void CreateDefault()
        {
            class_factory cf = new class_factory();
            T value = cf.CreateInstance();

            // This ensures that writes in the creation of
            // the default instance won't be shuffled beyond
            // the write to _default. Only matters on multiproc
            // machines where the hardware allows this. Does
            // nothing on an x86.
            Thread.MemoryBarrier();
            _default = value;
        }
    }
}
