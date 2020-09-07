Thank you for using my software! If you like my program, please consider a small donation to my PayPal: polishsirhawk@gmail.com.

This file contains basic control for the program, including handling Arduino code. You require .NET Framework 4.7.2 to be able to use my program
and FastLED library (https://github.com/FastLED/FastLED) to upload Arduino code to your microcontroler.

WASAPI Arduino is an ultra light program that uses WASAPI to capture the sound directly from operating system, this bypasses the need for any extra sound source or mixing. Through CSCore library the sound data is processed 
with Fast Fourier Transform (FFT), sorted into 10 columns representing regular 10 band frequency bars. Afterwards, the highest column is being selected and sent through selected USB port. It does nothing else, which was 
the principle while making WASAPI Arduino, so there's no influence in Arduino behaviour, only data bits are sent. Any change you make in the current session is saved and carried over to the next one upon closing the application.

How to use:

Download the release version you're interested in, put the 3 files (CSCore.dll, CSCore.xml [not necessary], WASAPI Arduino.exe) in one folder and double click on the executable.

WASAPI Arduino

- Press left mouse button on the program tray icon to start/stop the program.
- When launched, the program will show up as an icon in the tray menu. If there is no USB device available connected, you will be greeted with an appropriate message;
- Press right mouse button to open context menu;
- COM List shows a list of selectabe COM (USB) devicesIn context menu you have to select COM port to send the data to, select the port your Arduino is connected to;
- Update speed: chose how fast (in Hz) the program is supposed to calculate data;
- Sound columns are used to determine if further data is supposed to be taken from first 3 sound frequency octaves or from 10 column range;
- Corrector opens a equalizer window, use it to counter your actual audio equalizer so WASAPI Arduino will function like there was no interference in output signal. Doing so will also prevent abnormalities like not detecting
a signal, if you have an aggresive preset, keep in mind you need to input a mirrored data, so if you boosted your 31Hz column by 3dB you need to input a -3 in the corrector window. Smoothing bar is the weight given to the previous sample 
for time-based smoothing, for smoother transitions between values. High value works great when sending it to the LED strip when the software is set to a high refresh rate, making the transition between values much milder, lower values 
increase accuracy of sampling. Setting it too low introduces VERY annoying flicker; The faster the refresh rate, the higher this value should be set.
- Exit closes the application and saves all changes made.

Before uploading the code to your Arduino:
- Change the NUM_LEDS number to a number of LEDs you are about to drive;
- LED_PIN value represents a digital pin in your Arduino/clone unit, which will send the signal to LED stripe controller. Bear in mind,
if you were to change that PIN it must be a PWM pin, which you can check that in your device pinout;
- Color is represented in RGB range, you have to input manually your desired color;
- The code uses FastLED library, which has a great variety of control, albeit in this use case only the brightness control is used.
