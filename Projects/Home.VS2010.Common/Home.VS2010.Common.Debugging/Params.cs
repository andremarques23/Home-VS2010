//-----------------------------------------------------------------------
// <copyright file="Params.cs" company="Home">
//     Home development project. No rights reserved.
// </copyright>
// <author>André Marques de Araújo</author>
//-----------------------------------------------------------------------

namespace Home.VS2010.Common.Debugging
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Globalization;
    using Home.VS2010.Common.Debugging.Resources;

    /// <summary>
    /// Delegate used for getting error text.
    /// </summary>
    /// <returns>Returns the error text.</returns>
    public delegate string ParamErrorTextHandler();

    /// <summary>
    /// Sealed assert class used to verify method parameters.
    /// </summary>
    public sealed class Params
    {
        /// <summary>
        /// Prevents a default instance of the Params class from being created.
        /// </summary>
        private Params()
        {
        }

        /// <summary>
        /// Provides a list of parameters that do not need to be verified.
        /// </summary>
        /// <param name="values">Parameters to ignore.</param>
        [Conditional("DEBUG")]
        public static void Ignore(params object[] values)
        {
        }

        /// <summary>
        /// Checks an individual parameter and throws an <see cref="ArgumentException"/> if it is not correct.
        /// This is meant to be used in public facing methods.
        /// </summary>
        /// <param name="test">The boolean state of the parameter test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="errorTextHandler">Delegate for getting the error text.</param>
        /// <remarks>It is more efficient to pass the error text through a delegate if the text is extracted
        /// from a resource file. The text will only be loaded if it is actually needed.</remarks>
        /// <exception cref="ArgumentException"></exception>
        public static void Require(bool test, string parameterName, ParamErrorTextHandler errorTextHandler)
        {
            Params.Ignore(test, parameterName, errorTextHandler);

            if (test == false)
            {
                string message = string.Empty;
                if (errorTextHandler != null)
                {
                    message = errorTextHandler();
                }

                Debug.Assert(test, parameterName, message);
                throw new ArgumentException(message, parameterName);
            }
        }

        /// <summary>
        /// Checks an individual parameter and throws an <see cref="ArgumentException"/> if it is not correct.
        /// This is meant to be used in public facing methods.
        /// </summary>
        /// <param name="test">The boolean state of the parameter test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="exceptionMessage">Message of the exception to create.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void Require(bool test, string parameterName, string exceptionMessage)
        {
            Params.Ignore(test, parameterName, exceptionMessage);

            if (test == false)
            {
                Debug.Assert(test, parameterName, exceptionMessage);
                throw new ArgumentException(parameterName, exceptionMessage);
            }
        }

        /// <summary>
        /// Requires that the given parameter must not be null.
        /// </summary>
        /// <param name="parameter">The parameter to check for null.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static void RequireNotNull(object parameter, string parameterName)
        {
            Params.Ignore(parameter, parameterName);

            RequireNotNull(parameter, parameterName, delegate { return Strings.CannotBeNull; });
        }

        /// <summary>
        /// Requires that the given parameter must not be null.
        /// </summary>
        /// <param name="parameter">The parameter to check for null.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="errorTextHandler">Delegate for getting the error text.</param>
        /// <remarks>It is more efficient to pass the error text through a delegate if the text is extracted
        /// from a resource file. The text will only be loaded if it is actually needed.</remarks>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RequireNotNull(object parameter, string parameterName, ParamErrorTextHandler errorTextHandler)
        {
            Params.Ignore(parameter, parameterName, errorTextHandler);

            if (parameter == null)
            {
                string message = string.Empty;
                if (errorTextHandler != null)
                {
                    message = errorTextHandler();
                }

                Debug.Assert(false, parameterName, message);
                throw new ArgumentNullException(parameterName, message);
            }
        }

        /// <summary>
        /// Requires that the given parameter must not be null.
        /// </summary>
        /// <param name="parameter">The parameter to check for null.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="exceptionMessage">Message of the exception to create.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RequireNotNull(object parameter, string parameterName, string exceptionMessage)
        {
            Params.Ignore(parameter, parameterName, exceptionMessage);

            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName, exceptionMessage);
            }
        }

        /// <summary>
        /// Requires that an index be between a valid range.
        /// </summary>
        /// <param name="test">The boolean state of the parameter test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="errorTextHandler">Delegate for getting the error text.</param>
        /// <remarks>It is more efficient to pass the error text through a delegate if the text is extracted
        /// from a resource file. The text will only be loaded if it is actually needed.</remarks>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireValidIndex(bool test, string parameterName, ParamErrorTextHandler errorTextHandler)
        {
            Params.Ignore(test, parameterName, errorTextHandler);

            if (test == false)
            {
                string message = string.Empty;
                if (errorTextHandler != null)
                {
                    message = errorTextHandler();
                }

                Debug.Assert(test, parameterName, message);
                throw new ArgumentOutOfRangeException(parameterName, message);
            }
        }

        /// <summary>
        /// Requires that an index be between a valid range.
        /// </summary>
        /// <param name="test">The boolean state of the parameter test.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="exceptionMessage">Message of the exception to create.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireValidIndex(bool test, string parameterName, string exceptionMessage)
        {
            Params.Ignore(test, parameterName, exceptionMessage);

            if (test == false)
            {
                Debug.Assert(test, parameterName, exceptionMessage);
                throw new ArgumentOutOfRangeException(parameterName, exceptionMessage);
            }
        }

        /// <summary>
        /// Requires that the given string is not null or empty.
        /// </summary>
        /// <param name="parameter">The string to check for null or empty.</param>
        /// <param name="parameterName">The name of the string parameter.</param>
        public static void RequireValidString(string parameter, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(!string.IsNullOrEmpty(parameter), parameterName, delegate { return Strings.StringCannotBeNullOrEmpty; });
        }

        /// <summary>
        /// Requires that the given collection is not null or empty.
        /// </summary>
        /// <param name="parameter">The collection to check for null or empty.</param>
        /// <param name="parameterName">The name of the collection parameter.</param>
        public static void RequireValidCollection(ICollection parameter, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(parameter != null && parameter.Count > 0, parameterName, delegate { return Strings.CollectionCannotBeNullOrEmpty; });
        }

        /// <summary>
        /// Requires that the given number is greater than zero.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireGreaterThanZero(short number, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(number > 0, parameterName, delegate { return Strings.MustBeGreaterThanZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than zero.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireGreaterThanZero(int number, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(number > 0, parameterName, delegate { return Strings.MustBeGreaterThanZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than zero.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireGreaterThanZero(long number, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(number > 0, parameterName, delegate { return Strings.MustBeGreaterThanZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than zero.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireGreaterThanZero(float number, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(number > 0, parameterName, delegate { return Strings.MustBeGreaterThanZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than zero.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireGreaterThanZero(double number, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(number > 0, parameterName, delegate { return Strings.MustBeGreaterThanZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireGreaterThanOrEqualToZero(short number, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(number >= 0, parameterName, delegate { return Strings.MustBeGreaterThanOrEqualToZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireGreaterThanOrEqualToZero(int number, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(number >= 0, parameterName, delegate { return Strings.MustBeGreaterThanOrEqualToZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireGreaterThanOrEqualToZero(long number, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(number >= 0, parameterName, delegate { return Strings.MustBeGreaterThanOrEqualToZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireGreaterThanOrEqualToZero(float number, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(number >= 0, parameterName, delegate { return Strings.MustBeGreaterThanOrEqualToZero; });
        }

        /// <summary>
        /// Requires that the give number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireGreaterThanOrEqualToZero(double number, string parameterName)
        {
            Params.Ignore(parameterName);

            Params.Require(number >= 0, parameterName, delegate { return Strings.MustBeGreaterThanOrEqualToZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The value which the number must be greater.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireGreaterThan(short number, int minimum, string parameterName)
        {
            Params.Ignore(number, minimum, parameterName);

            if (number <= minimum)
            {
                string message = Strings.MustBeGreaterThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
            }
        }

        /// <summary>
        /// Requires that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The value which the number must be greater.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireGreaterThan(int number, int minimum, string parameterName)
        {
            Params.Ignore(number, minimum, parameterName);

            if (number <= minimum)
            {
                string message = Strings.MustBeGreaterThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
            }
        }

        /// <summary>
        /// Requires that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The value which the number must be greater.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireGreaterThan(long number, int minimum, string parameterName)
        {
            Params.Ignore(number, minimum, parameterName);

            if (number <= minimum)
            {
                string message = Strings.MustBeGreaterThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
            }
        }

        /// <summary>
        /// Requires that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The value which the number must be greater.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireGreaterThan(float number, int minimum, string parameterName)
        {
            Params.Ignore(number, minimum, parameterName);

            if (number <= minimum)
            {
                string message = Strings.MustBeGreaterThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
            }
        }

        /// <summary>
        /// Requires that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The value which the number must be greater.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireGreaterThan(double number, int minimum, string parameterName)
        {
            Params.Ignore(number, minimum, parameterName);

            if (number <= minimum)
            {
                string message = Strings.MustBeGreaterThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
            }
        }

        /// <summary>
        /// Requires that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The value which the number must be greater than or equal to.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireGreaterThanOrEqualTo(short number, int minimum, string parameterName)
        {
            Params.Ignore(number, minimum, parameterName);

            if (number < minimum)
            {
                string message = Strings.MustBeGreaterThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
            }
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The value which the number must be greater than or equal to.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireGreaterThanOrEqualTo(int number, int minimum, string parameterName)
        {
            Params.Ignore(number, minimum, parameterName);

            if (number < minimum)
            {
                string message = Strings.MustBeGreaterThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
            }
        }

        /// <summary>
        /// Requires that the given number is greater than of equal to the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The value which the number must be greater than or equal to.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireGreaterThanOrEqualTo(long number, int minimum, string parameterName)
        {
            Params.Ignore(number, minimum, parameterName);

            if (number < minimum)
            {
                string message = Strings.MustBeGreaterThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
            }
        }

        /// <summary>
        /// Requires that the given number is greater than of equal to the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The value which the number must be greater than or equal to.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireGreaterThanOrEqualTo(float number, int minimum, string parameterName)
        {
            Params.Ignore(number, minimum, parameterName);

            if (number < minimum)
            {
                string message = Strings.MustBeGreaterThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
            }
        }

        /// <summary>
        /// Requires that the given number is greater than of equal to the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The value which the number must be greater than or equal to.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireGreaterThanOrEqualTo(double number, int minimum, string parameterName)
        {
            Params.Ignore(number, minimum, parameterName);

            if (number < minimum)
            {
                string message = Strings.MustBeGreaterThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
            }
        }

        /// <summary>
        /// Requires that the given number is less than the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maximum">The value which the number must be less.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireLessThan(short number, int maximum, string parameterName)
        {
            Params.Ignore(number, maximum, parameterName);

            if (number >= maximum)
            {
                string message = Strings.MustBeLessThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
            }
        }

        /// <summary>
        /// Requires that the given number is less than the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maximum">The value which the number must be less.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireLessThan(int number, int maximum, string parameterName)
        {
            Params.Ignore(number, maximum, parameterName);

            if (number >= maximum)
            {
                string message = Strings.MustBeLessThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
            }
        }

        /// <summary>
        /// Requires that the given number is less than the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maximum">The value which the number must be less.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireLessThan(long number, int maximum, string parameterName)
        {
            Params.Ignore(number, maximum, parameterName);

            if (number >= maximum)
            {
                string message = Strings.MustBeLessThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentUICulture, message, maximum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
            }
        }

        /// <summary>
        /// Requires that the given number is less than the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maximum">The value which the number must be less.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireLessThan(float number, int maximum, string parameterName)
        {
            Params.Ignore(number, maximum, parameterName);

            if (number >= maximum)
            {
                string message = Strings.MustBeLessThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
            }
        }

        /// <summary>
        /// Requires that the given number is less than the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maximum">The value which the number must be less.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireLessThan(double number, int maximum, string parameterName)
        {
            Params.Ignore(number, maximum, parameterName);

            if (number >= maximum)
            {
                string message = Strings.MustBeLessThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
            }
        }

        /// <summary>
        /// Requires that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maximum">The value which the number must be less than or equal to.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireLessThanOrEqualTo(short number, int maximum, string parameterName)
        {
            Params.Ignore(number, maximum, parameterName);

            if (number > maximum)
            {
                string message = Strings.MustBeLessThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
            }
        }

        /// <summary>
        /// Requires that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maximum">The value which the number must be less than or equal to.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireLessThanOrEqualTo(int number, int maximum, string parameterName)
        {
            Params.Ignore(number, maximum, parameterName);

            if (number > maximum)
            {
                string message = Strings.MustBeLessThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
            }
        }

        /// <summary>
        /// Requires that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maximum">The value which the number must be less than or equal to.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireLessThanOrEqualTo(long number, int maximum, string parameterName)
        {
            Params.Ignore(number, maximum, parameterName);

            if (number > maximum)
            {
                string message = Strings.MustBeLessThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
            }
        }

        /// <summary>
        /// Requires that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maximum">The value which the number must be less than or equal to.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireLessThanOrEqualTo(float number, int maximum, string parameterName)
        {
            Params.Ignore(number, maximum, parameterName);

            if (number > maximum)
            {
                string message = Strings.MustBeLessThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
            }
        }

        /// <summary>
        /// Requires that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maximum">The value which the number must be less than or equal to.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void RequireLessThanOrEqualTo(double number, int maximum, string parameterName)
        {
            Params.Ignore(number, maximum, parameterName);

            if (number > maximum)
            {
                string message = Strings.MustBeLessThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
            }
        }

        /// <summary>
        /// Requires that the given number is between the two given values.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireBetween(short number, int minimum, int maximum, string parameterName)
        {
            Params.Ignore(number, minimum, maximum, parameterName);

            Params.RequireValidIndex(
                                    number >= minimum && number <= maximum,
                                    parameterName,
                                    delegate { return string.Format(CultureInfo.CurrentCulture, Strings.MustBeBetween, minimum, maximum); });
        }

        /// <summary>
        /// Requires that the given number is between the two given values.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireBetween(int number, int minimum, int maximum, string parameterName)
        {
            Params.Ignore(number, minimum, maximum, parameterName);

            Params.RequireValidIndex(
                                    number >= minimum && number <= maximum,
                                    parameterName,
                                    delegate { return string.Format(CultureInfo.CurrentCulture, Strings.MustBeBetween, minimum, maximum); });
        }

        /// <summary>
        /// Requires that the given number is between the two given values.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireBetween(long number, int minimum, int maximum, string parameterName)
        {
            Params.Ignore(number, minimum, maximum, parameterName);

            Params.RequireValidIndex(
                                    number >= minimum && number <= maximum,
                                    parameterName,
                                    delegate { return string.Format(CultureInfo.CurrentCulture, Strings.MustBeBetween, minimum, maximum); });
        }

        /// <summary>
        /// Requires that the given number is between the two given values.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireBetween(float number, int minimum, int maximum, string parameterName)
        {
            Params.Ignore(number, minimum, maximum, parameterName);

            Params.RequireValidIndex(
                                    number >= minimum && number <= maximum,
                                    parameterName,
                                    delegate { return string.Format(CultureInfo.CurrentCulture, Strings.MustBeBetween, minimum, maximum); });
        }

        /// <summary>
        /// Requires that the given number is between the two given values.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <param name="parameterName">The name of the number parameter.</param>
        public static void RequireBetween(double number, int minimum, int maximum, string parameterName)
        {
            Params.Ignore(number, minimum, maximum, parameterName);

            Params.RequireValidIndex(
                                    number >= minimum && number <= maximum,
                                    parameterName,
                                    delegate { return string.Format(CultureInfo.CurrentCulture, Strings.MustBeBetween, minimum, maximum); });
        }
    }
}