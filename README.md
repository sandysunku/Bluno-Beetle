# Bluno-Beetle
Xamarin forms application to light up a LED using Ble with Bluno Beetle (Compact Arduino Uno)

## What is Bluno Beetle?
The Beetle Ble (Former name as Bluno Beetle) is a board based on Arduino Uno with Bluetooth 4.0 (BLE). It is another milestone in wearable electronics device area based arduino uno, which makes DIY users have more options in the project design. It is fully compatible with Bluno in instructions and procedures, supporting Bluetooth HID and ibeacon modes. And it not only supports USB programming, but also wireless programming method.

<p align="center">
  <img src="/assets/blunobeetle.png">
</p>

## Starting with Bluno
Bluno into action you require following 
### Hardware
1. Bluno : Bluno can be purchased online.
2. Breadboard : To form the circuit.
3. LED light : to lit up using ble
4. Connecting Wires: To connect the circuit
5. Resistor : To control current flow as LED is very small.
6. Mobile: To build and install the App.

### Software
1. Arduino IDE : IDE to program and upload the skecth to bluno. To download and know more about Arduino you can refer https://www.arduino.cc/en/Guide/ArduinoUno
2. Visual Studio : To develop mobile app to control LED via Bluno

## Using the Code
1. Upload the sketch to Bluno which is under bluno_beetle_arduino_sketch directory
2. Build and install the xamrin forms application to your mobile and control to LED.

## Circuit diagram
<p align="center">
  <img src="/assets/circuit_daigram.JPG">
</p>

### Note: You need to supply power to Bluno either using usb cable or you can connect to any battery. Make sure that operating voltage should not exceed 8v
