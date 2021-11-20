using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BlunoBeetleLEDDemo
{
    public partial class MainPage : ContentPage
    {
        IList<IDevice> deviceList = new List<IDevice>();
        IBluetoothLE ble = CrossBluetoothLE.Current;
        IAdapter adapter = CrossBluetoothLE.Current.Adapter;
        private IService service;
        private ICharacteristic characteristic;
        private string status = "1";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ScanDevices()
        {
            adapter.ScanMode = Plugin.BLE.Abstractions.Contracts.ScanMode.LowLatency;
            adapter.ScanTimeout = 5000;
            adapter.DeviceDiscovered += (s, a) =>
            {
                if (deviceList.Count == 0 && !string.IsNullOrEmpty(a.Device.Name) && a.Device.Name.ToLower().Equals("bluno"))
                {
                    deviceList.Add(a.Device);
                    StatusLabel.Text = a.Device.Name + " scanned successfully";
                }
            };

            await adapter.StartScanningForDevicesAsync();
        }

        private void ScanClicked(object sender, EventArgs e)
        {
            ScanDevices();
        }

        private async void ConnectClicked(object sender, EventArgs e)
        {
            try
            {
                var device = deviceList.FirstOrDefault();
                var parameters = new ConnectParameters(forceBleTransport: true);
                await adapter.ConnectToDeviceAsync(device, parameters);
                var ser = device.GetServicesAsync();
                service = await device.GetServiceAsync(Guid.Parse("0000dfb0-0000-1000-8000-00805f9b34fb"));
                characteristic = await service.GetCharacteristicAsync(Guid.Parse("0000dfb1-0000-1000-8000-00805f9b34fb"));

                StatusLabel.Text = deviceList.FirstOrDefault().Name + " connected successfully.";
            }
            catch (DeviceConnectionException ex)
            {
                StatusLabel.Text = deviceList.FirstOrDefault().Name + " connection unsuccessful.";
            }
        }

        private void ToggleClicked(object sender, EventArgs e)
        {
            try
            {
                characteristic.WriteAsync(Encoding.ASCII.GetBytes(status));
                if (status.Equals("1"))
                    status = "0";
                else
                {
                    status = "1";
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }
    }
}
