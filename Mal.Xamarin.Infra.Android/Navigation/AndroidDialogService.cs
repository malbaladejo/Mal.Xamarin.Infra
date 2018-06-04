﻿using Android.App;
using Android.Content;
using GalaSoft.MvvmLight.Views;
using System;
using System.Threading.Tasks;

namespace Mal.Xamarin.Infra.Android.Navigation
{
    /// <summary>
    /// An implementation of <see cref="IDialogService"/> allowing
    /// to display simple dialogs to the user. Note that this class
    /// uses the built in Android dialogs which may or may not
    /// be sufficient for your needs. Using this class is easy
    /// but feel free to develop your own IDialogService implementation
    /// if needed.
    /// </summary>
    ////[ClassInfo(typeof(IDialogService))]
    public class AndroidDialogService : IDialogService
    {
        private readonly IAndroidNavigationService androidNavigationService;

        public AndroidDialogService(IAndroidNavigationService androidNavigationService)
        {
            this.androidNavigationService = androidNavigationService;
        }

        /// <summary>
        /// Displays information about an error.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonText">The text shown in the only button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            Action<bool> callback = r =>
            {
                if (afterHideCallback != null)
                {
                    afterHideCallback();
                    afterHideCallback = null;
                }
            };

            var info = this.CreateDialog(
                message,
                title,
                buttonText,
                null,
                callback);

            info.Dialog.Show();
            return info.Tcs.Task;
        }

        /// <summary>
        /// Displays information about an error.
        /// </summary>
        /// <param name="error">The exception of which the message must be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonText">The text shown in the only button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            Action<bool> callback = r =>
            {
                if (afterHideCallback != null)
                {
                    afterHideCallback();
                    afterHideCallback = null;
                }
            };

            var info = this.CreateDialog(
                error.Message,
                title,
                buttonText,
                null,
                callback);

            info.Dialog.Show();
            return info.Tcs.Task;
        }

        /// <summary>
        /// Displays information to the user. The dialog box will have only
        /// one button with the text "OK".
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task ShowMessage(string message, string title)
        {
            var info = this.CreateDialog(
                message,
                title);

            info.Dialog.Show();
            return info.Tcs.Task;
        }

        /// <summary>
        /// Displays information to the user. The dialog box will have only
        /// one button.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonText">The text shown in the only button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            Action<bool> callback = r =>
            {
                if (afterHideCallback != null)
                {
                    afterHideCallback();
                    afterHideCallback = null;
                }
            };

            var info = this.CreateDialog(
                message,
                title,
                buttonText,
                null,
                callback);

            info.Dialog.Show();
            return info.Tcs.Task;
        }

        /// <summary>
        /// Displays information to the user. The dialog box will have only
        /// one button.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonConfirmText">The text shown in the "confirm" button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="buttonCancelText">The text shown in the "cancel" button
        /// in the dialog box. If left null, the text "Cancel" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user. The callback method will get a boolean
        /// parameter indicating if the "confirm" button (true) or the "cancel" button
        /// (false) was pressed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited. The task will return
        /// true or false depending on the dialog result.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task<bool> ShowMessage(
            string message,
            string title,
            string buttonConfirmText,
            string buttonCancelText,
            Action<bool> afterHideCallback)
        {
            Action<bool> callback = r =>
            {
                if (afterHideCallback != null)
                {
                    afterHideCallback(r);
                    afterHideCallback = null;
                }
            };

            var info = this.CreateDialog(
                message,
                title,
                buttonConfirmText,
                buttonCancelText ?? "Cancel",
                callback);

            info.Dialog.Show();
            return info.Tcs.Task;
        }

        /// <summary>
        /// Displays information to the user in a simple dialog box. The dialog box will have only
        /// one button with the text "OK". This method should be used for debugging purposes.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task ShowMessageBox(string message, string title)
        {
            return ShowMessage(message, title);
        }

        private AlertDialogInfo CreateDialog(
            string content,
            string title,
            string okText = null,
            string cancelText = null,
            Action<bool> afterHideCallbackWithResponse = null)
        {
            var tcs = new TaskCompletionSource<bool>();

            var builder = new AlertDialog.Builder(this.androidNavigationService.CurrentActivity);
            builder.SetMessage(content);
            builder.SetTitle(title);

            AlertDialog dialog = null;

            builder.SetPositiveButton(
                okText ?? "OK",
                (d, index) =>
                {
                    tcs.TrySetResult(true);

                    // ReSharper disable AccessToModifiedClosure
                    if (dialog != null)
                    {
                        dialog.Dismiss();
                        dialog.Dispose();
                    }

                    afterHideCallbackWithResponse?.Invoke(true);
                    // ReSharper restore AccessToModifiedClosure
                });

            if (cancelText != null)
            {
                builder.SetNegativeButton(
                    cancelText,
                    (d, index) =>
                    {
                        tcs.TrySetResult(false);

                        // ReSharper disable AccessToModifiedClosure
                        if (dialog != null)
                        {
                            dialog.Dismiss();
                            dialog.Dispose();
                        }

                        afterHideCallbackWithResponse?.Invoke(false);
                        // ReSharper restore AccessToModifiedClosure
                    });
            }

            builder.SetOnDismissListener(
                new OnDismissListener(
                    () =>
                    {
                        tcs.TrySetResult(false);

                        afterHideCallbackWithResponse?.Invoke(false);
                    }));

            dialog = builder.Create();

            return new AlertDialogInfo
            {
                Dialog = dialog,
                Tcs = tcs
            };
        }

        private struct AlertDialogInfo
        {
            public AlertDialog Dialog;
            public TaskCompletionSource<bool> Tcs;
        }

        private sealed class OnDismissListener : Java.Lang.Object, IDialogInterfaceOnDismissListener
        {
            private readonly Action _action;

            public OnDismissListener(Action action)
            {
                _action = action;
            }

            public void OnDismiss(IDialogInterface dialog)
            {
                _action();
            }
        }
    }
}