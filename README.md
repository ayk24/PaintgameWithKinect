# Paintgame With Kinect

## Description
<img src="https://github.com/ayk24/paintgame_with_kinect/blob/master/doc/app.png" width=50%>

It's a game where you can use Kinect to draw a picture with your body and guess what it is.

You can change colors by waving your left wrist left or right, and you can actually draw a picture with your right hand.

The server side (the person who poses the question) has a question in the text box and draws a picture according to the subject.
The client side (the person answering the question) has to try to answer correctly.

## Features
- **Communication**: Uses its own variable-length packets, which are made to match type and data.
- **Paint-type data**: Contains start and end point coordinates and color information, and the paint packets are constantly being sent to the client side.
- **Chat-type data**: Contains user names and text information, and chat packets are sent by any client to the server, which broadcasts them to all clients.

## Requirement
- Visual Studio 2017
- .NET Framework 4.7.2
- Kinect v1
