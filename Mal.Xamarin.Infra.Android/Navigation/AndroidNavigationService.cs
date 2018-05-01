using Android.App;
using Android.Content;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;

namespace Mal.Xamarin.Infra.Android.Navigation
{
    public interface IAndroidNavigationService : INavigationService
    {
        Activity CurrentActivity { get; set; }

        /// <summary>
        /// Adds a key/page pair to the navigation service.
        /// </summary>
        /// <remarks>For this navigation service to work properly, your Activities
        /// should derive from the <see cref="ActivityBase"/> class.</remarks>
        /// <param name="key">The key that will be used later
        /// in the <see cref="NavigateTo(string)"/> or <see cref="NavigateTo(string, object)"/> methods.</param>
        /// <param name="activityType">The type of the activity (page) corresponding to the key.</param>
        void Configure(string key, Type activityType);

        /// <summary>
        /// Allows a caller to get the navigation parameter corresponding 
        /// to the Intent parameter.
        /// </summary>
        /// <param name="intent">The <see cref="Android.App.Activity.Intent"/> 
        /// of the navigated page.</param>
        /// <returns>The navigation parameter. If no parameter is found,
        /// returns null.</returns>
        object GetAndRemoveParameter(Intent intent);

        // <summary>
        /// Allows a caller to get the navigation parameter corresponding 
        /// to the Intent parameter.
        /// </summary>
        /// <typeparam name="T">The type of the retrieved parameter.</typeparam>
        /// <param name="intent">The <see cref="Android.App.Activity.Intent"/> 
        /// of the navigated page.</param>
        /// <returns>The navigation parameter casted to the proper type.
        /// If no parameter is found, returns default(T).</returns>
        T GetAndRemoveParameter<T>(Intent intent);

        string RootPageKey { get; }
    }

    internal class AndroidNavigationService : IAndroidNavigationService
    {
        private const string rootPageKey = "-- ROOT --";

        /// <summary>
        /// The key that is returned by the <see cref="CurrentPageKey"/> property
        /// when the current Activiy is the root activity.
        /// </summary>
        public string RootPageKey => rootPageKey;

        private const string ParameterKeyName = "ParameterKey";

        private readonly Dictionary<string, Type> pagesByKey = new Dictionary<string, Type>();
        private readonly Dictionary<string, object> parametersByKey = new Dictionary<string, object>();

        public Activity CurrentActivity { get; set; }

        /// <summary>
        /// The key corresponding to the currently displayed page.
        /// </summary>
        public string CurrentPageKey { get; set; } = rootPageKey;

        /// <summary>
        /// Adds a key/page pair to the navigation service.
        /// </summary>
        /// <remarks>For this navigation service to work properly, your Activities
        /// should derive from the <see cref="ActivityBase"/> class.</remarks>
        /// <param name="key">The key that will be used later
        /// in the <see cref="NavigateTo(string)"/> or <see cref="NavigateTo(string, object)"/> methods.</param>
        /// <param name="activityType">The type of the activity (page) corresponding to the key.</param>
        public void Configure(string key, Type activityType)
        {
            lock (pagesByKey)
            {
                if (pagesByKey.ContainsKey(key))
                {
                    pagesByKey[key] = activityType;
                }
                else
                {
                    pagesByKey.Add(key, activityType);
                }
            }
        }

        /// <summary>
        /// Allows a caller to get the navigation parameter corresponding 
        /// to the Intent parameter.
        /// </summary>
        /// <param name="intent">The <see cref="Android.App.Activity.Intent"/> 
        /// of the navigated page.</param>
        /// <returns>The navigation parameter. If no parameter is found,
        /// returns null.</returns>
        public object GetAndRemoveParameter(Intent intent)
        {
            if (intent == null)
            {
                throw new ArgumentNullException("intent", "This method must be called with a valid Activity intent");
            }

            var key = intent.GetStringExtra(ParameterKeyName);
            intent.RemoveExtra(ParameterKeyName);

            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            lock (parametersByKey)
            {
                if (parametersByKey.ContainsKey(key))
                {
                    var param = parametersByKey[key];
                    parametersByKey.Remove(key);
                    return param;
                }

                return null;
            }
        }

        /// <summary>
        /// Allows a caller to get the navigation parameter corresponding 
        /// to the Intent parameter.
        /// </summary>
        /// <typeparam name="T">The type of the retrieved parameter.</typeparam>
        /// <param name="intent">The <see cref="Android.App.Activity.Intent"/> 
        /// of the navigated page.</param>
        /// <returns>The navigation parameter casted to the proper type.
        /// If no parameter is found, returns default(T).</returns>
        public T GetAndRemoveParameter<T>(Intent intent)
        {
            return (T)GetAndRemoveParameter(intent);
        }

        /// <summary>
        /// If possible, discards the current page and displays the previous page
        /// on the navigation stack.
        /// </summary>
        public void GoBack()
        {
            this.CurrentActivity?.OnBackPressed();
        }

        /// <summary>
        /// Displays a new page corresponding to the given key. 
        /// Make sure to call the <see cref="Configure"/>
        /// method first.
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        /// <exception cref="ArgumentException">When this method is called for 
        /// a key that has not been configured earlier.</exception>
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        /// <summary>
        /// Displays a new page corresponding to the given key,
        /// and passes a parameter to the new page.
        /// Make sure to call the <see cref="Configure"/>
        /// method first.
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        /// <param name="parameter">The parameter that should be passed
        /// to the new page.</param>
        /// <exception cref="ArgumentException">When this method is called for 
        /// a key that has not been configured earlier.</exception>
        public void NavigateTo(string pageKey, object parameter)
        {
            if (this.CurrentActivity == null)
            {
                throw new InvalidOperationException($"An instance of {nameof(ActivityBase)} must be set in {nameof(IAndroidNavigationService)}.{nameof(IAndroidNavigationService.CurrentActivity)}.");
            }

            lock (pagesByKey)
            {
                if (!pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey),
                        "pageKey");
                }

                var intent = new Intent(this.CurrentActivity, pagesByKey[pageKey]);

                if (parameter != null)
                {
                    lock (parametersByKey)
                    {
                        var guid = Guid.NewGuid().ToString();
                        parametersByKey.Add(guid, parameter);
                        intent.PutExtra(ParameterKeyName, guid);
                    }
                }

                this.CurrentPageKey = pageKey;
                this.CurrentActivity.StartActivity(intent);
            }
        }
    }
}