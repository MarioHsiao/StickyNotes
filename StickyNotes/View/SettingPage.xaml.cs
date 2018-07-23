﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace StickyNotes
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SettingPage : Page
    {
        public SettingPage()
        {
            this.InitializeComponent();
        }
        private void BackButton_OnClick(object sender, RoutedEventArgs e) {
            OnBackRequested();
        }

        private void OnBackRequested() {
            Frame.GoBack(new DrillInNavigationTransitionInfo());
        }

        private void Cstyle_Loaded(object sender, RoutedEventArgs e) {

        }

        private void Cbig_Loaded(object sender, RoutedEventArgs e) {

        }

        private void B_color_Loaded(object sender, RoutedEventArgs e) {

        }

        private void Start_Loaded(object sender, RoutedEventArgs e) {

        }

        private void RedSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e) {
            
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e) {
            await LoadState();
        }
        public async Task LoadState() {
            var task = await StartupTask.GetAsync("StickyNotes");

            switch (task.State)
            {
                case StartupTaskState.Disabled:
                    // 禁用狀態
                    this.btnSetState.Content = "啟用";
                    this.btnSetState.IsEnabled = true;
                    break;
                case StartupTaskState.DisabledByPolicy:
                    // 由管理員或組策略禁用
                    this.btnSetState.Content = "被系統策略禁用";
                    this.btnSetState.IsEnabled = false;
                    break;
                case StartupTaskState.DisabledByUser:
                    // 由用户手工禁用
                    this.btnSetState.Content = "被用户禁用";
                    this.btnSetState.IsEnabled = false;
                    break;
                case StartupTaskState.Enabled:
                    // 當前狀態為已啟用
                    this.btnSetState.Content = "已啟用";
                    this.btnSetState.IsEnabled = false;
                    break;
            }
        }

        private async void btnSetState_Click(object sender, RoutedEventArgs e) {
            var task = await StartupTask.GetAsync("StickyNotes");
            if (task.State == StartupTaskState.Disabled)
            {
                await task.RequestEnableAsync();
            }

            // 重新加載狀態
            await LoadState();
        }

        private void RecoverButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QiuteModleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ColorChoose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}