paintgame_with_kinect
====
### Paint Game with Kinect
<img src="https://github.com/ayk24/paintgame_with_kinect/blob/master/doc/app.png" width=50%>
It's a game where you can use Kinect to draw a picture with your body and guess what it is.<br>
You can change colors by waving your left wrist left or right, and you can actually draw a picture with your right hand.<br>
The server side (the person who poses the question) has a question in the text box and draws a picture according to the subject.<br>
The client (the person answering the question) has to try to answer correctly.<br>

## Description
The communication uses its own variable-length packets, which are made to match type and data.<br>
The paint type data contains start and end point coordinates and color information, and the paint packets are constantly being sent to the client side.<br>
Chat-type data contains user names and text information, and chat packets are sent by any client to the server, which broadcasts them to all clients.<br>
Since there was a large amount of blurring in the straight line drawing, we adjusted the interval between the acquisition of the coordinates of the two points necessary to make the curve look smooth and less affected by the blurring.<br>

## Requirement
* Visual Studio 2017
* .NET Framework 4.7.2
* Kinect v1
